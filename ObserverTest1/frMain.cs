using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ObserverTest1
{
    public partial class frMain : Form
    {
//        private ManualResetEvent ev;
        private TimerBox tb;
//        private Thread thr;
        private bool isProgress = false;

        public frMain()
        {
            tb = new TimerBox();
            InitializeComponent();

            //thr и ev объявлены глобально
            //thr = new System.Threading.Thread(ff);       //функция ff вызывается в отдельном потоке
            //ev = new System.Threading.ManualResetEvent(false);

            LabelObserver lb = new LabelObserver(label1);
            tb.AddObserver(lb);

            progressBar1.Maximum = 1000;

            ProgressbarObserver pb = new ProgressbarObserver(progressBar1);
            tb.AddObserver(pb);

            ListBoxObserver lbox = new ListBoxObserver(listBox1);
            tb.AddObserver(lbox);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isProgress)
            {
                MessageBox.Show("Proccess in progress");
            }
            else
            {
                Thread thread = new Thread(new ThreadStart(ThreadProcSafe));
                thread.Start();
                isProgress = true;
            }
        }

        private void ThreadProcSafe()
        {
            //tb.clear();
            for (int i = 0; i < 1000; i++)
            {
                SetValue(tb);
                Thread.Sleep(5);
            }
            isProgress = false;
            MessageBox.Show("Done!");
            clear(tb);
        }

        delegate void SetTextCallback(TimerBox tb);
        
        private void clear(TimerBox tb)
        {
            if (tb.InvokeRequired())
            {
                SetTextCallback d = new SetTextCallback(clear);
                Invoke(d, new object[] { tb });
            }
            else
            {
                tb.clear();
            }
        }
        private void SetValue(TimerBox tb)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (tb.InvokeRequired())
            {
                SetTextCallback d = new SetTextCallback(SetValue);
                Invoke(d, new object[] { tb });
            }
            else
            {
                tb.Increment();
            }
        }

        /*
        private void ff(IProgress<string> progress)
        {
            for (int i = 0; i < 300; i++)
            {
                tb.Increment();
                Task.Delay(500).Wait();
            }
        }
        */

    }
}
