using System;
using System.Windows;
using HeuristicAlghorithmsComparer.Database;
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
        private MLApp.MLApp _matlabContext;

        public MatlabService(IAlghoritmRequestManager alghoritmRequestManager, IMatlabContextWrapper matlabContextWrapper, IDatabaseService databaseService)
        {
            _alghoritmRequestManager = alghoritmRequestManager;
            _databaseService = databaseService;
            _matlabContext = matlabContextWrapper.GetMatlabContext();
        }

        public void CheckMatlabConnection()
        {
            MessageBox.Show(_matlabContext.Execute("1+1"));
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

        public void ExecuteGeneticAlghoritm()
        {
            try
            {
                var testFunction = _databaseService.GetTestFunction(TestFunction.Bochachevsky);
                var alghoritm = _databaseService.GetAlghoritm(Alghoritm.GeneticAlghoritm);
                var inputParameter = new InputParameter()
                {
                    MaxTime = 5,
                    MaxIterations = 1000, // MaxGenerations
                    PopulationSize = 100,
                    MaxStallIterations = 10000 // MaxStallGenerations
                };

                var geneticResultsDetails = _alghoritmRequestManager.ExecuteAlghoritm(alghoritm, testFunction,
                    inputParameter);

                var result = new Result()
                {
                    InputParameter = inputParameter,
                    ResultDetail = geneticResultsDetails,
                    TestFunctionId = testFunction.Id,
                    Alghoritm = alghoritm
                };

                _databaseService.SaveResult(result);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void ExecuteParticleSwarmTest()
        {
            try
            {
                var testFunction = _databaseService.GetTestFunction(TestFunction.Bochachevsky);
                var alghoritm = _databaseService.GetAlghoritm(Alghoritm.ParticleSwarmOptimization);
                var inputParameter = new InputParameter()
                {
                    MaxTime = 5,
                    MaxIterations = 1000, // MaxGenerations
                    SwarmSize = 100,
                    MaxStallIterations = 10000 // MaxStallGenerations
                };

                var geneticResultsDetails = _alghoritmRequestManager.ExecuteAlghoritm(alghoritm, testFunction,
                    inputParameter);

                var result = new Result()
                {
                    InputParameter = inputParameter,
                    ResultDetail = geneticResultsDetails,
                    TestFunctionId = testFunction.Id,
                    Alghoritm = alghoritm
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