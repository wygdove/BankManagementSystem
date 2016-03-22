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
    /// ShowEducation.xaml 的交互逻辑
    /// </summary>
    public partial class ShowEducation : Page
    {
        public ShowEducation()
        {
            InitializeComponent();
           
            this.show();
          
        }
        public void show()
        {
            InitializeComponent();
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
                            专业 = t1.SlProfession,
                            院系 = t1.SlInstitute,
                            余额 = t2.Balance,
                            贷款类型 = "教学贷款"
                        };
                data.ItemsSource = q.ToList();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window se = new EducationService();
            se.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            se.ShowDialog();
            this.show();
           
        }
    }
}
