using HeuristicAlghorithmsComparer.Model.Enums;

namespace HeuristicAlghorithmsComparer.Model.Services
{
    public interface IMatlabService
    {
        void CheckMatlabConnection();
        void ExecuteGeneticAlghoritm();
        void ExecuteParticleSwarmTest();
        void ExecuteSimulatedAnnealing(TestFunction function, Alghoritm alghoritm, int maxTime, int maxIterations, int maxFunctionEvaluations, int maxStall);
    }
}