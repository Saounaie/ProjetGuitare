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
using System.Windows.Shapes;

namespace Fabrication_IHM
{
    /// <summary>
    /// Logique d'interaction pour CLientsWindow.xaml
    /// </summary>
    public partial class CLientsWindow : Window
    {

        public CLientsWindow()
        {
            InitializeComponent();
            DataContext = Coordination.Coordination.Instance;
        }
    }
}
