using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DontShowHiddens
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }


        private void Main_Load(object sender, EventArgs e)
        {
            Task.Factory.StartNew(Do);
        }
        /// <summary>
        /// Uncheck Hidden CheckBox in windows every 3 
        /// secounds if given password is incorrect
        /// </summary>
        void Do()
        {
            //runs for ever
            while (true)
            {
                //wait 3 sec
                Task.Delay(3000);
                if (Str != "omidtavana.com")
                {
                    Hidden("0");
                }
            }
        }
        public string Str { get { return textBox1.Text; } set { value = textBox1.Text; } }
        /// <summary>
        /// Change windows Hiddent Registry to hide or show hidden files
        /// </summary>
        /// <param name="value">0/1</param>
        void Hidden(string value)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", true);
            key.SetValue("Hidden", value, RegistryValueKind.DWord);
            key.Close();
        }

        private void WhileForm_MouseClick(object sender, MouseEventArgs e)
        {
        }
    }
}
