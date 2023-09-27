using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplikasiInputMahasiswa2
{
    public partial class Form1 : Form
    {
        private List<Mahasiswa> list = new List<Mahasiswa>();
        public Form1()
        {
            InitializeComponent();
            InisialisasiListView();
        }
        private void InisialisasiListView()
        {
            lvwMahasiswa.View = View.Details;
            lvwMahasiswa.FullRowSelect = true;
            lvwMahasiswa.GridLines = true;

            lvwMahasiswa.Columns.Add("No", 30, HorizontalAlignment.Center);
            lvwMahasiswa.Columns.Add("Nim", 91, HorizontalAlignment.Center);
            lvwMahasiswa.Columns.Add("Nama", 200, HorizontalAlignment.Left);
            lvwMahasiswa.Columns.Add("Kelas", 70, HorizontalAlignment.Center);
            lvwMahasiswa.Columns.Add("Nilai", 50, HorizontalAlignment.Center);
            lvwMahasiswa.Columns.Add("Nilai Huruf", 80, HorizontalAlignment.Center);
        }
        private void ResetForm()
        {
            txtNim.Clear();
            txtNama.Clear();
            txtKelas.Clear();
            txtNilai.Text = "0";
            txtNim.Focus();
        }
        private bool NumericOnly(KeyPressEventArgs e)
        {
            var strValid = "0123456789";

            if (!(e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                if (strValid.IndexOf(e.KeyChar) < 0)
                {
                    return true;
                }
                return false;
            }
            else
                return false;
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (lvwMahasiswa.SelectedItems.Count > 0)
            {
                var konfimasi = MessageBox.Show("Apakah Data Mahasiswa ingin dihapus", "konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (konfimasi == DialogResult.Yes)
                {
                    var index = lvwMahasiswa.SelectedIndices[0];
                    list.RemoveAt(index);
                    TampilkanData();
                }
            }
            else
            {
                MessageBox.Show("Data Mahasiswa belum dipilih !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtNilai_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = NumericOnly(e);
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {

            Mahasiswa mhs = new Mahasiswa();

            mhs.Nim = txtNim.Text;
            mhs.Nama = txtNama.Text;
            mhs.Kelas = txtKelas.Text;
            mhs.Nilai = int.Parse(txtNilai.Text);

            if (mhs.Nilai <= 20)
            {
                mhs.Huruf = "E";
            } else if (mhs.Nilai <= 40)
            {
                mhs.Huruf = "D";
            }
            else if (mhs.Nilai <= 60)
            {
                mhs.Huruf = "C";
            }
            else if (mhs.Nilai <= 80)
            {
                mhs.Huruf = "B";
            }
            else if (mhs.Nilai <= 100)
            {
                mhs.Huruf = "A";
            }
            else if (mhs.Nilai > 100)
            {
                mhs.Huruf = "-";
            }

            list.Add(mhs);

            var msg = "Data Mahasiswa berhasil disimpan";

            MessageBox.Show(msg, "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ResetForm();
        }
        private void TampilkanData()
        {
            lvwMahasiswa.Items.Clear();

            foreach (var mhs in list)
            {
                var noUrut = lvwMahasiswa.Items.Count + 1;

                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(mhs.Nim);
                item.SubItems.Add(mhs.Nama);
                item.SubItems.Add(mhs.Kelas);
                item.SubItems.Add(mhs.Nilai.ToString());
                item.SubItems.Add(mhs.Huruf);

                lvwMahasiswa.Items.Add(item);



            }
        }
        private void btnTampilkan_Click(object sender, EventArgs e)
        {
            TampilkanData();
        }

        private void btnTampilkan_Click_1(object sender, EventArgs e)
        {
            TampilkanData();
        }
    }
}
