using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Win32;
using Newtonsoft.Json;
using r3d.PrinterSettings;
using Path = System.IO.Path;

namespace r3d
{
    /// <summary>
    /// Interaction logic for MaintainSettings.xaml
    /// </summary>
    public partial class MaintainSettings : Window
    {
        public string SettingsFolder;
        public string SettingsFile;
        private Settings printerSettings;

        public MaintainSettings()
        {
            InitializeComponent();
        }

        public MaintainSettings(string folder, string file)
        {
            InitializeComponent();

            if (string.IsNullOrWhiteSpace(folder) || string.IsNullOrWhiteSpace(file))
            {
                CreateNewPrinterSettingsFile();
            }
            else
            {
                SettingsFolder = folder;
                SettingsFile = file;
            }

            DisplaySettings();
            XAxisMinimum.Focus();
        }

        private void DisplaySettings()
        {
            LabelSettingsFolder.Content = SettingsFolder;
            TextSettingsFileName.Text = SettingsFile;

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

        private void SaveSettings()
        {
            printerSettings.XAxis.Minimum = Convert.ToInt32(XAxisMinimum.Text);
            printerSettings.XAxis.Maximum = Convert.ToInt32(XAxisMaximum.Text);
            printerSettings.XAxis.PointsPerMillimeter = Convert.ToInt32(XAxisPointsPerMillimeter.Text);

            printerSettings.YAxis.Minimum = Convert.ToInt32(YAxisMinimum.Text);
            printerSettings.YAxis.Maximum = Convert.ToInt32(YAxisMaximum.Text);
            printerSettings.YAxis.PointsPerMillimeter = Convert.ToInt32(YAxisPointsPerMillimeter.Text);

            printerSettings.ZAxis.Minimum = Convert.ToInt32(ZAxisMinimum.Text);
            printerSettings.ZAxis.Maximum = Convert.ToInt32(ZAxisMaximum.Text);
            printerSettings.ZAxis.PointsPerMillimeter = Convert.ToInt32(ZAxisPointsPerMillimeter.Text);
        }

        private void Menu_ExitClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void LoadJsonSettings()
        {
            using (var r = new StreamReader(Path.Combine(SettingsFolder, SettingsFile)))
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

        private void Menu_NewClick(object sender, RoutedEventArgs e)
        {
            CreateNewPrinterSettingsFile();
        }

        private void CreateNewPrinterSettingsFile()
        {
            printerSettings = new Settings
            {
                XAxis = new Axis { Minimum = 0, Maximum = 40, PointsPerMillimeter = 10},
                YAxis = new Axis { Minimum = 0, Maximum = 20, PointsPerMillimeter = 10 },
                ZAxis = new Axis { Minimum = 0, Maximum = 80, PointsPerMillimeter = 20 }
            };
            var json = JsonConvert.SerializeObject(printerSettings);

            var createNewSettingsFileDialog = new SaveFileDialog
            {
                InitialDirectory = SettingsFolder,
                DefaultExt = ".json",
                Filter = "Files (.json)|*.json|All files (*.*)|*.*",
                CheckPathExists = true
            };
            createNewSettingsFileDialog.ShowDialog();
            if (createNewSettingsFileDialog.FileName != "")
            {
                SettingsFolder = Path.GetDirectoryName(createNewSettingsFileDialog.FileName);
                SettingsFile = Path.GetFileName(createNewSettingsFileDialog.FileName);
                LabelSettingsFolder.Content = SettingsFolder;
                TextSettingsFileName.Text = SettingsFile;
                File.WriteAllText(createNewSettingsFileDialog.FileName, json);
            }
        }

        private void Menu_SaveClick(object sender, RoutedEventArgs e)
        {
            SaveSettings();
            var json = JsonConvert.SerializeObject(printerSettings);
            File.WriteAllText(Path.Combine(SettingsFolder, SettingsFile), json);
        }

        private void Menu_SaveAsClick(object sender, RoutedEventArgs e)
        {
            SaveSettings();
            var json = JsonConvert.SerializeObject(printerSettings);

            var saveAsUsingFileDialog = new SaveFileDialog
            {
                InitialDirectory = SettingsFolder,
                DefaultExt = ".json",
                Filter = "Files (.json)|*.json|All files (*.*)|*.*",
                CheckPathExists = true
            };
            saveAsUsingFileDialog.ShowDialog();
            if (saveAsUsingFileDialog.FileName != "")
            {
                SettingsFolder = Path.GetDirectoryName(saveAsUsingFileDialog.FileName);
                SettingsFile = saveAsUsingFileDialog.SafeFileName;
                LabelSettingsFolder.Content = SettingsFolder;
                TextSettingsFileName.Text = SettingsFile;
                File.WriteAllText(saveAsUsingFileDialog.FileName, json);
            }
        }
    }
}
