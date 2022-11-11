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
using DevExpress.Xpf.Docking;
using System.Data;
namespace GUI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	using setting = Properties.Settings;
	using DevExpress.Xpf.Docking;
	public partial class frm_HeThongQuanLy : Window
	{
		public static DataTable dtquyen;

		public static int timtenformtrongdt(string tenmodun, DataTable dt)
		{
			for(int i = 0; i < dt.Rows.Count; i++)
			{
				if(dt.Rows[i]["MODULE"].ToString().Equals(tenmodun))
				{
					return i;
				}
			}
			return -1;
		}

		public string TenND { get { return setting.Default.tennguoidung; } }
		public frm_HeThongQuanLy()
		{
			InitializeComponent();
			this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
		}

		void MainWindow_Loaded(object sender, RoutedEventArgs e)
		{
			//role();
		}

		private void ShowUserControl(string title, UserControl wd)
		{
			DocumentGroup documentGroup = dockManagerMainForm.GetItem("dockManagerMainForm") as DocumentGroup;
			if(documentGroup == null)
			{
				documentGroup = dockManagerMainForm.DockController.AddDocumentGroup(DevExpress.Xpf.Layout.Core.DockType.Left); // create the if necessary
				documentGroup.Name = "dockManagerMainForm";
			}
			LayoutPanel panel = dockManagerMainForm.DockController.AddDocumentPanel(documentGroup);  // сreate a panel in the document group
			panel.Content = wd;
			panel.Caption = title;
			panel.ShowCloseButton = true;
			panel.ShowCaption = true;
			panel.CaptionAlignMode = CaptionAlignMode.AlignInGroup;

			this.dockManagerMainForm.DockController.Activate(panel);
		}

		private void cmd_ThongTinTK_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
		{
			ShowUserControl("Thông tin tài khoản", G_system.Show("frm_ThongTinTaiKhoan", "GUI"));
		}

		private void cmd_DangNhap_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
		{
			login();
		}

		void login()
		{
			frm_DangNhap _dangnhap = new frm_DangNhap();
			var res = MessageBox.Show("Bạn có muốn thoát chương trình không?", "Thông báo", MessageBoxButton.YesNo);
			if(res == MessageBoxResult.Yes)
			{
				_dangnhap.Show();
				this.Close();
			}
		}

		private void cmd_SinhVien_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
		{
			ShowUserControl("Sinh Viên", G_system.Show("frm_Sinhvien", "GUI"));
		}

		private void cmd_Thoat_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
		{
			var res = MessageBox.Show("Bạn có muốn thoát chương trình không?", "Thông báo", MessageBoxButton.YesNo);
			if(res == MessageBoxResult.Yes)
			{
				this.Close();
			}
		}

		private void cmd_xemDiem_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
		{
			ShowUserControl("Xem Điểm", G_system.Show("frm_xemDiem", "GUI"));
		}
	}
}
