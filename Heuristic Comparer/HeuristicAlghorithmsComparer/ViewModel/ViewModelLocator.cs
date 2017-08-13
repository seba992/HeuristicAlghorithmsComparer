/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocatorTemplate xmlns:vm="clr-namespace:HeuristicAlghorithmsComparer.ViewModel"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using HeuristicAlghorithmsComparer.Model.Database;
using Microsoft.Practices.ServiceLocation;
using HeuristicAlghorithmsComparer.Model.Managers;
using HeuristicAlghorithmsComparer.Model.Parser;
using HeuristicAlghorithmsComparer.Model.Services;
using HeuristicAlghorithmsComparer.Model.Wrappers;

namespace HeuristicAlghorithmsComparer.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                
            }
            else
            {
                SimpleIoc.Default.Register<EntityDataModelContainer>();
                SimpleIoc.Default.Register<IDatabaseService, DatabaseService>();
                SimpleIoc.Default.Register<IMatlabService, MatlabService>();
                SimpleIoc.Default.Register<IAlghoritmRequestManager, AlghoritmRequestManager>();
                SimpleIoc.Default.Register<IMatlabContextWrapper, MatlabContextWrapper>();
                SimpleIoc.Default.Register<IResultParser, ResultParser>();
            }

            SimpleIoc.Default.Register<MainViewModel>();
        }

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
        }
    }
}