   M S B A M L   `   `   `  ����N  JWpfBalieMedewerkers, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:WpfBalieMedewerkersWpfBalieMedewerkers  5   	   "    WpfBalieMedewerkers.WpfLogin   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:WpfBalieMedewerkers     5   	     � Title$  Login��5   	   $	��450��6   $	��400��6$   .��5	      � ���	#FFA45D5D � RowDefinitions 5
   
   �� 5      $	��175 �6   6+   �� 5      $��* �6   6)    � ColumnDefinitions 5   
   �� 5      $	��130 �6   6-   �� 5      $��* �6   6+   �� 5      $	��130 �6   6-   .+�5   
   �� $��0��6   $��1��6   $��download.gif��6-   6F   �� 5   
   $��1��6   $��1��6"   .+�5      �� $��Gebruikersnaam:��6   
�������6.   �� 5      -   5         ��Name$ tbxGebruikersnaam��5      $��23��61    �� TextWrapping$
 Wrap=�6=   $
��6471��6Q   �� 5      $��Wachtwoord:��6   
�������6*   G� 5      -   5         G�Name$ tbxWachtwoord��5      $��23��61    G� Password$ kantoor��6=   �� 5      -   5         ��Name$ btnLogin��5   S   ���	#FF833636
�������
���   �$��0,20,0,0q�6e   $��Inloggen��6w   $��14(�6�   6�   �� 5      -   5         ��Name$ lblError��5   &   $��0,20,0,0q�6   $��Center=�68   $
��Left=�6S   5      5      5      