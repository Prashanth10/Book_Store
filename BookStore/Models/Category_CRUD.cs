using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace BookStore.Models
{
    public class Category_CRUD : ICategoryRepository
    {
        private SqlConnection conn;
        public void Connection()
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            conn = new SqlConnection(connectionstring);
        }
        public bool AddCategory(Category category)      //http://localhost:63709/api/category (httpput)
        {
            Connection();
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "insert into category (cat_name,cat_description,cat_image,cat_position) " +
                "values('"+category.Name+"','"+category.Description+ "','" + category.Image + "'," + category.Position+")";
            int row = comm.ExecuteNonQuery();
            conn.Close();
            return row > 0;
        }

        public bool DeleteCategory(int id)      //http://localhost:63709/api/category/1 (httpdelete)
        {
            Connection();
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "delete from category where cat_id="+id;
            int row = comm.ExecuteNonQuery();
            conn.Close();
            return row > 0;
        }

        public List<Category> GetAllCategory()      //http://localhost:63709/api/category (httpget)
        {
            Connection();
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "select * from category";
            SqlDataReader dr = comm.ExecuteReader();
            List<Category> categories = new List<Category>();
            while (dr.Read())
            {
                Category cat = new Category();
                cat.Id = dr.GetInt32(0);
                cat.Name = dr.GetString(1);
                cat.Description = dr.GetString(2);
                cat.Image = dr.GetString(3);
                cat.Status = dr.GetBoolean(4);
                cat.Position = dr.GetInt32(5);
                cat.CreatedAt = dr.GetDateTime(6);
                categories.Add(cat);
            }
            conn.Close();
            return categories;
        }

        public Category GetCategory(int id)     //http://localhost:63709/api/category/1 (httpget)
        {
            Connection();
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "select * from category where cat_id="+id;
            SqlDataReader dr = comm.ExecuteReader();
            Category cat = new Category();
            if (dr.Read())
            {
                cat.Id = dr.GetInt32(0);
                cat.Name = dr.GetString(1);
                cat.Description = dr.GetString(2);
                cat.Image = dr.GetString(3);
                cat.Status = dr.GetBoolean(4);
                cat.Position = dr.GetInt32(5);
                cat.CreatedAt = dr.GetDateTime(6);
            }
            conn.Close();
            return cat;
        }

        public bool UpdateCategory(Category category)       //http://localhost:63709/api/category/ (httppost)
        {
            Connection();
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            int status = Convert.ToInt32(category.Status);
            comm.CommandText = "update category set cat_name='"+category.Name+"', cat_description='"+category.Description+"', cat_image='"+category.Image+"'," +
                "cat_status="+ status + ", cat_position="+category.Position+" where cat_id=" + category.Id;
            int row = comm.ExecuteNonQuery();
            conn.Close();
            return row > 0;
        }
    }
}