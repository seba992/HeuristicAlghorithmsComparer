using GalaSoft.MvvmLight;
using HeuristicAlghorithmsComparer.Model;
using HeuristicAlghorithmsComparer.Model.Services;

namespace HeuristicAlghorithmsComparer.ViewModel
{

    public class MainViewModel : ViewModelBase
    {
        private readonly IDatabaseService _databaseService;
        private readonly IMatlabService _matlabService;

        public const string WelcomeTitlePropertyName = "WelcomeTitle";



        public string WelcomeTitle { get; set; }

        public MainViewModel(IDatabaseService databaseService, IMatlabService matlabService)
        {
            _databaseService = databaseService;
            _matlabService = matlabService;

            //            _databaseService.CheckDbConnection();

            _databaseService.CheckInsertOperation();
            _matlabService.CheckMatlabConnection();
        }

        public void ExecuteSimulatedAnnealingTest()
        {
            _matlabService.ExecuteSimulatedAnnealing(); // TODO: add params from view
        }
    }
}