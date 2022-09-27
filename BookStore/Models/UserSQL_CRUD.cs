﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace BookStore.Models
{
    public class UserSQL_CRUD : IUserRepository
    {
        private SqlConnection conn;
        private void Connection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            conn = new SqlConnection(connectionString);
        }
        public bool AddUser(User user)
        {
            Connection();
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "insert into User (user_name,user_email,user_dob,user_gender,user_phone,user_password) " +
                "values ('" + user.Name + "','" + user.Email + "','" + user.DOB + "'," + user.Phone + ",'" + user.Password + "')";
            int row = comm.ExecuteNonQuery();
            conn.Close();
            return row > 0;
        }

        public bool DeleteUser(int id)
        {
            Connection();
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "delete from user where user_id=" + id;
            int row = comm.ExecuteNonQuery();
            conn.Close();
            return row > 0 ? true : false;
        }

        public List<User> GetAllUsers()
        {
            Connection();
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "select * from user";
            SqlDataReader dr = comm.ExecuteReader();
            List<User> users = new List<User>();
            while (dr.Read())
            {
                User user = new User();
                user.Id = dr.GetInt32(0);
                user.Name = dr.GetString(1);
                user.Email = dr.GetString(2);
                user.DOB = dr.GetDateTime(3);
                user.Gender = dr.GetString(4);
                user.Phone = dr.GetInt32(5);
                user.Password = dr.GetString(6);
                user.Active = dr.GetInt32(7);
                users.Add(user);
            }
            conn.Close();
            return users;
        }

        public User GetUser(int id)
        {
            Connection();
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "select * from user where id=" + id;
            SqlDataReader dr = comm.ExecuteReader();
            User user = new User();
            if (dr.Read())
            {
                user.Id = dr.GetInt32(0);
                user.Name = dr.GetString(1);
                user.Email = dr.GetString(2);
                user.DOB = dr.GetDateTime(3);
                user.Gender = dr.GetString(4);
                user.Phone = dr.GetInt32(5);
                user.Password = dr.GetString(6);
                user.Active = dr.GetInt32(7);
            }
            conn.Close();
            return user;
        }

        public bool UpdateUser(User user)
        {
            Connection();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "update [user] set user_name='" + user.Name + "',user_email='" + user.Email + "',user_dob='" + user.DOB + "'," +
                "user_gender='" + user.Gender + "',user_phone=" + user.Phone + ",user_password='" + user.Password + "' where user_id=" + user.Id;
            int row = comm.ExecuteNonQuery();
            return row > 0;
        }
    }
}