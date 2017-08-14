using System;
using System.ComponentModel;
using System.Windows;
using HeuristicAlghorithmsComparer.Model.Database;
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
                    return ExecuteParticleSwarmAlghoritm(alghoritm, testFunction, inputParameter);
                case Enums.Alghoritm.GeneticAlghoritm:
                    return ExecuteGeneticAlghoritmAlghoritm(alghoritm, testFunction, inputParameter);
                default:
                    throw new InvalidEnumArgumentException();
            }
        }

        private ResultDetail ExecuteParticleSwarmAlghoritm(Alghoritm alghoritm, TestFunction testFunction, InputParameter inputParameter)
        {
            try
            {
                var alghoritmFileName = FunctionNameMatcher.GetAlghoritmFileName(alghoritm);
                var testFunctionFileName = FunctionNameMatcher.GetFunctionFileName(testFunction);

                _computedResult = null;

                _matlabContext.Feval(
                    alghoritmFileName,
                    5, // OutputParamsNumber
                    out _computedResult,
                    (double)inputParameter.MaxTime,
                    (double)inputParameter.MaxIterations,
                    (double)inputParameter.SwarmSize,
                    (double)inputParameter.MaxStallIterations,
                    testFunctionFileName,
                    (double)testFunction.BoundRange,
                    (double)testFunction.Dimension
                    );

                return _resultParser.ParseResult(_computedResult as object[]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
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
                    5, // OutputParamsNumber
                    out _computedResult,
                    (double)inputParameter.MaxTime,
                    (double)inputParameter.MaxIterations,
                    (double)inputParameter.PopulationSize,
                    (double)inputParameter.MaxStallIterations,
                    testFunctionFileName,
                    (double)testFunction.BoundRange,
                    (double)testFunction.Dimension
                    );

                return _resultParser.ParseResult(_computedResult as object[]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
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
                    5, // OutputParamsNumber
                    out _computedResult,
                    (double)inputParameter.MaxTime,
                    (double)inputParameter.MaxIterations,
                    (double)inputParameter.MaxFunctionEvaluations,
                    (double)inputParameter.MaxStallIterations,
                    testFunctionFileName,
                    (double)testFunction.BoundRange,
                    testFunction.Dimension
                    );

                return _resultParser.ParseResult(_computedResult as object[]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
        }
    }
}