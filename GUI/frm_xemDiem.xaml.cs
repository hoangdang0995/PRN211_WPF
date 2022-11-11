using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GUI
{
	/// <summary>
	/// Interaction logic for frm_xemDiem.xaml
	/// </summary>
	public partial class frm_xemDiem : UserControl
	{
		public frm_xemDiem()
		{
			InitializeComponent();
		}

		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			Load_BangDiem();
			View.Commands.ShowSearchPanel.Execute(null);
		}

		private void Load_BangDiem()
		{
			Init();
		}

		private void Init()
		{
			DataTable dt = (new DAO.Database()).Select("SELECT BD.MABANGDIEM, SV.MASINHVIEN, SV.HOTENSINHVIEN, SV.EMAIL,  BD.DIEMTHUCHANH1, BD.DIEMTHUCHANH2, BD.DIEMTHUCHANH3 FROM SINHVIEN SV, BANGDIEM BD WHERE SV.MASINHVIEN = BD.MASINHVIEN");
			gctrl_xemDiem.ItemsSource = dt;
		}

		private void cmd_Add_Click(object sender, RoutedEventArgs e)
		{
			popup.pop_NhapDiem pop_NhapDiem = new popup.pop_NhapDiem();
			var res = pop_NhapDiem.ShowDialog();
			if(res == true)
			{
				Init();
			}
		}

		private void cmd_Edit_Click(object sender, RoutedEventArgs e)
		{
			popup.pop_NhapDiem pop_NhapDiem = new popup.pop_NhapDiem(gctrl_xemDiem.GetFocusedRowCellValue("MABANGDIEM").ToString());
			var res = pop_NhapDiem.ShowDialog();
			if(res == true)
			{
				Init();
			}
		}

		private void cmd_Delete_Click(object sender, RoutedEventArgs e)
		{
			var res = MessageBox.Show("Bạn có muốn xoá điểm của sinh viên tên '" + gctrl_xemDiem.GetFocusedRowCellValue("HOTENSINHVIEN") + "' có mã là '" + gctrl_xemDiem.GetFocusedRowCellValue("MASINHVIEN").ToString() + "' này không? \nNhấn YES để xoá - Nhấn NO để thoát.", "Thông báo", MessageBoxButton.YesNo);
			if(res == MessageBoxResult.Yes)
			{
				(new DAO.Database()).Query("DELETE FROM BANGDIEM WHERE MABANGDIEM = '" + gctrl_xemDiem.GetFocusedRowCellValue("MABANGDIEM").ToString() + "'");
				Init();
			}
		}
	}
}
