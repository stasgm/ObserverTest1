using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverTest1
{
    class TimerBox : IObservable
    {
        private List<IObserver> observers;

        private int Value;
        public TimerBox()
        {
            observers = new List<IObserver>();
            Value = 0;
        }
        public void AddObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            observers.Remove(o);
        }

        public void NotifyObservers()
        {
            foreach (IObserver o in observers)
            {
                o.Update(Value);
            }
        }
        public void Increment()
        {
            Value++;
            NotifyObservers();
        }

        public bool InvokeRequired()
        {
            bool isInvokeRequired = true;
            foreach (IObserver o in observers)
            {
                isInvokeRequired = o.InvokeRequired();
            }
            return isInvokeRequired;
        }

        public void clear()
        {
            Value = 0;
            foreach (IObserver o in observers)
            {
                o.clear();
            }
        }

    }
}
