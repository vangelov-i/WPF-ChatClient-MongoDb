   M S B A M L   `   `   `  ����P  LChatSystem.WPF-Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:ChatSystem.WPF_ClientChatSystem.WPF_Client  5   	   &     ChatSystem.WPF_Client.ChatWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:ChatSystem.WPF_Client     5   	     � Title$  Chat Window��5   	   $��556.093��6   $��564.042��6.    � WindowStartupLocation$ CenterScreen=�6>   .��5	      � $��0,0,0,-3q�6    � ColumnDefinitions 5
   
   �� 5      $
��345* �6   �� 5      $
��211* �6   .+�5   
   �� -   5         ��Name$ tbCurrentMessage��5      $
��Left=�6,   $��30��6G   $��	0,489,0,0q�6S    �� TextWrapping$
 Wrap=�6f   $	��Top=�6z   $	��499��6�   ���	#FFDED6D6$��16(�6�   $
��Bold"�6�   $��2��6�   �� 5   
   -   5         ��Name$ lbChatHistory��5      $
��Left=�6)   $	��484��6D   $	��Top=�6Q   $	��547��6i   ���	#FFBFBCBC$��16(�6�   $
��Bold"�6�   $��2��6�   �� 5   
   -   5         ��Name$ btnSend��5      $
��Send��6"   $
��Left=�61   $��159,491,0,0q�6L   $	��Top=�6a   $��43��6y   $��1��6�   ��5      �� 5       �� EndPoint$	 0,1&�6&    �� 
StartPoint$	 0,0&�65   .��5      � 	 � Color$	 	#FFF3F3F3��6#   
 � Offset$
 0Q�65   � 5      $	 	#FFEBEBEB��6#   $	
 0.5Q�65   � 5      $	 	#FFDDDDDD��6#   $	
 0.5Q�65   � 5      $	 	#FF6AE233��6#   $
 1Q�65   5      5      5      5      