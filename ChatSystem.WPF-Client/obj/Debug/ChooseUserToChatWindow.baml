   M S B A M L   `   `   `  ����P  LChatSystem.WPF-Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:ChatSystem.WPF_ClientChatSystem.WPF_Client  5   	   2    ,ChatSystem.WPF_Client.ChooseUserToChatWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:ChatSystem.WPF_Client     5   	   $��158.262��5      $��439.83��6+     � WindowStartupLocation$  CenterScreen=�6:    � 
ResizeMode$ NoResize=�6_   .��5      � $��0,0,0,-1q�6   ��5	   
   �� 5
       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ Black��6    � Offset$ 0Q�6-   � 5      $ White��6   $ 1Q�6-   5       � ColumnDefinitions 5   
   �� 5      $	��48* �6   �� 5      $	��25* �6   .+�5   
   �� -   5         ��Name$ listBoxUsers��5      $
��Left=�6(   $	��109��6C   $	��Top=�6P   $	��143��6h   $��
279,20,0,0q�6t   $��2��6�   $
��Bold"�6�   $��13.333(�6�   �� 5   
   -   5         ��Name$ tbUserToChatWith��5      $
��Left=�6,   $��23��6G   $��8,51,0,0q�6S   	 �� TextWrapping$
	 Wrap=�6e   $	��Top=�6y   $	��257��6�   $
��Bold"�6�   $��13.333(�6�   �� 5   
   -   5        
 ��Name$
 labelUserToChatWith��5      $%��Username you want to chat with:��6-   $
��Left=�6W   $��8,20,0,0q�6r   $	��Top=�6�   $��16(�6�   $
��Bold"�6�   ���	#FFF0F0F06�   �� 5   
   -   5         ��Name$ btnStartChat��5      $��
Start chat��6'   $
��Left=�6<   $��8,79,0,0q�6W   $	��Top=�6i   $	��257��6�   $
��Bold"�6�   �� 5   
   -   5        $
 labelAvailableUsers��5      $��Reachable usernames:��6-   $
��Left=�6L   $��
279,-8,0,0q�6g   $	��Top=�6{   $	��153��6�   $
��Bold"�6�   $��13.333(�6�   ���	#FFF9F9F9$��2��6�   5      5      