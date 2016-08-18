using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObserverTest1
{
    class ListBoxObserver : IObserver
    {
        private ListBox lbox;
        public ListBoxObserver(ListBox newlbox)
        {
            lbox = newlbox;
        }
        public void Update(int Value)
        {
            lbox.Items.Add(Value.ToString());
        }
        public bool InvokeRequired()
        {
            return lbox.InvokeRequired;
        }
        public void clear()
        {
            lbox.Items.Clear();
        }
    }
}
