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
    /// DeleteStaff.xaml 的交互逻辑
    /// </summary>
    public partial class DeleteStaff : Window
    {
        public DeleteStaff()
        {
            InitializeComponent();
        }
        private void b3_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new BMS_DBEntities())
            {
                var q = from t in context.EmployeeInfoes
                        where t.EId == this.SId.Text && t.EIdCardNumber == this.SIdCard.Text && t.EName == this.SName.Text && t.EPassword == this.password.Password
                        select t;
                foreach(var v in q)
                { 
                    context.EmployeeInfoes.Remove(v); 
                }

                context.SaveChanges();
                context.Dispose();
                MessageBox.Show("删除成功");
            }
            this.Close();
        }

        private void b4_Click(object sender, RoutedEventArgs e)
        {
            this.SId.Clear();
            this.password.Clear();
            this.SIdCard.Clear();
            this.SName.Clear();
            this.Close();
        }

      
       
    }
}
