using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlySV
{
    public partial class Form1 : Form
    {
        sinhvienBLL bllSV;
        public Form1()
        {
            InitializeComponent();
            bllSV = new sinhvienBLL();
        }
        public void ShowAllSinhVien()
        {
            DataTable dt = bllSV.getAllSinhVien();
            dataGridView1.DataSource = dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowAllSinhVien();
        }
        public bool CheckData()
        {
            if (string.IsNullOrEmpty(txtMaSV.Text)){
                MessageBox.Show("ban chua nhap ma sinh vien.", "thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaSV.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtTenSV.Text)){
                MessageBox.Show("ban chua nhap ten sinh vien.", "thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenSV.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtLop.Text))
            {
                MessageBox.Show("ban chua nhap lop sinh vien.", "thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLop.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtDiem.Text))
            {
                MessageBox.Show("ban chua nhap diem sinh vien.", "thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiem.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtDiaChi.Text))
            {
                MessageBox.Show("ban chua nhap dia chi sinh vien.", "thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiaChi.Focus();
                return false;
            }
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                tblsinhvien sv = new tblsinhvien();
                sv.MaSV = txtMaSV.Text;
                sv.TenSV = txtTenSV.Text;
                sv.Diem = Double.Parse(txtDiem.Text);
                sv.Lop = txtLop.Text;
                sv.DiaChi = txtDiaChi.Text;
               
          
                if (bllSV.InsertSinhVien(sv))
                {
                    ShowAllSinhVien();
                }
                else MessageBox.Show("Error", "thong bao", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        int ID;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                ID = Int32.Parse(dataGridView1.Rows[index].Cells["id"].Value.ToString());
                txtMaSV.Text = dataGridView1.Rows[index].Cells["MaSV"].Value.ToString();
                txtTenSV.Text = dataGridView1.Rows[index].Cells["TenSV"].Value.ToString();
                txtDiem.Text = dataGridView1.Rows[index].Cells["Diem"].Value.ToString();
                txtLop.Text = dataGridView1.Rows[index].Cells["Lop"].Value.ToString();
                txtDiaChi.Text = dataGridView1.Rows[index].Cells["DiaChi"].Value.ToString();

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                tblsinhvien sv = new tblsinhvien();
                sv.id = ID;
                sv.MaSV = txtMaSV.Text;
                sv.TenSV = txtTenSV.Text;
                sv.Diem = Double.Parse(txtDiem.Text);
                sv.Lop = txtLop.Text;
                sv.DiaChi = txtDiaChi.Text;


                if (bllSV.UpdateSinhVien(sv))
                {
                    ShowAllSinhVien();
                }
                else MessageBox.Show("Error", "thong bao", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("ban co muon xoa hay khong?","canh bao", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                tblsinhvien sv = new tblsinhvien();
                sv.id = ID;
                if (bllSV.DeleteSinhVien(sv))
                {
                    ShowAllSinhVien();
                }
                else MessageBox.Show("Error", "thong bao", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            string value = txtTimKiem.Text;
            if (!string.IsNullOrEmpty(value))
            {
                DataTable dt = bllSV.FindSinhVien(value);
                dataGridView1.DataSource = dt;
            }
            else ShowAllSinhVien();
        }
    }
}
