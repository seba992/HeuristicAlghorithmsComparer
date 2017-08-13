using System;
using HeuristicAlghorithmsComparer.Model.Database;

namespace HeuristicAlghorithmsComparer.Model.Services
{
    public interface IDatabaseService
    {
        TestFunction GetTestFunction(Enums.TestFunction testFunction);

        void SaveResult(Result result);

        Alghoritm GetAlghoritm(Enums.Alghoritm alghoritm);
    }
}
