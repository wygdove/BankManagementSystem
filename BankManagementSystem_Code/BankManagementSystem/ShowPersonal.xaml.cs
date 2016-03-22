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
    /// ShowPersonal.xaml 的交互逻辑
    /// </summary>
    public partial class ShowPersonal :Page
    {
        public ShowPersonal()
        {
            InitializeComponent();
           
            this.show();
          
        }
        public void show()
        {
            //查找数据库有关信息
            using (var context = new BMS_DBEntities())
            {
                var q = from t1 in context.PersonalLoanInfoes
                        from t2 in context.UserAccountInfoes
                        where t1.PlAccountNumber == t2.UAccountNumber
                        select new
                        {
                            账户 = t1.PlAccountNumber,
                            姓名 = t2.UName,
                            所在单位 = t1.PlWork,
                            基本工资 = t1.PlSalary,
                            余额 = t2.Balance,
                            贷款类型 = "个人贷款"
                        };
                ////test
                //var q = from t in context.PersonalLoanInfoes
                //        select t;
                ////test
                data.ItemsSource = q.ToList();
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window p = new PersonalService();
            p.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            p.ShowDialog();
            this.show();
        }
    }
}
