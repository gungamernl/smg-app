   M S B A M L   `   `   `  ����B  >SMG_app, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:SMG_appSMG_app  5   	       SMG_app.gebruikers   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:SMG_app     5   	     � Title$  
gebruikers��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
   
   � $��10q�6    � ColumnDefinitions 5      �� 5      6%   �� 5      6%   �� 5      6%   .+�5      ]� $��0��6   .+�5      �� -   5         ��Name$ lb_gebruikers��5       �� DisplayMemberPath$ gebruikersnaam��61   6�   5      �� 5      $��1��6   $��10,20q�6)   .+�5      �� -   5         ��Name$ tb_gebruikersnaam��5   &   $��30��6   $
��0,10q�6A   6Q   �� 5      -   5        $ tb_voornaam��5   &   $��30��6   $
��0,10q�6;   6K   �� 5      -   5        $ tb_achternaam��5   &   $��30��6   $
��0,10q�6=   6M   �� 5      -   5        $ tb_email��5   &   $��30��6   $
��0,10q�68   6H   �� 5      -   5        $ tb_wachtwoord��5   &   $��30��6   $
��0,10q�6=   6M   5      �� 5      $��2��6   $��10,20q�6)   .+�5      �� -   5        $��30��5   .   $
��0,10q�6:   .��6H   	toevoegen6S   �� 5      -   5        $��30��5   .   $
��0,10q�6:   .��6H   verwijderen6U   �� 5      -	   5        $��30��5   .   $
��0,10q�6:   .��6H   
wijzigen6R   �� 5       -
   5        $	��0,4q�5       .��6:   terug6A   5"      5$      5%      5&      