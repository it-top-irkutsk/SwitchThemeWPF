using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SwitchThemeWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
 
            var styles = new List<string> { "light", "dark" };
            styleBox.ItemsSource = styles;
            styleBox.SelectedItem = "dark";
        }
 
        private void ThemeChange(object sender, SelectionChangedEventArgs e)
        {
            var style = styleBox.SelectedItem as string;
            var uri = new Uri(style + ".xaml", UriKind.Relative);
            var resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }
    }
}