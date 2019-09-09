namespace Aeddimedia.ServiceInterfaces
{
    /// <summary>
    /// Interface for a basic IoC container.
    /// </summary>
    public interface IIoCContainer
    {
        /// <summary>
        /// Registers an instance of the given type.
        /// </summary>
        /// <typeparam name="InterfaceType">The type of the inerface that will be requested.</typeparam>
        /// <typeparam name="ImplementedType">The type of the actual implementation that will be returned when the interface is requested.</typeparam>
        void RegisterInstance<InterfaceType, ImplementedType>();

        /// <summary>
        /// Registers the given type as a singleton.
        /// </summary>
        /// <typeparam name="InterfaceType">The type of the inerface that will be requested.</typeparam>
        /// <typeparam name="ImplementedType">The type of the actual implementation that will be returned when the interface is requested.</typeparam>
        void RegisterSingleton<InterfaceType, ImplementedType>();

        /// <summary>
        /// Resolves an instance of the given type.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <returns>An instance of the type.</returns>
        T Resolve<T>();
    }
}
