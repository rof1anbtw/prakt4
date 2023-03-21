using PRAKTIK4.Praktik2DataSetTableAdapters;
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

namespace PRAKTIK4
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        ordersTableAdapter order = new ordersTableAdapter();
        usersTableAdapter users = new usersTableAdapter();
        public Window1()
        {
            InitializeComponent();
            TableDataGrid.ItemsSource = users.GetData();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            object id = (TableDataGrid.SelectedItem as DataRowView).Row[0];
            users.UpdateQuery(Name.Text,Email.Text,Convert.ToInt32(id));
            TableDataGrid.ItemsSource = users.GetData();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1= new Window1();
            window1.ShowDialog();
            
        }
    }
}
