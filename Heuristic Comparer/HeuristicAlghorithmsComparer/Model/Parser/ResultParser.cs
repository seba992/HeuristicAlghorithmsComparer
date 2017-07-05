using System;
using HeuristicAlghorithmsComparer.Database;
using HeuristicAlghorithmsComparer.Model.Managers;

namespace HeuristicAlghorithmsComparer.Model.Parser
{
    public class ResultParser : IResultParser
    {
        public ResultDetail ParseAnnealingResult(object[] result)
        {
            var resultDetails = new ResultDetail
            {
                BestFunctionValue = Convert.ToDecimal(result[1]),
                Iterations = Convert.ToInt32(result[2]),
                FunctionEvaluations = Convert.ToInt32(result[3]),
                TotalTime = Convert.ToInt32(result[4]),
            };

            var resultPointLoc = result[0] as double[,];
            for (var i = 0; i < resultPointLoc.Length; i++)
            {
                resultDetails.Point.Add(new Point
                {
                    PointValue = resultPointLoc[0,i],
                    ResultDimension = i + 1,
                });
            }

            return resultDetails;
        }

        public ResultDetail ParseParticleSwarmResult(object[] result)
        {
            return new ResultDetail()
            {
            /*    FinalPointX = Convert.ToDecimal(result[0]),
                FinalPointY = Convert.ToDecimal(result[1]),*/
                BestFunctionValue = Convert.ToDecimal(result[2]),
                Iterations = Convert.ToInt32(result[3]),
                FunctionEvaluations = Convert.ToInt32(result[4]),
                TotalTime = Convert.ToInt32(result[5])
            };
        }

        public ResultDetail ParseGeneticResult(object[] result)
        {
            return new ResultDetail()
            {
               /* FinalPointX = Convert.ToDecimal(result[0]),
                FinalPointY = Convert.ToDecimal(result[1]),*/
                BestFunctionValue = Convert.ToDecimal(result[2]),
                Iterations = Convert.ToInt32(result[3]),
                FunctionEvaluations = Convert.ToInt32(result[4]),
                TotalTime = Convert.ToInt32(result[5])
            };
        }
    }
}