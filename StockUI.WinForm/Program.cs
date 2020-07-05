using AutoMapper;
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
            Application.Run(new Form1());
        }

        public static IUnityContainer BuildContainer()
        {
            var currentContainer = new UnityContainer();
            //currentContainer.RegisterType<FrmTreasury>();
            //currentContainer.RegisterType<FrmAccountHolder>();
            //currentContainer.RegisterType<Form1>();
            //currentContainer.RegisterType<FrmRecite>();
            //currentContainer.RegisterType<FrmCrResite>();
            //currentContainer.RegisterType<FrmReport>();
            //currentContainer.RegisterType<FrmDataGrid>();
            //currentContainer.RegisterSingleton<ISqlDataAccess, SqlDataAccess>();
            //currentContainer.RegisterType<IAccountHolderEndPoint, AccountHolderEndPoint>();
            //currentContainer.RegisterType<ItreasuryDetailEndPoint, treasuryDetailEndPoint>();
            //currentContainer.RegisterType<IAccountBankTreasuryEndPoint, AccountBankTreasuryEndPoint>();
            //currentContainer.RegisterType<ITreasuryEndPoint, TreasuryEndPoint>();
            //currentContainer.RegisterType<IReciteEndPoint, ReciteEndPoint>();
            //currentContainer.RegisterType<ICrReciteEndPoint, CrReciteEndPoint>();
            //currentContainer.RegisterType<IBankEndPoint, BankEndPoint>();
            //currentContainer.RegisterType<IDashPortEndPoint, DashPortEndPoint>();
            //currentContainer.RegisterType<IBankTreasuryEndPoint, BankTreasuryEndPoint>();
            //currentContainer.RegisterType<ReciteReport>();
            currentContainer.RegisterInstance(ConfigurAtuoMaper());
            // note: registering types could be moved off to app config if you want as well
            return currentContainer;
        }
        private static IMapper ConfigurAtuoMaper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                //cfg.CreateMap<AccountHolder, AccountHolderDisplay>();
                //cfg.CreateMap<TreasuryDetail, TreasuryDetailDisplay>();
                //cfg.CreateMap<AccountBankTreasury, AccountBankTreasuryDisplay>();
                //cfg.CreateMap<Treasurey, TreasureyDisplay>();
                //cfg.CreateMap<Recite, ReciteDisplay>();
                //cfg.CreateMap<CrResite, CrResiteDisplay>();
                //cfg.CreateMap<Bank, BankDisplay>();
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
