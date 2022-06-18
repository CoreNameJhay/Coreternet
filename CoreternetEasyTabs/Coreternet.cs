using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CefSharp;
using CefSharp.WinForms;
using System.Windows.Forms;

namespace CoreternetEasyTabs
{
    public partial class Coreternet : Form
    {
        ChromiumWebBrowser chrome;
        public Coreternet()
        {
            InitializeComponent();
        }

        private void Coreternet_Load(object sender, EventArgs e)
        {
            textBox1.Text = "https://google.com/";
            chrome = new ChromiumWebBrowser(textBox1.Text);
            this.panel1.Controls.Add(chrome);
            chrome.Dock = DockStyle.Fill;
            chrome.AddressChanged += Chrome_AddressChanged;
        }



        private void Chrome_AddressChanged(object sender, AddressChangedEventArgs e)
        {
            this.Invoke(new MethodInvoker(() =>
            {
                // Enter a Website then Press Enter or Go Button
                textBox1.Text = e.Address;
            }
            ));



        }

        private void Coreternet_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                chrome.Load(textBox1.Text);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cef.Shutdown();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (chrome.CanGoBack)
                chrome.Back();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (chrome.CanGoForward)
                chrome.Forward();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Settings f2 = new Settings();
            f2.ShowDialog();
        }
    }   }
