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
    /// ShowBusiness.xaml 的交互逻辑
    /// </summary>
    public partial class ShowBusiness : Page
    {
        public ShowBusiness()
        {
            InitializeComponent();
            this.show();
          
        }
        public void show()
        {   
            
            //查找数据库有关信息
            using (var context = new BMS_DBEntities())
            {
                
                var q = from t1 in context.BusinessLoanInfoes
                        from t2 in context.UserAccountInfoes
                        where t1.BlAccountNumber == t2.UAccountNumber
                        select new
                        {
                            账号 = t1.BlAccountNumber,
                            姓名 = t2.UName,
                            公司 = t1.BlCompany,
                            总资产 = t1.BlCompanyAsset,
                            余额 = t2.Balance,
                            贷款类型 = "企业贷款"
                        };
                data.ItemsSource = q.ToList();
                //var q1 = from t2 in context.UserAccountInfoes
                //         from t1 in context.BusinessLoanInfoes
                //        where t1.BlAccountNumber == t2.UAccountNumber
                //        select t2;
                //data.ItemsSource = q1.ToList();
            }
         
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window bs = new BusinessService();
            bs.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            bs.ShowDialog();
            this.show();
        }

      
    }
}
