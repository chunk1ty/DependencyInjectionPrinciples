using System;
using Autofac;

namespace CyclicDependencies.Before
{
    class Program
    {
        static void Main(string[] args)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<Worker>().As<IWorker>();
            containerBuilder.RegisterType<Worker1>().As<IWorker1>();

            IContainer container = containerBuilder.Build();

            // throw exception Autofac.Core.DependencyResolutionException: An exception was thrown while activating CyclicDependencies.Before.Worker
            container.Resolve<IWorker>();
        }
    }

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
            _worker1.DoSomething1();
            Console.WriteLine("DoSomething");
        }
    }

    public interface IWorker1
    {
        void DoSomething1();
    }

    public class Worker1 : IWorker1
    {
        private readonly Worker _worker;

        public Worker1(Worker worker)
        {
            _worker = worker;
        }

        public void DoSomething1()
        {
            _worker.DoSomething();
            Console.WriteLine("DoSomething");
        } 
    }
}
