using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using Newtonsoft.Json;
using r3d.PrinterSettings;
using Path = System.IO.Path;
using SvgLibrary;

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

        private SvgDocument svgDocument;

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
            // Sample z-axis
            // 1.75e-007 || .000000175 || .175 mm || this is a Slic3r issue, not sure why the divide by 1M
            // 3.75e-007
            // 4.25e-007
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
                printSettingsFolder = Path.GetDirectoryName(dlg.FileName);
                printSettingsFileName = dlg.SafeFileName;
                LabelSettingsFolder.Content = printSettingsFolder;
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
                printFilesFolder = Path.GetDirectoryName(dlg.FileName);
                printFileName = dlg.SafeFileName;
                LabelFilesFolder.Content = printFilesFolder;
                TextFileName.Text = printFileName;

                LoadTreeFromSvgFile();
            }
        }

        private void ResetTree()
        {
            //m_sFileName = "";

            //m_lvstate = new Hashtable();

            //txtXML.Text = "";
            TreeViewPrintFile.Items.Clear();

            svgDocument = new SvgDocument();
        }

        private void LoadTreeFromSvgFile()
        {
            //var openFile = new OpenFileDialog();
            //if (openFile.ShowDialog(this) != DialogResult.OK)
            //{
            //    return;
            //}

            //if (!File.Exists(openFile.FileName))
            //{
            //    MessageBox.Show("The file does not exists!", "SVGPad", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}

            ResetTree();

            //m_sFileName = openFile.FileName;

            if (!svgDocument.LoadFromFile(Path.Combine(printFilesFolder, printFileName)) || svgDocument.GetSvgRoot() == null)
            {
                MessageBox.Show("The file is not a valid Svg!", "SVGLoad", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            //sb.Text = m_sFileName;

            AddNodeToTree(null, svgDocument.GetSvgRoot(), null);
        }

        private SvgElement GetCurrentSvgElement()
        {
            TreeViewItem node = TreeViewPrintFile.SelectedItem as TreeViewItem;
            if (node == null)
            {
                return null;
            }

            // the tree view node tag is the SvgElement getInternalId()
            SvgElement ele = svgDocument.GetSvgElement((int)node.Tag);

            return ele;
        }

        private TreeViewItem FindNodeByTag(TreeViewItem nodeParent, string sTag)
        {
            //if (nodeParent == null)
            //{
            //    // start from the root
            //    nodeParent = TreeViewPrintFile.Items[0];
            //}
            //if (nodeParent == null)
            //{
            //    // the tree is empty
            //    return null;
            //}

            //if (nodeParent.Tag.ToString() == sTag)
            //{
            //    return nodeParent;
            //}

            //foreach (TreeNode nod in nodeParent.Nodes)
            //{
            //    TreeNode nodToRet = FindNodeByTag(nod, sTag);
            //    if (nodToRet != null)
            //    {
            //        return nodToRet;
            //    }
            //}

            return null;
        }

        private void AddNodeToTree(SvgElement ele)
        {
            if (ele == null)
            {
                return;
            }

            SvgElement parent = GetCurrentSvgElement();
            AddNodeToTree(parent, ele, null);
        }

        private void AddNodeToTree(SvgElement eleParent,
                                   SvgElement eleToAdd,
                                   SvgElement eleBefore)
        {
            if (eleToAdd == null)
            {
                return;
            }

            string sNodeName = eleToAdd.GetElementName();
            string sId;
            sId = eleToAdd.Id;


            if (sId != "")
            {
                sNodeName += "_";
                sNodeName += sId;
                //sNodeName += ")";
            }
            TreeViewItem node = new TreeViewItem { Name = sNodeName };
            node.Tag = eleToAdd.GetInternalId();

            TreeViewItem nodeParent = null;
            TreeViewItem nodeBefore = null;

            if (eleParent != null)
            {
                nodeParent = FindNodeByTag(null, eleParent.GetInternalId().ToString());
            }

            if (eleBefore != null)
            {
                nodeBefore = FindNodeByTag(nodeParent, eleBefore.GetInternalId().ToString());
            }

            if (nodeParent == null)
            {
                if (nodeBefore == null)
                {
                    TreeViewPrintFile.Items.Add(node);
                }
                else
                {
                    //TreeViewPrintFile.Items.Insert(nodeBefore.Index, node);
                }
            }
            else
            {
                if (nodeBefore == null)
                {
                    nodeParent.Items.Add(node);
                }
                else
                {
                    //nodeParent.Items.Insert(nodeBefore.Index, node);
                }
            }

            //node.ImageIndex = (int)eleToAdd.getElementType();
            //node.SelectedImageIndex = nod.ImageIndex;
            //node.Expand();

            if (eleToAdd.GetChild() != null)
            {
                AddNodeToTree(eleToAdd, eleToAdd.GetChild(), null);

                SvgElement nxt = eleToAdd.GetChild().GetNext();
                while (nxt != null)
                {
                    AddNodeToTree(eleToAdd, nxt, null);
                    nxt = nxt.GetNext();
                }
            }
            TreeViewPrintFile.Items.MoveCurrentTo(node);
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
