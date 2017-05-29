using HeuristicAlghorithmsComparer.Database;
using HeuristicAlghorithmsComparer.Model.Managers;

namespace HeuristicAlghorithmsComparer.Model.Parser
{
    public class ResultParser : IResultParser
    {
        public ResultDetail ParseAnnealingResult(object[] result)
        {
            return new ResultDetail()
            {
                FinalPointX = (decimal) result[0],
                FinalPointY = (decimal) result[1],
                BestFunctionValue = (decimal) result[2],
                Iterations = (int) result[3],
                FunctionEvaluations = (int) result[4],
                StartingPointX = (decimal?) result[5],
                StartingPointY = (decimal?) result[6],
            };
        }

        public ResultDetail ParseParticleSwarmResult(object[] result)
        {
            throw new System.NotImplementedException();
        }

        public ResultDetail ParseGeneticResult(object[] result)
        {
            throw new System.NotImplementedException();
        }
    }
}