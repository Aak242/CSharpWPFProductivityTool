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
    /// Interaction logic for UserControlAddEditTask.xaml
    /// </summary>
    public partial class UserControlAddEditTask : UserControl
    {
        SqlConnection sqlCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=C:\Users\Aak242\Documents\IADB.mdf;Integrated Security=True;Connect Timeout=30");
        int TaskNumber = 0;

        public UserControlAddEditTask()
        {
            InitializeComponent();
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sqlCon.State == System.Data.ConnectionState.Closed)
                {
                    sqlCon.Open();
                }

                if (Convert.ToString(AddTasksButton.Content) == "Save Task")
                {
                    SqlCommand sqlCmd = new SqlCommand("InsertorEditTask", sqlCon);
                    sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@mode", "Add");
                    sqlCmd.Parameters.AddWithValue("@TaskNumber", 0);
                    sqlCmd.Parameters.AddWithValue("@TaskName", txtName.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@StartTime", StartTimeCombobox.Text);
                    sqlCmd.Parameters.AddWithValue("@EndTime", EndTimeCombobox.Text);
                    sqlCmd.Parameters.AddWithValue("@TaskDescription", DescriptionBox.Text);
                    sqlCmd.Parameters.AddWithValue("@NotifyIsChecked", NotifyCheckbox.IsChecked);
                    sqlCmd.ExecuteNonQuery();

                    if (NotifyCheckbox.IsChecked == true)
                    {
                        NotificationSystem();
                    }

                    MessageBox.Show("Task saved Successfully!");
                    ResetFields();
                }

                else
                {
                    SqlCommand sqlCmd = new SqlCommand("InsertorEditTask", sqlCon);
                    sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@mode", "Edit");
                    sqlCmd.Parameters.AddWithValue("@TaskNumber", TaskNumber);
                    sqlCmd.Parameters.AddWithValue("@TaskName", txtName.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@StartTime", StartTimeCombobox.Text);
                    sqlCmd.Parameters.AddWithValue("@EndTime", EndTimeCombobox.Text);
                    sqlCmd.Parameters.AddWithValue("@TaskDescription", DescriptionBox.Text);
                    sqlCmd.Parameters.AddWithValue("@NotifyIsChecked", NotifyCheckbox.IsChecked);
                    sqlCmd.ExecuteNonQuery();



                    if (NotifyCheckbox.IsChecked == true)
                    {
                        NotificationSystem();
                    }

                    MessageBox.Show("Task updated successfully!");
                    ResetFields();
                    sqlCon.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
            finally
            {
                sqlCon.Close();
            }
        }

        private void ResetFields()
        {
            txtName.Text = string.Empty;
            txtName.RaiseEvent(new RoutedEventArgs(LostFocusEvent, txtName));

            StartTimeCombobox.SelectedItem = null;
            StartTimeCombobox.Text = "Task starts from:";

            EndTimeCombobox.SelectedItem = null;
            EndTimeCombobox.Text = "Task ends at:";

            DescriptionBox.Text = string.Empty;

            AddTasksButton.Content = "Save Task";
            TaskNumber = 0;
            DeleteButton.IsEnabled = false;

            SqlDataAdapter sqlDa = new SqlDataAdapter("ViewTask", sqlCon);
            sqlDa.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;

            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            DisplayTasks.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = dtbl });

            DisplayTasks.Columns[0].Visibility = Visibility.Collapsed;
            DisplayTasks.Columns[5].Visibility = Visibility.Collapsed;

            sqlCon.Close();


        }

        /// <summary>
        /// System that sends a toast notification 5 minutes before the start of a task
        /// </summary>

        private void NotificationSystem()
        {

            string GetStartTime = ((ComboBoxItem)StartTimeCombobox.SelectedItem).Content.ToString();     //Gets the start time from the value selected in the StartTimeCombobox

            DateTime StartDateTime = DateTime.Parse(GetStartTime);            //Converting the string of the selected value into a DateTime format (short time => HH:mm:ss)

            TimeSpan InputTimeSpan = StartDateTime.TimeOfDay;            //Converting inputted time into a timespan to isolate the time (since the date time format contains both the date and the time)

            TimeSpan CurrentTime = DateTime.Now.TimeOfDay;            //Gets the current system time as a TimeSpan

            TimeSpan StartTimeDifference = InputTimeSpan.Subtract(CurrentTime);      //Calculates the difference between the inputted time and the current time 

            int HoursToMinutes = StartTimeDifference.Hours * 60;

            int NotifyTimeLength = HoursToMinutes + StartTimeDifference.Minutes - 5;       //Converting the TimeSpan format from hours and minutes to total minutes, 
                                                                                           //and having the difference in time as an integer for use in the Scheduled toast notification. 
                                                                                           //5 minutes are subtracted from this difference to ensure the notification is sent 5 minutes before the task begins.

            int NotifyTimeLengthAtTaskStart = HoursToMinutes + StartTimeDifference.Minutes;

            string GetEndTime = ((ComboBoxItem)EndTimeCombobox.SelectedItem).Content.ToString();
            DateTime EndDateTime = DateTime.Parse(GetEndTime);                                      //Performing same operations but for the notification displayed when task ends.
            TimeSpan InputEndTimeSpan = EndDateTime.TimeOfDay;
            TimeSpan EndTimeDifference = InputEndTimeSpan.Subtract(CurrentTime);
            int EndHoursToMinutes = EndTimeDifference.Hours * 60;
            int EndNotifyTimeLength = EndHoursToMinutes + EndTimeDifference.Minutes;


            if (NotifyTimeLength > 0 && NotifyTimeLengthAtTaskStart > 0)             //If the difference between the two times is positive, 
                                                                                     //then a toast notification is set to trigger {NotifyTimeLength} minutes from the current system time.
            {
                //-------------------------------------------------------------------------------TOAST NOTIFICATION 5 MINUTES BEFORE TASK BEGINS-----------------------------------------------------------------------------------------------------------------------------//

                string xml = @"<toast>
            <visual>
            <binding template=""ToastGeneric"">
            <image placement=""appLogoOverride"" src=""C:\Users\Aak242\source\repos\Computer Science IA - Productivity Tool\Computer Science IA - Productivity Tool\Icons\customer-service.png""/>
                <text>A Reminder</text>
                <text>Your task is going to start in 5 minutes. Get ready!</text> 
                <actions>
                    content=""Dismiss""
                    imageUri = ""Assets/ToastButtonIcons/Dismiss.png""
                    arguments = ""dismiss""
                    activationType = ""background""
                </actions>

                <audio src=""ms - winsoundevent:Notification.Reminder""/>

              </binding>
            </visual>
            </toast>";

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);

                ScheduledToastNotification toast = new ScheduledToastNotification(doc, DateTimeOffset.Now.AddMinutes(NotifyTimeLength));
                ToastNotificationManager.CreateToastNotifier().AddToSchedule(toast);

                //-------------------------------------------------------------------------------TOAST NOTIFICATION WHEN TASK BEGINS-----------------------------------------------------------------------------------------------------------------------------//

                string xml2 = @"<toast>
            <visual>
            <binding template=""ToastGeneric"">
            <image placement=""appLogoOverride"" src=""C:\Users\Aak242\source\repos\Computer Science IA - Productivity Tool\Computer Science IA - Productivity Tool\Icons\customer-service.png""/>
                <text>Let's begin!</text>
                <text>Your task has started. Get to work!</text> 
                <actions>
                    content=""Dismiss""
                    imageUri = ""Assets/ToastButtonIcons/Dismiss.png""
                    arguments = ""dismiss""
                    activationType = ""background""
                </actions>

                <audio src=""ms-winsoundevent:Notification.Looping.Alarm""/>

              </binding>
            </visual>
            </toast>";

                XmlDocument doc2 = new XmlDocument();
                doc2.LoadXml(xml2);

                ScheduledToastNotification toast2 = new ScheduledToastNotification(doc2, DateTimeOffset.Now.AddMinutes(NotifyTimeLengthAtTaskStart));
                ToastNotificationManager.CreateToastNotifier().AddToSchedule(toast2);

                //-------------------------------------------------------------------------------------TOAST NOTIFICATION WHEN TASK ENDS----------------------------------------------------------------------//

                string xml3 = @"<toast>
            <visual>
            <binding template=""ToastGeneric"">
            <image placement=""appLogoOverride"" src=""C:\Users\Aak242\source\repos\Computer Science IA - Productivity Tool\Computer Science IA - Productivity Tool\Icons\customer-service.png""/>
                <text>You're done!</text>
                <text>Your task has ended. Good job!</text> 
                <actions>
                    content=""Dismiss""
                    imageUri = ""Assets/ToastButtonIcons/Dismiss.png""
                    arguments = ""dismiss""
                    activationType = ""background""
                </actions>

                <audio src=""ms-winsoundevent:Notification.Looping.Alarm""/>

              </binding>
            </visual>
            </toast>";

                XmlDocument doc3 = new XmlDocument();
                doc3.LoadXml(xml3);

                ScheduledToastNotification toast3 = new ScheduledToastNotification(doc3, DateTimeOffset.Now.AddMinutes(EndNotifyTimeLength));
                ToastNotificationManager.CreateToastNotifier().AddToSchedule(toast3);

                MessageBox.Show("Notification scheduled at " + StartTimeCombobox.Text + " and five minutes earlier");

            }

            else if (NotifyTimeLengthAtTaskStart > 0)
            {
                string xml = @"<toast>
            <visual>
            <binding template=""ToastGeneric"">
            <image placement=""appLogoOverride"" src=""C:\Users\Aak242\source\repos\Computer Science IA - Productivity Tool\Computer Science IA - Productivity Tool\Icons\customer-service.png""/>
                <text>Let's begin!</text>
                <text>Your task has started. Get to work!</text> 
                <actions>
                    content=""Dismiss""
                    imageUri = ""Assets/ToastButtonIcons/Dismiss.png""
                    arguments = ""dismiss""
                    activationType = ""background""
                </actions>

                <audio src=""ms-winsoundevent:Notification.Looping.Alarm""/>

              </binding>
            </visual>
            </toast>";

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);

                ScheduledToastNotification toast = new ScheduledToastNotification(doc, DateTimeOffset.Now.AddMinutes(NotifyTimeLengthAtTaskStart));
                ToastNotificationManager.CreateToastNotifier().AddToSchedule(toast);

                MessageBox.Show("Notification scheduled at " + StartTimeCombobox.Text);

            }

            else            //If the value is negative, that is, the StartTime set is a time that has already passed, then an error message is sent to the user and the notification is not scheduled, allowing the user to try again with a valid selection.

            {
                MessageBox.Show("You have selected a start time for your task that is past the current system time. Please schedule your task to a later time if you wish to recieve a notification.");
            }


        }

        private void txtName_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= txtName_GotFocus;
        }

        private void txtName_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb.Text == string.Empty)
            {
                tb.Text = "Name of Task";
                tb.GotFocus += txtName_GotFocus;
            }
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
            //Getting the search query entered by the user.
            sqlDa.SelectCommand.Parameters.AddWithValue("@TaskName", SearchTasks.Text.Trim());

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

        private void EditTasksButton_Click(object sender, RoutedEventArgs e)
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

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            //Calling the FillDataGridView function when the 'search' button is clicked.
            try
            {
                FillDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        private void DisplayTasks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid gd = (DataGrid)sender;
            DataRowView RowSelected = gd.SelectedItem as DataRowView;

            if (RowSelected != null)
            {
                TaskNumber = Convert.ToInt32(RowSelected["TaskNumber"].ToString());
                txtName.Text = RowSelected["TaskName"].ToString();
                StartTimeCombobox.Text = RowSelected["StartTime"].ToString();
                EndTimeCombobox.Text = RowSelected["EndTime"].ToString();
                DescriptionBox.Text = RowSelected["TaskDescription"].ToString();

                AddTasksButton.Content = "Update Task";
                DeleteButton.IsEnabled = true;
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sqlCon.State == System.Data.ConnectionState.Closed)
                {
                    sqlCon.Open();
                }

                SqlCommand sqlCmd = new SqlCommand("DeleteTask", sqlCon);
                sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@TaskNumber", TaskNumber);
              
                sqlCmd.ExecuteNonQuery();

                MessageBox.Show("Task deleted Successfully!");
                ResetFields();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        
    }
}