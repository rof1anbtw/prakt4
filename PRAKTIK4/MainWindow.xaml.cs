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
using PRAKTIK4.Praktik2DataSetTableAdapters;

namespace PRAKTIK4
{
   public partial class MainWindow : Window
    {
        ordersTableAdapter order = new ordersTableAdapter();
        usersTableAdapter users = new usersTableAdapter();
        int user_id = 0;
        public MainWindow()
        {
            InitializeComponent();
            TableDataGrid.ItemsSource = order.GetData();
            ComboBox.ItemsSource= users.GetData();
            ComboBox.DisplayMemberPath = "id";

        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object cell = (ComboBox.SelectedItem as DataRowView).Row[0];
            user_id = Convert.ToInt32(cell);

        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            object id = (TableDataGrid.SelectedItem as DataRowView).Row[0];
            order.UpdateQuery(user_id, OrderTbx.Text, TotalTbx.Text,Convert.ToInt32(id));
            TableDataGrid.ItemsSource = order.GetData();
        }
        private void Next_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.ShowDialog();

        }
    }
}
