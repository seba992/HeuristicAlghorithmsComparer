using System;
using HeuristicAlghorithmsComparer.Model.Database;

namespace HeuristicAlghorithmsComparer.Model.Services
{
    public interface IDatabaseService
    {
        void GetData(Action<DataItem, Exception> callback);
        void CheckDbConnection();
        void CheckInsertOperation();

        TestFunction GetTestFunction(Enums.TestFunction testFunction);

        void SaveResult(Result result);
        Alghoritm GetAlghoritm(Enums.Alghoritm alghoritm);
    }
}
