using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Data;

namespace Ödev
{

    public class Suppliers
    {
        public int UnitsInStock { get; set; }
        public int SupplersID { get; set; }
        public virtual void YeniKayitEkle()
        {
            SqlConnection con = new SqlConnection("Data Source = OSMANSIVRIKAYA; Initial Catalog = Northwind; Integrated Security = True");
            //con.ConnectionString = connection;
            SqlDataAdapter adtr;
            SqlCommand komut;
            DataTable tablo = new DataTable();
            TelefonSatis ts = new TelefonSatis();
            con.Open();
            komut = new SqlCommand("spYeniKayıt", con);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@OrderDate", DateTime.Now.ToString());
            komut.ExecuteNonQuery();
            con.Close();
        }
        
    }
    public class TelefonSatis : Suppliers
    {
        public double UnitPrice { get; set; }
        public string ProductName { get; set; }
        public int CategoryID { get; set; }
        public override void YeniKayitEkle()
        {
            SqlConnection con = new SqlConnection("Data Source=OSMANSIVRIKAYA;Initial Catalog=Northwind;Integrated Security=True");
            SqlDataAdapter adtr;
            SqlCommand komut;
            DataTable tablo = new DataTable();
            con.Open();
            komut = new SqlCommand("psYeniKullaniciEkle", con);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@ProductName", ProductName);
            komut.Parameters.AddWithValue("@SupplierID", SupplersID);
            komut.Parameters.AddWithValue("@CategoryID", CategoryID);
            komut.Parameters.AddWithValue("@UnitsInStock", UnitsInStock);
            komut.Parameters.AddWithValue("@UnitPrice", UnitPrice);
            komut.ExecuteNonQuery();
            con.Close();
        }
       
    }
}
