using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Ödev
{
    public partial class Form1 : Form
    {
        Connection con = new Connection();
        DataTable tablo = new DataTable();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            KayitGoster();
            dataGridView2.DataSource = KayitGoster2();
        }
        public void KayitGoster()
        {
            tablo.Clear();
            con.adtr = new SqlDataAdapter("spGoster", con.con);
            con.adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
        }
        DataTable KayitGoster2()
        {
            con.con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from Orders order by OrderID desc", con.con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.con.Close();
            return dt;
        }

        TelefonSatis ts = new TelefonSatis();
        private void button1_Click(object sender, EventArgs e)
        {
            
            ts.ProductName = textBox1.Text;
            ts.SupplersID = Convert.ToInt32(textBox2.Text);
            ts.CategoryID = Convert.ToInt32(textBox3.Text);
            ts.UnitsInStock = Convert.ToInt32(textBox4.Text);
            ts.UnitPrice = Convert.ToDouble(textBox5.Text);
            Suppliers s = new Suppliers();
            s.YeniKayitEkle();
            ts.YeniKayitEkle();
            Form1_Load(this, null);
            //KayitGoster();
        }

       
    }
}
