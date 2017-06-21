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

        public ResultDetail ExecuteAlghoritm(Alghoritm alghoritm, TestFunction testFunction, InputParameter inputParameter)
        {
            switch ((Enums.Alghoritm)Enum.Parse(typeof(Enums.Alghoritm), alghoritm.Name.Replace(" ",string.Empty)))
            {
                case Enums.Alghoritm.SimulatedAnnealing:
                    return ExecuteSimulatedAnnealingAlghoritm(alghoritm, testFunction, inputParameter);
                case Enums.Alghoritm.ParticleSwarmOptimization:
                    return null;
                    break;
                case Enums.Alghoritm.GeneticAlghoritm:
                    return ExecuteGeneticAlghoritmAlghoritm(alghoritm, testFunction, inputParameter);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
        }

        private ResultDetail ExecuteGeneticAlghoritmAlghoritm(Alghoritm alghoritm, TestFunction testFunction, InputParameter inputParameter)
        {
            try
            {
                var alghoritmFileName = FunctionNameMatcher.GetAlghoritmFileName(alghoritm);
                var testFunctionFileName = FunctionNameMatcher.GetFunctionFileName(testFunction);

                _computedResult = null;

                _matlabContext.Feval(
                    alghoritmFileName,
                    6, // OutputParamsNumber
                    out _computedResult,
                    (double)inputParameter.MaxTime,
                    (double)inputParameter.MaxIterations,
                    (double)2, // Nvariables
                    (double)inputParameter.PopulationSize,
                    (double)inputParameter.MaxStallIterations,
                    testFunctionFileName,
                    testFunction.LowerBoundX,
                    testFunction.LowerBoundY,
                    testFunction.UpperBoundX,
                    testFunction.UpperBoundY
                    );


                return _resultParser.ParseGeneticResult(_computedResult as object[]);
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

        private ResultDetail ExecuteSimulatedAnnealingAlghoritm(Alghoritm alghoritm, TestFunction testFunction, InputParameter inputParameter)
        {
            try
            {
                var alghoritmFileName = FunctionNameMatcher.GetAlghoritmFileName(alghoritm);
                var testFunctionFileName = FunctionNameMatcher.GetFunctionFileName(testFunction);

                _computedResult = null;

                _matlabContext.Feval(
                    alghoritmFileName,
                    8, // OutputParamsNumber
                    out _computedResult,
                    (double)inputParameter.MaxTime,
                    (double)inputParameter.MaxIterations,
                    (double)inputParameter.MaxFunctionEvaluations,
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