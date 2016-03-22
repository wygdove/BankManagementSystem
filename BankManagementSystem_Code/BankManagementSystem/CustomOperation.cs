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
using BankManagementSystem.DB;

namespace BankManagementSystem
{
    class CustomOperation
    {

        /// <summary>
        /// 开户
        /// </summary>
        /// <param name="accountInfo"></param>
        public static void CreateUser(UserAccountInfo accountInfo)
        {
            using (var context = new BMS_DBEntities())
            {
                try
                {
                    accountInfo.Statement = "normal";
                    context.UserAccountInfoes.Add(accountInfo);

                    OperateRecordInfo operateinfo = new OperateRecordInfo();
                    operateinfo.OTime = System.DateTime.Now;
                    operateinfo.OType = "开户";
                    operateinfo.OAccountNumber = accountInfo.UAccountNumber;
                    operateinfo.OAccountChange = (double)accountInfo.Balance;
                    operateinfo.AccountRemaining = (double)accountInfo.Balance; 
                    context.OperateRecordInfoes.Add(operateinfo);
                    context.SaveChanges();

                    context.Dispose();
                }
                catch
                {
                    MessageBox.Show("修改失败");
                }
            }
        }

        /// <summary>
        /// 存款
        /// </summary>
        /// <param name="accountInfo"></param>
        public static void UpdateSave(UserAccountInfo accountInfo)
        {
            using (var context = new BMS_DBEntities())
            {
                try
                {
                    OperateRecordInfo operateinfo = new OperateRecordInfo();

                    var q = from t in context.UserAccountInfoes
                            where accountInfo.UAccountNumber == t.UAccountNumber
                            select t;
                    foreach (var i in q)
                    {
                        i.Balance += accountInfo.Balance;
                        operateinfo.AccountRemaining = (double)i.Balance;
                    }

                    operateinfo.OTime = System.DateTime.Now;
                    operateinfo.OType = "存款";
                    operateinfo.OAccountNumber = accountInfo.UAccountNumber;
                    operateinfo.OAccountChange = (double)accountInfo.Balance;
                    context.OperateRecordInfoes.Add(operateinfo);
                    context.SaveChanges();
                    context.Dispose();
                }
                catch
                {
                    MessageBox.Show("修改失败");
                }
            }
        }

        /// <summary>
        /// 取款
        /// </summary>
        /// <param name="accountInfo"></param>
        public static void UpdateDraw(UserAccountInfo accountInfo)
        {
            using (var context = new BMS_DBEntities())
            {
                try
                {
                    OperateRecordInfo operateinfo = new OperateRecordInfo();

                    var q = from t in context.UserAccountInfoes
                            where accountInfo.UAccountNumber == t.UAccountNumber
                            select t;
                    foreach (var i in q)
                    {
                        if(!i.UAccountPassword.Equals(accountInfo.UAccountPassword))
                        {
                            MessageBox.Show("密码不正确");
                            return;
                        }
                        i.Balance -= accountInfo.Balance;
                        operateinfo.AccountRemaining = (double)i.Balance;
                    }

                    operateinfo.OTime = System.DateTime.Now;
                    operateinfo.OType = "取款";
                    operateinfo.OAccountNumber = accountInfo.UAccountNumber;
                    operateinfo.OAccountChange = (double)accountInfo.Balance;
                    
                    context.OperateRecordInfoes.Add(operateinfo);
                    context.SaveChanges();
                    context.Dispose();
                }
                catch
                {
                    MessageBox.Show("修改失败");
                }
            }
            
        }

        public static void CreateLoan(UserAccountInfo accountInfo,string loantype)
        {
            using (var context = new BMS_DBEntities())
            {
                try
                {
                    context.UserAccountInfoes.Add(accountInfo);

                    OperateRecordInfo operateinfo = new OperateRecordInfo();
                    operateinfo.OTime = System.DateTime.Now;
                    operateinfo.OType = loantype;
                    operateinfo.OAccountNumber = accountInfo.UAccountNumber;
                    operateinfo.OAccountChange = (double)accountInfo.Balance;
                    operateinfo.AccountRemaining = (double)accountInfo.Balance;
                    context.OperateRecordInfoes.Add(operateinfo);
                    context.SaveChanges();

                }
                catch
                {
                    MessageBox.Show("修改失败");
                }
                context.Dispose();
            }
        }
    }
}


/**
 * by wygdove
 */