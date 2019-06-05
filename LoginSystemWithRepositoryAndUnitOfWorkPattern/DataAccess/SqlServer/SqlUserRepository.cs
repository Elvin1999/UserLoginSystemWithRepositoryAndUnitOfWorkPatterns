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
                string cmdText = $"Insert into Users output inserted.Id values(@Username, @Password, @HasAdminRule)";
                using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", data.UserName);
                    cmd.Parameters.AddWithValue("@Password", data.Password);
                    cmd.Parameters.AddWithValue("@HasAdminRule", data.HasAdminRule);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {
                        MessageBox.Show(e.Message.ToString(), "Error Message");
                    }
                }
            }
        }

        public void DeleteData(User data)
        {
            using (SqlConnection conn = new SqlConnection(db.ConnectionString))
            {
                conn.Open();
                string cmdText = $"delete from Users where Users.Id=@User_Id";
                using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                {
                    cmd.Parameters.AddWithValue("@User_Id", data.Id);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {
                        MessageBox.Show(e.Message.ToString(), "Error Message");
                    }
                }
            }
        }
        public int No { get; set; } = 0;
        public object Message { get; private set; }

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
                            user.UserName = Convert.ToString(reader[nameof(user.UserName)]);
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
            var users = GetAllData();
            var user = users.FirstOrDefault(x => x.Id == id);
            return user;
        }

        public void UpdateData(User data)
        {
            MessageBox.Show(data.Id.ToString());
            Helper helper = new Helper();
            data.Password = helper.GetHashOfString(data.Password);
            using (SqlConnection conn = new SqlConnection(db.ConnectionString))
            {
                conn.Open();
                string cmdText = $@"UPDATE Users
                SET Username = @Username, Password = @Password , HasAdminRule=@HasAdminRule
                Where Users.Id = @User_Id";
                using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                {
                    cmd.Parameters.AddWithValue("@User_Id", data.Id);
                    cmd.Parameters.AddWithValue("@Username", data.UserName);
                    cmd.Parameters.AddWithValue("@Password", data.Password);
                    cmd.Parameters.AddWithValue("@HasAdminRule", data.HasAdminRule);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {
                        MessageBox.Show(e.Message.ToString(), "Error Message");
                    }
                }
            }
        }
    }
}
