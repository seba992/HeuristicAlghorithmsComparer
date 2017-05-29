using HeuristicAlghorithmsComparer.Database;

namespace HeuristicAlghorithmsComparer.Model.Managers
{
    public interface IAlghoritmRequestManager
    {
        ResultDetail ExecuteAlghoritm(Alghoritm alghoritm, Database.TestFunction testFunction, InputParameter inputParameter);
    }
}