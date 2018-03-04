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
using System.Net.Http;

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
            GetHtmlAsync();
        }

        private static async void GetHtmlAsync()
        {
            string produto = "robot";

            var url = "https://www.ebay.com/sch/i.html?_from=R40&_trksid=p2050601.m570.l1313.TR0.TRC0.H0.Xrobot.TRS0&_nkw=" + produto + "&_sacat=0";

            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);

            var htmlDocument = new HtmlAgilityPack.HtmlDocument();
            htmlDocument.LoadHtml(html);

            var ProdutosHtml = htmlDocument.DocumentNode.Descendants("ul").Where(node => node.GetAttributeValue("id", "").Equals("ListViewInner")).ToList();

            var produtoListaItem = ProdutosHtml[0].Descendants("li").Where(node => node.GetAttributeValue("id", "").Contains("item")).ToList();

            for (int i = 0; i < 3; i++)
            {
                var idProduto = produtoListaItem[i].GetAttributeValue("iid", "");

                url = "https://cart.payments.ebay.com/sc/add?item=iid:322946784974,qty:1&srt=01000200000050e5c4b12fd67545beef286954514106d90ee70a82520b3e15ba72b1840426261a5bd215c0f03fd7475bc2bf8fea948c42f2e0509a9bef38d1d3da90dcfdc88ad48835de2b8a1549cd12397282156804a5&ssPageName=CART:ATC";

                httpClient = new HttpClient();
                html = await httpClient.GetStringAsync(url);
            }

            //AddCart(produtoListaItem);

        }

        private static async void AddCart( List<HtmlNode> Produtos)
        {
            
        }

    }
}
