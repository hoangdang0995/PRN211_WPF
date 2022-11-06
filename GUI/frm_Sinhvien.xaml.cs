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
    /// Interaction logic for frm_Sinhvien.xaml
    /// </summary>
    public partial class frm_Sinhvien : UserControl
    {
        public frm_Sinhvien()
        {
            InitializeComponent();
        }

        //private void role()
        //{
        //    DataTable dtpquyen = frm_HeThongQuanLy.dtquyen;
        //    if (frm_HeThongQuanLy.timtenformtrongdt("SINHVIEN", dtpquyen) > -1)
        //    {
        //        cmd_Add.IsEnabled = false;
        //        if (dtpquyen.Rows[frm_HeThongQuanLy.timtenformtrongdt("SINHVIEN", dtpquyen)]["THEM"].ToString().ToLower() == "true")
        //            cmd_Add.IsEnabled = true;
        //        cmd_Edit.IsEnabled = false;
        //        if (dtpquyen.Rows[frm_HeThongQuanLy.timtenformtrongdt("SINHVIEN", dtpquyen)]["SUA"].ToString().ToLower() == "true")
        //            cmd_Edit.IsEnabled = true;
        //        cmd_Delete.IsEnabled = false;
        //        if (dtpquyen.Rows[frm_HeThongQuanLy.timtenformtrongdt("SINHVIEN", dtpquyen)]["XOA"].ToString().ToLower() == "true")
        //            cmd_Delete.IsEnabled = true;
        //    }
        //}

        void Init()
        {
            DataTable dt = (new DAO.Database()).Select("SELECT MASINHVIEN,HOTENSINHVIEN,GIOITINH,NGAYSINH,NOISINH,HOTENCHA,HOTENME,DIENTHOAI,EMAIL FROM SINHVIEN ORDER BY MASINHVIEN");
            gctrl_SinhVien.ItemsSource = dt;
        }

        void Load_SinhVien()
        {
            Init();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Load_SinhVien();
            View.Commands.ShowSearchPanel.Execute(null);
            //role();
        }

        private void cmd_Add_Click(object sender, RoutedEventArgs e)
        {
            popup.pop_SinhVien _sinhvien = new popup.pop_SinhVien();
            var res = _sinhvien.ShowDialog();
            if (res == true)
                Init();
        }

        private void cmd_Edit_Click(object sender, RoutedEventArgs e)
        {
            popup.pop_SinhVien _sinhvien = new popup.pop_SinhVien(gctrl_SinhVien.GetFocusedRowCellValue("MASINHVIEN").ToString());
            var res = _sinhvien.ShowDialog();
            if (res == true)
                Init();
        }

        private void cmd_Delete_Click(object sender, RoutedEventArgs e)
        {
            var res = MessageBox.Show("Bạn có muốn xoá sinh viên tên '" + gctrl_SinhVien.GetFocusedRowCellValue("TENSINHVIEN") + "' có mã là '" + gctrl_SinhVien.GetFocusedRowCellValue("MASINHVIEN").ToString() + "' này không? \nNhấn YES để xoá - Nhấn NO để thoát.", "Thông báo", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                (new DAO.Database()).Query("DELETE FROM SINHVIEN WHERE MASINHVIEN = '" + gctrl_SinhVien.GetFocusedRowCellValue("MASINHVIEN").ToString() + "'");
                Init();
            }
        }

        private void cmdexport_Click(object sender, RoutedEventArgs e)
        {
            DataTable dtie = (new DAO.Database()).Select("SELECT MASINHVIEN AS MÃ_SINH_VIÊN,HOTENSINHVIEN AS HỌ_TÊN_SINH_VIÊN,GIOITINH AS GIỚI_TÍNH,NGAYSINH AS NGÀY_SINH,NOISINH AS NƠI_SINH,TENDANTOC AS DÂN_TỘC,TENTONGIAO AS TÔN_GIÁO,HOTENCHA AS HỌ_TÊN_CHA,HOTENME AS HỌ_TÊN_MẸ,DIENTHOAI AS SỐ_ĐIỆN_THOẠI,EMAIL AS ĐỊA_CHỈ_EMAIL FROM SINHVIEN,TONGIAO,DANTOC WHERE SINHVIEN.MATONGIAO=TONGIAO.MATONGIAO AND SINHVIEN.MADANTOC=DANTOC.MADANTOC ORDER BY MASINHVIEN");
            BUS.Bus.Export(dtie, "DanhSachSinhVien");
        }
    }
}
