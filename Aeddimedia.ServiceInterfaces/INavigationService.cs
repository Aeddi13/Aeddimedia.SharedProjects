using System;

namespace Aeddimedia.ServiceInterfaces
{
    /// <summary>
    /// An interface that contains methods to enable viewmodel based navigation in an MVVM application.
    /// </summary>
    public interface INavigationService
    {
        /// <summary>
        /// Displays the corresponding View to the given ViewModel.
        /// The View is displayed modally in the region to which the ViewModel is registered to.
        /// </summary>
        /// <param name="viewModelType">The type of the ViewModel to navigate to.</param>
        void DisplayViewModally(Type viewModelType);

        /// <summary>
        /// Displays the corresponding View to the given ViewModel.
        /// The View is displayed in the region to which the ViewModel is registered to.
        /// </summary>
        /// <param name="viewModelType">The type of the ViewModel to navigate to.</param>
        void DisplayView(Type viewModelType);

        /// <summary>
        /// Registers a region with the give name.
        /// </summary>
        /// <param name="regionElement">The region.</param>
        /// <param name="regionName">The name of the region.</param>
        void RegisterRegion(object regionElement, string regionName);

        /// <summary>
        /// Registers a ViewModel type to the region with the given name.
        /// </summary>
        /// <param name="viewModelType">The type of the ViewModel.</param>
        /// <param name="regionName">The name of the region.</param>
        void RegisterViewModelToRegion(Type viewModelType, string regionName);
    }
}
