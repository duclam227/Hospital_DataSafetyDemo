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
using System.Windows.Shapes;

namespace GUI_HospitalManagement
{
    /// <summary>
    /// Interaction logic for ViewDataSet.xaml
    /// </summary>
    public partial class ViewDataSet : Page
    {
        public ViewDataSet(DataTable data)
        {
            InitializeComponent();
            DataGridView.ItemsSource = new DataView(data);
        }
    }
}
