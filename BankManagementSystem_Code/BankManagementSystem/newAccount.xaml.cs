using BankManagementSystem.DB;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BankManagementSystem
{
    /// <summary>
    /// newAccount.xaml 的交互逻辑
    /// </summary>
    public partial class newAccount : Page
    {
        public newAccount()
        {
            InitializeComponent();
            InitComboBox();
        }
        private void InitComboBox()
        {
            //string[] items = Enum.GetNames(typeof(MoneyAccountType));                  //数据库
            //by wygdove start
            string[] items = Enum.GetNames(typeof(RateType));
            //by wygdove end
            foreach (var s in items)
            {
                comboBoxAccountType.Items.Add(s);
            }
            comboBoxAccountType.SelectedIndex = 0;
        }
        //开户
        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            UserAccountInfo accountinfo = new UserAccountInfo();
            accountinfo.UAccountNumber = this.txtAccountNo.Text;
            accountinfo.UIdCardNumber = this.txtIDCard.Text;
            accountinfo.UName = this.txtAccountName.Text;
            accountinfo.UAccountPassword = this.txtPass.Password;
            accountinfo.Balance = decimal.Parse(this.txtMoney.Text);
            CustomOperation.CreateUser(accountinfo);
            
            OperateRecord page = new OperateRecord();
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(page);
        }
        //取消开户
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.txtAccountName.Clear();
            this.txtIDCard.Clear();
            this.txtAccountName.Clear();
            this.txtPass.Clear();
            this.txtMoney.Clear();
            OperateRecord page = new OperateRecord();
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(page);
        }

        private void comboBoxAccountType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string s = comboBoxAccountType.SelectedItem.ToString();
            using (BMS_DBEntities c = new BMS_DBEntities())                           //数据库
            {
                var q = from t in c.UserAccountInfoes
                        where t.LoanType == s
                        select t;
                if (q.Count() > 0)
                {
                    this.txtAccountNo.Text = string.Format("{0}", int.Parse(q.Max(x => x.UAccountNumber)) + 1);
                }
                else
                {
                    txtAccountNo.Text = string.Format("{0}00001", comboBoxAccountType.SelectedIndex + 1);
                }
            }
        }
    }
}
