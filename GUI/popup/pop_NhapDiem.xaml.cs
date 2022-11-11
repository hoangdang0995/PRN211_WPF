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
using DAO;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace GUI.popup
{
	/// <summary>
	/// Interaction logic for pop_NhapDiem.xaml
	/// </summary>
	public partial class pop_NhapDiem : Window
	{
		const string C_ADD = "add";
		const string C_EDIT = "edit";
		String id;
		String type = "";
		public pop_NhapDiem()
		{
			id = null;
			type = C_ADD;
			InitializeComponent();
		}

		public pop_NhapDiem(String id)
		{
			this.id = id;
			type = C_EDIT;
			InitializeComponent();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			Init();
		}

		private void Init()
		{
			Init_Sinhvien();
		}

		private void Init_Sinhvien()
		{
			if(type == C_ADD)
			{
				initInAddMode();
			} else if(type == C_EDIT)
			{
				initInEditMode();
			}
		}

		private void cmdDongY_Click(object sender, RoutedEventArgs e)
		{
			//2 cai combobox sau cũng vậy
			string _masv = ((StackPanel)cbo_TenSinhVien.SelectedItem).Tag.ToString();
			string diem1 = txt_diem1.Text;
			string diem2 = txt_diem2.Text;
			string diem3 = txt_diem3.Text;

			StringBuilder sb = checkInput();
			if(sb.Length != 0)
			{
				MessageBox.Show(sb.ToString());
				return;
			}

			if(type == C_ADD)
			{
				StringBuilder query = new StringBuilder();
				query.Append("INSERT INTO ");
				query.Append("	BANGDIEM(MASINHVIEN, DIEMTHUCHANH1, DIEMTHUCHANH2, DIEMTHUCHANH3) ");
				query.Append("VALUES( ");
				query.Append("'" + _masv + "', ");
				query.Append("'" + diem1 + "', ");
				query.Append("'" + diem2 + "', ");
				query.Append("'" + diem3 + "' );");

				(new DAO.Database()).Query(query.ToString());
			}
			else if(type == C_EDIT)
			{
				StringBuilder query = new StringBuilder();
				query.Append("UPDATE ");
				query.Append("	BANGDIEM ");
				query.Append("SET ");
				query.Append("	MASINHVIEN = '" + _masv + "', ");
				query.Append("	DIEMTHUCHANH1 = '" + diem1 + "', ");
				query.Append("	DIEMTHUCHANH2 = '" + diem2 + "', ");
				query.Append("	DIEMTHUCHANH3 = '" + diem3 + "' ");
				query.Append("WHERE ");
				query.Append("	MABANGDIEM = " + id);

				(new DAO.Database()).Query(query.ToString());
			}
			this.DialogResult = true;
			Close();
		}

		private void cmdExit_Click(object sender, RoutedEventArgs e)
		{
			this.DialogResult = false;
			Close();
		}

		public StringBuilder checkInput()
		{
			StringBuilder sb = new StringBuilder();

			int errIndex = 1;

			try
			{
				if(
					string.IsNullOrEmpty(txt_diem1.Text)
					|| string.IsNullOrEmpty(txt_diem2.Text)
					|| string.IsNullOrEmpty(txt_diem3.Text)
				)
				{
					return sb.Append("VUI LÒNG NHẬP ĐẦY ĐỦ THÔNG TIN");
				}
				Int32.Parse(txt_diem1.Text);
				errIndex++;
				Int32.Parse(txt_diem2.Text);
				errIndex++;
				Int32.Parse(txt_diem3.Text);
				errIndex = 0;
			}
			catch(Exception ex)
			{
				return sb.Append("ĐIỂM THỰC HÀNH " + errIndex.ToString() + " PHẢI LÀ SỐ");
			}

			return sb;
		}
		
		public void initInAddMode()
		{
			StringBuilder sql = new StringBuilder();
			sql.Append("SELECT SV.MASINHVIEN, SV.HOTENSINHVIEN, SV.GIOITINH, SV.NGAYSINH ");
			sql.Append("  FROM SINHVIEN SV ");
			sql.Append("WHERE ");
			sql.Append("	SV.MASINHVIEN NOT IN ( ");
			sql.Append("		SELECT BD.MASINHVIEN FROM BANGDIEM BD ");
			sql.Append("	) ");
			//DataTable dt = (new DAO.Database()).Select("SELECT MASINHVIEN, HOTENSINHVIEN,GIOITINH,NGAYSINH FROM SINHVIEN");
			DataTable dt = (new DAO.Database()).Select(sql.ToString());
			for(int i = 0; i < dt.Rows.Count; i++)
			{
				StackPanel _stptemp = new StackPanel();

				TextBlock _txtmsv = new TextBlock();
				_txtmsv.Text = dt.Rows[i]["MASINHVIEN"].ToString();

				TextBlock _txthotensv = new TextBlock();
				_txthotensv.Text = "Họ tên sinh viên : " + dt.Rows[i]["HOTENSINHVIEN"].ToString();

				TextBlock _txtgioitinh = new TextBlock();
				_txtgioitinh.Text = "Giới tính : " + dt.Rows[i]["GIOITINH"].ToString();

				TextBlock _txtngaysinh = new TextBlock();
				_txtngaysinh.Text = "Ngày sinh : " + dt.Rows[i]["NGAYSINH"].ToString();


				if(i % 2 == 0)
					_stptemp.Background = Brushes.Khaki;

				_stptemp.Width = 350;

				_stptemp.Children.Add(_txthotensv);
				_stptemp.Children.Add(_txtmsv);
				_stptemp.Children.Add(_txtgioitinh);
				_stptemp.Children.Add(_txtngaysinh);
				_stptemp.Tag = dt.Rows[i]["MASINHVIEN"].ToString();
				cbo_TenSinhVien.Items.Add(_stptemp);
			}
			if(dt.Rows.Count != 0)
				cbo_TenSinhVien.SelectedIndex = 0;
		}

		public void initInEditMode()
		{
			StringBuilder sql = new StringBuilder();
			sql.Append("SELECT ");
			sql.Append("	BD.MASINHVIEN, ");
			sql.Append("	BD.MABANGDIEM, ");
			sql.Append("	BD.DIEMTHUCHANH1, ");
			sql.Append("	BD.DIEMTHUCHANH2, ");
			sql.Append("	BD.DIEMTHUCHANH3, ");
			sql.Append("	SV.MASINHVIEN, ");
			sql.Append("	SV.HOTENSINHVIEN, ");
			sql.Append("	SV.GIOITINH, ");
			sql.Append("	SV.NGAYSINH ");
			sql.Append("FROM ");
			sql.Append("	BANGDIEM BD, ");
			sql.Append("	SINHVIEN SV ");
			sql.Append("WHERE ");
			sql.Append("	MABANGDIEM = " + id + " ");
			sql.Append("	AND  BD.MASINHVIEN = SV.MASINHVIEN ");
			DataTable dt = (new DAO.Database()).Select(sql.ToString());
			if(dt.Rows.Count > 0)
			{
				// add to first combobox when init
				StackPanel _stptemp = new StackPanel();

				TextBlock _txtmsv = new TextBlock();
				_txtmsv.Text = dt.Rows[0]["MASINHVIEN"].ToString();

				TextBlock _txthotensv = new TextBlock();
				_txthotensv.Text = "Họ tên sinh viên : " + dt.Rows[0]["HOTENSINHVIEN"].ToString();

				TextBlock _txtgioitinh = new TextBlock();
				_txtgioitinh.Text = "Giới tính : " + dt.Rows[0]["GIOITINH"].ToString();

				TextBlock _txtngaysinh = new TextBlock();
				_txtngaysinh.Text = "Ngày sinh : " + dt.Rows[0]["NGAYSINH"].ToString();

				_stptemp.Width = 350;

				_stptemp.Children.Add(_txthotensv);
				_stptemp.Children.Add(_txtmsv);
				_stptemp.Children.Add(_txtgioitinh);
				_stptemp.Children.Add(_txtngaysinh);
				_stptemp.Tag = dt.Rows[0]["MASINHVIEN"].ToString();
				cbo_TenSinhVien.Items.Add(_stptemp);
				cbo_TenSinhVien.SelectedIndex = 0;

				txt_diem1.Text = dt.Rows[0]["DIEMTHUCHANH1"].ToString();
				txt_diem2.Text = dt.Rows[0]["DIEMTHUCHANH2"].ToString();
				txt_diem3.Text = dt.Rows[0]["DIEMTHUCHANH3"].ToString();
			}
			txt_diem1.Focus();
		}
	}
}
