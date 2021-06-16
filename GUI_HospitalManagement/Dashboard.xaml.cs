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
            MessageBox.Show(role + username);
        }
    }
}
