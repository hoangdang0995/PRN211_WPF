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
    /// Interaction logic for frm_monhoc.xaml
    /// </summary>
    public partial class frm_monhoc : UserControl
    {
        private void role()
        {
            DataTable dtpquyen = frm_HeThongQuanLy.dtquyen;
            if (frm_HeThongQuanLy.timtenformtrongdt("MONHOC", dtpquyen) > -1)
            {
                cmdadd.IsEnabled = false;
                if (dtpquyen.Rows[frm_HeThongQuanLy.timtenformtrongdt("MONHOC", dtpquyen)]["THEM"].ToString().ToLower() == "true")
                    cmdadd.IsEnabled = true;
                cmdedit.IsEnabled = false;
                if (dtpquyen.Rows[frm_HeThongQuanLy.timtenformtrongdt("MONHOC", dtpquyen)]["SUA"].ToString().ToLower() == "true")
                    cmdedit.IsEnabled = true;
                cmddelete.IsEnabled = false;
                if (dtpquyen.Rows[frm_HeThongQuanLy.timtenformtrongdt("MONHOC", dtpquyen)]["XOA"].ToString().ToLower() == "true")
                    cmddelete.IsEnabled = true;
            }
        }

        public frm_monhoc()
        {
            InitializeComponent();
        }

        void Init()
        {
            DataTable dt = (new DAO.Database()).Select("SELECT MAMONHOC,TENMONHOC,MONHOC.MACHUYENNGANH,MONHOC.MOTA,SOTINCHI,TENCHUYENNGANH FROM MONHOC,CHUYENNGANH WHERE MONHOC.MACHUYENNGANH=CHUYENNGANH.MACHUYENNGANH");
            gctrl_monhoc.ItemsSource = dt;
        }

        void Load_MonHoc()
        {
            Init();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Load_MonHoc();
            View.Commands.ShowSearchPanel.Execute(null);
            role();
        }

        private void cmdadd_Click(object sender, RoutedEventArgs e)
        {
            popup.pop_MonHoc _monhoc = new popup.pop_MonHoc();
            var res = _monhoc.ShowDialog();
            if (res == true)
                Init();
        }

        private void cmdedit_Click(object sender, RoutedEventArgs e)
        {
            popup.pop_MonHoc _monhoc = new popup.pop_MonHoc(gctrl_monhoc.GetFocusedRowCellValue("MAMONHOC").ToString());
            var res = _monhoc.ShowDialog();
            if (res == true)
                Init();
        }

        private void cmddelete_Click(object sender, RoutedEventArgs e)
        {
            var res = MessageBox.Show("Bạn có muốn xoá tên môn học  '" + gctrl_monhoc.GetFocusedRowCellValue("TENMONHOC") + "' có mã là '" + gctrl_monhoc.GetFocusedRowCellValue("MAMONHOC").ToString() + "' này không? \nNhấn YES để xoá - Nhấn NO để thoát.", "Thông báo", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                (new DAO.Database()).Query("DELETE FROM MONHOC WHERE MAMONHOC = '" + gctrl_monhoc.GetFocusedRowCellValue("MAMONHOC").ToString() + "'");
                Init();
            }
        }

        private void cmdimport_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cmdexport_Click(object sender, RoutedEventArgs e)
        {
            DataTable dtie = (new DAO.Database()).Select("SELECT MAMONHOC AS MÃ_MÔN_HỌC, TENMONHOC AS TÊN_MÔN_HỌC,SOTINCHI AS SỐ_TÍN_CHỈ, TENCHUYENNGANH AS TÊN_CHUYÊN_NGÀNH, MONHOC.MOTA AS MÔ_TẢ FROM MONHOC, CHUYENNGANH WHERE MONHOC.MACHUYENNGANH=CHUYENNGANH.MACHUYENNGANH");
            BUS.Bus.Export(dtie, "MonHoc");
        }
    }
}
