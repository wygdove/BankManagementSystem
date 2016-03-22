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
    /// ShowStudent.xaml 的交互逻辑
    /// </summary>
    public partial class ShowStudent : Page
    {
        public ShowStudent()
        {
            InitializeComponent();
            this.show();
        }
        public void show()
        {
            //查找数据库有关信息
            using (var context = new BMS_DBEntities())
            {
                var q = from t1 in context.StudentLoanInfoes
                        from t2 in context.UserAccountInfoes
                        where t1.SlAccountNumber == t2.UAccountNumber
                        select new
                        {
                            账户 = t1.SlAccountNumber,
                            姓名 = t2.UName,
                            学校 = t1.SlSchool,
                            手机号码=t2.UPhone,
                            余额 = t2.Balance,
                            贷款类型 = "学生短期借款"
                        };
                data.ItemsSource = q.ToList();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window s = new StudentBorrowService();
            s.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            s.ShowDialog();
            this.show();
        }
    }
}
