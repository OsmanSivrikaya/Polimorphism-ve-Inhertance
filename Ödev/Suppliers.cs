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
            Connection con = new Connection();
            DataTable tablo = new DataTable();
            TelefonSatis ts = new TelefonSatis();
            con.con.Open();
            con.komut = new SqlCommand("spYeniKayıt", con.con);
            con.komut.CommandType = CommandType.StoredProcedure;
            con.komut.Parameters.AddWithValue("@OrderDate", DateTime.Now.ToString());
            con.komut.ExecuteNonQuery();
            con.con.Close();
        }
        
    }
    public class TelefonSatis : Suppliers
    {
        public double UnitPrice { get; set; }
        public string ProductName { get; set; }
        public int CategoryID { get; set; }
        public override void YeniKayitEkle()
        {
            Connection con = new Connection();
            DataTable tablo = new DataTable();
            con.con.Open();
            con.komut = new SqlCommand("psYeniKullaniciEkle", con.con);
            con.komut.CommandType = CommandType.StoredProcedure;
            con.komut.Parameters.AddWithValue("@ProductName", ProductName);
            con.komut.Parameters.AddWithValue("@SupplierID", SupplersID);
            con.komut.Parameters.AddWithValue("@CategoryID", CategoryID);
            con.komut.Parameters.AddWithValue("@UnitsInStock", UnitsInStock);
            con.komut.Parameters.AddWithValue("@UnitPrice", UnitPrice);
            con.komut.ExecuteNonQuery();
            con.con.Close();
        }
       
    }
}
