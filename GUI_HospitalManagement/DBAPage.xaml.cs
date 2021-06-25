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
using System.Data;

namespace GUI_HospitalManagement
{
    /// <summary>
    /// Interaction logic for DBAPage.xaml
    /// </summary>
    public partial class DBAPage : Page
    {
        public DBAPage()
        {
            InitializeComponent();
        }

        private void RunCommandButton_Click(object sender, RoutedEventArgs e)
        {
            string cmd = commandTextBox.Text;
            //MessageBox.Show(cmd);

            try
            {
                DataTable dt = BUS_HospitalManagement.UserManagement.RunQuery(cmd);
                DataReturnGrid.ItemsSource = new DataView(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddPatientButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BUS_HospitalManagement.BUS_Dept.AddPatient(NameTextBox.Text, DOBTextBox.Text, AddressTextBox.Text, PhoneTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
