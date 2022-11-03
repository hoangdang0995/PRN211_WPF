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
    /// Interaction logic for frm_HocKy.xaml
    /// </summary>
    public partial class frm_HocKy : UserControl
    {
        private void role()
        {
            DataTable dtpquyen = frm_HeThongQuanLy.dtquyen;
            if (frm_HeThongQuanLy.timtenformtrongdt("HOCKY", dtpquyen) > -1)
            { 
                cmdadd.IsEnabled = false;
                if (dtpquyen.Rows[frm_HeThongQuanLy.timtenformtrongdt("HOCKY", dtpquyen)]["THEM"].ToString().ToLower() == "true")
                    cmdadd.IsEnabled = true;
                cmdedit.IsEnabled = false;
                if (dtpquyen.Rows[frm_HeThongQuanLy.timtenformtrongdt("HOCKY", dtpquyen)]["SUA"].ToString().ToLower() == "true")
                    cmdedit.IsEnabled = true;
                cmddelete.IsEnabled = false;
                if (dtpquyen.Rows[frm_HeThongQuanLy.timtenformtrongdt("HOCKY", dtpquyen)]["XOA"].ToString().ToLower() == "true")
                    cmddelete.IsEnabled = true;
            }
        }

        public frm_HocKy()
        {
            InitializeComponent();
        }

        void Init()
        {
            DataTable dt = (new DAO.Database()).Select("SELECT MAHOCKY, TENHOCKY, MOTA  FROM HOCKY");
            gctrl_HocKy.ItemsSource = dt;
        }

        void Load_HocKy()
        {
            Init();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Init();
            role();
        }

        private void cmdadd_Click(object sender, RoutedEventArgs e)
        {
            popup.pop_HocKy _hocky = new popup.pop_HocKy();
            var res = _hocky.ShowDialog();
            if (res == true)
                Init();
        }

        private void cmdedit_Click(object sender, RoutedEventArgs e)
        {
            popup.pop_HocKy _hocky = new popup.pop_HocKy(gctrl_HocKy.GetFocusedRowCellValue("MAHOCKY").ToString());
            var res = _hocky.ShowDialog();
            if (res == true)
                Init();
        }

        private void cmddelete_Click(object sender, RoutedEventArgs e)
        {
            var res = MessageBox.Show("Bạn có muốn xoá tên học kỳ '" + gctrl_HocKy.GetFocusedRowCellValue("TENHOCKY") + "' có mã là '" + gctrl_HocKy.GetFocusedRowCellValue("MAHOCKY").ToString() + "' này không? \nNhấn YES để xoá - Nhấn NO để thoát.", "Thông báo", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                (new DAO.Database()).Query("DELETE FROM HOCKY WHERE MAHOCKY = '" + gctrl_HocKy.GetFocusedRowCellValue("MAHOCKY").ToString() + "'");
                Init();
            }
        }

        private void cmdimport_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cmdexport_Click(object sender, RoutedEventArgs e)
        {
            DataTable dtie = (new DAO.Database()).Select("SELECT MAHOCKY AS MÃ_HỌC_KỲ, TENHOCKY AS TÊN_HỌC_KỲ, MOTA AS MÔ_TẢ  FROM HOCKY");
            BUS.Bus.Export(dtie, "HocKy");
        }
    }
}
