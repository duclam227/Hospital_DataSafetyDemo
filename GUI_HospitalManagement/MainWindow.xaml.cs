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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //this.Width = SystemParameters.WorkArea.Width;
            //this.Height = SystemParameters.WorkArea.Height;
            DataContext = this;
        }

        private void Btn_Login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BUS_HospitalManagement.Utilities.Login(TextBox_Username.Text, TextBox_Password.Password);
                Dashboard dashboard = new Dashboard();
                dashboard.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
