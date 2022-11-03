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
    /// Interaction logic for frm_hocham_hocvi.xaml
    /// </summary>
    public partial class frm_hocham_hocvi : UserControl
    {
        public frm_hocham_hocvi()
        {
            InitializeComponent();
        }

        private void role()
        {
            DataTable dtpquyen = frm_HeThongQuanLy.dtquyen;
            if (frm_HeThongQuanLy.timtenformtrongdt("HOCVIHOCHAM", dtpquyen) > -1)
            {
                cmd_add.IsEnabled = false;
                if (dtpquyen.Rows[frm_HeThongQuanLy.timtenformtrongdt("HOCVIHOCHAM", dtpquyen)]["THEM"].ToString().ToLower() == "true")
                    cmd_add.IsEnabled = true;
                cmd_edit.IsEnabled = false;
                if (dtpquyen.Rows[frm_HeThongQuanLy.timtenformtrongdt("HOCVIHOCHAM", dtpquyen)]["SUA"].ToString().ToLower() == "true")
                    cmd_edit.IsEnabled = true;
                cmd_delete.IsEnabled = false;
                if (dtpquyen.Rows[frm_HeThongQuanLy.timtenformtrongdt("HOCVIHOCHAM", dtpquyen)]["XOA"].ToString().ToLower() == "true")
                    cmd_delete.IsEnabled = true;
            }
        }

        void LoadFormHocHamHocVi()
        {
            Init();
        }

        void Init()
        {
            DataTable dt = (new DAO.Database()).Select("SELECT * FROM HOCVIHOCHAM");
            gctrl_HocHamHocVi.ItemsSource = dt;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadFormHocHamHocVi();
            role();
        }

        private void cmd_add_Click(object sender, RoutedEventArgs e)
        {
            popup.pop_HocHamHocVi _hochamhocvi = new popup.pop_HocHamHocVi();
            var res = _hochamhocvi.ShowDialog();
            if (res == true)
            {
                Init();
            }
        }

        private void cmd_edit_Click(object sender, RoutedEventArgs e)
        {
            popup.pop_HocHamHocVi _hochamhocvi = new popup.pop_HocHamHocVi(gctrl_HocHamHocVi.GetFocusedRowCellValue("MAHOCVIHOCHAM").ToString());
            var res = _hochamhocvi.ShowDialog();
            if (res == true)
            {
                Init();
            }
        }

        private void cmd_delete_Click(object sender, RoutedEventArgs e)
        {
            var res = MessageBox.Show("Bạn có muốn xoá tên học hàm học vị '" + gctrl_HocHamHocVi.GetFocusedRowCellValue("TENHOCVIHOCHAM") + "' có mã là '" + gctrl_HocHamHocVi.GetFocusedRowCellValue("MAHOCVIHOCHAM").ToString() + "' này không? \nNhấn YES để xoá - Nhấn NO để thoát.", "Thông báo", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                string str = "DELETE FROM HOCVIHOCHAM WHERE MAHOCVIHOCHAM = '" + gctrl_HocHamHocVi.GetFocusedRowCellValue("MAHOCVIHOCHAM").ToString() + "'";
                (new DAO.Database()).Query(str);
                Init();
            }
        }

        private void cmdexport_Click(object sender, RoutedEventArgs e)
        {
            DataTable dtie = (new DAO.Database()).Select("SELECT MAHOCVIHOCHAM AS MÃ_HỌC_HÀM_HỌC_VỊ, TENHOCVIHOCHAM AS TÊN_HỌC_HÀM_HỌC_VỊ FROM HOCVIHOCHAM");
            BUS.Bus.Export(dtie, "HocHamHocVi");
        }

        private void cmdimport_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
