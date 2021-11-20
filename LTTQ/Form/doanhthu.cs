using LiveCharts;
using LiveCharts.Wpf;
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
    public partial class doanhthu : Form
    {
        SQL ketnoi = new SQL();
        public doanhthu()
        {
           
            InitializeComponent();
        }
        Func<ChartPoint, string> label = chartpoin => string.Format("{0}  ({1:P})", chartpoin.Y, chartpoin.Participation);

        private void doanhthu_Load(object sender, EventArgs e)
        {
           
            this.chart1.Series["DoanhThu"].Points.AddXY("1", 33);
            this.chart1.Series["DoanhThu"].Points.AddXY("2", 80);
            this.chart1.Series["DoanhThu"].Points.AddXY("3", 50);
            this.chart1.Series["DoanhThu"].Points.AddXY("4", 10);
            this.chart1.Series["DoanhThu"].Points.AddXY("5", 20);
            this.chart1.Series["DoanhThu"].Points.AddXY("6", 20);
            this.chart1.Series["DoanhThu"].Points.AddXY("7", 20);
            this.chart1.Series["DoanhThu"].Points.AddXY("8", 20);
            this.chart1.Series["DoanhThu"].Points.AddXY("9", 20);
            this.chart1.Series["DoanhThu"].Points.AddXY("10", 20);
            this.chart1.Series["DoanhThu"].Points.AddXY("11", 20);
            this.chart1.Series["DoanhThu"].Points.AddXY("12", 20);


            this.chart2.Series["DoanhThu"].Points.AddXY("Max", 20);
            this.chart2.Series["DoanhThu"].Points.AddXY("tuanngoc", 80);
            this.chart2.Series["DoanhThu"].Points.AddXY("trung", 50);
            this.chart2.Series["DoanhThu"].Points.AddXY("cao", 10);
            this.chart2.Series["DoanhThu"].Points.AddXY("thanh", 20);


        }
        private void bieudo()
        {
            //SeriesCollection series = new SeriesCollection();
            //series.Add(new PieSeries() { Title = "Lego", Values = new ChartValues<int> { 123 }, DataLabels = true, LabelPoint = label } ) ;
            //pieChart1.Series = series;
            //series.Add(new PieSeries() { Title = "Siku", Values = new ChartValues<int> {100}, DataLabels = true, LabelPoint = label });
            //pieChart1.Series = series;
            //series.Add(new PieSeries() { Title = "Hotwheel", Values = new ChartValues<int> {900}, DataLabels = true, LabelPoint = label });
            //pieChart1.Series = series;
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
