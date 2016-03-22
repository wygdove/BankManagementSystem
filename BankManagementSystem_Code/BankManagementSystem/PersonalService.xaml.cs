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
    /// PersonalService.xaml 的交互逻辑
    /// </summary>
    public partial class PersonalService :Window
    {
        public PersonalService()
        {
            InitializeComponent();
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            //by wygdove start
            UserAccountInfo accountinfo = new UserAccountInfo();
            using (var context = new BMS_DBEntities())
            {
                accountinfo.UAccountNumber = this.AccountId.Text;
                accountinfo.UName = this.PName.Text;
                accountinfo.UPhone = this.PPhone.Text;
                accountinfo.Balance = decimal.Parse(this.LoanAmount.Text);

                var q = from t in context.UserAccountInfoes
                        where t.UAccountNumber == accountinfo.UAccountNumber
                        select t;
                if (q.Count() == 0)
                {
                    CustomOperation.CreateLoan(accountinfo, "个人贷款");
                    context.SaveChanges();
                    context.Dispose();
                }
            }
            //by wygdove end

            //将贷款信息添置数据库
            using (var context = new BMS_DBEntities())
            {
                PersonalLoanInfo person = new PersonalLoanInfo()
               {

                   PlWork = this.Unit.Text,
                   //PlSalary = this.Wage.Text,
                   PlAccountNumber = this.AccountId.Text,
                   PlSalary=decimal.Parse(this.Wage.Text)
               };
                try
                {
                    context.PersonalLoanInfoes.Add(person);
                    context.SaveChanges();
                    MessageBox.Show("贷款成功");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("贷款失败!" + ex.Message);

                }

            }
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.PName.Clear();
            this.PID.Clear();
            this.Unit.Clear();
            this.Wage.Clear();
            this.PPhone.Clear();
            this.AccountId.Clear();
            this.LoanAmount.Clear();
            this.Close();
        }
    }
      
}
