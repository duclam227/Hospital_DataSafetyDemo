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

namespace GUI_HospitalManagement
{
    /// <summary>
    /// Interaction logic for ReceptionPage.xaml
    /// </summary>
    public partial class ReceptionPage : Page
    {
        public ReceptionPage()
        {
            InitializeComponent();
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
                return;
            }
            MessageBox.Show("Đã thêm thành công!");
        }

        private void ShowPatientButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PatientList.ItemsSource = BUS_HospitalManagement.BUS_Dept.GetAllPatient();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
