using AutoMapper;
using StockSystem.Libarary.Interfaces;
using StockUI.Libarary.BL;
using StockUI.Libarary.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockUI.WinForm.FrmUI
{
    public partial class FrmKind : Form
    {
        private readonly IMapper mapper;
        private readonly Validation validation;
        private readonly IKindEndPoint kindEndPoint;
        private List<KindDisplay> kindDisplays = new List<KindDisplay>();
        public FrmKind(IMapper mapper, Validation validation,IKindEndPoint kindEndPoint)
        {
            InitializeComponent();
            this.mapper = mapper;
            this.validation = validation;
            this.kindEndPoint = kindEndPoint;
        }
        private void FrmKind_Load(object sender, EventArgs e)
        {

        }
    }
}
