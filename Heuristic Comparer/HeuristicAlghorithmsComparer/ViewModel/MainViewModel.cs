using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using HeuristicAlghorithmsComparer.Model;
using HeuristicAlghorithmsComparer.Model.Enums;
using HeuristicAlghorithmsComparer.Model.Services;

namespace HeuristicAlghorithmsComparer.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IMatlabService _matlabService;
        private Alghoritm _selectedAlghoritm;
        private string _iterationGenerationName;
        private bool _isPopulationAlghoritm;
        private string _populationSwarmSizeName;

        public MainViewModel(IMatlabService matlabService)
        {
            _matlabService = matlabService;
            ExecuteCommand = new RelayCommand(ExecuteAction);

            SelectedAlghoritm = Alghoritm.SimulatedAnnealing;
            ActivateButtonLogic(SelectedAlghoritm);

            SelectedTestFunction = TestFunction.Bochachevsky;
        }

        public ICommand ExecuteCommand { get; set; }

        public IList<Alghoritm> AlghoritmTypes => Enum.GetValues(typeof(Alghoritm)).Cast<Alghoritm>().ToList();

        public IList<TestFunction> TestFunctions => Enum.GetValues(typeof(TestFunction)).Cast<TestFunction>().ToList();

        public Alghoritm SelectedAlghoritm
        {
            get { return _selectedAlghoritm; }
            set
            {
                _selectedAlghoritm = value;
                ActivateButtonLogic(value);
            }
        }

        public string IterationGenerationName
        {
            get { return _iterationGenerationName; }
            set
            {
                _iterationGenerationName = value;
                RaisePropertyChanged();
            }
        }

        public string PopulationSwarmSizeName
        {
            get { return _populationSwarmSizeName; }
            set
            {
                _populationSwarmSizeName = value; 
                RaisePropertyChanged();
            }
        }

        public TestFunction SelectedTestFunction { get; set; }

        public bool IsPopulationAlghoritm
        {
            get { return _isPopulationAlghoritm; }
            set
            {
                _isPopulationAlghoritm = value; 
                RaisePropertyChanged();
            }
        }

        public int TestCount { get; set; }

        public int MaxTime { get; set; }

        public int MaxIterations { get; set; }

        public int MaxFunctionEvaluations { get; set; }

        public int MaxStall { get; set; }

        public int PopulationSwarmSize { get; set; }
        private void ActivateButtonLogic(Alghoritm alghoritm)
        {
            IterationGenerationName = alghoritm == Alghoritm.SimulatedAnnealing
                ? MetaheuristicResources.LiczbaIteracji
                : MetaheuristicResources.LiczbaGeneracji;
            PopulationSwarmSizeName = alghoritm == Alghoritm.GeneticAlghoritm
                ? MetaheuristicResources.WielkoscPopulacji
                : (alghoritm == Alghoritm.ParticleSwarmOptimization ? MetaheuristicResources.WielkoscRoju : "");

            IsPopulationAlghoritm = alghoritm != Alghoritm.SimulatedAnnealing;
        }

        private void ExecuteAction()
        {
            switch (SelectedAlghoritm)
            {
                case Alghoritm.SimulatedAnnealing:
                    ExecuteSimulatedAnnealingTest(SelectedTestFunction, SelectedAlghoritm, MaxTime, MaxIterations, MaxFunctionEvaluations, MaxStall, TestCount);
                    break;
                case Alghoritm.ParticleSwarmOptimization:
                    ExecuteParticleSwarmTest(SelectedTestFunction, SelectedAlghoritm, MaxTime, MaxIterations, PopulationSwarmSize, MaxStall, TestCount);
                    break;
                case Alghoritm.GeneticAlghoritm:
                    ExecuteGeneticAlghoritmTest(SelectedTestFunction, SelectedAlghoritm, MaxTime, MaxIterations, PopulationSwarmSize, MaxStall, TestCount);
                    break;
                default:
                    throw new InvalidEnumArgumentException();
            }
        }

        private void ExecuteSimulatedAnnealingTest(TestFunction testFunction, Alghoritm alghoritm, int maxTime, int maxIterations, int maxFunctionEvaluations, int maxStall, int testCount)
        {
            for (var i = 0; i < testCount; i++)
            {
                _matlabService.ExecuteSimulatedAnnealing(testFunction,alghoritm,maxTime,maxIterations,maxFunctionEvaluations,maxStall);
            }
        }

        private void ExecuteGeneticAlghoritmTest(TestFunction testFunction, Alghoritm alghoritm, int maxTime, int maxGenerations, int populationSize, int maxStall, int testCount)
        {
            for (var i = 0; i < testCount; i++)
            {
                _matlabService.ExecuteSimulatedAnnealing(testFunction, alghoritm, maxTime, maxGenerations, populationSize, maxStall);
            }
        }

        private void ExecuteParticleSwarmTest(TestFunction testFunction, Alghoritm alghoritm, int maxTime, int maxGenerations, int swarmSize, int maxStall, int testCount)
        {
            for (var i = 0; i < testCount; i++)
            {
                _matlabService.ExecuteSimulatedAnnealing(testFunction, alghoritm, maxTime, maxGenerations, swarmSize, maxStall);
            }
        }
    }
}