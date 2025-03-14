using System;
using System.Windows.Forms;

namespace StopwatchApp
{
    public partial class MainForm : Form
    {
        private Timer timer;
        private TimeSpan elapsedTime;
        private bool isRunning;

        public MainForm()
        {
            InitializeComponent(); // Laadt de UI-componenten
            timer = new Timer();
            timer.Interval = 1000; // 1 seconde
            timer.Tick += Timer_Tick;
            elapsedTime = TimeSpan.Zero;
            isRunning = false;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            elapsedTime = elapsedTime.Add(TimeSpan.FromSeconds(1));
            lblTime.Text = elapsedTime.ToString(@"hh\:mm\:ss");
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!isRunning)
            {
                timer.Start();
                isRunning = true;
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (isRunning)
            {
                timer.Stop();
                isRunning = false;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            timer.Stop();
            elapsedTime = TimeSpan.Zero;
            lblTime.Text = "00:00:00";
            isRunning = false;
        }
    }
}
