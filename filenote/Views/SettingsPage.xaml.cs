﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Sbs20.Filenote.Data;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Sbs20.Filenote.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            this.InitializeComponent();
            this.DarkThemeToggle.IsOn = Settings.ApplicationTheme == ApplicationTheme.Dark;
        }

        private async void ChangeStorageLocation_Click(object sender, RoutedEventArgs e)
        {
            await Settings.SelectLocalDirectoryAsync();
        }

        private void ApplyTheme_Click(object sender, RoutedEventArgs e)
        {
            this.RequestedTheme = ElementTheme.Dark;
        }

        private void DarkThemeToggle_Toggled(object sender, RoutedEventArgs e)
        {
            ApplicationTheme selectedTheme = this.DarkThemeToggle.IsOn ? ApplicationTheme.Dark : ApplicationTheme.Light;
            Settings.ApplicationTheme = selectedTheme;
            var appShell = Window.Current.Content as AppShell;
            appShell.RequestedTheme = selectedTheme == ApplicationTheme.Dark ? ElementTheme.Dark : ElementTheme.Light;
        }
    }
}
