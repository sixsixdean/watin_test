using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WatiN.Core;
using System.Threading;
namespace ConsoleApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {

            ////考勤系统
            //IE ie = new IE("http://szkq.szcentaline.com.cn:8181/Index.aspx"); 
            //ie.TextField(Find.ById("edtEmpNo")).Value = "zenghuan.sz";
            //ie.TextField(Find.ById("edtPwd")).Value = "yy.520";
            //ie.ImageButton("ImageButlogin").ClickNoWait();


            ////采购系统
            //IE ie = new IE("http://szpms.szcentaline.com.cn:85/Login.aspx");

            //ie.TextField(Find.ById("UserName")).Value = "zenghuan.sz";
            //ie.TextField(Find.ById("password")).Value = "yy.520";
            //ie.Button("btn_login").ClickNoWait();

            ////CCAI
            //IE ie = new IE();
            //ie.GoTo("http://szccai/frmLogin.aspx");
            //ie.TextField(Find.ById("Login1_txtADUserID")).Value = "fugd";
            //ie.TextField(Find.ById("Login1_txtPWD2")).Value = "SZ.999";
            //ie.Button("Login1_btnLogin").ClickNoWait();


            //  名片申请系统
            //IE ie = new IE("http://szmp/login.aspx");

            //ie.TextField(Find.ById("userName")).Value = "zenghuan.sz";
            //ie.TextField(Find.ById("userPwd")).Value = "yy.520";
            //ie.Button("btnLogin").ClickNoWait();

            ////楼库系统
            //using (IE ie = new IE("http://szlk/Login.aspx"))
            //{
            //    ie.TextField(Find.ById("UserName")).Value = "zenghuan.sz";
            //    ie.TextField(Find.ById("password")).Value = "yy.520";
            //    ie.Button("btn_login").ClickNoWait();
            //}


            Thread newthread = new Thread(new ThreadStart(test));
            newthread.SetApartmentState(ApartmentState.STA);
            newthread.Start();


        }

        public static void test()
        {
            IE ie = new IE("http://www.baidu.com");

            ie.TextField(Find.ById("kw")).Value = "苹果手机套";

            ie.Element("su").Click();

            Thread.Sleep(500);
            List<Span> spanlist = ie.Spans.ToList();
            List<Div> divlist1 = new List<Div>();
            foreach (var s in spanlist)
            {

                if (s.InnerHtml != null && s.InnerHtml.Length > 0 && s.InnerHtml.Contains("www.voglove.com"))
                {
                    Div div1 = getParent(s);
                    divlist1.Add(div1);
                }
            }
            foreach (var d in divlist1)
            {


                if (d.Links != null && d.Links.Count > 0)
                {
                    List<Link> linklist = d.Links.ToList();
                    foreach (var l in linklist)
                    {
                        if (l.InnerHtml != null && l.InnerHtml.Length > 0 && l.InnerHtml.Contains("www.voglove.com"))
                        {
                            l.Click();
                        }
                    }
                }

            }
        }

        public static Div getParent(Element s)
        {
            if (s.Parent.GetType() != typeof(Div))
            {
                return getParent(s.Parent);
            }
            else
            {
                return (Div)s.Parent;
            }
        }
    }
}
