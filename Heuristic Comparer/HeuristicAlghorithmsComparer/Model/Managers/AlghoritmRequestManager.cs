using System;
using System.Windows;
using HeuristicAlghorithmsComparer.Model.Utils;
using HeuristicAlghorithmsComparer.Model.Wrappers;

namespace HeuristicAlghorithmsComparer.Model.Managers
{
    public class AlghoritmRequestManager : IAlghoritmRequestManager
    {
        private readonly MLApp.MLApp _matlabContext;
        private object _computedResult;

        public AlghoritmRequestManager(IMatlabContextWrapper matlabContextWrapper)
        {
            _matlabContext = matlabContextWrapper.GetMatlabContext();
        }

        public void ExecuteAlghoritm(AlghoritmRequest alghoritmRequest)
        {
            try
            {
                var alghoritmFileName = FunctionNameMatcher.GetAlghoritmFileName(alghoritmRequest.Alghoritm);
                var testFunctionFileName = FunctionNameMatcher.GetFunctionFileName(alghoritmRequest.TestFunction);
                _matlabContext.Feval(
                    alghoritmFileName,
                    alghoritmRequest.OutputParamsNumber,
                    out _computedResult,
                    alghoritmRequest.MaxTime,
                    alghoritmRequest.MaxIterations, 
                    alghoritmRequest.MaxFunctionEvaluations,
                    alghoritmRequest.MaxStallIterations,
                    testFunctionFileName);
                object[] res = _computedResult as object[];
                MessageBox.Show(res[0].ToString());
                var test2 = _computedResult;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }
    }
}