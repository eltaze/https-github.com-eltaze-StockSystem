using AutoMapper;
using StockSystem.Libarary.BL;
using StockSystem.Libarary.DataBase;
using StockSystem.Libarary.Interfaces;
using StockSystem.Libarary.Model;
using StockUI.Libarary.BL;
using StockUI.Libarary.BL.Helper;
using StockUI.Libarary.Model;
using StockUI.WinForm.FrmUI;
using System;
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
            // Application.Run(container.Resolve<FrmDismisItem>());
            // Application.Run(container.Resolve<FrmItems>());
            Application.Run(container.Resolve<FrmOrder>());
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
            currentContainer.RegisterType<FrmItemRecit>();
            currentContainer.RegisterType<FrmOrder>();
            currentContainer.RegisterType<FrmItems>();
            currentContainer.RegisterType<FrmMoveOrder>();
            currentContainer.RegisterType<ReportForms>();
            currentContainer.RegisterType<FrmBarCode>();
            currentContainer.RegisterType<FrmDismisItem>();
            //Registering Database Layer
            currentContainer.RegisterSingleton<ISqlDataAccess, SqlDataAccess>();
            //Configuration AutoMapper
            currentContainer.RegisterInstance(ConfigurAtuoMaper());
            //Registering BL DataAccess Clasess
            currentContainer.RegisterType<IDepartmentEndPoint, DepartmentEndPoint>();
            currentContainer.RegisterType<IBaseStockItemEndPoint, BaseStockItemEndPoint>();
            currentContainer.RegisterType<UnitConversions>();
            //currentContainer.RegisterType<IBarCode>();
            currentContainer.RegisterType<IItemEndPoint, ItemEndPoint>();
            currentContainer.RegisterType<IOrderDetailEndPoint, OrderDetailEndPoint>();
            currentContainer.RegisterType<IOrderEndPoint, OrderEndPoint>();
            currentContainer.RegisterType<IKindEndPoint, KindEndPoint>();
            currentContainer.RegisterType<IStockEndPoint, StockEndPoint>();
            currentContainer.RegisterType<IStockItemEndPoint, StockItemEndPoint>();
            currentContainer.RegisterType<IUnitEndPoint, UnitEndPoint>();
            currentContainer.RegisterType<ImoveorderEndPoint, moveorderEndPoint>();
            currentContainer.RegisterType<ImoveorderdetailEndPoint, moveorderdetailEndPoint>();
            currentContainer.RegisterType<IRecitItemDetailEndPoint, RecitItemDetailEndPoint>();
            currentContainer.RegisterType<IRecitItemEndPoint, RecitItemEndPoint>();
            currentContainer.RegisterType<IDismisItemDetailEndPoint, DismisItemDetailEndPoint>();
            currentContainer.RegisterType<IDismisItemEndPoint, DismisItemEndPoint>();
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
                cfg.CreateMap<OrderDetail, OrderDetailDisplay>().ReverseMap();
                cfg.CreateMap<Order,OrderDisplay>().ReverseMap();
                cfg.CreateMap<MoveOrder, MoveorderDisplay>().ReverseMap();
                cfg.CreateMap<MoveOrderDetail, MoveOrderDetailDisplay>().ReverseMap();
                cfg.CreateMap<ItemRecit, ItemReciteDisplay>().ReverseMap();
                cfg.CreateMap<ItemRecitDetail, ItemRecitDetailDisplay>().ReverseMap();
                cfg.CreateMap<DismisItem, DismisItemDisplay>().ReverseMap();
                cfg.CreateMap<DismisItemDetail, DismisItemDetailDisplay>().ReverseMap();
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
