```csharp
using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Timers;
using System.Windows.Forms;

namespace CookieClickerAutoClicker
{
    public partial class MainForm : Form
    {
        private const string GameProcessName = "CookieClicker"; // Adjust this based on the actual process name
        private const int MouseClickInterval = 100; // Milliseconds between clicks
        private IntPtr gameWindowHandle;
        private System.Timers.Timer clickTimer;
        private bool isClicking;

        public MainForm()
        {
            InitializeComponent();
            InitializeGameWindowHandle();
            InitializeClickTimer();
        }

        private void InitializeComponent()
        {
            this.StartButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(50, 30);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 23);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(150, 30);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(75, 23);
            this.StopButton.TabIndex = 1;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 101);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.StopButton);
            this.Name = "MainForm";
            this.Text = "Cookie Clicker Auto Clicker";
            this.ResumeLayout(false);
        }

        private void InitializeGameWindowHandle()
        {
            var processes = Process.GetProcessesByName(GameProcessName);
            gameWindowHandle = processes.FirstOrDefault()?.MainWindowHandle ?? IntPtr.Zero;
        }

        private void InitializeClickTimer()
        {
            clickTimer = new System.Timers.Timer(MouseClickInterval);
            clickTimer.Elapsed += (s, e) => PerformClick();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (gameWindowHandle != IntPtr.Zero)
            {
                isClicking = true;
                clickTimer.Start();
            }
            else
            {
                MessageBox.Show("Game is not running.");
            }
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            isClicking = false;
            clickTimer.Stop();
        }

        private void PerformClick()
        {
            if (!isClicking || gameWindowHandle == IntPtr.Zero) return;

            SetForegroundWindow(gameWindowHandle);
            MouseClick();