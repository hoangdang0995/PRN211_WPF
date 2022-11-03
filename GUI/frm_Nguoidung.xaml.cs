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

namespace GUI
{
    /// <summary>
    /// Interaction logic for frm_Nguoidung.xaml
    /// </summary>
    public partial class frm_Nguoidung : UserControl
    {
        private void role()
        {
            DataTable dtpquyen = frm_HeThongQuanLy.dtquyen;
            if (frm_HeThongQuanLy.timtenformtrongdt("NGUOIDUNG", dtpquyen) > -1)
            {
                cmdadd.IsEnabled = false;
                if (dtpquyen.Rows[frm_HeThongQuanLy.timtenformtrongdt("NGUOIDUNG", dtpquyen)]["THEM"].ToString().ToLower() == "true")
                    cmdadd.IsEnabled = true;
                cmdedit.IsEnabled = false;
                if (dtpquyen.Rows[frm_HeThongQuanLy.timtenformtrongdt("NGUOIDUNG", dtpquyen)]["SUA"].ToString().ToLower() == "true")
                    cmdedit.IsEnabled = true;
                cmddelete.IsEnabled = false;
                if (dtpquyen.Rows[frm_HeThongQuanLy.timtenformtrongdt("NGUOIDUNG", dtpquyen)]["XOA"].ToString().ToLower() == "true")
                    cmddelete.IsEnabled = true;
            }
        }

        public frm_Nguoidung()
        {
            InitializeComponent();
        }
        void Load_NguoiDung()
        {
            Init();
        }

        void Init()
        {
            DataTable dt = (new DAO.Database()).Select("SELECT TENDANGNHAP,MATKHAU,NGUOIDUNG.MALOAI,TENNGUOIDUNG, TENLOAIND FROM NGUOIDUNG,LOAINGUOIDUNG WHERE NGUOIDUNG.MALOAI=LOAINGUOIDUNG.MALOAI");
            gctrl_nguoidung.ItemsSource = dt;
        }

        private void cmdedit_Click(object sender, RoutedEventArgs e)
        {
            popup.pop_NguoiDung _nguoidung = new popup.pop_NguoiDung(gctrl_nguoidung.GetFocusedRowCellValue("TENDANGNHAP").ToString());
            var res = _nguoidung.ShowDialog();
            if (res == true)
            {
                Init();
            }
        }

        private void cmddelete_Click(object sender, RoutedEventArgs e)
        {
            var res = MessageBox.Show("Bạn có muốn xoá tên người dùng '" + gctrl_nguoidung.GetFocusedRowCellValue("TENNGUOIDUNG") + "' có tên đăng nhập là '" + gctrl_nguoidung.GetFocusedRowCellValue("TENDANGNHAP").ToString() + "' này không? \nNhấn YES để xoá - Nhấn NO để thoát.", "Thông báo", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                (new DAO.Database()).Query("DELETE FROM NGUOIDUNG WHERE TENDANGNHAP = '" + gctrl_nguoidung.GetFocusedRowCellValue("TENDANGNHAP").ToString() + "'");
                Init();
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Load_NguoiDung();
            View.Commands.ShowSearchPanel.Execute(null);
            role();
        }

        private void cmdadd_Click(object sender, RoutedEventArgs e)
        {
            popup.pop_NguoiDung _nguoidung = new popup.pop_NguoiDung();
            var res = _nguoidung.ShowDialog();
            if (res == true)
            {
                Init();
            }
        }

        private void cmdimport_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cmdexport_Click(object sender, RoutedEventArgs e)
        {
            DataTable dtie = (new DAO.Database()).Select("SELECT TENNGUOIDUNG AS TÊN_NGƯỜI_DÙNG, TENDANGNHAP AS TÊN_ĐĂNG_NHẬP, MATKHAU AS MẬT_KHẨU , TENLOAIND AS LOẠI_NGƯỜI_DÙNG FROM NGUOIDUNG, LOAINGUOIDUNG WHERE NGUOIDUNG.MALOAI= LOAINGUOIDUNG.MALOAI");
            BUS.Bus.Export(dtie, "NguoiDung");
        }
    }
}
