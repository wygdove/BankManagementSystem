using BankManagementSystem.DB;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using BankManagementSystem;

namespace BankManagementSystem
{
    class DataOperation
    {
        public static readonly string[] AccountType = { "活期存款", "定期存款", "零存整取" };

        /// <summary>
        /// 获取操作员姓名
        /// </summary>
        /// <param name="id">操作员编号</param>
        /// <returns></returns>
        public static string GetOperateName(string id)
        {
            using (BMS_DBEntities c = new BMS_DBEntities())
            {
                var q = from t in c.EmployeeInfoes
                        where t.EId == id
                        select t;
                if (q != null && q.Count() >= 1)
                {
                    return q.First().EName;
                }
                else
                {
                    return "";
                }
            }
        }

        /// <summary>
        /// 根据存款类型创建存款用户
        /// </summary>
        /// <param name="accountType">存款类型</param>
        /// <returns></returns>
        public static Custom CreateCustom(string accountType)
        {
            Custom custom = null;
            switch (accountType)
            {
                case "活期存款":
                    custom = new CustomChecking();
                    break;
                case "定期存款":
                    custom = new CustomFixed();
                    break;
                case "零存整取":
                    break;
            }
            custom.AccountInfo.LoanType = accountType;
            return custom;
        }

        /// <summary>
        /// 获取存款用户信息,并初始化余额
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        public static Custom GetCustom(string accountNumber)
        {
            Custom custom = null;
            BMS_DBEntities c = new BMS_DBEntities();
            try
            {
                var q = (from t in c.UserAccountInfoes
                         where t.UAccountNumber == accountNumber
                         select t).Single();
                custom = CreateCustom(q.LoanType);
                custom.AccountInfo.UAccountNumber = accountNumber;
                custom.AccountInfo.UName = q.UName;
                custom.AccountInfo.UAccountPassword = q.UAccountPassword;
                custom.AccountInfo.UIdCardNumber = q.UIdCardNumber;
            }
            catch
            {
                return null;
            }
            var q1 = (from t in c.OperateRecordInfoes
                      where t.OAccountNumber == accountNumber
                      select t).Sum(x => x.OAccountChange);
            custom.AccountBalance = (double)q1;                             //??????????????????????????????????
            return custom;
        }

        /// <summary>
        /// 获取指定类别的利率
        /// </summary>
        /// <param name="rateType">利率类别</param>
        /// <returns>对应类别的利率值</returns>
        public static double GetRate(RateType rateType)
        {
            string type = rateType.ToString();
            BMS_DBEntities c = new BMS_DBEntities();
            var q = (from t in c.RateInfoes
                     where t.DepositType == type
                     select t.Rate).Single();
            return q.Value;
        }
    }
}
