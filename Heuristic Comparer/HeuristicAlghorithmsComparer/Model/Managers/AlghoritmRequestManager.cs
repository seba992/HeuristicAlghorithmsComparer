using System;
using System.Windows;
using HeuristicAlghorithmsComparer.Database;
using HeuristicAlghorithmsComparer.Model.Parser;
using HeuristicAlghorithmsComparer.Model.Utils;
using HeuristicAlghorithmsComparer.Model.Wrappers;

namespace HeuristicAlghorithmsComparer.Model.Managers
{
    public class AlghoritmRequestManager : IAlghoritmRequestManager
    {
        private readonly IResultParser _resultParser;
        private readonly MLApp.MLApp _matlabContext;
        private object _computedResult;

        public AlghoritmRequestManager(IMatlabContextWrapper matlabContextWrapper, IResultParser resultParser)
        {
            _resultParser = resultParser;
            _matlabContext = matlabContextWrapper.GetMatlabContext();
        }

        public ResultDetail ExecuteAlghoritm(Enums.Alghoritm alghoritm, TestFunction testFunction, InputParameter inputParameter)
        {
            try
            {
                var alghoritmFileName = FunctionNameMatcher.GetAlghoritmFileName(alghoritm);
                var testFunctionFileName = FunctionNameMatcher.GetFunctionFileName(testFunction);

                _matlabContext.Feval(
                    alghoritmFileName,
                    7, // OutputParamsNumber
                    out _computedResult,
                    inputParameter.MaxTime,
                    inputParameter.MaxIterations,
                    inputParameter.MaxFunctionEvaluations,
                    inputParameter.MaxStallIterations,
                    testFunctionFileName,
                    testFunction.LowerBoundX,
                    testFunction.LowerBoundY,
                    testFunction.UpperBoundX,
                    testFunction.UpperBoundY
                    );


                return _resultParser.ParseAnnealingResult(_computedResult as object[]);
//                
//
//                MessageBox.Show((_computedResult as object[])[0].ToString());
//
//                MessageBox.Show(res[0].ToString());
//                var test2 = _computedResult;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return null;
        }
    }
}