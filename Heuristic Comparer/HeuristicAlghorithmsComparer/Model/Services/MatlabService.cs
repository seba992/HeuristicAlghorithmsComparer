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
        private object _testResult;
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

        public void ExecuteSimulatedAnnealing()
        {
            try
            {
                var testFunction = _databaseService.GetTestFunction(TestFunction.Bochachevsky);
                var alghoritm = _databaseService.GetAlghoritm(Alghoritm.SimulatedAnnealing);
                var inputParameter = new InputParameter()
                {
                    MaxTime = 5,
                    MaxIterations = 10000,
                    MaxFunctionEvaluations = 10000,
                    MaxStallIterations = 10000
                };

                var annealingResultDetails = _alghoritmRequestManager.ExecuteAlghoritm(alghoritm, testFunction,
                    inputParameter);

                var result = new Result()
                {
                    InputParameter = inputParameter,
                    ResultDetail = annealingResultDetails,
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

                var annealingResultDetails = _alghoritmRequestManager.ExecuteAlghoritm(alghoritm, testFunction,
                    inputParameter);

                var result = new Result()
                {
                    InputParameter = inputParameter,
                    ResultDetail = annealingResultDetails,
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