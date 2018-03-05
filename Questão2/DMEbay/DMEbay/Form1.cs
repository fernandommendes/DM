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

            string htmlCart;
            var htmlDocumentCart = new HtmlAgilityPack.HtmlDocument();

            for (int i = 0; i < 3; i++)
            {
                //Entrando na página do produto
                var tagAProduto = produtoListaItem[i].Descendants("a").First().Attributes.First().Value;

                string htmlProduct = await httpClient.GetStringAsync(tagAProduto);
                var htmlDocumentProduct = new HtmlAgilityPack.HtmlDocument();
                htmlDocumentProduct.LoadHtml(htmlProduct);

                //Adicionando produto ao carrinho
                var urlAddCart = htmlDocumentProduct.GetElementbyId("isCartBtn_btn").Attributes[5].Value;

                htmlCart = await httpClient.GetStringAsync(urlAddCart);
                htmlDocumentCart.LoadHtml(htmlCart);

            }

            //Finalizar a compra
            string urlFinalizarCompra = "https://cart.payments.ebay.com/sc/";
            urlFinalizarCompra += htmlDocumentCart.GetElementbyId("ptcBtnRight").Attributes[2].Value;
            
            string htmlFinalizarCompra = await httpClient.GetStringAsync(urlFinalizarCompra);
            var htmlDocumentFinalizarCompra = new HtmlAgilityPack.HtmlDocument();
            htmlDocumentFinalizarCompra.LoadHtml(htmlFinalizarCompra);

            //Form1 frm1 = new Form1();
            //frm1.lblRetorno.Text = "Compra realizada com sucesso!";
            MessageBox.Show("Compra realizada com sucesso!");
        }
    }
}
