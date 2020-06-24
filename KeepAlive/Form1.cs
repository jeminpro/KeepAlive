using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeepAlive
{
    public partial class Form1 : Form
    {
        /* http://blackwasp.co.uk/DisableScreensaver.aspx
         * Note that in some instance this might only
         */

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
            buttonStart.Text = "Running";
            buttonStart.Enabled = false;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for(; ; )
            {
                SetThreadExecutionState(ExecutionState.EsDisplayRequired | ExecutionState.EsContinuous);
                Thread.Sleep(1000 * 60); // wait for a minute
            }
        }

        [DllImport("kernel32.dll")]
        static extern ExecutionState SetThreadExecutionState(ExecutionState esFlags);

        [Flags]
        enum ExecutionState: uint
        {
            EsAwaymodeRequired = 0x00000040,
            EsContinuous = 0x80000000,
            EsDisplayRequired = 0x00000002,
            EsSystemRequired = 0x00000001
        }

    }
}
