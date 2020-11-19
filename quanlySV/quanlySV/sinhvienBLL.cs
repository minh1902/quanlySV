using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlySV
{
    class sinhvienBLL
    {
        sinhvienDAL dalSV;
        public sinhvienBLL()
        {
            dalSV = new sinhvienDAL();
        }
        public DataTable getAllSinhVien()
        {
            return dalSV.getAllSinhVien();
        }
        public bool InsertSinhVien(tblsinhvien sv)
        {
            return dalSV.InsertSinhVien(sv);
        }
        public bool UpdateSinhVien(tblsinhvien sv)
        {
            return dalSV.UpdateSinhVien(sv);
        }
        public bool DeleteSinhVien(tblsinhvien sv)
        {
            return dalSV.DeleteSinhVien(sv);
        }
        public DataTable FindSinhVien(string st)
        {
            return dalSV.FindSinhVien(st);
        }
    }
}
