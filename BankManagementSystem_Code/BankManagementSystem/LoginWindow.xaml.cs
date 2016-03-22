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
using BankManagementSystem;
using BankManagementSystem.DB;


namespace BankManagementSystem
{
    /// <summary>
    /// LoginWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWindow : Window
    {
        public string UserName { get; set; }

        private BMS_DBEntities dbEntity = new BMS_DBEntities();            //创建对象实体（数据库）


        public LoginWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            UserName = ""; //UserName = string.Empty;//string.Empty就相当于""一般用于字符串的初始化
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //by wygdove start
            //测试，查看用户名和密码的获取内容
            //MessageBox.Show(this.combox.Text+"\n"+this.pass.Password);
            //by wygdove end

            //数据库
            var query = from t in dbEntity.EmployeeInfoes
                        where t.EId == this.combox.Text && t.EPassword == this.pass.Password
                        select t;
            if (query.Count() > 0)
            {
                var q = query.First();  //返回序列中的第一个元素
                UserName = DataOperation.GetOperateName(q.EId);
                //by wygdove start
                this.UserName = this.combox.Text;
                //by wygdove end
                this.Close();
            }
            else
            {
                MessageBox.Show("登录失败！");
                this.pass.Clear();                           //????
                this.pass.Focus();                           //????
            }

        }
        //关闭窗体
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        //窗体关闭时进行关闭操作
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //by wygdove start
            //测试，查看是否执行if条件内容
            //MessageBox.Show(this.UserName);
            //程序结束原因：此时的UserName为空
            //by wygdove end

            if (string.IsNullOrEmpty(this.UserName) == true)
            {
                App.Current.Shutdown();
            }
        }
        //将账户表中的账号信息显示到此处
        private void Window_SourceInitialized_1(object sender, EventArgs e)
        {
            var query = from t in dbEntity.EmployeeInfoes
                select t.EId;
            this.combox.ItemsSource = query.ToList();
        }
    }
}
