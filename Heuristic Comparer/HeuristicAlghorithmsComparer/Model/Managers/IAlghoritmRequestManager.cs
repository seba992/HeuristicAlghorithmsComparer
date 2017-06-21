using HeuristicAlghorithmsComparer.Database;

namespace HeuristicAlghorithmsComparer.Model.Managers
{
    public interface IAlghoritmRequestManager
    {
        ResultDetail ExecuteAlghoritm(Alghoritm alghoritm, TestFunction testFunction, InputParameter inputParameter);
    }
}