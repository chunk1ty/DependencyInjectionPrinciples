using Autofac;
using CyclicDependencies.After.PropertyInjection;


namespace CyclicDependencies.After
{
    public class Program
    {
        static void Main(string[] args)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<Worker>().As<IWorker>();
            containerBuilder.RegisterType<Worker1>().As<IWorker1>();

            IContainer container = containerBuilder.Build();

            var worker = container.Resolve<IWorker>();
            worker.DoSomething();

            var worker1 = container.Resolve<IWorker1>();
            worker1.Worker = new Worker(worker1);
            worker1.DoSomething1();
        }
    }
}
