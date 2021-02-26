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
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            flag = false;
            InitializeComponent();
        }

        private bool flag;
        public bool Flag
        {
            get { return this.flag; }
            set { this.flag = value; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (true)//Kiểm tra tk/mk
            {
                flag = true;
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
