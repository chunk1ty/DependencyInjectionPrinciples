using System;
using System.Transactions;
using AOP.Domain._3.FixOCPusingParameterObject;

namespace AOP.Domain._4.FixLSPintroducedInStep3WithGenericAbstraction
{
    // Avoid LSP violation and also removed the casting in each service
    // Main reason for the generic ICommandService<TCommand> is to prevent violating the LSP in its clients.

    // Changing the non-generic ICommandService into the generic ICommandService<TCommand> fixes our last SOLID violation.

    // This refactoring may be replaced with MediatR library 
    public interface ICommandService<TCommand>
    {
        void Execute(TCommand command);
    }

    public class TransactionCommandServiceDecorator<TCommand> : ICommandService<TCommand>
    {
        private readonly ICommandService<TCommand> decoratee;

        public void Execute(TCommand command)
        {
            using (var scope = new TransactionScope())
            {
                this.decoratee.Execute(command);
                scope.Complete();
            }
        }
    }

    public class SomeController
    {
        private readonly ICommandService<AdjustInventory> _adjustInventoryService;

        public SomeController(ICommandService<AdjustInventory> adjustInventoryService)
        {
            _adjustInventoryService = adjustInventoryService;
        }

        public void Index()
        {
            var adjustInventory = new AdjustInventory
            {
                Decrease = true,
                ProductId = Guid.NewGuid(),
                Quantity = 7
            };

            _adjustInventoryService.Execute(adjustInventory);
        }
    }

    public class AdjustInventoryService : ICommandService<AdjustInventory>
    {
        public void Execute(AdjustInventory command)
        {
            // call Db
        }
    }

    public interface IQueryService<TResult, TQuery>
    {
        TResult Execute(TQuery query);
    }
}
