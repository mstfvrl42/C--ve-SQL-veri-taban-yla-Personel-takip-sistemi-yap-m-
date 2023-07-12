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
namespace Personel_Takib_Sistemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void temizle()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "";
            maskedTextBox1.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            textBox1.Focus();


        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-AMB14G6\SQLEXPRESS;Initial Catalog=personel_takib_sistemi;Integrated Security=True");
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'personel_takib_sistemiDataSet1.tbl_personel' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.tbl_personelTableAdapter.Fill(this.personel_takib_sistemiDataSet1.tbl_personel);
            label8.Visible = false;
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'personel_takib_sistemiDataSet1.tbl_personel' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.tbl_personelTableAdapter.Fill(this.personel_takib_sistemiDataSet1.tbl_personel);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into tbl_personel (perad,persoyad,persehir,permaas,permeslek) values (@p1,@p2,@p3,@p4,@p5)",baglanti);
            komut.Parameters.AddWithValue("@p1",textBox2.Text);
            komut.Parameters.AddWithValue("@p2",textBox3.Text);
            komut.Parameters.AddWithValue("@p3",comboBox1.Text);
            komut.Parameters.AddWithValue("@p4",maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@p5",textBox4.Text);
            komut.ExecuteNonQuery(); 
            baglanti.Close();
            MessageBox.Show("Pesonel eklendi.");
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secim = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[secim].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secim].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[secim].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[secim].Cells[6].Value.ToString();
            comboBox1.Text= dataGridView1.Rows[secim].Cells[3].Value.ToString();
            maskedTextBox1.Text = dataGridView1.Rows[secim].Cells[4].Value.ToString();
            label8.Text= dataGridView1.Rows[secim].Cells[5].Value.ToString();
        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            if (label8.Text=="True")
            {
                radioButton1.Checked = true;

            }
            if (label8.Text == "False")
            {
                radioButton2.Checked = true;

            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked==true)
            {
                label8.Text = "True";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton2.Checked==true)
            {
                label8.Text = "False";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand sil = new SqlCommand("Delete From tbl_personel Where perid=@p1",baglanti);
            sil.Parameters.AddWithValue("@p1",textBox1.Text);
            sil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Veri silindi");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand guncelle = new SqlCommand("update tbl_personel Set perad=@p1,persoyad=@p2,persehir=@p3,permaas=@p4,perdurum=@p5,permeslek=@p6 where perid=@p7",baglanti);
            guncelle.Parameters.AddWithValue("@p1",textBox2.Text);
            guncelle.Parameters.AddWithValue("@p2",textBox3.Text);
            guncelle.Parameters.AddWithValue("@p3",comboBox1.Text);
            guncelle.Parameters.AddWithValue("@p4",maskedTextBox1.Text);
            guncelle.Parameters.AddWithValue("@p5",label8.Text);
            guncelle.Parameters.AddWithValue("@p6",textBox4.Text);
            guncelle.Parameters.AddWithValue("@p7",textBox1.Text);
            guncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Veri Güncellendi");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}
