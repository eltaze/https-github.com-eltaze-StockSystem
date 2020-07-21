using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockUI.WinForm.Formating
{
   public class DataGridFormat
    {
        public void Style(DataGridView dataGridView1)
        {
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;

            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.BlueViolet;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
           
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            // dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightCyan;
            dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.Wheat;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToResizeColumns = false;
        }
    }
}
