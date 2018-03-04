using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using HtmlAgilityPack;
using System.Net;

namespace DMEbay
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*
             id da barra de pesquisa = gh-ac
             */

            List<string> ebay = new List<string>();

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            String barraPesquisa = "";
            List<string> carrinho = new List<string>();
            XmlDocument page = new XmlDocument();

            string link = "https://www.ebay.com";
            using (WebClient client = new WebClient())
            {                
                doc.LoadHtml(link);
            }

            HtmlAgilityPack.HtmlNodeCollection(link);

            //XmlNodeList nodeList = page.SelectNodes("//input[@id='gh - ac']");

            //XmlNode barraPesquisa = page.SelectSingleNode("//input[@id='gh - ac']");

            MessageBox.Show(Convert.ToString(barraPesquisa));
        }
    }
}
