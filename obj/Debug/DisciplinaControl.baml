   M S B A M L   `   `   `  ����D  @DP_WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:DP_WpfApp	DP_WpfApp  5      !    DP_WpfApp.DisciplinaControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:DP_WpfApp     5      .��5	      �� .+�5
   
   �� -   5        $��btn_startDisciplin��5
      $��Start Disciplin��6+     �� Left$  10��6E   
 �� Top$ 10��6W   $��25��6g   $	��100��6s   y�6   ��  �� Path$ 
IsLiveData� �� Mode$ OneWay=�6�   �� 5   
   -   5        $��btn_endDisciplin��5      $��End Disciplin��6)   $  10��6A   $ 50��6R   $��25��6b   $	��100��6n   y�6z   �� $ 
IsLiveData�$ OneWay=�6�   �� 5   
   -   5        $��btn_save��5      $��Save To Database��6!    �� Right$ 10��6<   $ 10��6O   $��25��6_   $	��120��6k   y�6w   �� $ 
IsLiveData�$ OneWay=�6�   �� 5   
   -   5        $��combobox_discipliny��5      $	  115��5      $ 9��6   $��25��6.   $	��160��6:    �� DisplayMemberPath$ Label��5      ��5      �� $ comboboxListDisciplines� �� SelectedValue 5      �� *CurrentSelectionDiscipline+y�5      �� $ IsHistoricData�5      �� 5   
   $	  315��5      $ 9��6"   $��25��61   $��Choose Run: ��5      y�5      �� $ IsHistoricData�5      �� 5   
   $  10��5      $ 10��6!   $��25��61   $��Choose Discipline:��5      y�5      �� $ IsHistoricData�5      �� 5   
   -   5        $��	typ_label��5      $	  200��5      $ 60��6"   $��25��62   $	��150��6>   $��	typ_label��5       y�5   !   �� $ IsHistoricData�5!      �� 5"   
   -   5        $��combobox_okruh��5#      $	  400��5$      $ 10��6   $��25��6/   $	��220��6;   $ Label��5&      ��5%      �� $ comboboxListRuns� 5'      �� *CurrentSelectionRun+y�5)      �� $ IsRunCombobox�5*      5+      5,      