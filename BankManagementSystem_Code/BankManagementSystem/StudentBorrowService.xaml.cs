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
    /// StudentBorrowService.xaml 的交互逻辑
    /// </summary>
    public partial class StudentBorrowService : Window
    {
        public StudentBorrowService()
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
                accountinfo.UName = this.StuName.Text;
                accountinfo.UPhone = this.StuPhone.Text;
                accountinfo.Balance = decimal.Parse(this.BorrowAmount.Text);

                var q = from t in context.UserAccountInfoes
                        where t.UAccountNumber == accountinfo.UAccountNumber
                        select t;
                if (q.Count() == 0)
                {
                    CustomOperation.CreateLoan(accountinfo, "学生短期借款");
                    context.SaveChanges();
                    context.Dispose();
                }
            }
            //by wygdove end

            //将贷款信息添置数据库
            using (var context = new BMS_DBEntities())
            {
                StudentLoanInfo student = new StudentLoanInfo()
                {
                    SlAccountNumber = this.AccountId.Text,
                    SlSchool = this.StuSchool.Text,

                };
                try
                {
                    context.StudentLoanInfoes.Add(student);
                    context.SaveChanges();
                    MessageBox.Show("借款成功");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("借款失败!" + ex.Message);

                }
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.StuName.Clear();
            this.StuID.Clear();
            this.StuSchool.Clear();
            this.StuPhone.Clear();
            this.AccountId.Clear();
            this.BorrowAmount.Clear();
            this.Close();
        }

        private void StuID_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
      
}
