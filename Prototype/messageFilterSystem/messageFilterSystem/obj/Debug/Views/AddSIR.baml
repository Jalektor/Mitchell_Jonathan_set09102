   M S B A M L   `   `   `  ����N  JmessageFilterSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:messageFilterSystem.ViewsmessageFilterSystem.Views  5      &     messageFilterSystem.Views.AddSIR   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:messageFilterSystem.Views     5      
���?���.��5
      � .+�5   
   �� -   5          ��Name$  tBlockTitle��5      $
��Left=�6F   $��
120,10,0,0q�6a   $	��Top=�6u   $��18(�6�   ��6)   �� *TBlockTitle+6�   �� 5   
   -   5        $  tBlockMHeader��5      $
��Left=�6+   $��	20,50,0,0q�6F   $	��Top=�6x   ��6Y   �� *TBlockMHeader+6x   �� 5   
   -   5        $  	tBlockMID��5      $
��Left=�6'   $��	20,70,0,0q�6B   $	��Top=�6p   ��6U   �� *	TBlockMID+6p   �� 5   
   -   5        $  tBlockMChars��5      $
��Left=�6*   $��
120,70,0,0q�6E   $	��Top=�6w   ��6Y   �� *TBlockMChars+6w   �� 5   
   -   5         ��Name$ tBoxMID��5      $
��Left=�6#   $��19��6>   $��
335,70,0,0q�6J   $	��Top=�6w   $	��120��6�    �� 	MaxLength$ 9��6�   ��6^   �� *	TBoxMID+6�   �� 5   
   -   5        $  tBlockSender��5      $
��Left=�6*   $��
20,100,0,0q�6E   $	��Top=�6w   ��6Y   �� *TBlockSender+6w   �� 5   
   -   5        $ 
tBoxSender��5      $
��Left=�6&   $��19��6A   $��
70,100,0,0q�6M   $	��Top=�6}   $	��120��6�   ��6a   �� *
TBoxSender+6�   �� 5   
   -   5        $  tBlockSubject��5      $
��Left=�6+   $��230,100,0,0q�6F   $	��Top=�6z   ��6[   �� *TBlockSubject+6z   (  "System.Windows.Controls.DatePicker  5   
   -	   5          Name$ dPicker��5         SelectedDateFormat$ Short=�6&   $
��Left=�6A   $��335,100,0,0q�6\   $	��Top=�6�   $	��120��6�      SelectedDate 6q   �� *DPickerContent+ �� StringFormat$ 
dd/mm/yyyy��6�   �� 5   
   -
   5        $  
tBlockBody��5      $
��Left=�6(   $��
20,150,0,0q�6C   $	��Top=�6s   ��6W   �� *
TBlockBody+6s   �� 5   
   -   5        $  tBlockCentre��5      $
��Left=�6*   $��
70,140,0,0q�6E   $"��Sport Centre Code: 66-666-99��6Y   $	��Top=�6}   �� 5   
   -   5        $  tBlockIncident��5      $
��Left=�6,   $��250,140,0,0q�6G   $��Nature of Incident:��6\   $	��Top=�6w   �� 5   
   -   5         ��Name$ cBoxIncident��5      $
��Left=�6K   $��354,129,0,0q�6f   $	��Top=�6{   $	��150��6�   $��27��6�   ��6)   �� *	Incidents+ �� SelectedItem 6�   �� *
Incident+6�   �� 5   
   -   5        $ tBoxBody��5      $
��Left=�6$   $	��100��6?   $��
70,171,0,0q�6L   	 �� TextWrapping$
	 Wrap=�6`   $	��Top=�6�   $	��490��6�   $
 1028��6�   ��6t   �� *
TBoxBody+6�   �� 5   
   -   5        
 ��Name$
 btnInsertSMS��5      $
��Left=�6w   $��260,280,0,0q�6�   $	��Top=�6�   $��75��6�   ��6'   �� *BtnInsertSIRContent+��6O   �� *BtnInsertSIRCommand+6�   �� 5!   
   -   5        $  tBlockCharCount��5!      $
��Left=�6-   $��420,275,0,0q�6H   $	��Top=�6]   5%      5&      