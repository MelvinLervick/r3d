using System;
using System.Collections.Generic;
using System.IO;
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
using Newtonsoft.Json;
using r3d.PrinterSettings;
using Path = System.Windows.Shapes.Path;

namespace r3d
{
    /// <summary>
    /// Interaction logic for MaintainSettings.xaml
    /// </summary>
    public partial class MaintainSettings : Window
    {
        private string settingsFolder;
        private string settingsFile;
        private Settings printerSettings;

        public MaintainSettings()
        {
            InitializeComponent();
        }

        public MaintainSettings(string folder, string file)
        {
            InitializeComponent();
            settingsFolder = folder;
            settingsFile = file;

            DisplaySettings();
            XAxisMinimum.Focus();
        }

        private void DisplaySettings()
        {
            LoadJsonSettings();

            XAxisMinimum.Text = printerSettings.XAxis.Minimum.ToString();
            XAxisMaximum.Text = printerSettings.XAxis.Maximum.ToString();
            XAxisPointsPerMillimeter.Text = printerSettings.XAxis.PointsPerMillimeter.ToString();

            YAxisMinimum.Text = printerSettings.YAxis.Minimum.ToString();
            YAxisMaximum.Text = printerSettings.YAxis.Maximum.ToString();
            YAxisPointsPerMillimeter.Text = printerSettings.YAxis.PointsPerMillimeter.ToString();

            ZAxisMinimum.Text = printerSettings.ZAxis.Minimum.ToString();
            ZAxisMaximum.Text = printerSettings.ZAxis.Maximum.ToString();
            ZAxisPointsPerMillimeter.Text = printerSettings.ZAxis.PointsPerMillimeter.ToString();
        }

        private void Menu_ExitClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void LoadJsonSettings()
        {
            using (var r = new StreamReader(System.IO.Path.Combine(settingsFolder, settingsFile)))
            {
                var json = r.ReadToEnd();
                printerSettings = JsonConvert.DeserializeObject<Settings>(json);
            }
        }

        private void SelectAddress(object sender, RoutedEventArgs e)
        {
            var tb = (sender as TextBox);
            if (tb != null)
            {
                tb.SelectAll();
            }
        }

        private void SelectivelyIgnoreMouseButton(object sender,
            MouseButtonEventArgs e)
        {
            var tb = (sender as TextBox);
            if (tb != null)
            {
                if (!tb.IsKeyboardFocusWithin)
                {
                    e.Handled = true;
                    tb.Focus();
                }
            }
        }
    }
}
