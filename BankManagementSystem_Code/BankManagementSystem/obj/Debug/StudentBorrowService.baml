   M S B A M L   `   `   `  ����  BankManagementSystem/    )BankManagementSystem.StudentBorrowService   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  StudentBorrowService��5   	   $	��500��6&   $	��500��63   .��5      � $��0,0,0,-2q�6   $	��472��6   $	��Top=�6*    � ColumnDefinitions 5   
   �� 5      $
��442* �6   �� 5      $	��75* �6   ��5
   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FF382AC9��6    � Offset$ 0Q�61   � 5      $ 	#FFD6F1D0��6   $ 1.334Q�61   5      .+�5   
   �� $��学生借款中心��6   $��Center=�6!   $��48��6>   $��
146,0,57,0q�6J   $	��Top=�6^   $	��218��6v   $
��Bold"�6�   $��24(�6�    J� RenderTransformOrigin$ 0.017,-0.116&�6�   �� 5   
   -   5        $��	GroupBox1��5      $��学生基本信息��6%   $
��Left=�65   $	��186��6P   $��	68,39,0,0q�6]   $	��Top=�6p   $	��365��6�   $��2��6�   �� 5   
   $��姓名��6   $
��Left=�6   $��25��68   $��
115,63,0,0q�6D   $	��Top=�6X   $��38��6p   $
��Bold"�6{   �� 5   
   -   5        $��StuName��5      $
��Left=�6!   $��25��6<   $��
175,63,0,0q�6H    �� TextWrapping$
 Wrap=�6\   $	��Top=�6p   $	��209��6�   �� 5   
   $��身份证号��6   $
��Left=�6   $��25��6:   $��
100,93,0,0q�6F   $	��Top=�6Z   $��65��6r   $ -0.073,0.72&�6}   $
��Bold"�6�   �� 5   
   -   5        $��StuID��5      $
��Left=�6   $��25��6:   $��
175,93,0,0q�6F   $
 Wrap=�6Z   $	��Top=�6o   $	��209��6�   $ 
0.617,0.96&�6�   6�   �� 5   
   $��学校��6   $
��Left=�6   $��26��68   $��115,133,0,0q�6D   $	��Top=�6Y   $��38��6q   $
��Bold"�6|   �� 5   
   -   5        $��	StuSchool��5      $
��Left=�6#   $��26��6>   $��175,133,0,0q�6J   $	��Top=�6_   $	��209��6w   $ 0.515,0.208&�6�   �� 5   
   $��手机号码��6   $
��Left=�6   $��27��6:   $��100,175,0,0q�6F   $	��Top=�6[   $��65��6s   $
��Bold"�6~   �� 5   
   -   5        $��StuPhone��5      $
��Left=�6"   $��23��6=   $��175,179,0,0q�6I   $
 Wrap=�6^   $	��Top=�6s   $	��209��6�   �� 5   
   -   5        $��	GroupBox2��5      $��贷款信息��6$   $
��Left=�62   $	��116��6M   $��
68,247,0,0q�6Z   $	��Top=�6n   $	��365��6�   $��2��6�   �� 5   
   $��账户��6   $
��Left=�6   $��25��68   $��105,273,0,0q�6D   $	��Top=�6Y   $��65��6q   $ -0.073,0.72&�6|   $
��Bold"�6�   �� 5   
   -   5        $��	AccountId��5      $
��Left=�6#   $��25��6>   $��175,273,0,0q�6J   $
 Wrap=�6_   $	��Top=�6t   $	��209��6�   �� 5   
   $��借款金额��6   $
��Left=�6   $��25��6:   $��100,316,0,0q�6F   $	��Top=�6[   $��65��6s   $ -0.073,0.72&�6~   $
��Bold"�6�   �� 5    
   -   5        $��BorrowAmount��5       $
��Left=�6&   $��25��6A   $��175,316,0,0q�6M   $
 Wrap=�6b   $	��Top=�6w   $	��209��6�   �� 5"   
   -	   5        $��btnOk��5"      $��确认��6   $
��Left=�6?   $��31��6Z   $��146,389,0,0q�6f   $	��Top=�6{   $��60��6�   �� 5#   
   -
   5        $��	btnCancel��5#      $��取消��6"   $
��Left=�6G   $��31��6b   $��262,389,0,0q�6n   $	��Top=�6�   $��59��6�   5'      5)      