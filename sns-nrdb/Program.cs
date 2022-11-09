

using Microsoft.Extensions.Configuration;
using sns_nrdb.ConsoleApp;
using System;
using System.Runtime.Remoting.Contexts;

namespace sns_nrdb
{
    public class Program
    {
        static string ConnectionString
        {
            get
            {
                return new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("SNS");
            }
        }
        static void Main(string[] args)
        {
            var dbConnect = new DbConnection(ConnectionString);
            var login = new Login(dbConnect);
            var menu = new Menu(login, dbConnect);

            menu.ShowMenu();
        }
    }
}
