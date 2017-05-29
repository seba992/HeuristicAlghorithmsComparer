using HeuristicAlghorithmsComparer.Database;
using HeuristicAlghorithmsComparer.Model.Enums;

namespace HeuristicAlghorithmsComparer.Model.Managers
{
    public interface IAlghoritmRequestManager
    {
        ResultDetail ExecuteAlghoritm(Enums.Alghoritm alghoritm, Database.TestFunction testFunction, InputParameter inputParameter);
    }
}