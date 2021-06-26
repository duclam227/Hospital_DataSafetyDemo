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
using System.Data;
using BUS_HospitalManagement;

namespace GUI_HospitalManagement
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        private string role;
        private string username;

        public Dashboard()
        {
            InitializeComponent();
            DataContext = this;
        }

        public Dashboard(string input)
        {
            InitializeComponent();
            username = input;
            role = BUS_HospitalManagement.RoleManagement.GetRole();
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(role + username);
            string welcome = "Xin chào " + username + ", bạn là một ";

            if (username == "atbm" || username == "ATBM")
            {
                welcome += "DBA!";
                WelcomeTextBlock.Text = welcome;

                //show dba
                DBAPage dba = new DBAPage();
                RoleFrame.Navigate(dba);
            }
            else
            {
                switch (role)
                {
                    case "accounting":
                        {
                            welcome += "Kế toán!";
                            WelcomeTextBlock.Text = welcome;

                            AccountingPage accounting = new AccountingPage();
                            RoleFrame.Navigate(accounting);
                            break;
                        }
                    case "doctor":
                        {
                            welcome += "Bác sĩ!";
                            WelcomeTextBlock.Text = welcome;

                            DoctorPage doctor = new DoctorPage();
                            RoleFrame.Navigate(doctor);
                            break;
                        }
                    case "reception":
                        {
                            welcome += "Điều phối viên!";
                            WelcomeTextBlock.Text = welcome;

                            ReceptionPage recep = new ReceptionPage();
                            RoleFrame.Navigate(recep);
                            break;
                        }
                }
            }
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            BUS_HospitalManagement.Utilities.CloseConnection();
            MainWindow main = new MainWindow();
            this.Close();
            main.Show();
        }
    }
}
