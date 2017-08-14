using System;
using HeuristicAlghorithmsComparer.Model.Database;

namespace HeuristicAlghorithmsComparer.Model.Parser
{
    public class ResultParser : IResultParser
    {
        public ResultDetail ParseResult(object[] result)
        {
            var resultDetails = new ResultDetail
            {
                BestFunctionValue = Convert.ToDecimal(result[1]),
                Iterations = Convert.ToInt32(result[2]),
                FunctionEvaluations = Convert.ToInt32(result[3]),
                TotalTime = Convert.ToDecimal(result[4]),
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
    }
}