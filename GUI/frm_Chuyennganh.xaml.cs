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
    /// Interaction logic for frm_Chuyennganh.xaml
    /// </summary>
    public partial class frm_Chuyennganh : UserControl
    {
        public frm_Chuyennganh()
        {
            InitializeComponent();
        }

        private void role()
        {
            DataTable dtpquyen = frm_HeThongQuanLy.dtquyen;
            if (frm_HeThongQuanLy.timtenformtrongdt("CHUYENNGANH", dtpquyen) > -1)
            {
                cmdadd.IsEnabled = false;
                if (dtpquyen.Rows[frm_HeThongQuanLy.timtenformtrongdt("CHUYENNGANH", dtpquyen)]["THEM"].ToString().ToLower() == "true")
                    cmdadd.IsEnabled = true;
                cmdedit.IsEnabled = false;
                if (dtpquyen.Rows[frm_HeThongQuanLy.timtenformtrongdt("CHUYENNGANH", dtpquyen)]["SUA"].ToString().ToLower() == "true")
                    cmdedit.IsEnabled = true;
                cmddelete.IsEnabled = false;
                if (dtpquyen.Rows[frm_HeThongQuanLy.timtenformtrongdt("CHUYENNGANH", dtpquyen)]["XOA"].ToString().ToLower() == "true")
                    cmddelete.IsEnabled = true;
            }
        }

        void Init()
        {
            DataTable dt = (new DAO.Database()).Select("SELECT MACHUYENNGANH, TENCHUYENNGANH, MOTA, CHUYENNGANH.MAKHOA, TENKHOA FROM CHUYENNGANH, KHOA WHERE CHUYENNGANH.MAKHOA=KHOA.MAKHOA");
            gctrl_chuyennganh.ItemsSource = dt;
        }

        void Load_ChuyenNganh()
        {
            Init();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Load_ChuyenNganh();
            View.Commands.ShowSearchPanel.Execute(null);
            role();
        }

        private void cmdadd_Click(object sender, RoutedEventArgs e)
        {
            popup.pop_ChuyenNganh _chuyennganh = new popup.pop_ChuyenNganh();
            var res = _chuyennganh.ShowDialog();
            if (res == true)
                Init();
        }

        private void cmdedit_Click(object sender, RoutedEventArgs e)
        {
            popup.pop_ChuyenNganh _chuyennganh = new popup.pop_ChuyenNganh(gctrl_chuyennganh.GetFocusedRowCellValue("MACHUYENNGANH").ToString());
            var res = _chuyennganh.ShowDialog();
            if (res == true)
                Init();
        }

        private void cmddelete_Click(object sender, RoutedEventArgs e)
        {
            var res = MessageBox.Show("Bạn có muốn xoá tên chuyên ngành '" + gctrl_chuyennganh.GetFocusedRowCellValue("TENCHUYENNGANH") + "' có mã là '" + gctrl_chuyennganh.GetFocusedRowCellValue("MACHUYENNGANH").ToString() + "' này không? \nNhấn YES để xoá - Nhấn NO để thoát.", "Thông báo", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                (new DAO.Database()).Query("DELETE FROM CHUYENNGANH WHERE MACHUYENNGANH = '" + gctrl_chuyennganh.GetFocusedRowCellValue("MACHUYENNGANH").ToString() + "'");
                Init();
            }
        }

        

        private void cmdimport_Click(object sender, RoutedEventArgs e)
        {
            popup.Import imp = new popup.Import();
            var res = imp.ShowDialog();
            try
            {
                if (res == true)
                {
                    DataTable dttemp = imp.datareturn;
                    for (int i = 0; i < dttemp.Rows.Count; i++)
                    {
                        DataTable dtmp = (new DAO.Database()).Select("SELECT * FROM CHUYENNGANH WHERE MACHUYENNGANH = '" + dttemp.Rows[i]["MACHUYENNGANH"] + "'");
                        if (dtmp.Rows.Count > 0)
                        {
                            if (imp.tuychinh == "capnhat")
                                (new DAO.Database()).Query("UPDATE CHUYENNGANH SET TENCHUYENNGANH = '" + dttemp.Rows[i]["TENCHUYENNGANH"] + "', MOTA = '" + dttemp.Rows[i]["MOTA"] + "', MAKHOA = '" + dttemp.Rows[i]["MAKHOA"] + "' WHERE MACHUYENNGANH = '" + dttemp.Rows[i]["MACHUYENNGANH"] + "'");
                        }
                        else
                        {
                            (new DAO.Database()).Query("INSERT INTO CHUYENNGANH VALUES('" + dttemp.Rows[i]["MACHUYENNGANH"] + "','" + dttemp.Rows[i]["TENCHUYENNGANH"] + "','" + dttemp.Rows[i]["MOTA"] + "','" + dttemp.Rows[i]["MAKHOA"] + "')");
                        }
                    }
                    Init();
                    MessageBox.Show("Import thành công!");
                }
            }
            catch
            {
                MessageBox.Show("Import không thành công! Xin hãy kiểm tra lại dữ liệu!");
            }
        }

        private void cmdexport_Click(object sender, RoutedEventArgs e)
        {
            DataTable dtie = (new DAO.Database()).Select("SELECT MACHUYENNGANH as MÃ_CHUYÊN_NGÀNH,TENCHUYENNGANH as TÊN_CHUYÊN_NGÀNH, CHUYENNGANH.MAKHOA AS MÃ_KHOA,TENKHOA AS TÊN_KHOA,MOTA AS MÔ_TẢ FROM CHUYENNGANH, KHOA WHERE CHUYENNGANH.MAKHOA=KHOA.MAKHOA");
            BUS.Bus.Export(dtie, "ChuyenNganh");
        }

    }
}
