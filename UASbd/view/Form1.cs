using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UASbd.controller;
using UASbd.model;

namespace UASbd
{
    public partial class Form1 : Form
    {
        Connection conection = new Connection();
        Pasien_m pasien = new Pasien_m();
        string id;

        public void tampil()
        {
            //QUERY DATABASE
            DataTable.DataSource = conection.ShowData("SELECT * FROM pasien");

            DataTable.Columns[0].HeaderText = "ID";
            DataTable.Columns[1].HeaderText = "Nama";
            DataTable.Columns[2].HeaderText = "Umur";
            DataTable.Columns[3].HeaderText = "Penyakit";
            DataTable.Columns[4].HeaderText = "GolonganDarah";
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //method show
            tampil();

            //List Golongan Darah
            GolonganDarah.Items.Add("A");
            GolonganDarah.Items.Add("B");
            GolonganDarah.Items.Add("AB");
            GolonganDarah.Items.Add("O");
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if(Nama.Text == "" || Umur.Text == "" || Penyakit.Text == "" || GolonganDarah.SelectedIndex == -1)
            {
                MessageBox.Show("Data cannot be empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Pasien ps = new Pasien();
                pasien.Nama = Nama.Text;
                pasien.Umur = Umur.Text;
                pasien.Penyakit = Penyakit.Text;
                pasien.Golongandarah = GolonganDarah.Text;

                ps.Insert(pasien);
                Nama.Text = "";
                Umur.Text = "";
                Penyakit.Text = "";
                GolonganDarah.SelectedIndex = -1;

                tampil();
            }
        }

        private void DataTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = DataTable.Rows[e.RowIndex].Cells[0].Value.ToString();
            Nama.Text = DataTable.Rows[e.RowIndex].Cells[1].Value.ToString();
            Umur.Text = DataTable.Rows[e.RowIndex].Cells[2].Value.ToString();
            Penyakit.Text = DataTable.Rows[e.RowIndex].Cells[3].Value.ToString();
            GolonganDarah.Text = DataTable.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (Nama.Text == "" || Umur.Text == "" || Penyakit.Text == "" || GolonganDarah.SelectedIndex == -1)
            {
                MessageBox.Show("Data cannot be empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Pasien ps = new Pasien();
                pasien.Nama = Nama.Text;
                pasien.Umur = Umur.Text;
                pasien.Penyakit = Penyakit.Text;
                pasien.Golongandarah = GolonganDarah.Text;

                ps.Update(pasien,id);
                Nama.Text = "";
                Umur.Text = "";
                Penyakit.Text = "";
                GolonganDarah.SelectedIndex = -1;

                tampil();
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            DialogResult pesan = MessageBox.Show("Are you sure you want to delete this data?","Warning",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(pesan == DialogResult.Yes)
            {
                Pasien ps = new Pasien();
                ps.Delete(id);
                tampil();
            }
        }

        private void Search_TextChanged(object sender, EventArgs e)
        {
            //QUERY SEARCH DATA
            DataTable.DataSource = conection.ShowData("SELECT * FROM pasien WHERE nama LIKE '%' '" + Search.Text + "' '%' OR penyakit LIKE '%' '" + Search.Text + "' '%'");
        }
    }
}
