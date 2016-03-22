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
using BankManagementSystem.DB;

namespace BankManagementSystem
{
    /// <summary>
    /// Withdraw.xaml 的交互逻辑
    /// </summary>
    public partial class Withdraw : Page
    {
        public Withdraw()
        {
            InitializeComponent();
        }
        //取款
        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            UserAccountInfo accountinfo = new UserAccountInfo();
            accountinfo.UAccountNumber = this.txtAccount.Text;
            accountinfo.UAccountPassword = this.txtPassword.Password;
            try
            {
                accountinfo.Balance = decimal.Parse(this.txtmount.Text);
            }
            catch
            {
                MessageBox.Show("金额输入不正确");
            }
            CustomOperation.UpdateDraw(accountinfo);

            OperateRecord page = new OperateRecord();
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(page);
        }
        //取消取款
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            OperateRecord page = new OperateRecord();
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(page);
        }
    }
}
