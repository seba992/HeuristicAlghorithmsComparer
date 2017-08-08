using HeuristicAlghorithmsComparer.Model.Database;

namespace HeuristicAlghorithmsComparer.Model.Parser
{
    public interface IResultParser
    {
        ResultDetail ParseResult(object[] result);
    }
}