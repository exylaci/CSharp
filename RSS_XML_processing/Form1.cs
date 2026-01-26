using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RSS_XML_processing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            txbSource.Text = "https://24.hu//feed";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            WebClient downloader = new WebClient();
            downloader.Encoding = Encoding.UTF8;
            string feed = downloader.DownloadString(txbSource.Text);                    //try-catch ha nem érhető el az rss forrás
            XDocument xml = XDocument.Parse(feed);
            var articles = from article in xml.Root.Element("channel").Elements("item")
                           select new Article(article);

            lsbArticles.DataSource = null;
            lsbArticles.DataSource = articles.ToList();
        }

        private void lsbArticles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbArticles.SelectedIndex >= 0)
            {
                webBrowser1.DocumentText = (lsbArticles.SelectedItem as Article)?.Content ?? "";
            }
        }

        private void lsbArticles_DoubleClick(object sender, EventArgs e)
        {
            if (lsbArticles.SelectedIndex >= 0)
            {
                Process.Start((lsbArticles.SelectedItem as Article).Link);
            }
        }

        private void numFrequency_ValueChanged(object sender, EventArgs e)
        {
            timer.Interval = (int)(numFrequency.Value) * 60000;
        }

        private void chbAutomatic_CheckedChanged(object sender, EventArgs e)
        {
            if (chbAutomatic.Checked)
            {
                timer.Interval = (int)(numFrequency.Value) * 60000;
                timer.Start();
            }
            else
            {
                timer.Stop();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            btnRefresh_Click(sender, e);
        }
    }
}
