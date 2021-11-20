using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTTQ
{
    public partial class thatbai : Form
    {
        public thatbai()
        {
            InitializeComponent();
        }

        private void icbtnclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void thatbai_Load(object sender, EventArgs e)
        {
            Top = Screen.PrimaryScreen.Bounds.Height - Height - 100;
            Left = Screen.PrimaryScreen.Bounds.Width - Width - 20;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
