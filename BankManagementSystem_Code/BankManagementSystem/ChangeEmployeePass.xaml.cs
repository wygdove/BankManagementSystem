﻿using System;
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
    /// ChangeEmployeePass.xaml 的交互逻辑
    /// </summary>
    public partial class ChangeEmployeePass : Page
    {
        BMS_DBEntities context = new BMS_DBEntities();
        public ChangeEmployeePass()
        {
            InitializeComponent();
        }
        // 更改密码
        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            //获取该职员信息，修改密码
            var query = from t in context.EmployeeInfoes
                        where t.EId == this.EmployeeId.Text && t.EPassword == this.oldPass.Password
                        select t;
            if (query.Count() > 0 && this.newPass.Password.Length > 0)
            {
                var q = query.First();
                q.EPassword = this.newPass.Password;
                try
                {
                    context.SaveChanges();
                    MessageBox.Show("更改密码成功！");
                }
                catch
                {
                    MessageBox.Show("更改密码失败！");
                }
            }
            else
            {
                MessageBox.Show("更改密码失败！");
            }
        }
        //取消更改
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.oldPass.Clear();
            this.newPass.Clear();
        }
    }
}
