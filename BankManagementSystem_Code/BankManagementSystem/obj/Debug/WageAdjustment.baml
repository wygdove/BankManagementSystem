   M S B A M L   `   `   `  ����  BankManagementSystem)    #BankManagementSystem.WageAdjustment   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  StaffManagement��5      .��5	      �� ��5
   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FF382AC9��6    � Offset$ 0Q�61   � 5      $ 	#FFD6F1D0��6   $ 1.334Q�61   5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $
��show��5         AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows .  ���	#FFDDFBF9   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 员工姓名��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 100 6M   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *EName+6M     5      $	 工资��6%   $
 * 6M    61   �� *	ESalary+6M   5      �� 5   
   -   5        $��保存��5      $��70��6   $��0 10 0 0q�6)   6;   5      5      