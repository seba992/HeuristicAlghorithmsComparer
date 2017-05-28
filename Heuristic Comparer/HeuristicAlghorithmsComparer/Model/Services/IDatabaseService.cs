using System;

namespace HeuristicAlghorithmsComparer.Model.Services
{
    public interface IDatabaseService
    {
        void GetData(Action<DataItem, Exception> callback);
        void CheckDbConnection();
        void CheckInsertOperation();
    }
}
