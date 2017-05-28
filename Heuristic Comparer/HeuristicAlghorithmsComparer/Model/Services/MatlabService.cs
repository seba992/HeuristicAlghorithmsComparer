using System.Windows;
using HeuristicAlghorithmsComparer.Model.Enums;
using HeuristicAlghorithmsComparer.Model.Managers;
using HeuristicAlghorithmsComparer.Model.Wrappers;
using Alghoritm = HeuristicAlghorithmsComparer.Model.Enums.Alghoritm;

namespace HeuristicAlghorithmsComparer.Model.Services
{
    public class MatlabService : IMatlabService
    {
        private readonly IAlghoritmRequestManager _alghoritmRequestManager;
        private object _testResult;
        private MLApp.MLApp _matlabContext;

        public MatlabService(IAlghoritmRequestManager alghoritmRequestManager, IMatlabContextWrapper matlabContextWrapper)
        {
            _alghoritmRequestManager = alghoritmRequestManager;
            _matlabContext = matlabContextWrapper.GetMatlabContext();


        }

        public void CheckMatlabConnection()
        {
            MessageBox.Show(_matlabContext.Execute("1+1"));
        }

        public void ExecuteSimulatedAnnealing()
        {
            var annealingRequest = new AlghoritmRequest()
            {
                OutputParamsNumber = 5,
                Alghoritm = Alghoritm.SimulatedAnnealing,
                MaxTime = 5,
                MaxIterations = 10,
                MaxFunctionEvaluations = 1000,
                MaxStallIterations = 1000,
                TestFunction = TestFunction.Bochachevsky
            };

            _alghoritmRequestManager.ExecuteAlghoritm(annealingRequest);
        }
    }
}