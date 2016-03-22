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
    /// StaffManagement.xaml 的交互逻辑
    /// </summary>
    public partial class WageAdjustment : Page
    {
        BMS_DBEntities context = new BMS_DBEntities();
        public WageAdjustment()
        { 
            InitializeComponent();
            var q = from t in context.EmployeeInfoes
                    select t;
            show.ItemsSource = q.ToList();
        }

        private void StaffManagement_Unloaded(object sender, RoutedEventArgs e)
        {
            
            context.Dispose();
           
        }

        //保存
        private void Button_Click_staff(object sender, RoutedEventArgs e)
        {
            try
            {
                context.SaveChanges();
                MessageBox.Show("保存成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "保存失败");
            }
        }
    }
}
