using Humanizer;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace library.Models
{
    public class ordermodel
    {
        public int user_id { get; set; }
        public int product_id { get; set;}
           
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;database=admin;User Id=sa;pwd=project");

        public int order_book(int user_id,int product_id)
        {
            SqlCommand cmd = new SqlCommand("insert into [dbo].[o_book](u_id,p_id) values('" + user_id + "','" + product_id + "')", con);
            con.Open();

            return cmd.ExecuteNonQuery();
        }

        public DataSet show_order(int user_id)
        {
            SqlCommand cmd = new SqlCommand("select book.* , o_book.* from o_book join book on book.id=o_book.p_id where o_book.u_id="+user_id, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

           da.Fill(ds);

            return ds;
        }
        public int delete_order(int id)
        {
            SqlCommand cmd = new SqlCommand("delete book.* , o_book.* from book join o_book on book.id=o_book.id where o_book.id=" + id, con);
            con.Open();

            return cmd.ExecuteNonQuery();
        }
    }
}
