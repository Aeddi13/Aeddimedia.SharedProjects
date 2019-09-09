using Aeddimedia.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Aeddimedia.MVVM
{
    /// <summary>
    /// A basic IoC container.
    /// </summary>
    public class BasicIoCContainer : IIoCContainer
    {
        private Dictionary<Type, Type> _registeredTypes = new Dictionary<Type, Type>();

        /// <inheritdoc />
        public T GetInstance<T>()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void RegisterInstace<InterfaceType, ImplementedType>()
        {
            Type interfaceType = typeof(InterfaceType);
            Type implementedType = typeof(ImplementedType);

            if (_registeredTypes.ContainsKey(interfaceType))
            {
                Debug.Fail(string.Format("An instance of the type {0} has already been registered.", interfaceType));
            }

            _registeredTypes.Add(interfaceType, implementedType);
        }
    }
}
