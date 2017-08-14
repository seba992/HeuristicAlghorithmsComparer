﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using HeuristicAlghorithmsComparer.Model.Enums;
using HeuristicAlghorithmsComparer.Model.Services;

namespace HeuristicAlghorithmsComparer.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IMatlabService _matlabService;
        private int _currentProgress;
        private bool _isIndicatorBusy;
        private bool _isPopulationAlghoritm;
        private string _iterationGenerationName;
        private string _populationSwarmSizeName;
        private Alghoritm _selectedAlghoritm;
        private BackgroundWorker _worker;
        private int _currentProgressPercentage;
        private int _testCount;

        public MainViewModel(IMatlabService matlabService)
        {
            _matlabService = matlabService;
            ActivateButtonLogic(SelectedAlghoritm);
            SetDefaultWindowValues();
            InitializeBackgroundWorker();
            ProgressBarCommand = new RelayCommand(() => { _worker.RunWorkerAsync(); });
        }

        public ICommand ExecuteCommand { get; set; }

        public ICommand ProgressBarCommand { get; set; }

        public TestFunction SelectedTestFunction { get; set; }

        public IList<Alghoritm> AlghoritmTypes => Enum.GetValues(typeof(Alghoritm)).Cast<Alghoritm>().ToList();

        public IList<TestFunction> TestFunctions => Enum.GetValues(typeof(TestFunction)).Cast<TestFunction>().ToList();

        public int MaxTime { get; set; }

        public int MaxIterations { get; set; }

        public int MaxFunctionEvaluations { get; set; }

        public int MaxStall { get; set; }

        public int PopulationSwarmSize { get; set; }

        public bool ProgressVisibility { get; set; }

        public Alghoritm SelectedAlghoritm
        {
            get { return _selectedAlghoritm; }
            set
            {
                _selectedAlghoritm = value;
                ActivateButtonLogic(value);
                RaisePropertyChanged();
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

        public bool IsPopulationAlghoritm
        {
            get { return _isPopulationAlghoritm; }
            set
            {
                _isPopulationAlghoritm = value;
                RaisePropertyChanged();
            }
        }

        public int CurrentProgress
        {
            get { return _currentProgress; }
            set
            {
                if (_currentProgress == value) return;
                _currentProgress = value;
                CurrentProgressPercentage = GetPercentageProcessValue(value);
                RaisePropertyChanged();
            }
        }

        public int CurrentProgressPercentage
        {
            get { return _currentProgressPercentage; }
            set
            {
                _currentProgressPercentage = value;
                RaisePropertyChanged();
            }
        }

        public bool IsIndicatorBusy
        {
            get { return _isIndicatorBusy; }
            set
            {
                _isIndicatorBusy = value;
                RaisePropertyChanged();
            }
        }

        public int TestCount
        {
            get { return _testCount; }
            set
            {
                _testCount = value;
                RaisePropertyChanged();
            }
        }

        private int GetPercentageProcessValue(int value)
        {
            return (int)Math.Floor((double)(value * 100 / TestCount));
        }

        private void InitializeBackgroundWorker()
        {
            _worker = new BackgroundWorker {WorkerReportsProgress = true};
            _worker.DoWork += ExecuteAction;
            _worker.ProgressChanged += ProgressChanged;
            _worker.RunWorkerCompleted += (sender, args) => IsIndicatorBusy = false;
        }

        private void SetDefaultWindowValues()
        {
            MaxTime = 5;
            TestCount = 1;
            MaxIterations = 1000;
            MaxStall = 1000;
            MaxFunctionEvaluations = 1000;
            PopulationSwarmSize = 1000;
            SelectedAlghoritm = Alghoritm.SimulatedAnnealing;
            SelectedTestFunction = TestFunction.Bohachevsky;
        }

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

        private void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            CurrentProgress = e.ProgressPercentage;
        }

        private void ExecuteAction(object sender, DoWorkEventArgs e)
        {
            IsIndicatorBusy = true;
            
            SelectedTestFunction = TestFunction.Griewank;
            
            MaxIterations = 999999;
            TestCount = 5;
            MaxStall = 999999;
            MaxFunctionEvaluations = 999999;
            PopulationSwarmSize = 20;
            
            foreach (var alghoritmType in AlghoritmTypes)
            {
                for (int i = 1; i <= 3; i++)
                {
                    switch (alghoritmType)
                    {
                        case Alghoritm.SimulatedAnnealing:
                            MaxIterations = 999999;
                            ExecuteSimulatedAnnealingTest(SelectedTestFunction, alghoritmType, i, MaxIterations,
                                MaxFunctionEvaluations, MaxStall, TestCount);
                            break;
                        case Alghoritm.ParticleSwarmOptimization:
                            ExecuteParticleSwarmTest(SelectedTestFunction, alghoritmType, i, MaxIterations,
                                PopulationSwarmSize, MaxStall, TestCount);
                            break;
                        case Alghoritm.GeneticAlghoritm:
                            ExecuteGeneticAlghoritmTest(SelectedTestFunction, alghoritmType, i, MaxIterations,
                                PopulationSwarmSize, MaxStall, TestCount);
                            break;
                        default:
                            throw new InvalidEnumArgumentException();
                    }
                }
            }
            /*
            switch (SelectedAlghoritm)
            {
                case Alghoritm.SimulatedAnnealing:
                    ExecuteSimulatedAnnealingTest(SelectedTestFunction, SelectedAlghoritm, MaxTime, MaxIterations,
                        MaxFunctionEvaluations, MaxStall, TestCount);
                    break;
                case Alghoritm.ParticleSwarmOptimization:
                    ExecuteParticleSwarmTest(SelectedTestFunction, SelectedAlghoritm, MaxTime, MaxIterations,
                        PopulationSwarmSize, MaxStall, TestCount);
                    break;
                case Alghoritm.GeneticAlghoritm:
                    ExecuteGeneticAlghoritmTest(SelectedTestFunction, SelectedAlghoritm, MaxTime, MaxIterations,
                        PopulationSwarmSize, MaxStall, TestCount);
                    break;
                default:
                    throw new InvalidEnumArgumentException();
            }*/
        }

        private void ExecuteSimulatedAnnealingTest(TestFunction testFunction, Alghoritm alghoritm, int maxTime,
            int maxIterations, int maxFunctionEvaluations, int maxStall, int testCount)
        {
            for (var i = 0; i < testCount; i++)
            {
                _matlabService.ExecuteSimulatedAnnealing(testFunction, alghoritm, maxTime, maxIterations,
                    maxFunctionEvaluations, maxStall);
                _worker.ReportProgress(i);
            }
        }

        private void ExecuteGeneticAlghoritmTest(TestFunction testFunction, Alghoritm alghoritm, int maxTime,
            int maxGenerations, int populationSize, int maxStall, int testCount)
        {
            for (var i = 0; i < testCount; i++)
            {
                _matlabService.ExecuteGeneticAlghoritm(testFunction, alghoritm, maxTime, maxGenerations, populationSize,
                    maxStall);
                _worker.ReportProgress(i);
            }
        }

        private void ExecuteParticleSwarmTest(TestFunction testFunction, Alghoritm alghoritm, int maxTime,
            int maxGenerations, int swarmSize, int maxStall, int testCount)
        {
            for (var i = 0; i < testCount; i++)
            {
                _matlabService.ExecuteParticleSwarmTest(testFunction, alghoritm, maxTime, maxGenerations, swarmSize,
                    maxStall);
                _worker.ReportProgress(i);
            }
        }
    }
}