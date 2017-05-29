using System;
using HeuristicAlghorithmsComparer.Model.Enums;
using TestFunction = HeuristicAlghorithmsComparer.Database.TestFunction;

namespace HeuristicAlghorithmsComparer.Model.Utils
{
    public static class FunctionNameMatcher
    {
        public static string GetAlghoritmFileName(Database.Alghoritm alghoritm)
        {
            return $"{alghoritm.Name.Replace(" ", "")}TestFun";
        }

        public static string GetFunctionFileName(TestFunction testFunction)
        {
            return $"{testFunction.Name}Fun";
        }
    }
}
