   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:Snakes_and_Ladders_WPF_Game_MOO_ICT#Snakes_and_Ladders_WPF_Game_MOO_ICT  5   	   4    .Snakes_and_Ladders_WPF_Game_MOO_ICT.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Clocal1clr-namespace:Snakes_and_Ladders_WPF_Game_MOO_ICT     5   	     � Title$  Snake and Ladders Game��5   	   $	��800��6(   $	��900��65   .��5
      �� -   5        $��MyCanvas��5
      $
|�True��6   .+�5   
   � .+�5      o� $	��900��6   $��Center=�6   $	��Top=�6<    o� 
IsMainMenu$
 True��6T   .@�5      m� $
��File��6   .@�5      m� $��New game��6   63   m� 5      -   5        $
��Exit��5      6C   5      m� 5      $��About��6   .@�5      m� $��About��6   60   5      5      5      �� 5   
   $��26(�6   $��	ExtraBold"�6   $%��Snakes and Ladders Game MOO ICT��65   
������� �� Left$	 170��6r   
 �� Top$	 -10��6�   �� 5   
   $��16(�6   $
��Bold"�6   $P��JClick anywhere on the game to take your turn, CPU will take turn after you��60   
�������$	 122��6�   $ 27��6�   �� 5   
   $��images/player.gif��6   $��24��6+   $	 783��66   $	 320��6H   $
��Left=�6Y   $��30��6t   $	��Top=�6�    J� RenderTransformOrigin$ 14.333,0.88&�6�   �� 5   
   $��images/opponent.gif��6   $��20��6-   $	 782��68   $	 364��6J   $
��Left=�6[   $��32��6v   $	��Top=�6�   �� 5   
   -   5        $��txtPlayerPosition��5      $��16(�6)   $	��You��5      $	 809��6   $	 320��60   $
��Left=�6A   $	��Top=�6\   $ 0.795,0.561&�6t   �� 5   
   -   5        $��txtOpponentPosition��5      $��16(�6+   $��Your PC��69   $	 808��6K   $	 362��6]   $
��Left=�6n   $	��Top=�6�   �� 5   
   -   5        $��
Roll Dice!��5      $	 785��6&   $	 422��68   $��24��6I   $��86��6U   $��Center=�6s   $	��Top=�6�   5       5!      