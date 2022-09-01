using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using static ExampleBase.All_Class;

namespace ExampleBase
{
    /// <summary>
    /// Логика взаимодействия для Add_Client.xaml
    /// </summary>
    public partial class Add_Client : Window
    {
        public Add_Client()
        {
            InitializeComponent();
            conn = new SqlConnection(Svetlana_Base);
            conn.Open();
        }
        string Svetlana_Base = Connect.Svetlana_Base;
        SqlConnection conn;
        private void Button_Save(object sender, RoutedEventArgs e)
        {
            string name_contr = tbAddClient.Text;
            long phone = Convert.ToInt64(tbAddPhone.Text); ;
            long phone2 = Convert.ToInt64(tbAddPhone2.Text);
            string email = tbAddEmail.Text;
            string coment = rtbAddComent.ToString();
            string queryAddClient = $"insert into contragents (name_contr, phone, phone_2, email, coment) values (N'{name_contr}',{phone}, {phone2}, N'{email}', N'{coment}')";
            MessageBox.Show(queryAddClient);
            SqlCommand command = new SqlCommand(queryAddClient, conn);
            command.ExecuteNonQuery();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
