   M S B A M L   `   `   `  ����D  @DP_WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:DP_WpfApp	DP_WpfApp  5           DP_WpfApp.ActualMsgControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:DP_WpfApp     5      .��5	      � .+�5
   
   �� .@�5      �� $��Actual Msg part 1��6   .��5      �   � ColumnDefinitions  5      �� 5      $��1* �6+   �� 5      $��1* �6+   �� 5      $��1* �6+   �� 5      $��1* �6+   �� 5      $��1* �6+   �� 5      $��1* �6+   �� 5      $��1* �6+   �� 5      $��1* �6+   �� 5      $��1* �6+   �� 5      $��1* �6+   �� 5      $��1* �6+    � RowDefinitions 5      �� 5      $��* �6(   �� 5      $��* �6(   �� 5      $��* �6(   .+�5      � $��0��6   $��2��6+   
�������.+�5       ]� .+�5!      �� $	��Top=�6$   $
��Bold"�69   $��Center=�6K   $��	Box power��6o   6�   ]� 5"      $	��Top=�6(   .+�5#   "   �� $
��Left=�6(   $
��Left=�6>   $��	Voltage: ��6`   6v   �� 5$   "   $
��Left=�6(   $
��Left=�6>   ��6`   ��  �� Path$ BboxPower.voltage�6�   5%      ]� 5&      $	��Top=�6(   .+�5'   "   �� $
��Left=�6(   $
��Left=�6>   $��	Current: ��6`   6v   �� 5(   "   $
��Left=�6(   $
��Left=�6>   ��6`   �� $ BboxPower.current�6�   5)      ]� 5*      $	��Top=�6(   .+�5+   "   �� $
��left=�6(   $
��Left=�6>   $��Power: ��6`   6t   �� 5,   "   $
��Left=�6(   $
��Left=�6>   ��6`   �� $ BboxPower.power�6�   5-      5.      5/      � 50      $��1��6   $��2��6+   $��3��6?   
�������.+�51      ]� .+�52      �� $	��Top=�6$   $
��Bold"�69   $��Center=�6K   $��
Box Status��6o   6�   ]� 53      $
��Left=�6(   .+�54   "   ]� $	��Top=�6,   .+�55   &   �� $
��Left=�6,   $
��Left=�6B   $��SHD IN: ��6d   6y   �� 56   &   $
��Left=�6,   $
��Left=�6B   ��6d   �� $ BboxStatus.SHD_IN�6�   57   #   ]� 58   "   $	��Top=�6,   .+�59   &   �� $
��Left=�6,   $
��Left=�6B   $��	SHD OUT: ��6d   6z   �� 5:   &   $
��Left=�6,   $
��Left=�6B   ��6d   �� $ BboxStatus.SHD_OUT�6�   5;   #   ]� 5<   "   $	��Top=�6,   .+�5=   &   �� $
��Left=�6,   $
��Left=�6B   $��TSMS: ��6d   6w   �� 5>   &   $
��Left=�6,   $
��Left=�6B   ��6d   �� $ BboxStatus.TSMS�6�   5?   #   ]� 5@   "   $	��Top=�6,   .+�5A   &   �� $
��Left=�6,   $
��Left=�6B   $��AIR N: ��6d   6x   �� 5B   &   $
��Left=�6,   $
��Left=�6B   ��6d   �� $ BboxStatus.AIR_N�6�   5C   #   ]� 5D   "   $	��Top=�6,   .+�5E   &   �� $
��Left=�6,   $
��Left=�6B   $��AIR P: ��6d   6x   �� 5F   &   $
��Left=�6,   $
��Left=�6B   ��6d   �� $ BboxStatus.AIR_P�6�   5G   #   ]� 5H   "   $	��Top=�6,   .+�5I   &   �� $
��Left=�6,   $
��Left=�6B   $��PRECH 60V: ��6d   6|   �� 5J   &   $
��Left=�6,   $
��Left=�6B   ��6d   �� $ BboxStatus.PRECH_60V�6�   5K   #   ]� 5L   "   $	��Top=�6,   .+�5M   &   �� $
��Left=�6,   $
��Left=�6B   $��IMD OK: ��6d   6y   �� 5N   &   $
��Left=�6,   $
��Left=�6B   ��6d   �� $ BboxStatus.IMD_OK�6�   5O   #   5Q      ]� 5R      $��Right=�6(   .+�5S   "   ]� $	��Top=�6,   .+�5T   &   �� $
��Left=�6,   $
��Left=�6B   $��BMS OK: ��6d   6y   �� 5U   &   $
��Left=�6,   $
��Left=�6B   ��6d   �� $ BboxStatus.BMS_OK�6�   5V   #   ]� 5W   "   $	��Top=�6,   .+�5X   &   �� $
��Left=�6,   $
��Left=�6B   $��SIGNAL ERROR: ��6d   6   �� 5Y   &   $
��Left=�6,   $
��Left=�6B   ��6d   �� $ BboxStatus.SIGNAL_ERROR�6�   5Z   #   ]� 5[   "   $	��Top=�6,   .+�5\   &   �� $
��Left=�6,   $
��Left=�6B   $��SHD RESET: ��6d   6|   �� 5]   &   $
��Left=�6,   $
��Left=�6B   ��6d   �� $ BboxStatus.SHD_RESET�6�   5^   #   ]� 5_   "   $	��Top=�6,   .+�5`   &   �� $
��Left=�6,   $
��Left=�6B   $��SHD EN: ��6d   6y   �� 5a   &   $
��Left=�6,   $
��Left=�6B   ��6d   �� $ BboxStatus.SHD_EN�6�   5b   #   ]� 5c   "   $	��Top=�6,   .+�5d   &   �� $
��Left=�6,   $
��Left=�6B   $��
POLARITY: ��6d   6{   �� 5e   &   $
��Left=�6,   $
��Left=�6B   ��6d   �� $ BboxStatus.POLARITY�6�   5f   #   ]� 5g   "   $	��Top=�6,   .+�5h   &   �� $
��Left=�6,   $
��Left=�6B   $��FANS: ��6d   6w   �� 5i   &   $
��Left=�6,   $
��Left=�6B   ��6d   �� $ BboxStatus.FANS�6�   5j   #   ]� 5k   "   $	��Top=�6,   .+�5l   &   �� $
��Left=�6,   $
��Left=�6B   $��
STM Temp: ��6d   6{   �� 5m   &   $
��Left=�6,   $
��Left=�6B   ��6d   �� $ BboxStatus.STM_temp�6�   5n   #   5o      5p      5q      � 5r      $��3��6   $��3��6+   
�������.+�5s      ]� .+�5t      ]� .+�5u   "   �� $	��Top=�6(   $
��Bold"�6=   $��Center=�6O   $��GPS Data��6s   6�   ]� 5v   "   $	��Top=�6,   .+�5w   &   �� $
��Left=�6,   $
��Left=�6B   $��
Latitude: ��6d   6{   �� 5x   &   $
��Left=�6,   $
��Left=�6B   ��6d   �� $ GpsData.latitude�6�   5z   #   ]� 5{   "   $	��Top=�6,   .+�5|   &   �� $
��Left=�6,   $
��Left=�6B   $��
Lat.Char: ��6d   6{   �� 5}   &   $
��Left=�6,   $
��Left=�6B   ��6d   �� $ GpsData.latitude_char�6�   5~   #   ]� 5   "   $	��Top=�6,   .+�5�   &   �� $
��Left=�6,   $
��Left=�6B   $��Longitude: ��6d   6|   �� 5�   &   $
��Left=�6,   $
��Left=�6B   ��6d   �� $ GpsData.longitude�6�   5�   #   ]� 5�   "   $	��Top=�6,   .+�5�   &   �� $
��Left=�6,   $
��Left=�6B   $��long. char: ��6d   6}   �� 5�   &   $
��Left=�6,   $
��Left=�6B   ��6d   �� $ GpsData.longitude_char�6�   5�   #   ]� 5�   "   $	��Top=�6,   .+�5�   &   �� $
��Left=�6,   $
��Left=�6B   $��Speed: ��6d   6x   �� 5�   &   $
��Left=�6,   $
��Left=�6B   ��6d   �� $ GpsData.speed�6�   5�   #   ]� 5�   "   $	��Top=�6,   .+�5�   &   �� $
��Left=�6,   $
��Left=�6B   $��Course: ��6d   6y   �� 5�   &   $
��Left=�6,   $
��Left=�6B   ��6d   �� $ GpsData.course�6�   5�   #   ]� 5�   "   $	��Top=�6,   .+�5�   &   �� $
��Left=�6,   $
��Left=�6B   $��
Altitude: ��6d   6{   �� 5�   &   $
��Left=�6,   $
��Left=�6B   ��6d   �� $ GpsData.altitude�6�   5�   #   5�      5�      5�      � 5�      $��4��6   $��3��6+   
�������.+�5�      ]� .+�5�      �� $	��Top=�6$   $
��Bold"�69   $��Center=�6K   $��	ECU State��6o   6�   ]� 5�      $	��Top=�6(   .+�5�   "   �� $
��Left=�6(   $
��Left=�6>   $��ECU Status: ��6`   6y   �� 5�   "   $
��Left=�6(   $
��Left=�6>   ��6`   �� $ EcuState.ECU_Status�6�   5�      ]� 5�      $	��Top=�6(   .+�5�   "   �� $
��Left=�6(   $
��Left=�6>   $��FR AMK Status: ��6`   6|   �� 5�   "   $
��Left=�6(   $
��Left=�6>   ��6`   �� $ EcuState.FR_AMK_Status�6�   5�      ]� 5�      $	��Top=�6(   .+�5�   "   �� $
��Left=�6(   $
��Left=�6>   $��RL AMK Status: ��6`   6|   �� 5�   "   $
��Left=�6(   $
��Left=�6>   ��6`   �� $ EcuState.RL_AMK_Status�6�   5�      ]� 5�      $	��Top=�6(   .+�5�   "   �� $
��Left=�6(   $
��Left=�6>   $��RR AMK Status: ��6`   6|   �� 5�   "   $
��Left=�6(   $
��Left=�6>   ��6`   �� $ EcuState.RR_AMK_Status�6�   5�      ]� 5�      $	��Top=�6(   .+�5�   "   �� $
��Left=�6(   $
��Left=�6>   $��TempMotor H: ��6`   6z   �� 5�   "   $
��Left=�6(   $
��Left=�6>   ��6`   �� $ EcuState.TempMotor_H�6�   5�      ]� 5�      $	��Top=�6(   .+�5�   "   �� $
��Left=�6(   $
��Left=�6>   $��TempInverter H: ��6`   6}   �� 5�   "   $
��Left=�6(   $
��Left=�6>   ��6`   �� $ EcuState.TempInverter_H�6�   5�      ]� 5�      $	��Top=�6(   .+�5�   "   �� $
��Left=�6(   $
��Left=�6>   $��TempIGBT H: ��6`   6y   �� 5�   "   $
��Left=�6(   $
��Left=�6>   ��6`   �� $ EcuState.TempIGBT_H�6�   5�      5�      5�      � 5�      $��0��6   $��2��6+   
�������.+�5�      ]� .+�5�      �� $	��Top=�6$   $
��Bold"�69   $��Center=�6K   $��Box Commnad��6o   6�   ]� 5�      $	��Top=�6(   .+�5�   "   �� $
��Left=�6(   $
��Left=�6>   $��FANS: ��6`   6s   �� 5�   "   $
��Left=�6(   $
��Left=�6>   ��6`   �� $ BboxCommand.FANS�6�   5�      ]� 5�      $	��Top=�6(   .+�5�   "   �� $
��Left=�6(   $
��Left=�6>   $��SHD EN: ��6`   6u   �� 5�   "   $
��Left=�6(   $
��Left=�6>   ��6`   �� $ BboxCommand.SHD_EN�6�   5�      5�      5�      � 5�      $��5��6   $��0��6+   $��3��68   
�������.+�5�      ]� .+�5�      �� $	��Top=�6$   $
��Bold"�69   $��Center=�6K   $��FU Values 1��6o   6�   ]� 5�      $	��Top=�6(   .+�5�   "   �� $
��Left=�6(   $
��Left=�6>   $��Apps1: ��6`   6t   �� 5�   "   $
��Left=�6(   $
��Left=�6>   ��6`   �� $ FuValues1.apps1�6�   5�      ]� 5�      $	��Top=�6(   .+�5�   "   �� $
��Left=�6(   $
��Left=�6>   $��Apps2: ��6`   6t   �� 5�   "   $
��Left=�6(   $
��Left=�6>   ��6`   �� $ FuValues1.apps2�6�   5�      ]� 5�      $	��Top=�6(   .+�5�   "   �� $
��Left=�6(   $
��Left=�6>   $��Brake1: ��6`   6u   �� 5�   "   $
��Left=�6(   $
��Left=�6>   ��6`   �� $ FuValues1.brake1�6�   5�      ]� 5�      $	��Top=�6(   .+�5�   "   �� $
��Left=�6(   $
��Left=�6>   $��Brake2: ��6`   6u   �� 5�   "   $
��Left=�6(   $
��Left=�6>   ��6`   �� $ FuValues1.brake2�6�   5�      ]� 5�      $	��Top=�6(   .+�5�   "   �� $
��Left=�6(   $
��Left=�6>   $��Error: ��6`   6t   �� 5�   "   $
��Left=�6(   $
��Left=�6>   ��6`   �� $ FuValues1.error�6�   5�      5�      5�      � 5�      $��6��6   $��0��6+   $��3��68   
�������.+�5�      ]� .+�5�      �� $	��Top=�6$   $
��Bold"�69   $��Center=�6K   $��Interconnect��6o   6�   ]� 5�      $	��Top=�6(   .+�5�   "   �� $
��Left=�6(   $
��Left=�6>   $��Car State: ��6`   6x   �� 5�   "   $
��Left=�6(   $
��Left=�6>   ��6`   �� $ Interconnect.car_state�6�   5�      ]� 5�      $	��Top=�6(   .+�5�   "   �� $
��Left=�6(   $
��Left=�6>   $��Left W Pump: ��6`   6z   �� 5�   "   $
��Left=�6(   $
��Left=�6>   ��6`   �� $ Interconnect.left_w_pump�6�   5�      ]� 5�      $	��Top=�6(   .+�5�   "   �� $
��Left=�6(   $
��Left=�6>   $��Right W Pump: ��6`   6{   �� 5�   "   $
��Left=�6(   $
��Left=�6>   ��6`   �� $ Interconnect.right_w_pump�6�   5�      ]� 5�      $	��Top=�6(   .+�5�   "   �� $
��Left=�6(   $
��Left=�6>   $��Brake Red: ��6`   6x   �� 5�   "   $
��Left=�6(   $
��Left=�6>   ��6`   �� $ Interconnect.brake_red�6�   5�      ]� 5�      $	��Top=�6(   .+�5�   "   �� $
��Left=�6(   $
��Left=�6>   $��Brake White: ��6`   6z   �� 5�   "   $
��Left=�6(   $
��Left=�6>   ��6`   �� $ Interconnect.brake_white�6�   5�      ]� 5�      $	��Top=�6(   .+�5�   "   �� $
��Left=�6(   $
��Left=�6>   $��Tsas: ��6`   6s   �� 5�   "   $
��Left=�6(   $
��Left=�6>   ��6`   �� $ Interconnect.tsas�6�   5�      ]� 5�      $	��Top=�6(   .+�5�   "   �� $
��Left=�6(   $
��Left=�6>   $��Killswitch R: ��6`   6{   �� 5�   "   $
��Left=�6(   $
��Left=�6>   ��6`   �� $ Interconnect.killswitch_R�6�   5�      ]� 5�      $	��Top=�6(   .+�5�   "   �� $
��Left=�6(   $
��Left=�6>   $��Killswitch L: ��6`   6{   �� 5   "   $
��Left=�6(   $
��Left=�6>   ��6`   �� $ Interconnect.killswitch_L�6�   5     ]� 5     $	��Top=�6(   .+�5  "   �� $
��Left=�6(   $
��Left=�6>   $��	Reserve: ��6`   6v   �� 5  "   $
��Left=�6(   $
��Left=�6>   ��6`   �� $ Interconnect.reserve�6�   5     ]� 5     $	��Top=�6(   .+�5  "   �� $
��Left=�6(   $
��Left=�6>   $��	Susp RR: ��6`   6v   �� 5  "   $
��Left=�6(   $
��Left=�6>   ��6`   �� $ Interconnect.susp_RR�6�   5	     ]� 5
     $	��Top=�6(   .+�5  "   �� $
��Left=�6(   $
��Left=�6>   $��	Susp RL: ��6`   6v   �� 5  "   $
��Left=�6(   $
��Left=�6>   ��6`   �� $ Interconnect.susp_RL�6�   5     ]� 5     $	��Top=�6(   .+�5  "   �� $
��Left=�6(   $
��Left=�6>   $��Killswitch L: ��6`   6{   �� 5  "   $
��Left=�6(   $
��Left=�6>   ��6`   �� $ Interconnect.killswitch_L�6�   5     5     5     � 5     $��7��6   $��0��6+   $��3��68   
�������.+�5     ]� .+�5     �� $	��Top=�6$   $
��Bold"�69   $��Center=�6K   $��FU Values 2��6o   6�   ]� 5     $	��Top=�6(   .+�5  "   �� $
��Left=�6(   $
��Left=�6>   $��Steer: ��6`   6t   �� 5  "   $
��Left=�6(   $
��Left=�6>   ��6`   �� $ FuValues2.steer�6�   5     ]� 5     $	��Top=�6(   .+�5  "   �� $
��Left=�6(   $
��Left=�6>   $��	Susp FL: ��6`   6v   �� 5  "   $
��Left=�6(   $
��Left=�6>   ��6`   �� $ FuValues2.susp_FL�6�   5     ]� 5     $	��Top=�6(   .+�5   "   �� $
��Left=�6(   $
��Left=�6>   $��	Susp FR: ��6`   6v   �� 5!  "   $
��Left=�6(   $
��Left=�6>   ��6`   �� $ FuValues2.susp_FR�6�   5"     ]� 5#     $	��Top=�6(   .+�5$  "   �� $
��Left=�6(   $
��Left=�6>   $��Brake Pos: ��6`   6x   �� 5%  "   $
��Left=�6(   $
��Left=�6>   ��6`   �� $ FuValues2.brake_pos�6�   5&     ]� 5'     $	��Top=�6(   .+�5(  "   �� $
��Left=�6(   $
��Left=�6>   $��RTD: ��6`   6r   �� 5)  "   $
��Left=�6(   $
��Left=�6>   ��6`   �� $ FuValues2.RTD�6�   5*     ]� 5+     $	��Top=�6(   .+�5,  "   �� $
��Left=�6(   $
��Left=�6>   $��BOTS: ��6`   6s   �� 5-  "   $
��Left=�6(   $
��Left=�6>   ��6`   �� $ FuValues2.BOTS�6�   5.     ]� 5/     $	��Top=�6(   .+�50  "   �� $
��Left=�6(   $
��Left=�6>   $��SHDB: ��6`   6s   �� 51  "   $
��Left=�6(   $
��Left=�6>   ��6`   �� $ FuValues2.SHDB�6�   52     ]� 53     $	��Top=�6(   .+�54  "   �� $
��Left=�6(   $
��Left=�6>   $��INERTIA SW: ��6`   6y   �� 55  "   $
��Left=�6(   $
��Left=�6>   ��6`   �� $ FuValues2.INERTIA_SW�6�   56     ]� 57     $	��Top=�6(   .+�58  "   �� $
��Left=�6(   $
��Left=�6>   $��	Reserve: ��6`   6v   �� 59  "   $
��Left=�6(   $
��Left=�6>   ��6`   �� $ FuValues2.reserve�6�   5:     5;     5<     � 5=     $��8��6   $��0��6+   $��3��68   
�������.+�5>     ]� .+�5?     �� $	��Top=�6$   $
��Bold"�69   $��Center=�6K   $��Bms Command��6o   6�   ]� 5@     $	��Top=�6(   .+�5A  "   �� $
��Left=�6(   $
��Left=�6>   $��BMS Balanc: ��6`   6y   �� 5B  "   $
��Left=�6(   $
��Left=�6>   ��6`   �� $ BmsCommand.BMS_Balanc�6�   5C     ]� 5D     $	��Top=�6(   .+�5E  "   �� $
��Left=�6(   $
��Left=�6>   $��BMS FullModeL: ��6`   6|   �� 5F  "   $
��Left=�6(   $
��Left=�6>   ��6`   �� $ BmsCommand.BMS_FullMode�6�   5G     ]� 5H     $	��Top=�6(   .+�5I  "   �� $
��Left=�6(   $
��Left=�6>   $��BMS OK: ��6`   6u   �� 5J  "   $
��Left=�6(   $
��Left=�6>   ��6`   �� $ BmsCommand.susp_FR�6�   5K     ]� 5L     $	��Top=�6(   .+�5M  "   �� $
��Left=�6(   $
��Left=�6>   $��BMS ONOFF: ��6`   6x   �� 5N  "   $
��Left=�6(   $
��Left=�6>   ��6`   �� $ BmsCommand.BMS_ONOFF�6�   5O     ]� 5P     $	��Top=�6(   .+�5Q  "   �� $
��Left=�6(   $
��Left=�6>   $��	BMS CAN: ��6`   6v   �� 5R  "   $
��Left=�6(   $
��Left=�6>   ��6`   �� $ BmsCommand.BMS_CAN�6�   5S     5T     5U     � 5V     $��9��6   $��0��6+   $��3��68   
�������.+�5W     ]� .+�5X     �� $	��Top=�6$   $
��Bold"�69   $��Center=�6K   $��	Bms State��6o   6�   ]� 5Y     $	��Top=�6(   .+�5Z  "   �� $
��Left=�6(   $
��Left=�6>   $��
BMS Mode: ��6`   6w   �� 5[  "   $
��Left=�6(   $
��Left=�6>   ��6`   �� $ BmsState.BMS_Mode�6�   5\     ]� 5]     $	��Top=�6(   .+�5^  "   �� $
��Left=�6(   $
��Left=�6>   $��BMS Faults: ��6`   6y   �� 5_  "   $
��Left=�6(   $
��Left=�6>   ��6`   �� $ BmsState.BMS_Faults�6�   5`     ]� 5a     $	��Top=�6(   .+�5b  "   �� $
��Left=�6(   $
��Left=�6>   $��CellVolt L: ��6`   6y   �� 5c  "   $
��Left=�6(   $
��Left=�6>   ��6`   �� $ BmsState.CellVolt_L�6�   5d     ]� 5e     $	��Top=�6(   .+�5f  "   �� $
��Left=�6(   $
��Left=�6>   $��CellVolt H: ��6`   6y   �� 5g  "   $
��Left=�6(   $
��Left=�6>   ��6`   �� $ BmsState.CellVolt_H�6�   5h     ]� 5i     $	��Top=�6(   .+�5j  "   �� $
��Left=�6(   $
��Left=�6>   $��CellTemp L: ��6`   6y   �� 5k  "   $
��Left=�6(   $
��Left=�6>   ��6`   �� $ BmsState.CellTemp_L�6�   5l     ]� 5m     $	��Top=�6(   .+�5n  "   �� $
��Left=�6(   $
��Left=�6>   $��BMS Ident: ��6`   6x   �� 5o  "   $
��Left=�6(   $
��Left=�6>   ��6`   �� $ BmsState.BMS_Ident�6�   5p     5q     5r     � 5s     $��10��6   $��0��6,   $��3��69   
�������.+�5t     ]� .+�5u     �� $	��Top=�6$   $
��Bold"�69   $��Center=�6K   $��	Wheel RPM��6o   6�   ]� 5v     $	��Top=�6(   .+�5w  "   �� $
��Left=�6(   $
��Left=�6>   $��Front Right: ��6`   6z   �� 5x  "   $
��Left=�6(   $
��Left=�6>   ��6`   �� $ WheelRPM.front_right�6�   5y     ]� 5z     $	��Top=�6(   .+�5{  "   �� $
��Left=�6(   $
��Left=�6>   $��Front Left: ��6`   6y   �� 5|  "   $
��Left=�6(   $
��Left=�6>   ��6`   �� $ WheelRPM.front_left�6�   5}     ]� 5~     $	��Top=�6(   .+�5  "   �� $
��Left=�6(   $
��Left=�6>   $��Rear Right: ��6`   6y   �� 5�  "   $
��Left=�6(   $
��Left=�6>   ��6`   �� $ WheelRPM.rear_right�6�   5�     ]� 5�     $	��Top=�6(   .+�5�  "   �� $
��Left=�6(   $
��Left=�6>   $��Rear Left: ��6`   6x   �� 5�  "   $
��Left=�6(   $
��Left=�6>   ��6`   �� $ WheelRPM.rear_left�6�   5�     5�     5�     5�     5�     �� 5�     $��Actual Voltages��6   .��5�     &   System.Windows.Controls.DataGrid  -   5        $��voltagesDataGrid��5�        AutoGenerateColumns .     Columns 5�     0  *System.Windows.Controls.DataGridTextColumn  5�     ,  &System.Windows.Controls.DataGridColumn   Header$ 0��6.   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *BmsVoltagesList.Id0+  5�     $ 7��6.    69   �� *BmsVoltagesList.Id7+  5�     $ 14��6.    6:   �� *BmsVoltagesList.Id14+  5�     $ 21��6.    6:   �� *BmsVoltagesList.Id21+  5�     $ 28��6.    6:   �� *BmsVoltagesList.Id28+  5�     $ 35��6.    6:   �� *BmsVoltagesList.Id35+  5�     $ 42��6.    6:   �� *BmsVoltagesList.Id42+  5�     $ 49��6.    6:   �� *BmsVoltagesList.Id49+  5�     $ 56��6.    6:   �� *BmsVoltagesList.Id56+  5�     $ 63��6.    6:   �� *BmsVoltagesList.Id63+  5�     $ 70��6.    6:   �� *BmsVoltagesList.Id70+  5�     $ 77��6.    6:   �� *BmsVoltagesList.Id77+  5�     $ 84��6.    6:   �� *BmsVoltagesList.Id84+  5�     $ 91��6.    6:   �� *BmsVoltagesList.Id91+  5�     $ 98��6.    6:   �� *BmsVoltagesList.Id98+  5�     $	 105��6.    6;   �� *BmsVoltagesList.Id105+  5�     $	 112��6.    6;   �� *BmsVoltagesList.Id112+  5�     $	 119��6.    6;   �� *BmsVoltagesList.Id119+  5�     $	 126��6.    6;   �� *BmsVoltagesList.Id126+  5�     $	 133��6.    6;   �� *BmsVoltagesList.Id133+  5�     $	 140��6.    6;   �� *BmsVoltagesList.Id140+5�     5�     �� 5�     $��Actual Temperatures��6   .��5�       -   5        $��temperaturesDataGrid��5�      .   5�       5�     $ 0��6.    69   �� *BmsTemperaturesList.Id0+  5�     $ 7��6.    69   �� *BmsTemperaturesList.Id7+  5�     $ 14��6.    6:   �� *BmsTemperaturesList.Id14+  5�     $ 21��6.    6:   �� *BmsTemperaturesList.Id21+  5�     $ 28��6.    6:   �� *BmsTemperaturesList.Id28+  5�     $ 35��6.    6:   �� *BmsTemperaturesList.Id35+  5�     $ 42��6.    6:   �� *BmsTemperaturesList.Id42+  5�     $ 49��6.    6:   �� *BmsTemperaturesList.Id49+  5�     $ 56��6.    6:   �� *BmsTemperaturesList.Id56+  5�     $ 63��6.    6:   �� *BmsTemperaturesList.Id63+  5�     $ 70��6.    6:   �� *BmsTemperaturesList.Id70+  5�     $ 77��6.    6:   �� *BmsTemperaturesList.Id77+  5�     $ 84��6.    6:   �� *BmsTemperaturesList.Id84+  5�     $ 91��6.    6:   �� *BmsTemperaturesList.Id91+  5�     $ 98��6.    6:   �� *BmsTemperaturesList.Id98+  5�     $	 105��6.    6;   �� *BmsTemperaturesList.Id105+  5�     $	 112��6.    6;   �� *BmsTemperaturesList.Id112+  5�     $	 119��6.    6;   �� *BmsTemperaturesList.Id119+  5�     $	 126��6.    6;   �� *BmsTemperaturesList.Id126+  5�     $	 133��6.    6;   �� *BmsTemperaturesList.Id133+  5�     $	 140��6.    6;   �� *BmsTemperaturesList.Id140+5�     5�     5�     5�     5�     