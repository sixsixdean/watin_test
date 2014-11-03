using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Threading;
using WatiN.Core;
namespace WebApplication2
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {



        }



        public void test()
        {
            //WebBrowser web = new WebBrowser();
            //web.Navigate("www.baidu.com", true);
            ////考勤系统
            IE ie = new IE("http://szkq.szcentaline.com.cn:8181/Index.aspx");
            ie.TextField(Find.ById("edtEmpNo")).Value = "zenghuan.sz";
            ie.TextField(Find.ById("edtPwd")).Value = "yy.520";
            ie.Element("ImageButlogin").ClickNoWait();
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            //    //Thread.CurrentThread.SetApartmentState(ApartmentState.STA);
            //    //WebBrowser web = new WebBrowser();
            //    //web.Navigate("www.baidu.com", true);
            Thread newthread = new Thread(new ThreadStart(test));
            newthread.SetApartmentState(ApartmentState.STA);
            newthread.Start();
        }
    }
}
