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
using BankManagementSystem.DB;

namespace BankManagementSystem
{
    /// <summary>
    /// ChargeAccount.xaml 的交互逻辑
    /// </summary>
    public partial class ChargeAccount : Page
    {
        BMS_DBEntities context = new BMS_DBEntities();
        static UserAccountInfo accountinfo = new UserAccountInfo();
        static string statement = "";

        public ChargeAccount()
        {
            InitializeComponent();
            
        }
        
        //by wygdove start
        public int check()
        {
            accountinfo.UName = this.CName.Text;
            accountinfo.UIdCardNumber = this.IDCard.Text;
            accountinfo.UAccountNumber = this.CreditCard.Text;
            accountinfo.UAccountPassword = this.Password.Password;

            using (var context = new BMS_DBEntities())
            {
                try
                {
                    var q = from t in context.UserAccountInfoes
                            where t.UIdCardNumber == accountinfo.UIdCardNumber && t.UAccountPassword == accountinfo.UAccountPassword && t.UAccountNumber == accountinfo.UAccountNumber
                            select t;
                    foreach (var i in q)
                        MessageBox.Show("该账户状态为：" + i.Statement);
                    return q.ToList().Count();
                }
                catch
                {
                    MessageBox.Show("查询用户失败");
                }
            }
            return -1;
        }
        //by wygdove end

        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            //by wygdove start
            //ShowIdCard sid = new ShowIdCard(accountinfo);
            //sid.ShowDialog();
            int i=this.check();
            if(i<=0)
            {
                MessageBox.Show("用户不存在");
            }
            
            //by wygdove end
        }
        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
	    //取数据库相应账户挂失
            var query = from t in context.UserAccountInfoes
                        where t.UName == this.CName.Text && t.UAccountPassword == this.Password.Password
                        && t.UAccountNumber == this.CreditCard.Text && t.UIdCardNumber == this.IDCard.Text
                        && t.Statement!="lost"
                        select t;
            if (query.Count() >= 1)
            {
                var q = query.First();
                q.Statement = "lost";

                try
                {
                    context.SaveChanges();
                    MessageBox.Show("挂失成功！");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("挂失失败!" + ex.Message);

                }

            }
            else
            {
                MessageBox.Show("该账户信息输入有错误！");
            }


        }

       
        private void btnC_Click(object sender, RoutedEventArgs e)
        {
            var query = from t in context.UserAccountInfoes
                        where t.UName == this.CName.Text && t.UAccountPassword == this.Password.Password
                         && t.UIdCardNumber == this.IDCard.Text && t.UAccountNumber == this.CreditCard.Text && t.Statement == "lost"
                        select t;
            if (query.Count() == 1)
            {
                var q = query.First();
                q.Statement = "normal";

                try
                {
                    context.SaveChanges();
                    MessageBox.Show("解挂成功！");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("解挂失败!" + ex.Message);

                }

            }
            else
            {
                MessageBox.Show("该账户信息输入有错误！");
            }

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.CName.Clear();
            this.IDCard.Clear();
            this.CreditCard.Clear();
            this.Password.Clear();

        }


       
    }
}
