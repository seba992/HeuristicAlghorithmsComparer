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

        public MainViewModel(IMatlabService matlabService)
        {
            _matlabService = matlabService;

            //            _databaseService.CheckDbConnection();

            //_databaseService.CheckInsertOperation();
            //_matlabService.CheckMatlabConnection();
            for (int i = 0; i < 100; i++)
            {
                ExecuteSimulatedAnnealingTest();
            }
            
        }

        public void ExecuteSimulatedAnnealingTest()
        {
            _matlabService.ExecuteSimulatedAnnealing(); // TODO: add params from view
        }
    }
}