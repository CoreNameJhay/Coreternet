using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using CefSharp.WinForms.Internals;

namespace Core_Browser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ChromiumWebBrowser chrome;

        

        private void Form1_Load(object sender, EventArgs e)
        {
            //Starts the CefSharp then Loads Google
           CefSettings settings = new CefSettings();
            Cef.Initialize(settings);
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
                //Types any website from the TextBox
                textBox1.Text = e.Address;
            }
            ));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Goes Back to Website where you visited
            if (chrome.CanGoForward)
                chrome.Forward();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Shutdowns the CefSharp
            Cef.Shutdown();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Loads a Website From TextBox (The "Go" Button)
            chrome.Load(textBox1.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            chrome.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Goes Back to the Previous Website
            if (chrome.CanGoBack)
                chrome.Back();
        }
    }
}
