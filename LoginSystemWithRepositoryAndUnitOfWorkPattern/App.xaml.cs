using LoginSystemWithRepositoryAndUnitOfWorkPattern.DataAccess.SqlServer;
using LoginSystemWithRepositoryAndUnitOfWorkPattern.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LoginSystemWithRepositoryAndUnitOfWorkPattern
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IUnitOfWork DB;
        public App()
        {
            SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder()
            {
                IntegratedSecurity = true,
                DataSource = @"DOCUMENTS-ПК\MYSQLSERVERMSSQL",
                InitialCatalog = "LoginSystemDb"
            };

            DB = new SqlUnitOfWork(stringBuilder.ConnectionString);
        }
    }
}
