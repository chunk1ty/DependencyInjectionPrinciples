using System;

namespace CyclicDependencies.After.PropertyInjection
{
    public interface IWorker
    {
        void DoSomething();
    }

    public class Worker : IWorker
    {
        private readonly IWorker1 _worker1;

        public Worker(IWorker1 worker1)
        {
            _worker1 = worker1;
        }

        public void DoSomething()
        {
            Console.WriteLine("DoSomething");
        }
    }

    public interface IWorker1
    {
        IWorker Worker { get; set; }

        void DoSomething1();
    }

    public class Worker1 : IWorker1
    {
        private IWorker _worker;

        public IWorker Worker
        {
            get
            {
                if (_worker == null)
                {
                    _worker = new Worker(new Worker1());
                }

                return _worker;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }
                // Only allow Dependency to be defined once
                if (_worker != null)
                {
                    throw new InvalidOperationException();
                }

                _worker = value;
            }
        }

        public void DoSomething1()
        {
            Worker.DoSomething();
            Console.WriteLine("DoSomething1");
        }
    }
}
