   M S B A M L   `   `   `  ����M  ISnakeAndLaddersWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:SnakeAndLaddersWPFSnakeAndLaddersWPF  5   	   #    SnakeAndLaddersWPF.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:SnakeAndLaddersWPF     5   	     � 
ResizeMode$  NoResize=�5   	    � Title$ Snake And Ladders��5	   	   $	��700��6#   $	��800��60   .��5
      � $
��Left=�6   $	��800��6&   .+�5   
   �� -   5        $��startRoundBtn��5   &   $��
Dice Roll!��6   $
��Left=�6R   $��684,218,0,0q�6m   $	��Top=�6�    J� RenderTransformOrigin$ 2.496,0.262&�6�   �� 5   
   -   5         ��Name$ 	diceImage��5      $
��Left=�6#   $	��100��6>   $��666,100,0,0q�6K   $	��Top=�6`   $	��100��6x   o� 5   
   $	��800��6   $��Center=�6   $	��Top=�68    o� 
IsMainMenu$
 True��6P   .@�5      m� $
��File��6   .@�5      m� -   5        $��New game��5      6M   m� 5      -   5        $��Last Winner��5      6L   m� 5      -   5        $
��Exit��5      6>   5      m� 5      $��About��6   .@�5      m� -   5        $��About��5      6@   5      5      �� 5   
   $��images/player.gif��6   $��21��6+    �� Left$	 400��66   
 �� Top$	 320��6H   $
��Left=�6Y   $��36��6t   $	��Top=�6�   $ 14.333,0.88&�6�   $��677,301,0,0q�6�   �� 5   
   $��images/opponent.gif��6   $��22��6-   $	 782��68   $	 364��6J   $
��Left=�6[   $��35��6v   $	��Top=�6�   $��677,353,0,0q�6�   �� 5   
   -   5        $��
playerName��5      $	��You��6"   $
��Left=�60   $��703,308,0,0q�6K   $	��Top=�6`   $ -0.184,0.271&�6x   $��14(�6�   $
��Bold"�6�   �� 5   
   $��Your PC��6   $
��Left=�6"   $��704,363,0,0q�6=   $	��Top=�6R   $ -0.184,0.271&�6j   $��14(�6�   $
��Bold"�6�   �� 5   
   $/��)Developed by Ofek Sinai and Matan Mizrahi��6   $
��Left=�6D   $��243,632,0,0q�6_   $	��Top=�6t   �� 5   
   -   5        $��nameOfCurrentPlayer��5      $�� ��6+   $
��Left=�66   $��655,377,0,0q�6Q   $	��Top=�6f   $ 8.028,-1.116&�6~   �� 5   
   -	   5        $��gameBoardCanvas��5      $	��600��6(   $	��600��64   $��44,35,156,49q�6A   $
|�True��6X   �� 5   
   -
   5        $��funnyMessagesLabel��5      $�� ��6   $
��Left=�65   $��656,257,0,0q�6P   $	��Top=�6e   $��15(�6}   $ 1.367,0.458&�6�   $
��Bold"�6�   ���	#FFEC00006�   �� 5   
   -   5        $��activePlayerNameLabel��5      $
��Left=�6-   $��656,413,0,0q�6H   $	��Top=�6]   $ -2.633,0.804&�6u   5       5!      