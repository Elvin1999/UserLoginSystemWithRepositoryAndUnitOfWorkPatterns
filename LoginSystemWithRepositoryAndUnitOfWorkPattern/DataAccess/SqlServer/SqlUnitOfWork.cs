using LoginSystemWithRepositoryAndUnitOfWorkPattern.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginSystemWithRepositoryAndUnitOfWorkPattern.DataAccess.SqlServer
{
    public class SqlUnitOfWork : IUnitOfWork
    {
        public string ConnectionString;
        public Queue<SqlCommand> commands = new Queue<SqlCommand>();

        SqlContext context;
        public SqlUnitOfWork(string connString)
        {
            ConnectionString = connString;
            context = new SqlContext(this);
        }
        public void EnqueueCommand(SqlCommand cmd)
        {
            commands.Enqueue(cmd);
        }

        public void SaveChanges()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {

                    while (commands.Count > 0)
                    {
                        SqlCommand cmd = commands.Dequeue();
                        cmd.Transaction = transaction;
                        cmd.Connection = conn;

                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    commands = new Queue<SqlCommand>();
                }

            }
        }
        public IUserRepository UserRepository => new SqlUserRepository(context);
    }
}
