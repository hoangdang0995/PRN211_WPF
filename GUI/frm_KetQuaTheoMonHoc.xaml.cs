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
    /// Interaction logic for frm_KetQuaTheoMonHoc.xaml
    /// </summary>
    public partial class frm_KetQuaTheoMonHoc : UserControl
    {
        Database da = new Database();
        string _idkhoa = "";
        string _idmonhoc = "";

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

        void Load_MonHoc(string id)
        {
            DataTable dt = (new DAO.Database()).Select("SELECT MAMONHOC, TENMONHOC FROM MONHOC WHERE MACHUYENNGANH='" + id + "'");
            cbx_monhoc.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TextBlock _txttemp = new TextBlock();
                _txttemp.Tag = dt.Rows[i]["MAMONHOC"].ToString();
                _txttemp.Text = dt.Rows[i]["TENMONHOC"].ToString();
                cbx_monhoc.Items.Add(_txttemp);
            }
            if (dt.Rows.Count != 0)
            {
                cbx_monhoc.SelectedIndex = 0;
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
            DataTable dt = (new DAO.Database()).Select("SELECT * FROM THONGKE WHERE MAMONHOC='" + str + "'");
            gctrl_diem.ItemsSource = dt;            
        }
        
        public frm_KetQuaTheoMonHoc()
        {
            InitializeComponent();
        }

        private void cmd_HienThiDS_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _idmonhoc = (((TextBlock)cbx_monhoc.SelectedItem).Tag.ToString());                
                Init(_idmonhoc.ToString());
            }
            catch
            {
                MessageBox.Show("Bạn chưa chọn đầy đủ các thông tin! Xin vui lòng kiểm tra lại!", "Thông báo");
            }
        }

        private void cmd_XuatDS_Click(object sender, RoutedEventArgs e)
        {
            DataTable dtie = (new DAO.Database()).Select("SELECT MASINHVIEN AS MÃ_SINH_VIÊN, HOTENSINHVIEN AS HỌ_TÊN_SINH_VIÊN,DIEMGIUAKY AS ĐIỂM_GIỮA_KỲ, DIEMCUOIKY AS ĐIỂM_CUỐI_KỲ, DIEMTHILAI AS ĐIỂM_THI_LẠI, DTB AS TỔNG_KẾT_MÔN, KQ AS GHI_CHÚ FROM  THONGKE ORDER BY MAKETQUA");
            BUS.Bus.Export(dtie, "KetQuaTheoMonHoc");
        }

        private void cbx_chuyennganh_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (flash)
            {
                try
                {
                    Load_MonHoc(((TextBlock)cbx_chuyennganh.SelectedItem).Tag.ToString());
                }
                catch { }
            }
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

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Load_Khoa();
            flash = true;
        }
    }
}
