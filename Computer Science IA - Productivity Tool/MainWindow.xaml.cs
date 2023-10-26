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
using System.Data.SqlClient;
using Microsoft.Toolkit.Uwp.Notifications;
using Windows.UI.Notifications;
using Windows.Data.Xml.Dom;
using System.Globalization;

namespace Computer_Science_IA___Productivity_Tool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        } 

        private void ExpandMenuButton_Click(object sender, RoutedEventArgs e)
        {
            ExpandMenuButton.Visibility = Visibility.Collapsed;
            ShrinkMenuButton.Visibility = Visibility.Visible;
        }

        private void ShrinkMenuButton_Click(object sender, RoutedEventArgs e)
        {
            ExpandMenuButton.Visibility = Visibility.Visible;
            ShrinkMenuButton.Visibility = Visibility.Collapsed;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;

            switch(index)
            {
                case 0:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new UserControlViewAllTasks());
                    break;
                case 1:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new UserControlAddEditTask());
                    break;
                case 2:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new CalendarPage());
                    break;
                default:
                    break;
            }
        }
    }
}
