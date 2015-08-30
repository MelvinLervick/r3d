using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Windows;
using Microsoft.Win32;
using Newtonsoft.Json;
using r3d.PrinterSettings;
using Path = System.IO.Path;

namespace r3d
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int TimePeriod = 1000;
        private string arduinoPort;
        private SerialPort mySerialPort;
        public delegate void AddDataDelegate(string myString);
        public AddDataDelegate MyDelegate;
        //private int countRecorded;
        //private int totalValue;
        private Stopwatch timer;

        private string printSettingsFolder;
        private string printSettingsFileName;
        private Settings printerSettings;
        private string printFilesFolder;
        private string printFileName;

        public MainWindow()
        {
            InitializeComponent();
            Application.Current.MainWindow = this;

            GetAppSettings();

            try
            {
                mySerialPort = new SerialPort(arduinoPort)
                {
                    BaudRate = 9600,
                    DtrEnable = true
                };

                mySerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedEventHandler);
            }
            catch (Exception ex)
            {
                LogTextBlock.AppendText($@"{ex.ToString()}
");
            }

            LabelSettingsFolder.Content = printSettingsFolder;
            TextSettingsFileName.Text = printSettingsFileName;
            LabelFilesFolder.Content = printFilesFolder;

            //this.MyDelegate = new AddDataDelegate(AddDataMethod);
            //countRecorded = 0;
            //totalValue = 0;
            timer = new Stopwatch();
        }

        private void GetAppSettings()
        {
            arduinoPort = ConfigurationManager.AppSettings["ArduinoPort"];
            printSettingsFolder = ConfigurationManager.AppSettings["PrintSettingsFolder"];
            printFilesFolder = ConfigurationManager.AppSettings["PrintFilesFolder"];
            printFileName = ConfigurationManager.AppSettings["PrintFileName"];
        }

        private void Menu_FileExitClick(object sender, RoutedEventArgs e)
        {
            mySerialPort.Close();
            var app = Application.Current;
            app.Shutdown();
        }

        private void DataReceivedEventHandler(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                var sp = (SerialPort)sender;

                var data = mySerialPort.ReadLine();

                this.Dispatcher.BeginInvoke(MyDelegate, data);
            }
            catch (Exception ex)
            {
                this.Dispatcher.BeginInvoke(MyDelegate, ex);
            }
        }

        private void Menu_SettingsClick(object sender, RoutedEventArgs e)
        {
            var settingsWindow = new MaintainSettings(printSettingsFolder, printSettingsFileName)
            {
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };
            settingsWindow.ShowDialog();

            printSettingsFolder = settingsWindow.SettingsFolder;
            printSettingsFileName = settingsWindow.SettingsFile;
            LabelSettingsFolder.Content = printSettingsFolder;
            TextSettingsFileName.Text = printSettingsFileName;

            DisplaySettings();
        }

        private void WriteLine(string text)
        {
            SettingsTextBlock.AppendText($"{text}\r".Replace("\t","  "));
        }

        public void LoadJsonSettings()
        {
            using (var r = new StreamReader(Path.Combine(printSettingsFolder, printSettingsFileName)))
            {
                var json = r.ReadToEnd();
                printerSettings = JsonConvert.DeserializeObject<Settings>(json);
            }
        }

        private void Menu_OpenSvgFileClick(object sender, RoutedEventArgs e)
        {
        }

        private void Menu_ReadLayerClick(object sender, RoutedEventArgs e)
        {
        }

        private void Menu_SendLayerClick(object sender, RoutedEventArgs e)
        {
        }

        private void Button_SettingsClick(object sender, RoutedEventArgs e)
        {
            bool? result;
            var dlg = OpenFileDialog(out result, LabelSettingsFolder.Content.ToString(), "json");

            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document
                printSettingsFileName = dlg.SafeFileName;
                TextSettingsFileName.Text = printSettingsFileName;
            }

            DisplaySettings();
        }

        private void DisplaySettings()
        {
            SettingsTextBlock.Document.Blocks.Clear();

            LoadJsonSettings();

            WriteLine($"Settings:\r\tX-Axis:");
            WriteLine($"\t\tMinimum: {printerSettings.XAxis.Minimum}");
            WriteLine($"\t\tMaximum: {printerSettings.XAxis.Maximum}");
            WriteLine($"\t\tPoints/Millimeter: {printerSettings.XAxis.PointsPerMillimeter}");

            WriteLine($"\tY-Axis:");
            WriteLine($"\t\tMinimum: {printerSettings.YAxis.Minimum}");
            WriteLine($"\t\tMaximum: {printerSettings.YAxis.Maximum}");
            WriteLine($"\t\tPoints/Millimeter: {printerSettings.YAxis.PointsPerMillimeter}");

            WriteLine($"\tZ-Axis:");
            WriteLine($"\t\tMinimum: {printerSettings.ZAxis.Minimum}");
            WriteLine($"\t\tMaximum: {printerSettings.ZAxis.Maximum}");
            WriteLine($"\t\tPoints/Millimeter: {printerSettings.ZAxis.PointsPerMillimeter}");
        }

        private void Button_PrintClick(object sender, RoutedEventArgs e)
        {
            bool? result;
            var dlg = OpenFileDialog(out result, LabelFilesFolder.Content.ToString(), "svg");

            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                TextFileName.Text = dlg.SafeFileName;
            }
        }

        private static OpenFileDialog OpenFileDialog(out bool? result, string dir, string extDefault)
        {
            var dlg = new Microsoft.Win32.OpenFileDialog
            {
                InitialDirectory = dir,
                DefaultExt = ".xml".Replace("xml", extDefault),
                Filter = "Files (.xml)|*.xml|All files (*.*)|*.*".Replace("xml", extDefault),
                CheckPathExists = true,
                CheckFileExists = true
            };

            // Display OpenFileDialog by calling ShowDialog method 
            result = dlg.ShowDialog();
            return dlg;
        }
    }
}
