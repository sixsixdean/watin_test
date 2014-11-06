using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using WatiN.Core;
using System.IO;
namespace WindowsFormsApplication1
{
    public partial class Form1 : System.Windows.Forms.Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string KeyWord = tbKeyWords.Text.Trim();
            string WebSite = tbWebSite.Text.Trim();
            MyThreadParameter mtp = new MyThreadParameter(KeyWord, WebSite);
            Thread newthread = new Thread(new ParameterizedThreadStart(test));
            newthread.SetApartmentState(ApartmentState.STA);
            newthread.Start(mtp);
        }
        public static void test(object ms)
        {
            EventLog log = new EventLog();
            try
            {
                MyThreadParameter mtp = ms as MyThreadParameter;
                IE ie = new IE("http://www.baidu.com");
                log.CreateLog("实例化ie");
                ie.TextField(Find.ById("kw")).Value = mtp.KeyWord;
                log.CreateLog("输入关键字");
                ie.Element("su").Click();
                log.CreateLog("搜索成功");
                Thread.Sleep(500);
                List<Span> spanlist = ie.Spans.ToList();
                List<Div> divlist1 = new List<Div>();
                Div div2 = ie.Div(Find.ById("container"));
                 
                foreach (var s in spanlist)
                {

                    if (s.InnerHtml != null && s.InnerHtml.Length > 0 && s.InnerHtml.Contains(mtp.WebSite))
                    {
                        Div div1 = getParent(s);
                        divlist1.Add(div1);
                    }
                }
                log.CreateLog("找到" + divlist1.Count + "个关键字");
                int i = 1;
                foreach (var d in divlist1)
                {

                    if (d.Links != null && d.Links.Count > 0)
                    {
                        List<Link> linklist = d.Links.ToList();
                        foreach (var l in linklist)
                        {
                            if (l.InnerHtml != null && l.InnerHtml.Length > 0 && l.InnerHtml.Contains(mtp.WebSite))
                            {
                                l.Click();
                                log.CreateLog("第" + i + "次打开网页");
                            }
                        }
                    }

                }
            }
            catch (Exception e)
            {
                log.CreateLog(e.Message.ToString());
            }
            finally
            {
                log.CreateLog("本次搜索结束!");
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

    public class MyThreadParameter
    {
        private string _keyword;
        private string _website;
        public string KeyWord
        {
            get
            {
                return _keyword;
            }
            set
            {
                _keyword = value;
            }
        }
        public string WebSite
        {
            get
            {
                return _website;
            }
            set
            {
                _website = value;
            }
        }
        public MyThreadParameter(string keyword, string website)
        {
            this._keyword = keyword;
            this._website = website;
        }
    }

    public class EventLog
    {
        public void CreateLog(string msg)
        {
            string dirpath = @"C:\LOG";
            string filename = System.DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            string filepath = dirpath + @"\"+filename;
            if (!Directory.Exists(dirpath))
                Directory.CreateDirectory(dirpath);
            if (!File.Exists(filepath))
                File.Create(filepath).Dispose();
            StreamWriter sw = new StreamWriter(filepath, true);
            sw.WriteLine(msg + "---" + System.DateTime.Now.ToString());
            sw.Flush();
            sw.Close();

        }
    }

}
