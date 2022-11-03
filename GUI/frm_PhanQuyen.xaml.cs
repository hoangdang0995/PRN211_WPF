using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;

namespace GUI
{
    /// <summary>
    /// Interaction logic for frm_PhanQuyen.xaml
    /// </summary>
    public partial class frm_PhanQuyen : Window
    {
        string id;
        string[] mabang = {"BANGDIEM","SINHVIEN","GIANGVIEN","KHOA","KHOAHOC","MONHOC","LOPHOC","HOCKY","NGUOIDUNG","LOAINGUOIDUNG","LOAIGIANGVIEN","HOCVIHOCHAM","CHUYENNGANH","TONGIAO","DANTOC","KETQUA" };
        string[] tenbang = { "BẢNG ĐIỂM", "SINH VIÊN", "GIẢNG VIÊN", "KHOA", "KHOÁ HỌC", "MÔN HỌC", "LỚP HỌC", "HỌC KỲ", "NGƯỜI DÙNG", "LOẠI NGƯỜI DÙNG", "LOẠI GIẢNG VIÊN", "HỌC HÀM - HỌC VỊ", "CHUYÊN NGÀNH", "TÔN GIÁO", "DÂN TỘC","XẾP LỚP" };

        public frm_PhanQuyen()
        {
            InitializeComponent();
        }

        public frm_PhanQuyen(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = (new DAO.Database()).Select("SELECT * FROM LOAINGUOIDUNG WHERE MALOAI = '" + id + "'");
            if (dt.Rows.Count > 0)
            {
                txtMaLoai.Text = dt.Rows[0]["MALOAI"].ToString();
                txttenloai.Text = dt.Rows[0]["TENLOAIND"].ToString();
                Init();
            }
        }
        DataTable dttemp;
        private void Init()
        {
            DataTable dt = (new DAO.Database()).Select("SELECT * FROM PHANQUYEN WHERE MALOAI ='" + id + "'");

            dttemp = new DataTable();
            dttemp.Columns.Add("MODULE",typeof(string));

            DataColumn kh = new DataColumn();
            kh.DataType = typeof(bool);
            kh.DefaultValue = false;
            kh.ColumnName = "KICHHOAT";

            dttemp.Columns.Add(kh);

            DataColumn th = new DataColumn();
            th.DataType = typeof(bool);
            th.DefaultValue = false;
            th.ColumnName = "THEM";

            dttemp.Columns.Add(th);

            DataColumn sua = new DataColumn();
            sua.DataType = typeof(bool);
            sua.DefaultValue = false;
            sua.ColumnName = "SUA";

            dttemp.Columns.Add(sua);

            DataColumn xoa = new DataColumn();
            xoa.DataType = typeof(bool);
            xoa.DefaultValue = false;
            xoa.ColumnName = "XOA";
            dttemp.Columns.Add(xoa);


            for (int i = 0; i < mabang.Length; i++)
            {
                int timtemp = timtenformtrongdt(mabang[i], dt);
                if (timtemp > - 1)
                {
                    dttemp.Rows.Add(tenbang[Array.IndexOf(mabang, dt.Rows[timtemp]["MODULE"])], dt.Rows[timtemp]["KICHHOAT"], dt.Rows[timtemp]["THEM"], dt.Rows[timtemp]["SUA"], dt.Rows[timtemp]["XOA"]);
                }
                else
                {
                    dttemp.Rows.Add(tenbang[i]);
                }

            }

            gctrl_phanquyen.ItemsSource = dttemp;
        }

        int timtenformtrongdt(string tenmodun, DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["MODULE"].ToString().Equals(tenmodun))
                {
                    return i;
                }
            }
            return -1;
        }

        private void cmdluu_Click(object sender, RoutedEventArgs e)
        {
            (new DAO.Database()).Query("DELETE PHANQUYEN WHERE MALOAI = '" + id + "'");

            for (int i = 0; i < dttemp.Rows.Count; i++)
            {
                (new DAO.Database()).Query("INSERT INTO PHANQUYEN VALUES ('" + txtMaLoai.Text + "','" + mabang[Array.IndexOf(tenbang, dttemp.Rows[i]["MODULE"])] + "','" + dttemp.Rows[i]["KICHHOAT"] + "','" + dttemp.Rows[i]["THEM"] + "','" + dttemp.Rows[i]["SUA"] + "','" + dttemp.Rows[i]["XOA"] + "')");
            }
            MessageBox.Show("Lưu thành công!");
        }

    }
}
