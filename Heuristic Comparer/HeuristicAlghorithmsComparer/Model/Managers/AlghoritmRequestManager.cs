using HeuristicAlghorithmsComparer.Model.Enums;
using HeuristicAlghorithmsComparer.Model.Managers;
using HeuristicAlghorithmsComparer.Model.Wrappers;
using TestFunction = HeuristicAlghorithmsComparer.Database.TestFunction;

namespace HeuristicAlghorithmsComparer.Model.Services
{
    public class AlghoritmRequestManager : IAlghoritmRequestManager
    {
        private readonly MLApp.MLApp _matlabContext;
        private object _computingResult;

        public AlghoritmRequestManager(IMatlabContextWrapper matlabContextWrapper)
        {
            _matlabContext = matlabContextWrapper.GetMatlabContext();
        }

        public void CreateRequest(Alghoritm alghoritm, int maxTime, double maxIterations, double maxFunction,
            double maxFunctionEvaluations, double maxStallIterations, Enums.TestFunction testFunction)
        {
            var alghoritmFileName = Utils.FunctionNameMatcher.GetAlghoritmFileName(alghoritm);
            var testFunctionFileName = Utils.FunctionNameMatcher.GetFunctionFileName(testFunction);

            _matlabContext.Feval(alghoritmFileName, 5, out _computingResult, (double)10, (double)1000, (double)1000, (double)1000, 1);
        }
    }
}