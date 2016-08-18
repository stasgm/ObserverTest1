using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObserverTest1
{
    class LabelObserver : IObserver
    {
        private Label lb;
        public LabelObserver(Label newLabel)
        {
            lb = newLabel;
        }
        public void Update(int Value)
        {
            lb.Text = Value.ToString();
        }
        public bool InvokeRequired()
        {
            return lb.InvokeRequired;
        }

        public void clear()
        {
            lb.Text = "";
        }
    }
}
