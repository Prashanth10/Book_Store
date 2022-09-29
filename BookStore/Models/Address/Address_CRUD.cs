using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace BookStore.Models.Address
{
    public class Address_CRUD : IAddressRepository
    {
        private SqlConnection conn;
        private void Connection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            conn = new SqlConnection(connectionString);
        }
        
        public bool AddAddress(Address address)       //http://localhost:63709/api/address (httpput)
        {
            Connection();
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "insert into [address] (user_id, adrs) " +
                "values (" + address.UserId + ",'" + address.Adrs + "')";
            int row = comm.ExecuteNonQuery();
            conn.Close();
            return row > 0;
        }

        public bool DeleteAddress(int id)      //http://localhost:63709/api/address/3 (httpdelete)
        {
            Connection();
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "delete from [address] where address_id=" + id;
            int row = comm.ExecuteNonQuery();
            conn.Close();
            return row > 0 ? true : false;
        }

        public Address GetAddress(int id)        //http://localhost:63709/api/address/1 (httpget)
        {
            Connection();
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "select * from [address] where address_id=" + id;
            SqlDataReader dr = comm.ExecuteReader();
            Address address = new Address();
            if (dr.Read())
            {
                address.Id = dr.GetInt32(0);
                address.UserId = dr.GetInt32(1);
                address.Adrs = dr.GetString(2);
            }
            conn.Close();
            return address;
        }

        public List<Address> GetAllAddresss()        //http://localhost:63709/api/address (httpget)
        {
            Connection();
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "select * from [address]";
            SqlDataReader dr = comm.ExecuteReader();
            List<Address> addresss = new List<Address>();
            while (dr.Read())
            {
                Address address = new Address();
                address.Id = dr.GetInt32(0);
                address.UserId = dr.GetInt32(1);
                address.Adrs = dr.GetString(2);
                addresss.Add(address);
            }
            conn.Close();
            return addresss;
        }

        public List<Address> GetAllAddresss_ByUserId(int userId)        //http://localhost:63709/api/address?userId=1 (httpget)
        {
            Connection();
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "select * from [address] where user_id="+userId;
            SqlDataReader dr = comm.ExecuteReader();
            List<Address> addresss = new List<Address>();
            while (dr.Read())
            {
                Address address = new Address();
                address.Id = dr.GetInt32(0);
                address.UserId = dr.GetInt32(1);
                address.Adrs = dr.GetString(2);
                addresss.Add(address);
            }
            conn.Close();
            return addresss;
        }

        public bool UpdateAddress(Address address)         //http://localhost:63709/api/address (httppost)
        {
            Connection();
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "update [address] set adrs='" + address.Adrs + "' where address_id=" + address.Id;
            int row = comm.ExecuteNonQuery();
            conn.Close();
            return row > 0;
        }

    }
}