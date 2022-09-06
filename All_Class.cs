using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ExampleBase
{
    public partial class All_Class
    {
        public class Connect
        {
            public static string Svetlana_Base = ConfigurationManager.ConnectionStrings["Svetlana_base"].ConnectionString;
        }
        public  class Countragents
        {
            public  int id { get; set; }
            public  string name_contr { get; set; }
            public  string phone { get; set; }
            public  string phone_2 { get; set; }
            public  string email { get; set; }
            public  string coment { get; set; }
            public int id_notes { get; set; }

            public override string ToString()
            {
                return $" {name_contr}  ";

            }
        }
        public class Deals
        {
            public int id { get; set; }
            public int id_contr { get; set; }
            public string name_item { get; set; }
            public double price { get; set; }
            public string account_number { get; set; }
            public int count { get; set; }      
            public string date { get; set; }
            public string status { get; set; }

            public override string ToString()
            {
                return $" ({id_contr}) {name_item} ({price}) {account_number} ({count}) {date} {status}  ";

            }
        }
        public static class Reminder
        {
          public static int id { get; set; }
          public static string text { get; set; }
          public static string time { get; set; }
          public static string date { get; set; }

            public  static string ToString()
            {
                return $" ( {text}  {time} {date} ) ";

            }

        }
    }
}
