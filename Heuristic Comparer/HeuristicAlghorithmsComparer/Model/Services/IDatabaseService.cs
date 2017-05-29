using System;
using HeuristicAlghorithmsComparer.Database;
using HeuristicAlghorithmsComparer.Model.Enums;
using Alghoritm = HeuristicAlghorithmsComparer.Database.Alghoritm;
using TestFunction = HeuristicAlghorithmsComparer.Database.TestFunction;

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
