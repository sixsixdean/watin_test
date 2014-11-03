using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WatiN.Core;
using System.Threading;
namespace WebApplication1
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            Thread newthread = new Thread(new ThreadStart(test));
            newthread.SetApartmentState(ApartmentState.STA);
            newthread.Start();


        }

        public static void test()
        {
            IE ie = new IE("http://szkq.szcentaline.com.cn:8181/Index.aspx");

            ie.TextField(Find.ById("edtEmpNo")).Value = "zenghuan.sz";
            ie.TextField(Find.ById("edtPwd")).Value = "yy.520";

            //ie.ImageButton(Find.ById("ImageButlogin")).ClickNoWait();
            ie.Element("ImageButlogin").Click();

        }
    }
}
