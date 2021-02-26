using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace doan2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        object ThonTin = new object();

        public object Thon_Tin
        {
            get { return ThonTin; }
            set { ThonTin = value; }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            
        }
    }
}
