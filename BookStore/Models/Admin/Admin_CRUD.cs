using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace BookStore.Models.Admin
{
    public class Admin_CRUD : IAdminRepository
    {
        private SqlConnection conn;
        private void Connection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            conn = new SqlConnection(connectionString);
        }
        public bool AddAdmin(Admin admin)       //http://localhost:63709/api/admin (httpput)
        {
            Connection();
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "insert into [admin] (admin_name,admin_email,admin_phone,admin_password) " +
                "values ('" + admin.Name + "','" + admin.Email + "'," + admin.Phone + ",'" + admin.Password + "')";
            int row = comm.ExecuteNonQuery();
            conn.Close();
            return row > 0;
        }

        public bool DeleteAdmin(int id)      //http://localhost:63709/api/admin/3 (httpdelete)
        {
            Connection();
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "delete from [admin] where admin_id=" + id;
            int row = comm.ExecuteNonQuery();
            conn.Close();
            return row > 0 ? true : false;
        }

        public Admin GetAdmin(int id)        //http://localhost:63709/api/admin/1 (httpget)
        {
            Connection();
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "select * from [admin] where admin_id=" + id;
            SqlDataReader dr = comm.ExecuteReader();
            Admin admin = new Admin();
            if (dr.Read())
            {
                admin.Id = dr.GetInt32(0);
                admin.Name = dr.GetString(1);
                admin.Email = dr.GetString(2);
                admin.Phone = dr.GetInt64(3);
                admin.Password = dr.GetString(4);
            }
            conn.Close();
            return admin;
        }

        public List<Admin> GetAllAdmins()        //http://localhost:63709/api/admin (httpget)
        {
            Connection();
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "select * from [admin]";
            SqlDataReader dr = comm.ExecuteReader();
            List<Admin> admins = new List<Admin>();
            while (dr.Read())
            {
                Admin admin = new Admin();
                admin.Id = dr.GetInt32(0);
                admin.Name = dr.GetString(1);
                admin.Email = dr.GetString(2);
                admin.Phone = dr.GetInt64(3);
                admin.Password = dr.GetString(4);
                admins.Add(admin);
            }
            conn.Close();
            return admins;
        }

        public bool UpdateAdmin(Admin admin)         //http://localhost:63709/api/admin (httppost)
        {
            Connection();
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "update [admin] set admin_name='" + admin.Name + "',admin_email='" + admin.Email + "'," +
                "admin_phone=" + admin.Phone + ",admin_password='" + admin.Password + "' where admin_id=" + admin.Id;
            int row = comm.ExecuteNonQuery();
            conn.Close();
            return row > 0;
        }
    }
}