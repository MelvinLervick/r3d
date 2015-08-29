using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
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
using Microsoft.Win32;

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
        private string printFilesFolder;
        private string printFileName;

        public MainWindow()
        {
            InitializeComponent();

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

        //private void Menu_OpenClick(object sender, RoutedEventArgs e)
        //{
        //    LogTextBlock.AppendText("Start Recording\r\n");
        //    mySerialPort.Open();
        //    Thread.Sleep(3000);
        //}

        //private void Menu_StartClick(object sender, RoutedEventArgs e)
        //{
        //    mySerialPort.Write("S");
        //}

        //public void AddDataMethod(string data)
        //{
        //    var values = new List<int>();

        //    int dataValue;
        //    if (Int32.TryParse(data, out dataValue))
        //    {
        //        values.Add(dataValue);
        //    }
        //    else
        //    {
        //        LogTextBlock.AppendText(data);
        //    }

        //    if (values.Count > 0)
        //    {
        //        foreach (var value in values)
        //        {
        //            if (SaveRecordedValue(value))
        //            {
        //                long avgValue = totalValue / countRecorded;
        //                var outputValue = string.Format("{0}\t{1}", DateTime.UtcNow, avgValue);

        //                using (var w = File.AppendText(AnalogData))
        //                {
        //                    w.WriteLine(outputValue);
        //                    w.Flush();
        //                }

        //                if (ScreenIO) LogTextBlock.AppendText(outputValue + Environment.NewLine);
        //                totalValue = 0;
        //                countRecorded = 0;
        //            }
        //        }
        //    }
        //}

        //public bool SaveRecordedValue(int data)
        //{
        //    if (countRecorded == 0)
        //    {
        //        timer.Restart();
        //        countRecorded++;
        //        totalValue += data;
        //    }
        //    else
        //    {
        //        countRecorded++;
        //        totalValue += data;
        //        if (timer.ElapsedMilliseconds > TimePeriod)
        //        {
        //            return true;
        //        }
        //    }

        //    return false;
        //}

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

        //private void Menu_PauseClick(object sender, RoutedEventArgs e)
        //{
        //    mySerialPort.Write("B");
        //}

        //private void Menu_CloseClick(object sender, RoutedEventArgs e)
        //{
        //    LogTextBlock.AppendText("Stop Recording\r\n");
        //    mySerialPort.Close();
        //}

        private void Menu_SettingsClick(object sender, RoutedEventArgs e)
        {
            SettingsTextBlock.AppendText("This is a test.");
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
            var dlg = OpenFileDialog(out result, LabelSettingsFolder.Content.ToString(), "xml");

            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                //TextSettingsFileName.Text = System.IO.Path.GetDirectoryName(dlg.FileName);
                TextSettingsFileName.Text = dlg.SafeFileName;
            }
        }

        private void Button_PrintClick(object sender, RoutedEventArgs e)
        {
            bool? result;
            var dlg = OpenFileDialog(out result, LabelFilesFolder.Content.ToString(), "svg");

            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                //TextFileName.Text = System.IO.Path.GetDirectoryName(dlg.FileName);
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
