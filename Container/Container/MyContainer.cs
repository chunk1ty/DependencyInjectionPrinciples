using System;
using System.Collections.Generic;
using System.Linq;

namespace Container
{
    public class MyContainer
    {
        readonly Dictionary<Type, Func<object>> _registrations = new Dictionary<Type, Func<object>>();

        public void Register<TAbstraction>(Func<object> factory)
        {
            _registrations[typeof(TAbstraction)] = factory;
        }

        public void Register<TAbstraction, TImplementation>() where TImplementation : TAbstraction
        {
            _registrations[typeof(TAbstraction)] = () => CreateNew(typeof(TImplementation));
        }

        public void Register(Type abstraction, Func<object> instanceCreator)
        {
            _registrations[abstraction] = instanceCreator;
        }

        public void Register(Type abstraction, Type implementation)
        {
            _registrations[abstraction] = () => CreateNew(implementation);
        }

        public TAbstraction Resolve<TAbstraction>()
        {
            if (_registrations.ContainsKey(typeof(TAbstraction)))
            {
                return (TAbstraction)_registrations[typeof(TAbstraction)]();
            }

            throw new InvalidOperationException("No registration for " + typeof(TAbstraction));
        }

        public object Resolve(Type type)
        {
            if (_registrations.ContainsKey(type))
            {
                return _registrations[type]();
            }

            throw new InvalidOperationException("No registration for " + type);
        }

        private object CreateNew(Type componentType)
        {
            var ctor = componentType.GetConstructors().Single();
            var parameterTypes = ctor.GetParameters().Select(p => p.ParameterType);
            var dependencies = parameterTypes.Select(t => Resolve(t)).ToArray();

            return Activator.CreateInstance(componentType, dependencies);
        }
    }
}
