using System;
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
                FinalPointX = Convert.ToDecimal(result[0]),
                FinalPointY = Convert.ToDecimal(result[1]),
                BestFunctionValue = Convert.ToDecimal(result[2]),
                Iterations = Convert.ToInt32(result[3]),
                FunctionEvaluations = Convert.ToInt32(result[4]),
                TotalTime = Convert.ToInt32(result[5]),
                StartingPointX = Convert.ToDecimal(result[6]),
                StartingPointY = Convert.ToDecimal(result[7])
            };
        }

        public ResultDetail ParseParticleSwarmResult(object[] result)
        {
            throw new System.NotImplementedException();
        }

        public ResultDetail ParseGeneticResult(object[] result)
        {
            return new ResultDetail()
            {
                FinalPointX = Convert.ToDecimal(result[0]),
                FinalPointY = Convert.ToDecimal(result[1]),
                BestFunctionValue = Convert.ToDecimal(result[2]),
                Iterations = Convert.ToInt32(result[3]),
                FunctionEvaluations = Convert.ToInt32(result[4]),
                TotalTime = Convert.ToInt32(result[5])
            };
        }
    }
}