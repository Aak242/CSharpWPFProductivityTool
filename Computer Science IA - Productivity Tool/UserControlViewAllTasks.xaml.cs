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
using System.Data;


namespace Computer_Science_IA___Productivity_Tool
{
    /// <summary>
    /// Interaction logic for UserControlViewAllTasks.xaml
    /// </summary>
    public partial class UserControlViewAllTasks : UserControl
    {

        SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Aak242\Documents\IADB.mdf;Integrated Security=True;Connect Timeout=30");
        public UserControlViewAllTasks()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Function to fill the DataGrid with the values stroed in the database by the user.
        /// </summary>
        void FillDataGridView()
        {
            //Checking if the SQL server is open. If it is not, the connection is established with the database.
            if (sqlCon.State == System.Data.ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            //In the case of retrieving data, we have to use the SqlDataAdapter. The data adapter is then linked to the stored procedure we made to retrieve all fields.
            SqlDataAdapter sqlDa = new SqlDataAdapter("VieworSearchTask", sqlCon);
            sqlDa.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;

            //In order to store the result of the query from the stored procedure in SQL, we have to use a DataTable.
            DataTable dtbl = new DataTable();
            //Filling records into the data table.
            sqlDa.Fill(dtbl);
            //In order to show the retrieved results in the DataGrid table, we bind the data to our DataGrid, DisplayTasks.
            DisplayTasks.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = dtbl });


            //Hides the primary key, TaskNumber, from the user. 
            DisplayTasks.Columns[0].Visibility = Visibility.Collapsed;
            DisplayTasks.Columns[5].Visibility = Visibility.Collapsed;

            sqlCon.Close();
        }

        private void DayText_Loaded(object sender, RoutedEventArgs e)
        {

            DayText.Text = DateTime.Now.DayOfWeek.ToString();
            DayText.Text = DayText.Text.ToUpper();

        }

        private void DateText_Loaded(object sender, RoutedEventArgs e)
        {
            DateText.Text = DateTime.Now.ToShortDateString();
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            if (sqlCon.State == System.Data.ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            SqlDataAdapter sqlDa = new SqlDataAdapter("ViewTask", sqlCon);
            sqlDa.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;

            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            DisplayTasks.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = dtbl });

            DisplayTasks.Columns[0].Visibility = Visibility.Collapsed;
            DisplayTasks.Columns[5].Visibility = Visibility.Collapsed;

            sqlCon.Close();
        }
    }
}
