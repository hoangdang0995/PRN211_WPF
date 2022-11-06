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
    /// Interaction logic for frm_lophoc.xaml
    /// </summary>
    public partial class frm_lophoc : UserControl
    {
        private void role()
        {
            DataTable dtpquyen = frm_HeThongQuanLy.dtquyen;
            if (frm_HeThongQuanLy.timtenformtrongdt("LOPHOC", dtpquyen) > -1)
            {
                cmdadd.IsEnabled = false;
                if (dtpquyen.Rows[frm_HeThongQuanLy.timtenformtrongdt("LOPHOC", dtpquyen)]["THEM"].ToString().ToLower() == "true")
                    cmdadd.IsEnabled = true;
                cmdedit.IsEnabled = false;
                if (dtpquyen.Rows[frm_HeThongQuanLy.timtenformtrongdt("LOPHOC", dtpquyen)]["SUA"].ToString().ToLower() == "true")
                    cmdedit.IsEnabled = true;
                cmddelete.IsEnabled = false;
                if (dtpquyen.Rows[frm_HeThongQuanLy.timtenformtrongdt("LOPHOC", dtpquyen)]["XOA"].ToString().ToLower() == "true")
                    cmddelete.IsEnabled = true;
            }
        }

        public frm_lophoc()
        {
            InitializeComponent();
        }

        void Init()
        {
            DataTable dt = (new DAO.Database()).Select("SELECT MALOP,TENLOP,LOP.MAHOCKY,LOP.MACHUYENNGANH,LOP.MAKHOAHOC,SOLUONG,TENHOCKY,TENCHUYENNGANH,TENKHOAHOC FROM LOP, HOCKY,KHOAHOC,CHUYENNGANH WHERE LOP.MAHOCKY=HOCKY.MAHOCKY AND LOP.MACHUYENNGANH=CHUYENNGANH.MACHUYENNGANH AND LOP.MAKHOAHOC=KHOAHOC.MAKHOAHOC");
            gctrl_lophoc.ItemsSource = dt;
        }

        void LoadLopHoc()
        {
            Init();
        }
        
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadLopHoc();
            View.Commands.ShowSearchPanel.Execute(null);
            role();
        }

        private void cmdadd_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void cmdedit_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void cmddelete_Click(object sender, RoutedEventArgs e)
        {
            var res = MessageBox.Show("Bạn có muốn xoá lớp học tên '" + gctrl_lophoc.GetFocusedRowCellValue("TENLOP") + "' có mã là '" + gctrl_lophoc.GetFocusedRowCellValue("MALOP").ToString() + "' này không? \nNhấn YES để xoá - Nhấn NO để thoát.", "Thông báo", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                (new DAO.Database()).Query("DELETE FROM LOP WHERE MALOP = '" + gctrl_lophoc.GetFocusedRowCellValue("MALOP").ToString() + "'");
                Init();
            }
        }

        private void cmdimport_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cmdexport_Click(object sender, RoutedEventArgs e)
        {
            DataTable dtie = (new DAO.Database()).Select("SELECT MALOP AS MÃ_LỚP,TENLOP AS TÊN_LỚP,TENHOCKY AS TÊN_HỌC_KỲ,TENCHUYENNGANH AS TÊN_CHUYÊN_NGÀNH,TENKHOAHOC AS TÊN_KHOÁ_HỌC,SOLUONG AS SỐ_LƯỢNG_SV FROM LOP, HOCKY,KHOAHOC,CHUYENNGANH WHERE LOP.MAHOCKY=HOCKY.MAHOCKY AND LOP.MACHUYENNGANH=CHUYENNGANH.MACHUYENNGANH AND LOP.MAKHOAHOC=KHOAHOC.MAKHOAHOC");
            BUS.Bus.Export(dtie, "Lop");
        }
    }
}
