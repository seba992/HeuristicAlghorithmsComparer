using HeuristicAlghorithmsComparer.Database;

namespace HeuristicAlghorithmsComparer.Model.Parser
{
    public interface IResultParser
    {
        ResultDetail ParseAnnealingResult(object[] result);
        ResultDetail ParseParticleSwarmResult(object[] result);
        ResultDetail ParseGeneticResult(object[] result);
    }
}