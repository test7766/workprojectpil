   M S B A M L   `   `   `  ����Q  MFindRestOfItemsWindows, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:FindRestOfItemsWindows.ClassHelper"FindRestOfItemsWindows.ClassHelper  5   	   '    !FindRestOfItemsWindows.MainWindow   5   	   a ]DevExpress.Xpf.Core.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5   
   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5   	   f bDevExpress.Xpf.Grid.v17.1.Core, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa ]DevExpress.Xpf.Grid.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   5   	   <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  5   	   d `DevExpress.Xpf.Docking.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a@dxdo5http://schemas.devexpress.com/winfx/2008/xaml/docking  5	   	   ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5
   	   =local10clr-namespace:FindRestOfItemsWindows.ClassHelper  5   	   -   5        $��FindRestOfItemsMain��5        � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � DataContext 5      H   BFindRestOfItemsWindows.ClassHelper.INotifyPropertyChangedTestClass  5   
    � 	Resources 5       �� MergedDictionaries �� Source�� 5!   
    5"      �� 5#      $! Resource/MyDictionary1.xaml?�6%   %    5%      .��5�      �  � ShowGridLines .   � RowDefinitions 5�   
   �� 5�      $
��auto �6   �� 5�      $
��auto �6   �� 5�      $
��auto �6   �� 5�      $
��auto �6   �� 5�      $��* �6   .+�5�   
   .  (DevExpress.Xpf.Docking.DockLayoutManager     
LayoutRoot. 5�      (  "DevExpress.Xpf.Docking.LayoutGroup  $��0��6      Orientation$ Vertical=�6,   	   Items.	 5�      (  "DevExpress.Xpf.Docking.LayoutPanel  +  %DevExpress.Xpf.Docking.BaseLayoutItem
   ShowCaption
 .     Caption$D >Параметри пошуку руху по залишкам��67      ShowCloseButton .     ShowPinButton .     	AllowMove .     
AllowFloat .  (  "DevExpress.Xpf.Docking.ContentItem   Content. 5�      �  5�      �� 5�      $
��Auto �6,   �� 5�      $��* �6,   .+�5�      (  "DevExpress.Xpf.Bars.ToolBarControl  ,  &DevExpress.Xpf.Bars.ToolBarControlBase   BarItemDisplayMode$ ContentAndGlyph=�6-      UseWholeRow .    ShowDragWidget .     AllowCustomizationMenu .     	AllowHide .     AllowQuickCustomization .     Items. 5�      '	  !DevExpress.Xpf.Bars.BarButtonItem	  -   5        !
  DevExpress.Xpf.Bars.BarItem 
  Content)  #DevExpress.Xpf.Core.ObjectConverter$ Очистити 5�   0    
  RibbonStyle$ Default=�5�   4    
  GlyphAlignment$
 Left=�6J    
  Glyph 5�   D   *  $DevExpress.Xpf.Core.DXImageExtension     Image1  +DevExpress.Xpf.Core.Native.DXImageConverter$ ClearTableStyle_16x16.png  
  
LargeGlyph 5�   4     $ ClearTableStyle_32x32.png 5�   4   	  5�      -   5         	 Name$ BTN_Search_REST��5�   0   $ 
Пошук 6I    
  BarItemDisplayMode$ ContentAndGlyph=�6Y    5�   R     $ Find_32x32.png  6�     $ Find_16x16.png 	  5�      -   5          �Name$  btnExportDetails��5�   B   $ Експорт 60   ! � ToolTip$=! 7Зберегти переміщення в файл XLS��6Z    5�   0     $ ExportToXLS_16x16.png  6a     $ ExportToXLS_32x32.png 5�        5�      -   5        "  Name$" criteriaGroups��5�   +   $��1��6C   $ 
Horizontal=�6P   .	 5�        $y�Visible=�6/   $! По соглашениям��6D   $ Vertical=�6]   .	 5�   "     $ 
Horizontal=�63   
 .  #   
ItemHeight$
# Auto �6`   .	 5�   &   .  (DevExpress.Xpf.Docking.LayoutControlItem  $ 
Склад��6=   $
# Auto �6M   $   	ItemWidth$	$ 50* �6_   . 5�   *   %  DevExpress.Xpf.Editors.TextEdit  -   5        %  Name$% 
txtEditMCU��5�   7   %  DevExpress.Xpf.Editors.BaseEdit&   
IsReadOnly& . 6K   5�   '     5�   &   $ Код товару��6=   $
# Auto �6R   $	$ 50* �6d   . 5�   *     -   5        $% 
txtEditITM��5�   7   & . 6K   5�   '   5�   #     5�   "   $ 
Horizontal=�63   
 .  $
# Auto �6`   .	 5   &     $ 
Місце��6=   $
# Auto �6M   $	$ 50* �6_   . 5  *     -   5        $% txteditLOCN��5  8   5  '     5  &   $ Партія��6=   $
# Auto �6N   $	$ 50* �6`   . 5  *     -	   5        $% txtEditLOTN��5  7   5  '   5  #   5     5     �� 5	     $��Center=�6"   $	��200��6=   $��30��6I   
���������6U   �� *CustomerName+' �� RelativeSource' �� *FindAncestor+( �� AncestorType"( �) �� UpdateSourceTrigger$) PropertyChanged=�6�     5     -
   5        $��textBox��5  '   *   NullText$!* INotifyPropertyChangedLocal��66   $	��200��6^   $��30��6j   $��
492,5,92,5q�6  )  #DevExpress.Xpf.Editors.TextEditBase+   Text+ 6v   �� *CustomerName+' �� *FindAncestor+"( �, �� Mode$, TwoWay=�$) PropertyChanged=�6  5     5     5     5     � 5  
   $��2��6   .+�5     �� $��Center=�6   $
��Left=�64   - �� Orientation$- 
Horizontal=�6O   .+�5     �� $��Center=�6   $	��200��65   $��30��6A   
���������6M   �� *
AgeValue+$) PropertyChanged=�6�     5     -   5        $��textBox1��5     $#* INotifyPropertyChangedOutside��6/   $	��200��6Y   $��30��6e   + 6q   �� *
AgeValue+$, TwoWay=�$) PropertyChanged=�  5     -   5        $��textBox2��5     $	��200��6/   $��30��6;   + 6G   �� *Doc_Co+$, TwoWay=�$) PropertyChanged=�  5     -   5        $��textBox3��5     $	��200��6/   $��30��6;   
�������+ 6[   �� *Document_Number+$, TwoWay=�$) PropertyChanged=�5     5     � 5  
   -   5        . �Name$. PanelFiltrPagination��5     $��3��6   {�.  .+�5!     �� $��Right=�6   $��Bottom=�65   $- 
Horizontal=�6P   .+�5"       $	��100��6   /   	EditValue/ 6,   �� *NecessaryField+0 �� ElementName$0 FindRestOfItemsMain��$, TwoWay=�$) PropertyChanged=�  5$     1   MaskUseAsDisplayFormat1 . $* DependencyPropertyLocal��6B   $��Normal"�6e   2   MaskIgnoreBlank2 .  3   MaskCulture$3 ru-RU��5&  @   4   AllowNullInput4 . 
�������/ 5%  '   �� *NecessaryField+$0 FindRestOfItemsMain��$, TwoWay=�$) PropertyChanged=�5&  j   &   DevExpress.Xpf.Editors.CheckEdit  5*     -   5        5  Name$5 CheckMax��5*      6 � ToolTip$�6 |деактивація/активація кількість відображення елементів на сорінці��62   7   	IsChecked$7 FalseY�6~   $��0 0 5 0q�6�   8   Content$8 кількість 6�   %  DevExpress.Xpf.Editors.SpinEdit  5+     -   5        9  Name$9 
SplitEdita��5+     $d6 ^кількість елементів, що відображаються на сторінці��63   $��50��6p   $/ 5 6{   :   	Increment$: 1~�6�   ;   MinValue$; 5X�6�   <   MaxValue$	< 500X�6�   =   AllowSpinOnMouseWheel= .  6�     5,     $ ContentAndGlyph=�6%    .  .   .   .   .  . 5-     	  -   5        $ ShowUsercount��5-  (   $ Default=�6m   $
 Left=�6�   $
 ОК 6�    6B     $ Apply_16x16.png 6�   *  $DevExpress.Xpf.Bars.BarItemSeparator  5.     	  5/     -   5        $ ResetUserSearch��5/  (   $ Default=�6   $
 Left=�6�   $ скинути пошук 6�    6D     $% ResetModelDifferences_16x16.png 6�     50     51       53     $ 
Horizontal=�6#   
 .  $
# Auto �6P     54     -   5        >  Name$> tolbarArrow��54  %   $ ContentAndGlyph=�6:    .  .   .   .   .  . 55     	  -   5        $ BTN_Home_Name��55  )   $ Default=�6r   $
 Left=�6�   ? �� 	IsEnabled? .   6B     $ DoublePrev_16x16.png 6�   	  56     -   5        $ BTN_Previous_Name��56  )   $ Default=�6p   $
 Left=�6�   ? .   6F     $ Prev_16x16.png 6�   	  57     -   5        $ BTN_Next_Name��57  )   $ Default=�6l   $
 Left=�6�    6B     $ Next_16x16.png 6�   	  58     -   5        $ BTN_End_Name��58  )   $ Default=�6o   $
 Left=�6�    6?     $ DoubleNext_16x16.png 6�   59     �� 5:     -   5        @ ��Name$@ pageInfoText��5:     $��Center=�62   $	��5,0q�6M   5<     5=     � 5C  
   $��4��6   .+�5D       
 .  $ 
Склад��63   $	# 65* �6D    .   .  . 5E     %  DevExpress.Xpf.Grid.GridControl  -   5        A  Name$A ItemsMoveRest��5E  "   
B J� Uid$*B $55B558D8-70B2-47E7-9527-DF3C48759AC0��6:   )  #DevExpress.Xpf.Grid.DataControlBaseC   ClipboardCopyMode$C ExcludeHeader=�6e   {�. D   AllowMRUFilterListD .  E   AllowColumnMRUFilterListE .  F   IsFilterEnabledF .  G   ViewG 5F     #  DevExpress.Xpf.Grid.TableView  5G     H   ShowAutoFilterRowH .  &   DevExpress.Xpf.Grid.DataViewBaseI   AllowSortingI .  &   DevExpress.Xpf.Grid.GridViewBaseJ   ShowGroupPanelJ .  K   AllowEditingK .  L   BestFitMode$L Default=�5K  %   M   AllowBestFitM . N   	AutoWidthN .  O   ShowDataNavigatorO . P   AllowColumnFilteringP .  Q   AllowFilterEditorQ .  R   AutoScrollOnSortingR .  S   AllowGroupingS .  T   AllowFixedGroups]	 YDevExpress.Data.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a5 	 /DevExpress.Utils.Design.DefaultBooleanConverter$T False 5S  %   U   AllowColumnMovingU .  5T  %   V   ColumnsV 5V     $  DevExpress.Xpf.Grid.GridColumn  5W     -   5        W  Name$W Document_Number��5W  ^   $  DevExpress.Xpf.Grid.BaseColumnX   Header$#X Номер документу 6)   $  DevExpress.Xpf.Grid.ColumnBaseY   	FieldName$Y Document_Number��6B    !  Document_NumberHeaderTemplateZ   HeaderTemplate#Z [  6y   [   AllowSorting$[ False 6�   \   AllowAutoFilter\ .  ]   AllowGrouping$] False 6�     5X     -   5        $W Doc_Type��5X  U   $X Тип документу 6)   $Y Doc_Type��6@     Doc_TypeHeaderTemplate#Z [ 6g   $[ False 6�   \ .  $] False 6�     5Y     $)X #Компанія документу 6)   $Y Doc_Co��6E     Doc_CoHeaderTemplate#Z [ 6X   $[ False 6�   \ .  $] False 6�     5Z     $X Дата операції 6)   $Y Transaction_Date��6@    " Transaction_DateHeaderTemplate#Z [ 6]   $[ False 6�   \ .  $] False 6�     5[     $X Код складу 6)   $Y Branch_Plant��6=     Branch_PlantHeaderTemplate#Z [ 6V   $[ False 6�   \ .  $] False 6�     5\     $X Кількість 6)   $Y Quantity��6<     QuantityHeaderTemplate#Z [ 6Q   $[ False 6�   \ .  $] False 6�     5]     $X Од. виміру 6)   $Y 	Trans_UoM��6=     Trans_UoMHeaderTemplate#Z [ 6S   $[ False 6�   \ .  $] False 6�     5^     $X Вартість, грн 6)   $Y 	Unit_Cost��6@     Unit_CostHeaderTemplate#Z [ 6V   $[ False 6�   \ .  $] False 6�     5_     $X Партія 6)   $Y 
Lot_Serial��69     Lot_SerialHeaderTemplate#Z [ 6P   $[ False 6�   \ .  $] False 6�     5`     $X 
Місце 6)   $Y Location��68    	 LocationHeaderTemplate#Z [	 6M   $[ False 6�   \ .  $] False 6�     5a     $(X "Код статусу партії 6)   $Y Lot_Status_Code��6E    !
 Lot_Status_CodeHeaderTemplate#Z [
 6b   $[ False 6�   \ .  $] False 6�     5b     $%X Номер замовлення 6)   $Y Order_Number��6C   #Z [
 6\   $[ False 6�   \ .  $] False 6�     5c     $!X Тип замовлення 6)   $Y Order_Ty��6A     Order_TyHeaderTemplate#Z [ 6V   $[ False 6�   \ .  $] False 6�     5d     $+X %Компанія замовлення 6)   $Y Order_Co��6F     Order_CoHeaderTemplate#Z [ 6[   $[ False 6�   \ .  $] False 6�     5e     $X Номер рядка 6)   $Y LineNum��6>     LineNumHeaderTemplate#Z [ 6R   $[ False 6�   \ .  $] False 6�     5f     $X Клас ГК 6)   $Y 
Class_Code��6:     Class_CodeHeaderTemplate#Z [ 6Q   $[ False 6�   \ .  $] False 6�     5g     $X Дата ГК 6)   $Y GL_Date��6:     GL_DateHeaderTemplate#Z [ 6N   $[ False 6�   \ .  $] False 6�     5h     $X 
Серія 6)   $Y Supplier_Lot_Number��68    % !Supplier_Lot_NumberHeaderTemplate#Z [ 6X   $[ False 6�   \ .  $] False 6�     5i     $X Опис операції 6*   $
Y Trex��6A     TrexrHeaderTemplate#Z [ 6R   $[ False 6�   \ .  $] False 6�   ^   Width2  ,DevExpress.Xpf.Grid.GridColumnWidthConverter$	^ 150 6�     5j     $X З/на 6)   $Y FT��67     FTHeaderTemplate#Z [ 6F   $[ False 6y   \ .  $] False 6�   5l     5m     '  !DevExpress.Xpf.Core.WaitIndicator  5n     -   5        $%��FindRestOfItemLoadingDecorator1��5n      $.��(Завантаження данних...��6G   _   DeferedVisibility_ .  $��Center=�6�   $��Center=�6�   ��5o     �� 5p     .R�5q     �� $- Vertical=�6%   .+�5r     �� $,��&Зачекайте будь ласка��6(   $��20(�6D   �� 5s     ��6(   �� 5t     5u     5w     5x     5~     5     