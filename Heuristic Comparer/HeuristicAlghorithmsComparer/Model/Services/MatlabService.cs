using System.Windows;
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
            _alghoritmRequestManager.CreateRequest(Alghoritm.SimulatedAnnealing, 5, 10, 1000, 1000, 1000, Enums.TestFunction.Bochachevsky);
        }
    }
}