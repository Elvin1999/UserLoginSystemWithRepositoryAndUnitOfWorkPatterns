using LoginSystemWithRepositoryAndUnitOfWorkPattern.Domain.Abstractions;
using LoginSystemWithRepositoryAndUnitOfWorkPattern.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LoginSystemWithRepositoryAndUnitOfWorkPattern.DataAccess.SqlServer
{
    public class SqlUserRepository : IUserRepository
    {
        SqlContext db;
        public SqlUserRepository(SqlContext db)
        {
            this.db = db;
        }
        public void AddData(User data)
        {
           // throw new NotImplementedException();
        }

        public void DeleteData(User data)
        {
           // throw new NotImplementedException();
        }
        public int No { get; set; } = 0;
        public ObservableCollection<User> GetAllData()
        {

            ObservableCollection<User> users = new ObservableCollection<User>();
            using (SqlConnection conn = new SqlConnection(db.ConnectionString))
            {
                try
                {

                    conn.Open();
                    string cmdText = "select * from Users";
                    using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            User user = new User();


                            user.Id = Convert.ToInt32(reader[nameof(user.Id)]);
                            user.Username = Convert.ToString(reader[nameof(user.Username)]);
                            user.Password = Convert.ToString(reader[nameof(user.Password)]);
                            user.HasAdminPermission = Convert.ToBoolean(reader[nameof(user.HasAdminPermission)]);
                            user.No = ++No;
                            users.Add(user);
                        }


                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            return users;
        }

        public User GetData(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateData(User data)
        {
            //throw new NotImplementedException();
        }
    }
}
