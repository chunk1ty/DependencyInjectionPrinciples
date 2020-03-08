using System;
using System.Collections.Generic;
using System.Text;

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
}
