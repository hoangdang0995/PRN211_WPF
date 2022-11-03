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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using DAO;

namespace GUI
{
    /// <summary>
    /// Interaction logic for frm_KetQuaCua1SinhVien.xaml
    /// </summary>
    public partial class frm_KetQuaCua1SinhVien : UserControl
    {
        Database da = new Database();
        string _idkhoa = "";
        string _idsinhvien = "";

        private bool flash = false;

        void Load_Khoa()
        {
            DataTable dt = (new DAO.Database()).Select("SELECT MAKHOA, TENKHOA FROM KHOA");
            cbx_khoa.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TextBlock _txttemp = new TextBlock();
                _txttemp.Tag = dt.Rows[i]["MAKHOA"].ToString();
                _txttemp.Text = dt.Rows[i]["TENKHOA"].ToString();
                cbx_khoa.Items.Add(_txttemp);
            }
            if (dt.Rows.Count != 0)
            {
                cbx_khoa.SelectedIndex = 0;
                _idkhoa = cbx_khoa.SelectedItem.ToString();
            }
        }

        void Load_ChuyenNganh(string id)
        {
            DataTable dt = (new DAO.Database()).Select("SELECT MACHUYENNGANH, TENCHUYENNGANH FROM CHUYENNGANH WHERE MAKHOA='" + id + "'");
            cbx_chuyennganh.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TextBlock _txttemp = new TextBlock();
                _txttemp.Tag = dt.Rows[i]["MACHUYENNGANH"].ToString();
                _txttemp.Text = dt.Rows[i]["TENCHUYENNGANH"].ToString();
                cbx_chuyennganh.Items.Add(_txttemp);
            }
            if (dt.Rows.Count != 0)
            {
                cbx_chuyennganh.SelectedIndex = 0;
            }
        }

        void Load_Lop(string id)
        {
            DataTable dt = (new DAO.Database()).Select("SELECT MALOP, TENLOP FROM LOP WHERE MACHUYENNGANH='" + id + "'");
            cbx_lophoc.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TextBlock _txttemp = new TextBlock();
                _txttemp.Tag = dt.Rows[i]["MALOP"].ToString();
                _txttemp.Text = dt.Rows[i]["TENLOP"].ToString();
                cbx_lophoc.Items.Add(_txttemp);
            }
            if (dt.Rows.Count != 0)
            {
                cbx_lophoc.SelectedIndex = 0;
            }
        }

        void Load_SinhVien(string id)
        {
            DataTable dt = (new DAO.Database()).Select("SELECT SV.MASINHVIEN, HOTENSINHVIEN FROM KETQUA kq,SINHVIEN sv WHERE kq.MASINHVIEN=sv.MASINHVIEN AND  MALOP='" + id + "'");
            cbx_SinhVien.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TextBlock _txttemp = new TextBlock();
                _txttemp.Tag = dt.Rows[i]["MASINHVIEN"].ToString();
                _txttemp.Text = dt.Rows[i]["HOTENSINHVIEN"].ToString();
                cbx_SinhVien.Items.Add(_txttemp);
            }
            if (dt.Rows.Count != 0)
            {
                cbx_SinhVien.SelectedIndex = 0;
            }
        }

        private void Init()
        {
            string sql = @"SELECT * FROM THONGKE ORDER BY MAKETQUA";
            DataTable dt = (new DAO.Database()).Select(sql);
            gctrl_diem.ItemsSource = dt;
        }

        void Init(string str)
        {
            DataTable dt = (new DAO.Database()).Select("SELECT * FROM BANGDIEMSINHVIEN WHERE MASINHVIEN='" + str + "'");
            gctrl_diem.ItemsSource = dt;
        }
        
        public frm_KetQuaCua1SinhVien()
        {
            InitializeComponent();
        }

        private void cbx_khoa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (flash)
                    Load_ChuyenNganh(((TextBlock)cbx_khoa.SelectedItem).Tag.ToString());
            }
            catch { }
        }

        private void cbx_chuyennganh_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (flash)
            {
                try
                {
                    Load_Lop(((TextBlock)cbx_chuyennganh.SelectedItem).Tag.ToString());
                }
                catch { }
            }
        }

        private void cbx_lophoc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (flash)
            {
                try
                {
                    Load_SinhVien(((TextBlock)cbx_lophoc.SelectedItem).Tag.ToString());
                }
                catch { }
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Load_Khoa();
            flash = true;
        }

        private void cmd_HienThiDS_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _idsinhvien = (((TextBlock)cbx_SinhVien.SelectedItem).Tag.ToString());
                Init(_idsinhvien.ToString());
            }
            catch
            {
                MessageBox.Show("Bạn chưa chọn đầy đủ các thông tin! Xin vui lòng kiểm tra lại!", "Thông báo");
            }
        }

        private void cmd_XuatDS_Click(object sender, RoutedEventArgs e)
        {
            DataTable dtie = (new DAO.Database()).Select("SELECT TENMONHOC AS TÊN_MÔN_HỌC,DIEMGIUAKY AS ĐIỂM_GIỮA_KỲ, DIEMCUOIKY AS ĐIỂM_CUỐI_KỲ, DIEMTHILAI AS ĐIỂM_THI_LẠI, DTB AS TỔNG_KẾT_MÔN, KQ AS GHI_CHÚ FROM  THONGKE ORDER BY MaHocKy");
            BUS.Bus.Export(dtie, "KetQuaCua1SinhVien");
        }
    }
}
