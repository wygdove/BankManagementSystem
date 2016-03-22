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
    /// OperateRecord.xaml 的交互逻辑
    /// </summary>
    public partial class OperateRecord : Page
    {
        public OperateRecord()
        {
            InitializeComponent();
            BMS_DBEntities context = new BMS_DBEntities();
            var query = from t in context.OperateRecordInfoes
                        select t;
            this.datagrid1.ItemsSource = query.ToList();       //数据库
        }
    }
}
