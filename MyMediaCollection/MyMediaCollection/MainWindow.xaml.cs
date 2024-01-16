﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;

using Windows.Foundation;
using Windows.Foundation.Collections;

using MyMediaCollection.Enums;
using MyMediaCollection.Model;
using MyMediaCollection.ViewModels;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MyMediaCollection
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        public MainViewModel ViewModel => App.ViewModel;

        //private async void AddButton_Click(object sender, RoutedEventArgs e)
        //{
        //    var dialog = new ContentDialog
        //    {
        //        Title = "Media Collection",
        //        Content = "Not implementing",
        //        CloseButtonText = "OK",
        //        XamlRoot = Content.XamlRoot
        //    };
        //    await dialog.ShowAsync();
        //}
    }
}
