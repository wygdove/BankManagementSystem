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
    /// TotalQuery.xaml 的交互逻辑
    /// </summary>
    public partial class TotalQuery : Page
    {
        BMS_DBEntities context = new BMS_DBEntities();
        public TotalQuery()
        {
            InitializeComponent();
            this.Unloaded += TotalQuery_Unloaded;
        }
        void TotalQuery_Unloaded(object sender, RoutedEventArgs e)
        {
            context.Dispose();
        }
        //查询当前账号的所有记录信息
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var query = from t in context.OperateRecordInfoes
                        where t.OAccountNumber == txtID.Text
                        select t;
            datagrid1.ItemsSource = query.ToList();
        }
    }
}
