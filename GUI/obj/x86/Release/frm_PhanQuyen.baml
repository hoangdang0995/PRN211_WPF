   M S B A M L   `   `   `  ????   GUI    GUI.frm_PhanQuyen   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v22.1, Version=22.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     a ]DevExpress.Xpf.Grid.v22.1, Version=22.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af bDevExpress.Xpf.Grid.v22.1.Core, Version=22.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  -     ? Title$  PHÂN QUYỀN SỬ DỤNG??$	??600??$	??600??$	??790??$	??790?? ? 	Resources  ?? MergedDictionaries ?? Source??  ?? $ /Resources/Button.xaml??%    .???  ? RowDefinitions ?? $??50 ??? .+???  ?? Orientation$ 
Horizontal=?$??0??.+??? $??30??$??16(?$
??Left=?$??5 0 0 0q?$??Center=?Mã loại người dùng :?? -    ??Name$ 	txtMaLoai??$??30??$	??150??$??10 0 0 0q?$
??Left=?$??Center=?$??16(? ?? 
IsReadOnly . ?? $??30??$??16(?$??30 0 0 0q?$
??Left=?$??Center=?Tên loại người dùng :?? -   $ 
txttenloai??$??30??$	??150??$??10 0 0 0q?$
??Left=?$??Center=?$??16(? . ?? -   $??cmdluu??$??30??   ButtonStyle#??[  $??16(?$	??100??$??10 0 0 0q?.??Lưu%  DevExpress.Xpf.Grid.GridControl  -   $??gctrl_phanquyen??)  #DevExpress.Xpf.Grid.DataControlBase   AutoPopulateColumns . $
??Left=?$??1??$	??770??	   Columns	 $  DevExpress.Xpf.Grid.GridColumn  -   $  DevExpress.Xpf.Grid.BaseColumn
  Name$
 MODULE??$  DevExpress.Xpf.Grid.ColumnBase   	FieldName$ MODULE??   Header)  #DevExpress.Xpf.Core.ObjectConverter$ 
Màn hình   -   $

 NAME??$ KICHHOAT??$ Kích hoạt    EditSettings 7  1DevExpress.Xpf.Editors.Settings.CheckEditSettings    -   $	
 Add??$
 THEM??$ Thêm    	SortIndex$ 0??   	SortOrder] YDevExpress.Data.v22.1, Version=22.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a9  3DevExpress.Data.Design.ColumnSortOrderTypeConverter$ 
Descending      -	   $

 Edit??$ Sửa $	 SUA??     -
   $
 Delete??$
 Xoá $	 XOA??      View #	  DevExpress.Xpf.Grid.TableView	  -   $??
tableView1??&
   DevExpress.Xpf.Grid.DataViewBase 
  ShowTotalSummary . 