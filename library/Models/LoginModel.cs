using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace library.Models
{
    public class LoginModel
    {
        public string book_image { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string student_name { get; set; }
        public string book_name { get; set; }
        public string author_name { get; set; }
        public string isbn { get; set; }
        public string description { get; set; }
        public string date { get; set; }
        public string age { get; set; }
        public string contact_number { get; set; }
        public string deposite { get; set; }
        public string price { get; set; }

        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;database=admin;User Id=sa;pwd=project");


        public DataSet login(string email, string password)
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].[admin_login] where email='" + email + "' and password='" + password + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            return ds;
        }

        public int Add_book(string book_name, string author_name, string isbn,string description, string book_image,string price)
        {
            SqlCommand cmd = new SqlCommand("insert into [dbo].[book](book_name,author_name,isbn,description,photo,price) values('" + book_name + "','" + author_name + "','" + isbn + "','"+description+"','" + book_image + "','"+price+"')", con);
            con.Open();

            return cmd.ExecuteNonQuery();
        }
        public DataSet view_book()
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].[book]", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            da.Fill(ds);

            return ds;

        }
        public int delete_book(int id)
        {
            SqlCommand cmd = new SqlCommand("delete from [dbo].[book] Where id =" + id, con);
            con.Open();

            return cmd.ExecuteNonQuery();
        }
        public DataSet select_updatebook(int id)
        {

            SqlCommand cmd = new SqlCommand("select * from [dbo].[book] where id='" + id + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public int update_book(string book_name, string author_name, string isbn, string description, string photo,string price, int id)
        {
            SqlCommand cmd = new SqlCommand("update [dbo].[book] set book_name='" + book_name + "',author_name='" + author_name + "',isbn='" + isbn + "',description='" + description + "',photo='" + photo + "',price='"+price+"' where id='" + id + "'", con);
            con.Open();
            return cmd.ExecuteNonQuery();
        }

        public int issue_book(string student_name, string book_name, string author_name, string date)
        {
            SqlCommand cmd = new SqlCommand("insert into [dbo].[issue_book](student_name,book_name,author_name,date) values('"+student_name+"','" + book_name + "','" + author_name + "','" + date + "')", con);
            con.Open();

            return cmd.ExecuteNonQuery();
        }
        public DataSet select_updateissue(int id)
        {

            SqlCommand cmd = new SqlCommand("select * from [dbo].[issue_book] where id='" + id + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public int update_issue_book(string student_name, string book_name, string author_name, string date, int id)
        {
            SqlCommand cmd = new SqlCommand("update [dbo].[issue_book] set studdent_name='" + student_name + "',book_name='" + book_name + "',author_name='" + author_name + "',date='" + date + "'  where id='" + id + "'", con);
            con.Open();
            return cmd.ExecuteNonQuery();
        }
        public DataSet view_issue_book()
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].[issue_book] ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public int delete_issue_book(int id)
        {
            SqlCommand cmd = new SqlCommand("delete from [dbo].[issue_book] Where id =" + id, con);
            con.Open();

            return cmd.ExecuteNonQuery();
        }
        public int update_member(string name, string email, string age, string contact_number, string deposite)
        {
            SqlCommand cmd = new SqlCommand("insert into [dbo].[member](name,email,age,contact_number,deposite) values('" + name + "','" + email + "','" + age + "','" + contact_number + "','" + deposite + "')", con);
            con.Open();

            return cmd.ExecuteNonQuery();
        }
        public DataSet view_member()
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].[member] ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet select_updatemember(int id)
        {

            SqlCommand cmd = new SqlCommand("select * from [dbo].[member] where id='" + id + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public int update_member(string name, string email, string age, string contact_number, string deposite, int id)
        {
            SqlCommand cmd = new SqlCommand("update [dbo].[member] set name='" + name + "',email='" + email + "',age='" + age + "',contact_number='" + contact_number + "',deposite='" + deposite + "'  where id='" + id + "'", con);
            con.Open();
            return cmd.ExecuteNonQuery();
        }
        public int delete_member(int id)
        {
            SqlCommand cmd = new SqlCommand("delete from [dbo].[member] Where id =" + id, con);
            con.Open();

            return cmd.ExecuteNonQuery();
        }

    }

}
