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
    /// Interaction logic for frm_LoaiNguoiDung.xaml
    /// </summary>
    public partial class frm_LoaiNguoiDung : UserControl
    {
        private void role()
        {
            DataTable dtpquyen = frm_HeThongQuanLy.dtquyen;
            if (frm_HeThongQuanLy.timtenformtrongdt("LOAINGUOIDUNG", dtpquyen) > -1)
            {
                cmdadd.IsEnabled = false;
                if (dtpquyen.Rows[frm_HeThongQuanLy.timtenformtrongdt("LOAINGUOIDUNG", dtpquyen)]["THEM"].ToString().ToLower() == "true")
                    cmdadd.IsEnabled = true;
                cmdedit.IsEnabled = false;
                if (dtpquyen.Rows[frm_HeThongQuanLy.timtenformtrongdt("LOAINGUOIDUNG", dtpquyen)]["SUA"].ToString().ToLower() == "true")
                    cmdedit.IsEnabled = true;
                cmddelete.IsEnabled = false;
                if (dtpquyen.Rows[frm_HeThongQuanLy.timtenformtrongdt("LOAINGUOIDUNG", dtpquyen)]["XOA"].ToString().ToLower() == "true")
                    cmddelete.IsEnabled = true;
            }
        }

        public frm_LoaiNguoiDung()
        {
            InitializeComponent();
        }

        void Load_Form_LoaiNguoiDung()
        {
            Init();
        }

        void Init()
        {
            DataTable dt = (new DAO.Database()).Select("SELECT * FROM LOAINGUOIDUNG");
            gctrl_LoaiNguoiDung.ItemsSource = dt;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Load_Form_LoaiNguoiDung();
            role();
        }

        private void cmdadd_Click(object sender, RoutedEventArgs e)
        {
            popup.pop_LoaiNguoiDung _loaigiangvien = new popup.pop_LoaiNguoiDung();
            var res = _loaigiangvien.ShowDialog();
            if (res == true)
            {
                Init();
            }
        }

        private void cmdedit_Click(object sender, RoutedEventArgs e)
        {
            popup.pop_LoaiNguoiDung _loaigiangvien = new popup.pop_LoaiNguoiDung(gctrl_LoaiNguoiDung.GetFocusedRowCellValue("MALOAI").ToString());
            var res = _loaigiangvien.ShowDialog();
            if (res == true)
            {
                Init();
            }
        }

        private void cmddelete_Click(object sender, RoutedEventArgs e)
        {
            var res = MessageBox.Show("Bạn có muốn xoá loại người dùng có tên là '" + gctrl_LoaiNguoiDung.GetFocusedRowCellValue("TENLOAIND") + "' có mã là '" + gctrl_LoaiNguoiDung.GetFocusedRowCellValue("MALOAI").ToString() + "' này không? \nNhấn YES để xoá - Nhấn NO để thoát.", "Thông báo", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                (new DAO.Database()).Query("DELETE FROM LOAINGUOIDUNG WHERE MALOAI = '" + gctrl_LoaiNguoiDung.GetFocusedRowCellValue("MALOAI").ToString() + "'");
                Init();
            }
        }

        private void cmdexport_Click(object sender, RoutedEventArgs e)
        {
            DataTable dtie = (new DAO.Database()).Select("SELECT MALOAI AS MÃ_LOẠI_NGƯỜI_DÙNG, TENLOAIND AS TÊN_LOẠI_NGƯỜI_DÙNG FROM LOAINGUOIDUNG");
            BUS.Bus.Export(dtie, "LoaiNguoiDung");
        }

        private void cmdphanquyen_Click(object sender, RoutedEventArgs e)
        {
            frm_PhanQuyen pq = new frm_PhanQuyen(gctrl_LoaiNguoiDung.GetFocusedRowCellValue("MALOAI").ToString());
            pq.ShowDialog();
        }
    }
}
