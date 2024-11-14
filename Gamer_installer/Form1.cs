using System.Diagnostics;

namespace Gamer_installer
{
    public partial class Form1 : Form
    {
        private List<SetupFile> setupFilesList;

        public Form1()
        {
            InitializeComponent();
            ScanDirectory();

        }
        public class SetupFile
        {
            public string FileName { get; set; }
            public string DisplayName { get; set; }
            public string Arguments { get; set; }
            public string Directory { get; set; }

            public SetupFile(string fileName, string displayName, string arguments, string directory)
            {
                FileName = fileName;
                DisplayName = displayName;
                Arguments = arguments;
                Directory = directory;
            }
        }

        private void ScanDirectory()
        {
            listBoxSetups.Items.Clear();

            setupFilesList = new List<SetupFile>
            {
                new SetupFile("vlcsetup.exe", "VLC Media Player - 3.0.11 x64", "/S",""),
                new SetupFile("ChromeStandaloneSetup64.exe", "Chrome Browser", "/silent /install",""),
                new SetupFile("BraveBrowserStandaloneNightlySetup.exe", "Brave Browser", "/silent /install", ""),
                new SetupFile("winrarsetup.exe", "WinRAR", "/S", ""),
                new SetupFile("MSI Afterburner.exe", "MSI Afterburner 4.6.5", "/S", ""),
                new SetupFile("HWiNFO64.exe", "Hardware INFO", "/VERYSILENT /NORESTART /SUPPRESSMSGBOXES", ""),
                new SetupFile("CrystalDiskMark.exe", "Crystal Disk Mark", "/VERYSILENT /NORESTART", ""),
                new SetupFile("driver_booster_setup.exe", "IObit Driver Booster", "/verysilent", ""),
                new SetupFile("NDP452-KB2901907-x86-x64-AllOS-ENU.exe", "DOT NET V4.5.2 Runtime", "/q /AcceptEULA /norestart", ""),
                new SetupFile("windowsdesktop-runtime-6.0.31-win-x64.exe", "DOT NET V6.0.31 Runtime", "/q /AcceptEULA /norestart", ""),
                new SetupFile("DXSETUP.exe", "DirectX offline Installer", "/silent", "directx"),
                new SetupFile("install_all.bat", "Visual C++ (2003-2022) AIO Installer", "", "Visual-C-Runtimes-All-in-One-May-2024"),
                new SetupFile("Autocad2020-GaMeR.bat", "AutoCAD 2020 NetRUNNER version", "", "AutoCAD_GaMeR"),
                new SetupFile("MAS.cmd", "Activate Windows @NetRunner", "", "Microsoft-Activation-Scripts-master"),
                new SetupFile("Setup.cmd", "MS Office 2021 NetRUNNER version", "", "MSOffice_2021_GaMeR")

            };

            string[] filesInDirectory = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.exe");

            // Filter files based on allowed filenames
            foreach (SetupFile setupFile in setupFilesList)
            {
                if (!string.IsNullOrEmpty(setupFile.Directory))
                {
                    string dirPath = Path.Combine(Directory.GetCurrentDirectory(), setupFile.Directory);
                    if (Directory.Exists(dirPath))
                    {
                        string[] filesInSubDirectory = Directory.GetFiles(dirPath, setupFile.FileName);
                        foreach (string file in filesInSubDirectory)
                        {
                            listBoxSetups.Items.Add(setupFile.DisplayName);
                        }
                    }
                }
                else
                {
                    if (filesInDirectory.Contains(Path.Combine(Directory.GetCurrentDirectory(), setupFile.FileName)))
                    {
                        listBoxSetups.Items.Add(setupFile.DisplayName);
                    }
                }
            }

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            progressBarInstallation.Value = 0;
            progressBarInstallation.Maximum = listBoxSetups.CheckedItems.Count;
            listBoxSetups.Visible = false;
            textBoxInstallLog.Visible = true;
            textBoxInstallLog.Clear();


            foreach (string displayName in listBoxSetups.CheckedItems)
            {
                SetupFile setupFile = setupFilesList.FirstOrDefault(s => s.DisplayName == displayName);
                if (setupFile != null)
                {
                    textBoxInstallLog.AppendText($"!!!!---Installing {setupFile.DisplayName}...!!!\r\n");
                    await InstallSetupAsync(setupFile);
                    progressBarInstallation.Value++;
                    textBoxInstallLog.AppendText($"!!!!---{setupFile.DisplayName} installed successfully...!!!\r\n-_-\n");

                }
            }
            MessageBox.Show("Installation completed");
        }

        private Task InstallSetupAsync(SetupFile setupFile)
        {
            return Task.Run(() =>
            {
                string filePath = string.IsNullOrEmpty(setupFile.Directory) ?
                Path.Combine(Directory.GetCurrentDirectory(), setupFile.FileName) :
                Path.Combine(Directory.GetCurrentDirectory(), setupFile.Directory, setupFile.FileName);
                Process process = new Process
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = filePath,
                            Arguments = setupFile.Arguments,
                            UseShellExecute = false,
                            CreateNoWindow = true,
                            RedirectStandardOutput = true,  // Redirect standard output
                            RedirectStandardError = true   // Redirect standard error to capture any errors
                        }
                    };
                // Event handler for capturing output asynchronously
                process.OutputDataReceived += (sender, e) =>
                    {
                        if (!string.IsNullOrEmpty(e.Data))
                        {
                            // Use Invoke to update UI controls from a non-UI thread
                            BeginInvoke(new Action(() =>
                            {
                                textBoxInstallLog.AppendText(e.Data + Environment.NewLine);  // Append output to textBoxInstallLog
                            }));
                        }
                    };
                process.Start();
                process.BeginOutputReadLine();
                process.WaitForExit();
            });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ScanDirectory();
            listBoxSetups.Visible = true;
            textBoxInstallLog.Visible = false;
        }

        private void listBoxSetups_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
