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
            using (SqlConnection conn = new SqlConnection(db.ConnectionString))
            {
                conn.Open();
                string cmdText = $"Insert into Products output inserted.Id values(@Name, @Barcode, @Price)";
                using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", data.Username);
                    cmd.Parameters.AddWithValue("@Surname", data.Password);
                    cmd.Parameters.AddWithValue("@Age", data.HasAdminRule);
                    //cmd.ExecuteNonQuery();
                    //return (int)cmd.ExecuteScalar();
                }
            }
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
                            user.HasAdminRule = Convert.ToBoolean(reader[nameof(user.HasAdminRule)]);
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
