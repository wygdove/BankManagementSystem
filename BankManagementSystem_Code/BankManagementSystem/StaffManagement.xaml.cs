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
    /// WageAdjustment.xaml 的交互逻辑
    /// </summary>
    public partial class StaffManagement : Page
    {
        public StaffManagement()
        {

            InitializeComponent();
            staff();

           
      }
        public void staff()
        {
            BMS_DBEntities context = new BMS_DBEntities();
            var query = from t in context.EmployeeInfoes
                        select t;
            this.datagrid1.ItemsSource = query.ToList(); 
        }
        

        private void btnD_Click(object sender, RoutedEventArgs e)
        {
            Window de = new DeleteStaff();
            de.ShowDialog();
            staff();

        }

        private void btnA_Click(object sender, RoutedEventArgs e)
        {
            
            Window add = new AddStaff();
            add.ShowDialog();
            staff();
        }

        
      

      
    }
}
