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
    /// BusinessService.xaml 的交互逻辑
    /// </summary>
    public partial class BusinessService : Window
    {
        BMS_DBEntities context = new BMS_DBEntities();
        public BusinessService()
        {
            InitializeComponent();
              
        }
        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            //by wygdove start
            UserAccountInfo accountinfo = new UserAccountInfo();
            using (var context = new BMS_DBEntities())
            {
                accountinfo.UAccountNumber = this.AccountId.Text;
                accountinfo.UName = this.LName.Text;
                accountinfo.UPhone = this.LPhone.Text;
                accountinfo.Balance = decimal.Parse(this.LoanAmount.Text);

                var q = from t in context.UserAccountInfoes
                        where t.UAccountNumber == accountinfo.UAccountNumber
                        select t;
                if (q.Count() == 0)
                {
                    CustomOperation.CreateLoan(accountinfo, "企业贷款");
                    context.SaveChanges();
                    context.Dispose();
                }
            }
            //by wygdove end

            //将贷款信息添置数据库
            using (var context = new BMS_DBEntities())
            {
                BusinessLoanInfo firm = new BusinessLoanInfo()
                {
                    BlCompany = this.Company.Text,
                    BlCompanyLoaction = this.Location.Text,
                    BlAccountNumber = accountinfo.UAccountNumber,
                    BlCompanyAsset = this.TotalAssets.Text
                };

                try
                {
                    context.BusinessLoanInfoes.Add(firm);
                    context.SaveChanges();
                    context.Dispose();
                    MessageBox.Show("贷款成功");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("贷款失败! " + ex.Message);
                }
                context.Dispose();
                this.Close();
            }

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.LName.Clear();
            this.LID.Clear();
            this.Company.Clear();
            this.Location.Clear();
            this.LPhone.Clear();
            this.AccountId.Clear();
            this.LoanAmount.Clear();
            this.Close();

        }
    }
       
}
