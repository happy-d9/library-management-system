using System.Data.SqlClient;
using System.Data;

namespace library.Models
{
    public class UserModel
    {
        public string username { get; set; }
        public string password { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public IFormFile image { get; set; }
        public string barcode { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string phone_number { get; set; }
        public string email { get; set; }
        public string subject { get; set; }
        public string message { get; set; }
        public string id { get; set; }
        public string book_name { get; set; }
        public string author_name { get; set; }
        public string isbn { get; set; }
        public string price { get; set; }

        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;database=admin;User Id=sa;pwd=project");
		
		public DataSet login(string barcode, string password)
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].[user_login] where barcode='" + barcode + "' and password='" + password + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            return ds;
        }


        public int  register(string barcode,string password)
        {
            SqlCommand cmd = new SqlCommand("insert into [dbo].[user_login](barcode,password)values('" + barcode + "','" + password + "')", con);

            con.Open();
            return cmd.ExecuteNonQuery();

        }


        public int contact(string first_name, string last_name, string email, string phone_number, string message)
        {
            SqlCommand cmd = new SqlCommand("insert into [dbo].[contact](first_name,last_name,email,phone_number,message) values('" + first_name + "','" + last_name + "','" + email + "','" + phone_number + "','" + message + "')", con);
            con.Open();

            return cmd.ExecuteNonQuery();
        }
        public int cart(int id,string photo,string book_name, string author_name, string isbn, string price)
        {
            SqlCommand cmd = new SqlCommand("insert into [dbo].[cart](id,photo,book_name,author_name,isbn,price) values('" + id + "','"+photo+"','" + book_name + "','" + author_name + "','" + isbn + "','" + price + "')", con);
            con.Open();

            return cmd.ExecuteNonQuery();
        }

    }
}
