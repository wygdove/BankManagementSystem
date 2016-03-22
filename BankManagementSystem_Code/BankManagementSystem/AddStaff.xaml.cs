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
    /// AddStaff.xaml 的交互逻辑
    /// </summary>
    public partial class AddStaff : Window
    {
        public AddStaff()
        {
            InitializeComponent();
        }

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new BMS_DBEntities())
            {
                EmployeeInfo em = new EmployeeInfo()
                {
                    EId = this.Id.Text,
                    EName = this.stName.Text,
                    EPassword = this.pass.Password,
                    ESex = this.Sex.Text,
                    EIdCardNumber = this.IdCard.Text,
                    ESalary = decimal.Parse(this.Wage.Text),
                    EPhone = this.Conn.Text,

                };
                try
                {
                    context.EmployeeInfoes.Add(em);
                    context.SaveChanges();
                    context.Dispose();
                    MessageBox.Show("添加成功");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("添加失败!" + ex.Message);

                }

            } 
            this.Close();
            
           


        }

        private void b2_Click(object sender, RoutedEventArgs e)
        {
            this.Id.Clear();
            this.stName.Clear();
            this.pass.Clear();
            this.Sex.Clear();
            this.IdCard.Clear();
            this.Wage.Clear();
            this.Conn.Clear();
            this.Close();


        }

    }
}
