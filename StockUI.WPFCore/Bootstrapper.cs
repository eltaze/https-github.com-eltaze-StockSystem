﻿using Caliburn.Micro;
using StockSystem.Libarary.BL;
using StockUI.WPFCore.ViewModels;
using System.Collections.Generic;
using System;
using System.Linq;

using StockSystem.Libarary.Model;
using StockSystem.Libarary.Interfaces;
using StockSystem.Libarary.DataBase;

namespace StockUI.WPFCore
{
    public  class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer container = new SimpleContainer();
        public Bootstrapper()
        {
            Initialize();
        }
        protected override void Configure()
        {
            container.Instance(container);
            container
                .Singleton<IWindowManager, WindowManager>()
                .Singleton<ISqlDataAccess, SqlDataAccess>()
                //this is example for this registerations
               // .PerRequest<IReposit<Item>, ItemEndPoint>()
                .Singleton<IEventAggregator, EventAggregator>();
                GetType().Assembly.GetTypes()
                .Where(type => type.IsClass)
                .Where(type => type.Name.EndsWith("ViewModel"))
                .ToList().ForEach(ViewModelType => container.RegisterPerRequest(
                    ViewModelType, ViewModelType.ToString(), ViewModelType));
        }
        protected override void OnStartup(object sender, System.Windows.StartupEventArgs e)
        {
            this.DisplayRootViewForAsync(typeof(ShellViewModel), null);
        }
        protected override object GetInstance(Type service, string key)
        {
            return container.GetInstance(service,key);
        }
        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.GetAllInstances(service);
        }
        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }
    }
}
