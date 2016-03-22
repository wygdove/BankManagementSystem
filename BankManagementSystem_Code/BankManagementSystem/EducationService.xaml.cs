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
    /// EducationService.xaml 的交互逻辑
    /// </summary>
    public partial class EducationService : Window
    {
        BMS_DBEntities context = new BMS_DBEntities();
        public EducationService()
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
                accountinfo.UName = this.SName.Text;
                accountinfo.UPhone = this.Phone.Text;
                accountinfo.Balance = decimal.Parse(this.LoanAmount.Text);

                var q = from t in context.UserAccountInfoes
                        where t.UAccountNumber == accountinfo.UAccountNumber
                        select t;
                if (q.Count() == 0)
                {
                    CustomOperation.CreateLoan(accountinfo, "教学贷款");
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
                    SlSchool = this.School.Text,
                    SlInstitute = this.Academy.Text,
                    SlProfession = this.Major.Text,
                    SlAccountNumber = this.AccountId.Text

                };
                try
                {
                    context.StudentLoanInfoes.Add(student);
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
            this.SName.Clear();
            this.SID.Clear();
            this.School.Clear();
            this.Academy.Clear();
            this.Major.Clear();
            this.Phone.Clear();
            this.AccountId.Clear();
            this.LoanAmount.Clear();
            this.Close();
        }
    }
}
