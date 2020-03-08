using System;

namespace Container
{
    class Program
    {
        static void Main(string[] args)
        {
            MyContainer container = new MyContainer();

            container.Register<INewDomainService, NewDomainService>();
            container.Register<IDomainService, DomainService>();
            container.Register<IRepository, Repository>();
            container.Register<IDbContext, DbContext>();

            var newDomainService = container.Resolve<INewDomainService>();
            newDomainService.NewLogic();
        }
    }

    public class NewDomainService : INewDomainService
    {
        private readonly IDomainService _domainService;
        private readonly IRepository _repository;

        public NewDomainService(IDomainService domainService, IRepository repository)
        {
            _domainService = domainService;
            _repository = repository;
        }

        public void NewLogic()
        {
            Console.WriteLine("NewLogic");
            _domainService.Logic();
            _repository.Command();
        }
    }

    public interface INewDomainService
    {
        void NewLogic();
    }


    public class DomainService : IDomainService
    {
        public void Logic()
        {
            Console.WriteLine("logic");
        }
    }

    public interface IDomainService
    {
        void Logic();
    }

    public interface IRepository
    {
        void Command();
    }

    public class Repository : IRepository
    {
        private readonly IDbContext _context;

        public Repository(IDbContext context)
        {
            _context = context;
        }

        public void Command()
        {
            _context.Context();
            Console.WriteLine("Execute command");
        }
    }

    public interface IDbContext
    {
        void Context();
    }

    public class DbContext : IDbContext
    {
        public void Context()
        {
            Console.WriteLine("DbContext");
        }
    }
}

