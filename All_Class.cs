using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ExampleBase
{
    internal class All_Class
    {
        public class Connect
        {
            public static string Svetlana_Base = ConfigurationManager.ConnectionStrings["Svetlana_base"].ConnectionString;
        }
        public class Countragents
        {
            public int id { get; set; }
            public string name_contr { get; set; }
            public long phone { get; set; }
            public long phone_2 { get; set; }
            public string email { get; set; }
            public string coment { get; set; }



            public override string ToString()
            {
                return $" {name_contr} ({phone}) ({phone_2}) {email} {coment} ";

            }
        }
        public class Items
        {
            public int id { get; set; }
            public string name_item { get; set; }
            public int size { get; set; }
            public double price { get; set; }

            public override string ToString()
            {
                return $" {name_item} ({size}) ({price}) ";

            }

        }
        public class Deals
        {
            public int id { get; set; }
            public int id_contr { get; set; }
            public int id_item { get; set; }
            public string account_number { get; set; }
            public int count { get; set; }
            public double sum { get; set; }
            public int day { get; set; }
            public int month { get; set; }
            public int year { get; set; }
            public string status { get; set; }

            public override string ToString()
            {
                return $" ({id_contr}) ({id_item}) {account_number} ({sum}) ({day}) ({month}) ({year}) {status} ";

            }
        }
        public class Reminder
        {
          public int id { get; set; }
          public string text { get; set; }
          public string time { get; set; }
          public int date { get; set; }

            public override string ToString()
            {
                return $" ( {text}  ({time}) ({date}) ) ";

            }

        }
    }
}
