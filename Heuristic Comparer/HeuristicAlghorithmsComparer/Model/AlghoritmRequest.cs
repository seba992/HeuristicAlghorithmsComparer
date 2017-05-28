using HeuristicAlghorithmsComparer.Model.Enums;

namespace HeuristicAlghorithmsComparer.Model
{
    public class AlghoritmRequest
    {
        public int OutputParamsNumber { get; set; }
        public Alghoritm Alghoritm { get; set; }
        public double MaxTime { get; set; }
        public double MaxIterations { get; set; }
        public double MaxFunctionEvaluations { get; set; }
        public double MaxStallIterations { get; set; }
        public TestFunction TestFunction { get; set; }
    }
}
