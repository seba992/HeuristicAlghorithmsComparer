using HeuristicAlghorithmsComparer.Model.Enums;

namespace HeuristicAlghorithmsComparer.Model.Managers
{
    public interface IAlghoritmRequestManager
    {
        void CreateRequest(Alghoritm alghoritm, int maxTime, double maxIterations, double maxFunction,
            double maxFunctionEvaluations, double maxStallIterations, Enums.TestFunction testFunction);
    }
}