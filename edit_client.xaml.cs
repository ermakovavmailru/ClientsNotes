using System;
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
using System.Windows.Shapes;
using static ExampleBase.All_Class;

namespace ExampleBase
{
    /// <summary>
    /// Логика взаимодействия для edit_client.xaml
    /// </summary>
    public partial class edit_client : Window
    {
        public edit_client()
        {
            InitializeComponent();
            conn = new SqlConnection(Svetlana_Base);
            conn.Open();
            NameContrComboBox();
           
        }
        string Svetlana_Base = Connect.Svetlana_Base;
        SqlConnection conn;
        SqlCommand comm;
        SqlDataReader reader;
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void cbAddClient_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            //NameContrComboBox();

        }

        void NameContrComboBox()
        {
            comm = new SqlCommand(All_Query.query_name_contr, conn);
            reader = comm.ExecuteReader();
            while (reader.Read())
            {
                Countragents countragents = new Countragents
                {
                    name_contr = reader["name_contr"].ToString()
                };

                cbAddClient.Items.Add(countragents);
                /*
                string name_contr = tbAddClient.Text;
                long phone = Convert.ToInt64(tbAddPhone.Text); // !!!!!!!
                long phone_2 = Convert.ToInt64(tbAddPhone2.Text); // !!!!!!!
                string email = tbAddEmail.Text;
                string coment = tbAddComent.Text;
                string edit_client = $"update contragents set name_contr='{name_contr}', phone={phone}, phone_2={phone_2}, " +
                    $" email='{email}', coment='{coment}' where name_contr='{countragents.name_contr}' ";
                MessageBox.Show(edit_client);
                SqlCommand command = new SqlCommand(edit_client, conn);
                command.ExecuteNonQuery();
                */
               
            } 
            reader.Close();
            
        }
    }
}
