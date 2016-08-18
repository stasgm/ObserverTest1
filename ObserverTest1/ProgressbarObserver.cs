using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObserverTest1
{
    class ProgressbarObserver : IObserver
    {
        private ProgressBar pb;
        public ProgressbarObserver(ProgressBar newpb)
        {
            pb = newpb;
        }
        public void Update(int Value)
        {
            int predValue = pb.Value;
            try
            {
                pb.Value = Value;
            }
            catch (Exception e)
            {
                pb.Value = predValue;
            }
        }
        public bool InvokeRequired()
        {
            return pb.InvokeRequired;
        }
        public void clear()
        {
            pb.Value = 0;
        }
    }
}
