using System;
using System.Collections.Generic;
using System.Data;
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

namespace GUI_HospitalManagement
{
    /// <summary>
    /// Interaction logic for ReceptionPage.xaml
    /// </summary>
    public partial class AccountingPage : Page
    {
        public AccountingPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = this;
            try
            {
                DataView dataView = BUS_HospitalManagement.BUS_Employee.Instance.GetEmployeeInformation().DefaultView;
                dataView.Table.Columns[0].ColumnName = "ID";
                dataView.Table.Columns[1].ColumnName = "Name";
                dataView.Table.Columns[2].ColumnName = "Phone";
                dataView.Table.Columns[3].ColumnName = "Email";
                dataView.Table.Columns[4].ColumnName = "Address";
                dataView.Table.Columns[5].ColumnName = "DOB";
                dataView.Table.Columns[6].ColumnName = "Salary";
                dataView.Table.Columns[7].ColumnName = "Allowance";
                dataView.Table.Columns[8].ColumnName = "Position";
                dataView.Table.Columns[9].ColumnName = "Department ID";
                EmployeeInformationGrid.ItemsSource = dataView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                DataView dataView = BUS_HospitalManagement.BUS_Employee.Instance.GetExpense().DefaultView;
                dataView.Table.Columns[0].ColumnName = "ID";
                dataView.Table.Columns[1].ColumnName = "Description";
                dataView.Table.Columns[2].ColumnName = "Date";
                dataView.Table.Columns[3].ColumnName = "OperatorID";
                dataView.Table.Columns[4].ColumnName = "Amount";
                ExpenseHistoryGrid.ItemsSource = dataView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
