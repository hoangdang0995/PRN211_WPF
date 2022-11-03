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
using DAO;
namespace GUI
{
    /// <summary>
    /// Interaction logic for frm_NhapDiem.xaml
    /// </summary>
    public partial class frm_NhapDiem : UserControl
    {
        Database da = new Database();
        public static string _idkhoa = "";
        public static string _idmonhoc = "";
        public static string _idlophoc = "";

        public frm_NhapDiem()
        {
            InitializeComponent();
        }

        private void role()
        {
            DataTable dtpquyen = frm_HeThongQuanLy.dtquyen;
            if (frm_HeThongQuanLy.timtenformtrongdt("BANGDIEM", dtpquyen) > -1)
            {
                cmd_add.IsEnabled = false;
                if (dtpquyen.Rows[frm_HeThongQuanLy.timtenformtrongdt("BANGDIEM", dtpquyen)]["THEM"].ToString().ToLower() == "true")
                    cmd_add.IsEnabled = true;
            }
        }

        private void cmdadd_Click(object sender, RoutedEventArgs e)
        {
            popup.pop_NhapDiem nd = new popup.pop_NhapDiem();
            nd.ShowDialog();
        }

        private bool flash = false;

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Load_Khoa();
            flash = true;
            role();
        }

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

        void Load_LopHoc(string id)
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

        private void Init()
        {
            string sql = @"SELECT * FROM GETLIST_KQ ORDER BY MAKETQUA";
            DataTable dt = (new DAO.Database()).Select(sql);
            gctrl_diem.ItemsSource = dt;
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
                    Load_MonHoc(((TextBlock)cbx_chuyennganh.SelectedItem).Tag.ToString());
                    Load_LopHoc(((TextBlock)cbx_chuyennganh.SelectedItem).Tag.ToString());
                }
                catch { }
            }
        }

        void Init(string str1, string str2)
        {
            DataTable dt = (new DAO.Database()).Select("SELECT * FROM GETLIST_KQ WHERE MALOP='" + str1 + "' AND MAMONHOC='" + str2 + "'");
            gctrl_diem.ItemsSource = dt;
        }

        private string New_Id()
        {
            DataTable dt = (new Database()).Select("SELECT MAX(MABANGDIEM) FROM BANGDIEM");
            if (dt.Rows.Count > 0)
            {
                string str = dt.Rows[0][0].ToString();
                str = str.Substring(2);
                return "BD" + (int.Parse(str) + 1).ToString("00000000");
            }
            else
                return "BD00000001";
        }

        private void cmd_show_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _idlophoc = (((TextBlock)cbx_lophoc.SelectedItem).Tag.ToString());
                _idmonhoc = (((TextBlock)cbx_monhoc.SelectedItem).Tag.ToString());

                DataTable dtdsao = (new DAO.Database()).Select(@"SELECT * FROM KETQUA WHERE MALOP='" + _idlophoc + @"' AND MASINHVIEN NOT IN ( SELECT MASINHVIEN FROM GETLIST_KQ WHERE MALOP='" + _idlophoc + "' AND MAMONHOC='" + _idmonhoc + "')");

                if (dtdsao.Rows.Count > 0)
                {
                    for (int i = 0; i < dtdsao.Rows.Count; i++)
                    {
                        string str = "INSERT INTO BANGDIEM VALUES('" + dtdsao.Rows[i]["MASINHVIEN"].ToString() + "','" + New_Id() + "','" + dtdsao.Rows[i]["MAKETQUA"].ToString() + "','" + _idmonhoc + "','" + txt_hocky.Tag.ToString() + "',NULL,NULL,NULL,NULL)";
                        (new DAO.Database()).Query(str);
                    }
                }

                Init(_idlophoc.ToString(), _idmonhoc.ToString());
            }
            catch
            {
                MessageBox.Show("Bạn chưa chọn đầy đủ các thông tin! Xin vui lòng kiểm tra lại!", "Thông báo");
            }
        }

        private void cmd_add_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < gctrl_diem.VisibleRowCount; i++)
            {
                string sql = "UPDATE BANGDIEM SET DIEMGIUAKY = '" + gctrl_diem.GetCellValue(i, "DIEMGIUAKY").ToString() + "' , DIEMCUOIKY = '" + gctrl_diem.GetCellValue(i, "DIEMCUOIKY").ToString() + "' , DIEMTHILAI = '" + gctrl_diem.GetCellValue(i, "DIEMTHILAI").ToString() + "' , GHICHU = '" + gctrl_diem.GetCellValue(i, "GHICHU").ToString() + "' WHERE MABANGDIEM = '" + gctrl_diem.GetCellValue(i, "MABANGDIEM").ToString() + "' and mahocky = '" + txt_hocky.Tag.ToString() + "'";
                (new DAO.Database()).Query(sql);
            }
            MessageBox.Show("Lưu thành công !");
        }

        private void cbx_lophoc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string sql = @" SELECT * FROM KHOAHOC KH , LOP L , HOCKY HK
                            WHERE KH.MAKHOAHOC = L.MAKHOAHOC AND HK.MAHOCKY = L.MAHOCKY  AND L.MALOP = '" + ((TextBlock)cbx_lophoc.SelectedItem).Tag + "'";
            DataTable dtnoibo = (new DAO.Database()).Select(sql);
            if (dtnoibo.Rows.Count > 0)
            {
                txt_nambatdau.Text = dtnoibo.Rows[0]["NAMBATDAU"].ToString();
                txt_hocky.Text = dtnoibo.Rows[0]["TENHOCKY"].ToString();
                txt_hocky.Tag = dtnoibo.Rows[0]["MAHOCKY"].ToString();
            }
        }

        private void cmd_export_Click(object sender, RoutedEventArgs e)
        {
            DataTable dtie = (new DAO.Database()).Select("SELECT MASINHVIEN AS MÃ_SINH_VIÊN, HOTENSINHVIEN AS HỌ_TÊN_SINH_VIÊN,DIEMGIUAKY AS ĐIỂM_GIỮA_KỲ, DIEMCUOIKY AS ĐIỂM_CUỐI_KỲ, DIEMTHILAI AS ĐIỂM_THI_LẠI, GHICHU AS GHI_CHÚ FROM GETLIST_KQ WHERE MALOP = '" + ((TextBlock)cbx_lophoc.SelectedItem).Tag.ToString() + "' ORDER BY MASINHVIEN ");
            BUS.Bus.Export(dtie, "BangDiem");
        }

        private void cmd_import_Click(object sender, RoutedEventArgs e)
        {
            //popup.Import imp = new popup.Import();
            //var res = imp.ShowDialog();
            //if (res == true)
            //{
            //    DataTable dttemp = imp.datareturn;
            //    for (int i = 0; i < dttemp.Rows.Count; i++)
            //    {
            //        DataTable dtmp = (new DAO.Database()).Select("SELECT MASINHVIEN AS MÃ_SINH_VIÊN, HOTENSINHVIEN AS HỌ_TÊN_SINH_VIÊN,DIEMGIUAKY AS ĐIỂM_GIỮA_KỲ, DIEMCUOIKY AS ĐIỂM_CUỐI_KỲ, DIEMTHILAI AS ĐIỂM_THI_LẠI, GHICHU AS GHI_CHÚ FROM GETLIST_KQ WHERE MALOP = '" + ((TextBlock)cbx_lophoc.SelectedItem).Tag.ToString() + "' ORDER BY MASINHVIEN ");
            //        if (dtmp.Rows.Count > 0)
            //        {
            //            if (imp.tuychinh == "capnhat")
            //            {
            //                //(new DAO.Database()).Query("UPDATE GETLIST_KQ SET DIEMGIUAKY = '" + dttemp.Rows[i]["DIEMGIUAKY"] + "', DIEMCUOIKY = '" + dttemp.Rows[i]["DIEMCUOIKY"] + "', DIEMTHILAI = '" + dttemp.Rows[i]["DIEMTHILAI"] + "', MAKHOA = '" + dttemp.Rows[i]["MAKHOA"] + "' WHERE MABANGDIEM = '" + dttemp.Rows[i]["MABANGDIEM"] + "'");

            //                //(new DAO.Database()).Query("UPDATE SET GETLIST_KQ SET HOTENSINHVIEN = '" + dttemp.Rows[i]["HOTENSINHVIEN"] + "',DIEMGIUAKY= '" + dttemp.Rows[i]["DIEMGIUAKY"] + "', DIEMCUOIKY = '" + dttemp.Rows[i]["DIEMCUOIKY"] + "', DIEMTHILAI = '" + dttemp.Rows[i]["DIEMTHILAI"] + "', GHICHU = '" + dttemp.Rows[i]["GHICHU"] + "' FROM GETLIST_KQ WHERE MASINHVIEN = '" + dttemp.Rows[i]["MASINHVIEN"] + "' ORDER BY MASINHVIEN");

            //                string sql = "UPDATE SET GETLIST_KQ SET HOTENSINHVIEN = '" + dttemp.Rows[i]["HOTENSINHVIEN"] + "',DIEMGIUAKY= '" + dttemp.Rows[i]["DIEMGIUAKY"] + "', DIEMCUOIKY = '" + dttemp.Rows[i]["DIEMCUOIKY"] + "', DIEMTHILAI = '" + dttemp.Rows[i]["DIEMTHILAI"] + "', GHICHU = '" + dttemp.Rows[i]["GHICHU"] + "' FROM GETLIST_KQ WHERE MASINHVIEN = '" + dttemp.Rows[i]["MASINHVIEN"] + "' ORDER BY MASINHVIEN";
            //                (new DAO.Database()).Query(sql);                           
            //            }
            //        }
            //        else
            //        {
            //           // (new DAO.Database()).Query("INSERT INTO CHUYENNGANH VALUES('" + dttemp.Rows[i]["MACHUYENNGANH"] + "','" + dttemp.Rows[i]["TENCHUYENNGANH"] + "','" + dttemp.Rows[i]["MOTA"] + "','" + dttemp.Rows[i]["MAKHOA"] + "')");
            //        }
            //    }
            //    Init();
            //    MessageBox.Show("Import thành công!");
            //}
        }

        private void cmd_themsinhvien_Click(object sender, RoutedEventArgs e)
        {
            popup.pop_SinhVien_MonHoc _svmh = new popup.pop_SinhVien_MonHoc();
            var res = _svmh.ShowDialog();
            if (res == true)
                Init();
        }
    }
}
