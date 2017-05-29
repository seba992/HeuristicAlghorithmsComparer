using System;
using HeuristicAlghorithmsComparer.Model.Enums;
using TestFunction = HeuristicAlghorithmsComparer.Database.TestFunction;

namespace HeuristicAlghorithmsComparer.Model.Utils
{
    public static class FunctionNameMatcher
    {
        public static string GetAlghoritmFileName(Alghoritm alghoritm)
        {
            switch (alghoritm)
            {
                case Alghoritm.SimulatedAnnealing:
                    return MetaheuristicResources.SimulatedAnnealingFileName;
                case Alghoritm.ParticleSwarmOptimization:
                    return MetaheuristicResources.ParticleSwarmOptimizationFileName;
                case Alghoritm.GeneticAlghoritm:
                    return MetaheuristicResources.GeneticAlghoritmFileName;
                default:
                    throw new ArgumentOutOfRangeException(nameof(alghoritm), alghoritm, null);
            }
        }

        public static string GetFunctionFileName(TestFunction testFunction)
        {
            return $"{testFunction.Name}Fun";
        }
    }
}
