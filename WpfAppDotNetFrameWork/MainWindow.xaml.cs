﻿using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.Wpf;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
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


namespace WpfAppDotNetFrameWork
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public static WebView2 SystemWebView = new WebView2();
        public MainWindow()
        {
            InitializeComponent();
            System.Threading.Thread.Sleep(5000);
            nwebView2.Visibility = Visibility.Collapsed;
            nwebView2.WebMessageReceived += SystemWebView_WebMessageReceived;
            nwebView2.Source = new Uri("https://localhost:7144/");
            Grid.SetRow(nwebView2, 0);

            //browserWrapper.Children.Add(SystemWebView);
        }
        private void SystemWebView_WebMessageReceived(object sender = null, CoreWebView2WebMessageReceivedEventArgs e = null)
        {
            string commandString = e.TryGetWebMessageAsString();
            //nwebView2.Visibility = Visibility.Collapsed;
            nwebView2.CoreWebView2.Stop();
            UICommander commander = JsonConvert.DeserializeObject<UICommander>(commandString);
            lblCode.Content = commandString;
            //MessageBox.Show(string.Format("command is '{0}' and data is '{1}'", commander.command, commander.command), "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}

public class UICommander
{
    public string command { get; set; }
    public string meta { get; set; }
}


