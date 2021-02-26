using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BAL;
using BEL;

namespace doan2
{
    public partial class UCMuonSach : UserControl
    {
        public UCMuonSach()
        {
            InitializeComponent();
            Hienthi();

        }
        public void Hienthi()
        {
            BAL_Phieumuon xuly = new BAL_Phieumuon();
            dataGridView3.DataSource = xuly.DocDSPhieuMuon();
        }
    }
}
