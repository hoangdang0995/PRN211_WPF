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
    /// Interaction logic for frm_Giangvien.xaml
    /// </summary>
    public partial class frm_Giangvien : UserControl
    {
        public frm_Giangvien()
        {
            InitializeComponent();
        }

        private void role()
        {
            DataTable dtpquyen = frm_HeThongQuanLy.dtquyen;
            if (frm_HeThongQuanLy.timtenformtrongdt("GIANGVIEN", dtpquyen) > -1)
            {
                cmd_Add.IsEnabled = false;
                if (dtpquyen.Rows[frm_HeThongQuanLy.timtenformtrongdt("GIANGVIEN", dtpquyen)]["THEM"].ToString().ToLower() == "true")
                    cmd_Add.IsEnabled = true;
                cmd_Edit.IsEnabled = false;
                if (dtpquyen.Rows[frm_HeThongQuanLy.timtenformtrongdt("GIANGVIEN", dtpquyen)]["SUA"].ToString().ToLower() == "true")
                    cmd_Edit.IsEnabled = true;
                cmd_Delete.IsEnabled = false;
                if (dtpquyen.Rows[frm_HeThongQuanLy.timtenformtrongdt("GIANGVIEN", dtpquyen)]["XOA"].ToString().ToLower() == "true")
                    cmd_Delete.IsEnabled = true;
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            load_giangvien();
            View.Commands.ShowSearchPanel.Execute(null);
            role();
        }
        void load_giangvien()
        {
            Init();
        }

        void Init()
        {
            DataTable dt = (new DAO.Database()).Select("SELECT EMAIL,MAGIANGVIEN, TENGIANGVIEN, GIOITINH, DIACHI, DIENTHOAI, HOCVIHOCHAM.MAHOCVIHOCHAM,HOCVIHOCHAM.TENHOCVIHOCHAM,LOAIGIANGVIEN.MALOAIGV, LOAIGIANGVIEN.TENLOAIGV FROM GIANGVIEN,LOAIGIANGVIEN,HOCVIHOCHAM WHERE GIANGVIEN.MAHOCVIHOCHAM=HOCVIHOCHAM.MAHOCVIHOCHAM AND LOAIGIANGVIEN.MALOAIGV = GIANGVIEN.MALOAIGV");
            gctrl_GiangVien.ItemsSource = dt;
        }

        private void cmd_Add_Click(object sender, RoutedEventArgs e)
        {
            //popup.pop_GiangVien _giangvien = new popup.pop_GiangVien();
            ///var res = _giangvien.ShowDialog();
            //if (res == true)
            //{
            //    Init();
            //}
        }

        private void cmd_Edit_Click(object sender, RoutedEventArgs e)
        {
            //popup.pop_GiangVien _giangvien = new popup.pop_GiangVien(gctrl_GiangVien.GetFocusedRowCellValue("MAGIANGVIEN").ToString());
            ////var res = _giangvien.ShowDialog();
            //if (res == true)
            //    Init();
        }

        private void cmd_Delete_Click(object sender, RoutedEventArgs e)
        {
            var res = MessageBox.Show("Bạn có muốn xoá tên giảng viên '" + gctrl_GiangVien.GetFocusedRowCellValue("TENGIANGVIEN") + "' có mã là '" + gctrl_GiangVien.GetFocusedRowCellValue("MAGIANGVIEN").ToString() + "' này không? \nNhấn YES để xoá - Nhấn NO để thoát.", "Thông báo", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                (new DAO.Database()).Query("DELETE FROM GIANGVIEN WHERE MAGIANGVIEN = '" + gctrl_GiangVien.GetFocusedRowCellValue("MAGIANGVIEN").ToString() + "'");
                Init();
            }
        }

        private void cmdexport_Click(object sender, RoutedEventArgs e)
        {
            DataTable dtie = (new DAO.Database()).Select("SELECT MAGIANGVIEN AS MÃ_GIẢNG_VIÊN, TENGIANGVIEN AS TÊN_GIẢNG_VIÊN, GIOITINH AS GIỚI_TÍNH, DIACHI AS ĐỊA_CHỈ, DIENTHOAI AS SỐ_ĐIỆN_THOẠI,TENHOCVIHOCHAM AS HỌC_HÀM_HỌC_VỊ, TENLOAIGV AS LOẠI_GIẢNG_VIÊN, EMAIL FROM GIANGVIEN gv,LOAIGIANGVIEN lgv,HOCVIHOCHAM hh WHERE gv.MAHOCVIHOCHAM=hh.MAHOCVIHOCHAM AND lgv.MALOAIGV = gv.MALOAIGV");
            BUS.Bus.Export(dtie, "GiangVien");
        }
        
    }
}
