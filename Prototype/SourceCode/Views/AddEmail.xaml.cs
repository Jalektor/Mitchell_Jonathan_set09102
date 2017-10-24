﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using messageFilterSystem.ViewModels;

namespace messageFilterSystem.Views
{
    /// <summary>
    /// Interaction logic for AddEmail.xaml
    /// </summary>
    public partial class AddEmail : UserControl
    {
        public AddEmail()
        {
            InitializeComponent();

            this.DataContext = new AddEmailViewModel();
        }
    }
}
