using BankManagementSystem.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankManagementSystem
{
    public class Custom
    {
        /// <summary>
        /// 存款客户的帐户基本信息
        /// </summary>
        public UserAccountInfo AccountInfo { get; set; }
        /// <summary>
        /// 存款发生信息
        /// </summary>
        public OperateRecordInfo MoneyInfo { get; set; }
        /// <summary>
        /// 帐户余额
        /// </summary>
        public double AccountBalance { get; set; }
        public Custom()
        {
            AccountInfo = new UserAccountInfo();
            MoneyInfo = new OperateRecordInfo();
        }

        BMS_DBEntities context = new BMS_DBEntities();
        /// 开户
        /// </summary>
        /// <param name="accountNumber">帐号</param>
        /// <param name="money">开户金额</param>
        public virtual void Create(string accountNumber, double money)
        {
            this.AccountBalance = money;
            //插入到数据库
            try
            {
                context.UserAccountInfoes.Add(AccountInfo);
                context.SaveChanges();
            }
            catch
            {
                MessageBox.Show("开户失败！");
            }
            this.MoneyInfo.OAccountNumber = accountNumber;
            InsertData("开户", money);
        }

        /// <summary>
        ///存款 
        /// </summary>
        /// <param name="genType">类型</param>
        /// <param name="money">金额</param>
        public virtual void Diposit(string genType, double money)
        {
            if (money <= 0)
            {
                throw new Exception("存款金额不能为零或负值");
            }
            else
            {
                //修改余额
                AccountBalance += money;
                InsertData(genType, money);
            }
        }

        /// <summary>
        ///检查是否允许取款，允许返回true，否则返回false
        /// </summary>
        /// <param name="money">取款金额</param>
        public bool ValidBeforeWithdraw(double money)
        {
            if (money <= 0)
            {
                MessageBox.Show("取款金额不能为零或负值");
                return false;
            }
            if (money > AccountBalance)
            {
                MessageBox.Show("取款数不能比余额大");
                return false;
            }
            return true;
        }

        /// <summary>
        ///取款 
        /// </summary>
        /// <param name="money">取款金额</param>
        public virtual void Withdraw(double money)
        {
            AccountBalance -= money;
            InsertData("取款", -money);
        }

        /// <summary>
        /// 在表中添加新记录
        /// </summary>
        /// <param name="genType">发生类别</param>
        /// <param name="money">发生金额</param>
        public void InsertData(string genType, double money)
        {

            MoneyInfo.OAccountNumber = this.MoneyInfo.OAccountNumber;
            MoneyInfo.OTime = DateTime.Now;
            MoneyInfo.OType = genType;
           MoneyInfo.OAccountChange = money;
            MoneyInfo.AccountRemaining = AccountBalance;
            try
            {
                context.OperateRecordInfoes.Add(MoneyInfo);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("添加失败：" + ex.Message);
            }

        }
    }
}
