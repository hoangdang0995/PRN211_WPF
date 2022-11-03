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
    /// Interaction logic for frm_Tongiao.xaml
    /// </summary>
    public partial class frm_Tongiao : UserControl
    {
        private void role()
        {
            DataTable dtpquyen = frm_HeThongQuanLy.dtquyen;
            if (frm_HeThongQuanLy.timtenformtrongdt("TONGIAO", dtpquyen) > -1)
            {
                cmd_add.IsEnabled = false;
                if (dtpquyen.Rows[frm_HeThongQuanLy.timtenformtrongdt("TONGIAO", dtpquyen)]["THEM"].ToString().ToLower() == "true")
                    cmd_add.IsEnabled = true;
                cmd_edit.IsEnabled = false;
                if (dtpquyen.Rows[frm_HeThongQuanLy.timtenformtrongdt("TONGIAO", dtpquyen)]["SUA"].ToString().ToLower() == "true")
                    cmd_edit.IsEnabled = true;
                cmd_delete.IsEnabled = false;
                if (dtpquyen.Rows[frm_HeThongQuanLy.timtenformtrongdt("TONGIAO", dtpquyen)]["XOA"].ToString().ToLower() == "true")
                    cmd_delete.IsEnabled = true;
            }
        }

        public frm_Tongiao()
        {
            InitializeComponent();
        }

        void Init()
        {
            DataTable dt = (new DAO.Database()).Select("SELECT * FROM TONGIAO");
            gctrl_TonGiao.ItemsSource = dt;
        }

        void LoadFormTonGiao()
        {
            Init();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadFormTonGiao();
            role();
        }

        private void cmd_add_Click(object sender, RoutedEventArgs e)
        {
            popup.pop_TonGiao _tongiao = new popup.pop_TonGiao();
            var res = _tongiao.ShowDialog();
            if (res == true)
                Init();
        }

        private void cmd_edit_Click(object sender, RoutedEventArgs e)
        {
            popup.pop_TonGiao _tongiao = new popup.pop_TonGiao(gctrl_TonGiao.GetFocusedRowCellValue("MATONGIAO").ToString());
            var res = _tongiao.ShowDialog();
            if (res == true)
                Init();
        }

        private void cmd_delete_Click(object sender, RoutedEventArgs e)
        {
            var res = MessageBox.Show("Bạn có muốn xoá tên tôn giáo '" + gctrl_TonGiao.GetFocusedRowCellValue("TENTONGIAO") + "' có mã là '" + gctrl_TonGiao.GetFocusedRowCellValue("MATONGIAO").ToString() + "' này không? \nNhấn YES để xoá - Nhấn NO để thoát.", "Thông báo", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                (new DAO.Database()).Query("DELETE FROM TONGIAO WHERE MATONGIAO = '" + gctrl_TonGiao.GetFocusedRowCellValue("MATONGIAO").ToString() + "'");
                Init();
            }
        }

        private void cmdimport_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cmdexport_Click(object sender, RoutedEventArgs e)
        {
            DataTable dtie = (new DAO.Database()).Select("SELECT MATONGIAO AS MÃ_TÔN_GIÁO, TENTONGIAO AS TÊN_TÔN_GIÁO FROM TONGIAO");
            BUS.Bus.Export(dtie, "TonGiao");
        }
    }
}
