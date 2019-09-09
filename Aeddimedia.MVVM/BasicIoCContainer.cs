using Aeddimedia.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Aeddimedia.MVVM
{
    /// <summary>
    /// A basic IoC container.
    /// </summary>
    public class BasicIoCContainer : IIoCContainer
    {
        private Dictionary<Type, RegistrationInfo> _registeredTypes = new Dictionary<Type, RegistrationInfo>();
        static Dictionary<Type, object> _createdSingletons = new Dictionary<Type, object>();

        /// <inheritdoc />
        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        /// <inheritdoc />
        public void RegisterInstance<InterfaceType, ImplementedType>()
        {
            Register<InterfaceType, ImplementedType>(RegistrationType.Instance);
        }

        /// <inheritdoc />
        public void RegisterSingleton<InterfaceType, ImplementedType>()
        {
            Register<InterfaceType, ImplementedType>(RegistrationType.Singleton);
        }

        private object Resolve(Type requestedType)
        {
            object resolvedType = null;

            if (_registeredTypes.ContainsKey(requestedType))
            {
                RegistrationInfo registrationInfo = _registeredTypes[requestedType];
                Type typeToCreate = registrationInfo.ObjectType;

                if (registrationInfo.RegistrationType == RegistrationType.Singleton)
                {
                    if (!_createdSingletons.ContainsKey(typeToCreate))
                    {
                        // create singleton
                        _createdSingletons.Add(typeToCreate, CreateInstance(typeToCreate));
                    }

                    resolvedType = _createdSingletons[typeToCreate];
                }
                else
                {
                    // create new instance
                    resolvedType = CreateInstance(typeToCreate);
                }
            }
            else
            {
                Debug.Fail(string.Format("The type {0} you are trying to resolve has not been registered in this container. Please register the type before trying to resolve it.", requestedType));
            }

            return resolvedType;
        }

        private object CreateInstance(Type typeToCreate)
        {
            //create new instance
            ConstructorInfo[] consInfo = typeToCreate.GetConstructors();

            ConstructorInfo firstConstructor = consInfo.FirstOrDefault();

            ParameterInfo[] parameters = firstConstructor.GetParameters();
            List<object> arguments = new List<object>();

            // resolve each parameter
            foreach (var param in parameters)
            {
                Type type = param.ParameterType;
                arguments.Add(this.Resolve(type));
            }

            object[] argumentsArray = arguments.Count == 0 ? null : arguments.ToArray();

            // use the default constructor to create
            return Activator.CreateInstance(typeToCreate, argumentsArray);
        }

        private void Register<InterfaceType, ImplementedType>(RegistrationType registrationType)
        {
            Type interfaceType = typeof(InterfaceType);
            Type implementedType = typeof(ImplementedType);

            if (_registeredTypes.ContainsKey(interfaceType))
            {
                Debug.Fail(string.Format("An instance of the type {0} has already been registered.", interfaceType));
            }

            RegistrationInfo registrationModel = new RegistrationInfo()
            {
                ObjectType = implementedType,
                RegistrationType = registrationType
            };

            _registeredTypes.Add(interfaceType, registrationModel);
        }

        internal enum RegistrationType
        {
            Instance,
            Singleton
        };

        internal class RegistrationInfo
        {
            internal Type ObjectType { get; set; }
            internal RegistrationType RegistrationType { get; set; }
        }
    }
}
