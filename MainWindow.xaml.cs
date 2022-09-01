using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
using static ExampleBase.All_Class;

namespace ExampleBase
{
  
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            lblDateReminder.Content = "Напоминания на " + DateTime.Now.ToShortDateString();
            sbCurrentDate.Content = DateTime.Now.ToShortDateString();
            conn = new SqlConnection(Svetlana_Base);
            conn.Open();

            ShowReminder();

        }

        string Svetlana_Base = Connect.Svetlana_Base;
        SqlConnection conn;
        SqlCommand comm;
        DataTable table;
        SqlDataReader reader;

        

        private void ClearSearch(object sender, RoutedEventArgs e)
        {
            tbClientSearch.Text = "";
            tbContractSearch.Text = "";
            tbPhoneSearch.Text = "";
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           //if(tbClientSearch.Text !="")
           //{
                if (tbClientSearch != null)
                {
                    string query_client = $"select * from contragents where name_contr LIKE N'%{tbClientSearch.Text}%' ";
                    //SqlCommand comm = new SqlCommand(query_client,conn);
                    //reader = comm.ExecuteReader();
                    ShowItems(query_client);
                }
           //}
        }
        private void ShowItems(string query)
        {

            if (query == "")
            {
                MessageBox.Show("Не указана текст запроса!");
                return;
            }
            comm = new SqlCommand(query, conn);
            table = new DataTable();
            reader = comm.ExecuteReader();
            int line = 0;
            do
            {
                while (reader.Read())
                {
                    if (line == 0)
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            table.Columns.Add(reader.GetName(i));
                        }
                        line++;
                    }

                    DataRow row = table.NewRow();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        row[i] = reader[i];
                    }
                    table.Rows.Add(row);
                }
            } while (reader.NextResult());
            tbClientSearch.Text = tbClientSearch.Text.ToLower();
            dtGrid.ItemsSource = table.DefaultView;
            dtGrid.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = table });


            reader.Close();
        }
        private void reminder_Click(object sender, RoutedEventArgs e)
        {
            string reminder = tbReminder.Text.ToString();
            string time = cbTime.Text;
            string date = cbDate.ToString();

            string query_reminder = $"insert into reminder (text, time, date) values ('{reminder}', '{time}', '{date}')";
            MessageBox.Show(query_reminder);
            SqlCommand comm = new SqlCommand(query_reminder, conn);
            comm.ExecuteNonQuery();
        }
        private void AddClient(object sender, RoutedEventArgs e)
        {
            Add_Client addclient = new Add_Client();
            addclient.ShowDialog();
        }
        private void AddNotes(object sender, RoutedEventArgs e)
        {
            string notes = addNotes.Text;
            string AddNotes = $"insert into notes(note) values (N'{notes}')";
            MessageBox.Show("Успешно");
            SqlCommand comm = new SqlCommand(AddNotes, conn);
            comm.ExecuteNonQuery();
            addNotes.Text = ""; 
        }
        public void ShowReminder()
        {

        }

        private void Edit_Client(object sender, RoutedEventArgs e)
        {

        }
    }
}
