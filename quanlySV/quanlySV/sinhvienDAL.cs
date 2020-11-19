using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlySV
{
    class sinhvienDAL
    {
        DataConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;
        public sinhvienDAL()
        {
            dc = new DataConnection();
        }
        public DataTable getAllSinhVien()
        {
            string sql = "select * from tblsinhvien";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public bool InsertSinhVien(tblsinhvien sv)
        {
            string sql = "insert into tblsinhvien(MaSV, TenSV, Diem, Lop, DiaChi) values(@MaSV, @TenSV, @Diem, @Lop, @DiaChi)";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaSV", SqlDbType.NVarChar).Value = sv.MaSV;
                cmd.Parameters.Add("@TenSV", SqlDbType.NVarChar).Value = sv.TenSV;
                cmd.Parameters.Add("@Diem", SqlDbType.Float).Value = sv.Diem;
                cmd.Parameters.Add("@Lop", SqlDbType.NVarChar).Value = sv.Lop;
                cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = sv.DiaChi;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public bool UpdateSinhVien(tblsinhvien sv)
        {
            string sql = "update tblsinhvien set MaSV=@MaSV,TenSV=@TenSv, Lop=@Lop, Diem=@Diem, DiaChi=@DiaChi  where id=@id";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = sv.id;
                cmd.Parameters.Add("@MaSV", SqlDbType.NVarChar).Value = sv.MaSV;
                cmd.Parameters.Add("@TenSV", SqlDbType.NVarChar).Value = sv.TenSV;
                cmd.Parameters.Add("@Diem", SqlDbType.Float).Value = sv.Diem;
                cmd.Parameters.Add("@Lop", SqlDbType.NVarChar).Value = sv.Lop;
                cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = sv.DiaChi;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public bool DeleteSinhVien(tblsinhvien sv)
        {
            string sql = "delete tblsinhvien where id=@id";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = sv.id;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public DataTable FindSinhVien(string st)
        {
            string sql = "select * from tblsinhvien where TenSV like '%" + st + "%' or Lop like '%" + st + "%' ";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;

        }
    } 
}
