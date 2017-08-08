using System;
using System.Windows;
using HeuristicAlghorithmsComparer.Model.Database;
using HeuristicAlghorithmsComparer.Model.Managers;
using HeuristicAlghorithmsComparer.Model.Wrappers;
using Alghoritm = HeuristicAlghorithmsComparer.Model.Enums.Alghoritm;
using TestFunction = HeuristicAlghorithmsComparer.Model.Enums.TestFunction;

namespace HeuristicAlghorithmsComparer.Model.Services
{
    public class MatlabService : IMatlabService
    {
        private readonly IAlghoritmRequestManager _alghoritmRequestManager;
        private readonly IDatabaseService _databaseService;
        private readonly MLApp.MLApp _matlabContext;

        public MatlabService(IAlghoritmRequestManager alghoritmRequestManager, IMatlabContextWrapper matlabContextWrapper, IDatabaseService databaseService)
        {
            _alghoritmRequestManager = alghoritmRequestManager;
            _databaseService = databaseService;
            _matlabContext = matlabContextWrapper.GetMatlabContext();
        }

        public void ExecuteSimulatedAnnealing(TestFunction function, Alghoritm alghoritm, int maxTime, int maxIterations,
            int maxFunctionEvaluations, int maxStall)
        {
            try
            {
                var testFunction = _databaseService.GetTestFunction(function);
                var selectedAlghoritm = _databaseService.GetAlghoritm(alghoritm);
                var inputParameter = new InputParameter()
                {
                    MaxTime = maxTime,
                    MaxIterations = maxIterations,
                    MaxFunctionEvaluations = maxFunctionEvaluations,
                    MaxStallIterations = maxStall
                };

                var annealingResultDetails = _alghoritmRequestManager.ExecuteAlghoritm(selectedAlghoritm, testFunction,
                    inputParameter);

                var result = new Result()
                {
                    InputParameter = inputParameter,
                    ResultDetail = annealingResultDetails,
                    TestFunctionId = testFunction.Id,
                    Alghoritm = selectedAlghoritm
                };

                _databaseService.SaveResult(result);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        public void ExecuteGeneticAlghoritm(TestFunction function, Alghoritm alghoritm, int maxTime, int maxGenerations,
            int populationSize, int maxStall)
        {
            try
            {
                var testFunction = _databaseService.GetTestFunction(function);
                var selectedAlghoritm = _databaseService.GetAlghoritm(alghoritm);
                var inputParameter = new InputParameter()
                {
                    MaxTime = maxTime,
                    MaxIterations = maxGenerations, // MaxGenerations
                    PopulationSize = populationSize,
                    MaxStallIterations = maxStall, // MaxStallGenerations
                };

                var geneticResultsDetails = _alghoritmRequestManager.ExecuteAlghoritm(selectedAlghoritm, testFunction,
                    inputParameter);

                var result = new Result()
                {
                    InputParameter = inputParameter,
                    ResultDetail = geneticResultsDetails,
                    TestFunctionId = testFunction.Id,
                    Alghoritm = selectedAlghoritm
                };

                _databaseService.SaveResult(result);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void ExecuteParticleSwarmTest(TestFunction function, Alghoritm alghoritm, int maxTime, int maxGenerations,
            int swarmSize, int maxStall)
        {
            try
            {
                var testFunction = _databaseService.GetTestFunction(function);
                var selectedAlghoritm = _databaseService.GetAlghoritm(alghoritm);
                var inputParameter = new InputParameter()
                {
                    MaxTime = maxTime,
                    MaxIterations = maxGenerations, // MaxGenerations
                    SwarmSize = swarmSize,
                    MaxStallIterations = maxStall // MaxStallGenerations
                };

                var geneticResultsDetails = _alghoritmRequestManager.ExecuteAlghoritm(selectedAlghoritm, testFunction,
                    inputParameter);

                var result = new Result()
                {
                    InputParameter = inputParameter,
                    ResultDetail = geneticResultsDetails,
                    TestFunctionId = testFunction.Id,
                    Alghoritm = selectedAlghoritm
                };

                _databaseService.SaveResult(result);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}