using System;
using System.Collections.Generic;
using System.Text;

namespace AOP.Domain._3.FixOCPusingParameterObject._3._2.OneInterfaceToRuleThemAll
{
    // One interface to rule them all!

    //This design effectively prevents sweeping changes both when new features are added  and when new Cross-Cutting Concerns need to be applied. This design is now truly
    //closed for modification because:
    //      ¡ Adding a new(command) feature means creating a new command Parameter  Object and a supporting ICommandService implementation.No existing classes need to be    changed.
    //      ¡ Adding a new feature doesn’t force the creation of new Decorators nor the  change of existing Decorators.
    //      ¡ Adding a new Cross-Cutting Concern to the application can be done by adding  a single Decorator.
    //      ¡ Changing a Cross-Cutting Concern results in changing a single class.

    //Problem: LSP says that you must be able to substitute an Abstraction for an arbitrary implementation of that same Abstraction without changing the correctness of the client. But with the current code base we are able to violate LSP because we have one interface with 7 implementation and each of them does a different thing
    public interface ICommandService
    {
        void Execute(object command);
    }

    // The number of interfaces are reduced from seven back to one.
    // Consumers  can get this ICommandService injected into their constructor and call its Execute  method by supplying the appropriate Parameter Object.
    public class AdjustInventoryService : ICommandService
    {
        public void Execute(object cmd)
        {
            var command = (AdjustInventory)cmd;

            Guid id = command.ProductId;

            bool decrease = command.Decrease;
            int quantity = command.Quantity;
        }
    }
}
