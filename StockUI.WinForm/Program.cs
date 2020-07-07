using AutoMapper;
using StockSystem.Libarary.BL;
using StockSystem.Libarary.DataBase;
using StockSystem.Libarary.Interfaces;
using StockSystem.Libarary.Model;
using StockUI.Libarary.BL;
using StockUI.Libarary.Model;
using StockUI.WinForm.FrmUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace StockUI.WinForm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
       
        static void Main()
        {
            var container = BuildContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FrmStock());
            Application.Run(container.Resolve<FrmUnit>());
        }
        public static IUnityContainer BuildContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<FrmStock>();
            currentContainer.RegisterType<FrmKind>();
            currentContainer.RegisterType<FrmDepartment>();
            currentContainer.RegisterType<Validation>();
            currentContainer.RegisterType<StockDisplay>();
            currentContainer.RegisterType<FrmUnit>();
            //Registering Database Layer
            currentContainer.RegisterSingleton<ISqlDataAccess, SqlDataAccess>();
            //Configuration AutoMapper
            currentContainer.RegisterInstance(ConfigurAtuoMaper());
            //Registering BL DataAccess Clasess
            currentContainer.RegisterType<IDepartmentEndPoint, DepartmentEndPoint>();
            currentContainer.RegisterType<IBaseStockItemEndPoint, BaseStockItemEndPoint>();
            currentContainer.RegisterType<IItemEndPoint, ItemEndPoint>();
            currentContainer.RegisterType<IKindEndPoint, KindEndPoint>();
            currentContainer.RegisterType<IStockEndPoint, StockEndPoint>();
            currentContainer.RegisterType<IStockItemEndPoint, StockItemEndPoint>();
            currentContainer.RegisterType<IUnitEndPoint, UnitEndPoint>();
            //currentContainer.RegisterType<IBaseStockItemEndPoint, BaseStockItemEndPoint>();
            //currentContainer.RegisterType<IBaseStockItemEndPoint, BaseStockItemEndPoint>();
            // note: registering types could be moved off to app config if you want as well
            return currentContainer;
        }
        private static IMapper ConfigurAtuoMaper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BaseStockITem, BaseStockITemDisplay>();
                cfg.CreateMap<department, DepartmentDisplay>();
                cfg.CreateMap<Item, ItemDisplay>();
                cfg.CreateMap<Kind, KindDisplay>();
                cfg.CreateMap<Stock, StockDisplay>();
                cfg.CreateMap<stockitem, stockitemDisplay>();
                cfg.CreateMap<Unit, UnitDisplay>();
                //cfg.CreateMap<AccountBankTreasuryDashBoard, AccountBankTreasury>().ReverseMap();
                //cfg.CreateMap<BankTreasury, BankTreasuryDisplay>();
                //cfg.CreateMap<AccountBankTreasuryDashBoard, AccountBankTreasury>();
                //    cfg.CreateMap<AccountBankTreasuryDashBoard, AccountBankTreasuryDisplay>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        }
    }
}
