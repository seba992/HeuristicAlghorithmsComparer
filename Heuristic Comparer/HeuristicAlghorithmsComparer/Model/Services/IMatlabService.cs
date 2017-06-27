using HeuristicAlghorithmsComparer.Model.Enums;

namespace HeuristicAlghorithmsComparer.Model.Services
{
    public interface IMatlabService
    {
        void ExecuteParticleSwarmTest(TestFunction function, Alghoritm alghoritm, int maxTime, int maxGenerations,
            int swarmSize, int maxStall);

        void ExecuteGeneticAlghoritm(TestFunction function, Alghoritm alghoritm, int maxTime, int maxGenerations,
            int populationSize, int maxStall);

        void ExecuteSimulatedAnnealing(TestFunction function, Alghoritm alghoritm, int maxTime, int maxIterations,
            int maxFunctionEvaluations, int maxStall);
    }
}