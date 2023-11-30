using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UASbd.model;

namespace UASbd.controller
{
    internal class Pasien
    {
        
        Connection conection = new Connection();

        public bool Insert(Pasien_m pasien)
        {
            Boolean status = false;
            try
            {
                conection.OpenConnection();
                conection.ExecuteQuery("INSERT INTO pasien (nama, umur, penyakit, golongandarah) VALUES ('" + pasien.Nama + "', '" + pasien.Umur + "','" + pasien.Penyakit + "', '" + pasien.Golongandarah + "')");
                status= true;
                MessageBox.Show("Data added succesfully","Information",MessageBoxButtons.OK, MessageBoxIcon.Information);
                conection.CloseConnection();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return status;
        }

        public bool Update(Pasien_m pasien, string id)
        {
            Boolean status = false;
            try
            {
                conection.OpenConnection();
                conection.ExecuteQuery("UPDATE pasien SET nama='" + pasien.Nama + "', " + "umur='" + pasien.Umur + "', " + "penyakit='" + pasien.Penyakit + "', " + "golongandarah='" + pasien.Golongandarah + "' WHERE id='" + id + "'");
                status = true;
                MessageBox.Show("Data updated succesfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conection.CloseConnection();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return status;
        }

        public bool Delete(string id)
        {
            Boolean status = false;
            try
            {
                conection.OpenConnection();
                conection.ExecuteQuery("DELETE FROM pasien WHERE id='" + id + "'");
                status = true;
                MessageBox.Show("Data deleted succesfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conection.CloseConnection();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return status;
        }
    }
}
