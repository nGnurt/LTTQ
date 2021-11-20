using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace LTTQ
{
    public partial class MenuChinh : Form
    {
        SQL ketnoi = new SQL();
        private Form active = null;
        //private Label lbform = null;
        Guna2Button btnnut = null;
        public static string image = "";
        public static string name = "";
        
        public MenuChinh()
        {
            InitializeComponent();
        }
        public void Loadform(Form child)
        {
            if (active != null)
            {
                active.Close();
            }
            active = child;
            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            child.Dock = DockStyle.Fill;
            pnlmid.Controls.Add(child);
            pnlmid.Tag = child;
            child.BringToFront();
            child.ShowDialog();

        }

        private void MenuChinh_Load(object sender, EventArgs e)
        {
            //pcboxanh.Image = Image.FromFile(Application.StartupPath + "\\image\\" + image);
            lbtime.Text = DateTime.Now.ToString("hh:mm:ss");
            timer1.Start();
            lbname.Text = name;
            lbuser.Text = name;
        }
        private void hover(Guna2Button btn)
        {
            
            btn.FillColor= System.Drawing.ColorTranslator.FromHtml("#248CF6");
            btnnut = btn;
        }
        private void unhover()
        {
            if(btnnut!=null)
            {
                btnnut.FillColor = System.Drawing.ColorTranslator.FromHtml("#5E94FF");
            }
        }

        private void btntrangchu_Click(object sender, EventArgs e)
        {
            unhover();
            hover(btntrangchu);
            
        }

        private void btndochoi_Click(object sender, EventArgs e)
        {
            unhover();
            hover(btndochoi);
        
        }

        private void btnhangnhap_Click(object sender, EventArgs e)
        {
            unhover();
            hover(btnhangnhap);
     
        }

        private void btnhangban_Click(object sender, EventArgs e)
        {
            unhover();
            hover(btnhangban);
        }

        private void bankho_Click(object sender, EventArgs e)
        {
            unhover();
            hover(btnkho);
            
        }

        private void btnnhanvien_Click(object sender, EventArgs e)
        {
            unhover();
            hover(btnnhanvien);
            
        }

        private void btndoanhthu_Click(object sender, EventArgs e)
        {
            unhover();
            hover(btndoanhthu);
            Loadform(new doanhthu());
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbtime.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private void btndangxuat_Click(object sender, EventArgs e)
        {
            
        }

        private void pnltop_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
