namespace ObserverTest1
{
    interface IObserver
    {
        void Update(int Value);
        bool InvokeRequired();
        void clear();
    }
}
