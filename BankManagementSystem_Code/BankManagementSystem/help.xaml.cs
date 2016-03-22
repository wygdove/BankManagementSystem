using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;

namespace BankManagementSystem
{
    /// <summary>
    /// help.xaml 的交互逻辑
    /// </summary>
    public partial class help : Page
    {
        public help()
        {
            InitializeComponent();
              // Button.Click += Button_Click;
            //reeViewItem.MouseDoubleClickEv
            

        }
        private void a1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            textBox.Text = "";
            FileStream fs = new FileStream(@"helpFile\所需证件.txt", FileMode.OpenOrCreate, FileAccess.Read);//双击打开文件
            StreamReader sr = new StreamReader(fs, Encoding.Default);
            textBox.AppendText(sr.ReadToEnd());
            sr.Close();
            fs.Close();
        }

        private void a2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            textBox.Text = "";
            FileStream fs = new FileStream(@"helpFile\申请流程.txt", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(fs, Encoding.Default);
            textBox.AppendText(sr.ReadToEnd());
            sr.Close();
            fs.Close();
        }

        private void a3_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            textBox.Text = "";
            FileStream fs = new FileStream(@"helpFile\网上办理.txt", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(fs, Encoding.Default);
            textBox.AppendText(sr.ReadToEnd());
            sr.Close();
            fs.Close();
        }

        private void b1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            textBox.Text = "";
            FileStream fs = new FileStream(@"helpFile\修改密码.txt", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(fs, Encoding.Default);
            textBox.AppendText(sr.ReadToEnd());
            sr.Close();
            fs.Close();
        }

        private void b2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            textBox.Text = "";
            FileStream fs = new FileStream(@"helpFile\证件要求.txt", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(fs, Encoding.Default);
            textBox.AppendText(sr.ReadToEnd());
            sr.Close();
            fs.Close();
        }

        private void b3_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            textBox.Text = "";
            FileStream fs = new FileStream(@"helpFile\动态密码.txt", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(fs, Encoding.Default);
            textBox.AppendText(sr.ReadToEnd());
            sr.Close();
            fs.Close();
        }

        private void c1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            textBox.Text = "";
            FileStream fs = new FileStream(@"helpFile\助学贷款.txt", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(fs, Encoding.Default);
            textBox.AppendText(sr.ReadToEnd());
            sr.Close();
            fs.Close();
        }

        private void c2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            textBox.Text = "";
            FileStream fs = new FileStream(@"helpFile\个人贷款.txt", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(fs, Encoding.Default);
            textBox.AppendText(sr.ReadToEnd());
            sr.Close();
            fs.Close();
        }

        private void c3_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            textBox.Text = "";

            FileStream fs = new FileStream(@"helpFile\企业贷款.txt", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(fs, Encoding.Default);
            textBox.AppendText(sr.ReadToEnd());
            sr.Close();
            fs.Close();
        }
       
        }
    
}
