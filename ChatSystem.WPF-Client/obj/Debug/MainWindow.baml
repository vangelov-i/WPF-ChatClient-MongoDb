   M S B A M L   `   `   `  ����P  LChatSystem.WPF-Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:ChatSystem.WPF_ClientChatSystem.WPF_Client  5   	   &     ChatSystem.WPF_Client.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:ChatSystem.WPF_Client     5   	     � Title$  mIRK-ata��5   	   $��211.364��6   $��312.288��6+    � WindowStartupLocation$ CenterScreen=�6;    � 
ResizeMode$ NoResize=�6`   .��5	      � $��0,0,-8,2q�6    � ColumnDefinitions 5
   
   �� 5      $	��73* �6   �� 5      $	��24* �6   �� 5      $
��135* �6   ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ Black��6    � Offset$ 0Q�6-   � 5      $ White��6   $ 1Q�6-   5      .+�5   
   �� -   5         ��Name$ btnLogin��5      $��Login��6#   $
��Left=�63   $��
10,125,0,0q�6N   $	��Top=�6b   $��87��6z   	 J� RenderTransformOrigin$	 
0.705,0.64&�6�   $��2��6�   $��1��6�   $��42��6�   $��16(�6�   $
��Bold"�6�   �� 5   
   -   5        
 ��Name$
 
tbUsername��5      $
��Left=�6&   $��35��6A   $��	10,23,0,0q�6M    �� TextWrapping$
 Wrap=�6`   $	��Top=�6t   $	��178��6�   $��2��6�   $��1��6�   $��18.667(�6�   $
��Bold"�6�   �� 5   
   -   5         ��Name$ labelUsername��5      $��	Username:��6'   $
��Left=�6;   $��0,23,0,0q�6V   $	��Top=�6h   
�������$
��Bold"�6�   $	��120��6�   $��18.667(�6�   $��2��6�   �� 5   
   -   5        $ btnRegister��5      $��Register��6&   $��Right=�69   $��
0,125,10,0q�6U   $	��Top=�6i   $��87��6�   $��2��6�   $��42��6�   $��16(�6�   $
��Bold"�6�   �� 5   
   -   5        $ labelPassword��5      $��	Password:��6'   $
��Left=�6;   $��0,74,0,0q�6V   $	��Top=�6h   
�������$
��Bold"�6�   $	��120��6�   $��18.667(�6�   $��2��6�   G� 5   
   -   5         G�Name$ tbPasswordBox��5      $
��Left=�6-   $��	10,74,0,0q�6H   $	��Top=�6[   $	 
-3.7,-0.35&�6s   $	��178��6�   $��35��6�   $��2��6�   $��1��6�   $��18.667(�6�   $
��Bold"�6�   5      5      