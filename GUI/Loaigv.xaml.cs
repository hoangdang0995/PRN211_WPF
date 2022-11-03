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
    /// Interaction logic for Loaigv.xaml
    /// </summary>
    public partial class Loaigv : UserControl
    {
        public Loaigv()
        {
            InitializeComponent();
        }

        private void role()
        {
            DataTable dtpquyen = frm_HeThongQuanLy.dtquyen;
            if (frm_HeThongQuanLy.timtenformtrongdt("LOAIGIANGVIEN", dtpquyen) > -1)
            {
                cmd_add.IsEnabled = false;
                if (dtpquyen.Rows[frm_HeThongQuanLy.timtenformtrongdt("LOAIGIANGVIEN", dtpquyen)]["THEM"].ToString().ToLower() == "true")
                    cmd_add.IsEnabled = true;
                cmd_edit.IsEnabled = false;
                if (dtpquyen.Rows[frm_HeThongQuanLy.timtenformtrongdt("LOAIGIANGVIEN", dtpquyen)]["SUA"].ToString().ToLower() == "true")
                    cmd_edit.IsEnabled = true;
                cmd_delete.IsEnabled = false;
                if (dtpquyen.Rows[frm_HeThongQuanLy.timtenformtrongdt("LOAIGIANGVIEN", dtpquyen)]["XOA"].ToString().ToLower() == "true")
                    cmd_delete.IsEnabled = true;
            }
        }

        void Init()
        {
            DataTable dt = (new DAO.Database()).Select("SELECT * FROM LOAIGIANGVIEN");
            gctrlLoaiGV.ItemsSource = dt;
        }

        void LoadFormLoaiGV()
        {
            Init();   
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadFormLoaiGV();
            role();
        }

        private void cmd_add_Click(object sender, RoutedEventArgs e)
        {
            popup.pop_LoaiGiangVien _loaigv = new popup.pop_LoaiGiangVien();
            var res = _loaigv.ShowDialog();
            if (res == true)
            {
                Init();
            }
        }

        private void cmd_edit_Click(object sender, RoutedEventArgs e)
        {
            popup.pop_LoaiGiangVien _loaigv = new popup.pop_LoaiGiangVien(gctrlLoaiGV.GetFocusedRowCellValue("MALOAIGV").ToString());
            var res = _loaigv.ShowDialog();
            if (res == true)
            {
                Init();
            }
        }

        private void cmd_delete_Click(object sender, RoutedEventArgs e)
        {
            var res = MessageBox.Show("Bạn có muốn xoá tên loại giảng viên '" + gctrlLoaiGV.GetFocusedRowCellValue("TENLOAIGV") + "' có mã loại là '" + gctrlLoaiGV.GetFocusedRowCellValue("MALOAIGV").ToString() + "' này không? \nNhấn YES để xoá - Nhấn NO để thoát.", "Thông báo", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                (new DAO.Database()).Query("DELETE FROM LOAIGIANGVIEN WHERE MALOAIGV = '" + gctrlLoaiGV.GetFocusedRowCellValue("MALOAIGV").ToString() + "'");
                Init();
            }
        }

        private void cmd_export_Click(object sender, RoutedEventArgs e)
        {
            DataTable dtie = (new DAO.Database()).Select("SELECT MALOAIGV AS MÃ_LOẠI_GIẢNG_VIÊN, TENLOAIGV AS TÊN_LOẠI_GIẢNG_VIÊN FROM LOAIGIANGVIEN");
            BUS.Bus.Export(dtie, "LoaiGiangVien");
        }

        private void cmd_import_Click(object sender, RoutedEventArgs e)
        {
            //popup.Import imp = new popup.Import();
            //var res = imp.ShowDialog();
            //try
            //{
            //    if (res == true)
            //    {
            //        DataTable dttemp = imp.datareturn;
            //        for (int i = 0; i < dttemp.Rows.Count; i++)
            //        {
            //            DataTable dtmp = (new DAO.Database()).Select("SELECT * FROM LOAIGIANGVIEN WHERE MALOAIGV = '" + dttemp.Rows[i]["MÃ_LOẠI_GIẢNG_VIÊN"] + "'");
            //            if (dtmp.Rows.Count > 0)
            //            {
            //                if (imp.tuychinh == "capnhat")
            //                {
            //                    string sqlu = "UPDATE LOAIGIANGVIEN SET TENLOAIGV = '" + dttemp.Rows[i]["TÊN_LOẠI_GIẢNG_VIÊN"] + "' WHERE MALOAIGV = '" + dttemp.Rows[i]["TÊN_LOẠI_GIẢNG_VIÊN"] + "'";
            //                    (new DAO.Database()).Query(sqlu);
            //                }
            //            }
            //            else
            //            {
            //                string sqli = "INSERT INTO LOAIGIANGVIEN VALUES('" + dttemp.Rows[i]["MÃ_LOẠI_GIẢNG_VIÊN"] + "','" + dttemp.Rows[i]["TÊN_LOẠI_GIẢNG_VIÊN"] + "')";
            //                (new DAO.Database()).Query(sqli);
            //            }
            //        }
            //        Init();
            //        MessageBox.Show("Lấy dữ liệu thành công!");
            //    }
            //}
            //catch
            //{
            //    MessageBox.Show("Lấy dữ liệu không thành công! Xin hãy kiểm tra lại dữ liệu!");
            //}
        }
    }
}
