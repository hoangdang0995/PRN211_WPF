   M S B A M L   `   `   `  ????   GUI    GUI.frm_KetQuaTheoLopHoc   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v22.1, Version=22.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     a ]DevExpress.Xpf.Grid.v22.1, Version=22.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af bDevExpress.Xpf.Grid.v22.1.Core, Version=22.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   -     ? 	Resources   ?? MergedDictionaries ?? Source??  ?? $ /Resources/Button.xaml??%    .???  ? RowDefinitions ?? $??50 ??? .+???  ?? Orientation$ 
Horizontal=?$??0??.+??? $??30??$??13(?$
??Left=?$??5 0 0 0q?$??Center=?Chọn Khoa :?? -    ??Name$ cbx_khoa??$??30??$??13(?$	??200??$??5 0 0 0q?$
??Left=?$??Center=? ?? 
IsReadOnly . ?? $??30??$??13(?$??5 0 0 0q?$
??Left=?$??Center=?Chọn Ngành:?? -   $ cbx_chuyennganh??$??30??$??13(?$	??180??$??5 0 0 0q?$
??Left=?$??Center=? . ?? $??30??$??13(?$??5 0 0 0q?$
??Left=?$??Center=?Chọn Lớp Học :?? -   $ 
cbx_lophoc??$??30??$??13(?$	??160??$??5 0 0 0q?$
??Left=?$??Center=? . ?? -   $??cmd_HienThiDS??$??30??   ButtonStyle#??[  $??13(?$	??100??$??10 0 0 0q?.??Hiển thị DS?? -   $??
cmd_XuatDS??$??30??#??[  $??13(?$	??100??$??10 0 0 0q?.??Xuất tập tin%  DevExpress.Xpf.Grid.GridControl  -   $??
gctrl_diem??$??1??)  #DevExpress.Xpf.Grid.DataControlBase   AutoPopulateColumns .  $??0,0,12,0q?   AllowColumnMRUFilterList . 	   AllowMRUFilterList	 . 
   IsFilterEnabled
 .    ShowLoadingPanel .     
ShowBorder .     AutoExpandAllGroups .    IsRecursiveExpand .  (   !DesignTimeUseDistinctSampleValues .    DesignTimeShowSampleData . {?.    Columns $  DevExpress.Xpf.Grid.GridColumn  $  DevExpress.Xpf.Grid.ColumnBase   	FieldName$ 
MABANGDIEM??$  DevExpress.Xpf.Grid.BaseColumn   Header)  #DevExpress.Xpf.Core.ObjectConverter$ MÃ BẢNG ĐIỂM    ReadOnly .    Visible .    $ 
MASINHVIEN??$ MÃ SINH VIÊN  .    VisibleIndex$ 0??  $ HOTENSINHVIEN??$ HỌ TÊN SINH VIÊN  . $ 1??  $ 
DIEMGIUAKY??$ ĐIỂM GIỮA KỲ $ 2??  $ 
DIEMCUOIKY??$ ĐIỂM CUỐI KỲ $ 3??  $ 
DIEMTHILAI??$ ĐIỂM THI LẠI $ 4??  $	 DTB??$ TỔNG KẾT MÔN $ 5??  $ KQ??$ GHI CHÚ $ 6??   View #  DevExpress.Xpf.Grid.TableView  -   $??
tableView1??&   DevExpress.Xpf.Grid.DataViewBase   ShowTotalSummary . 