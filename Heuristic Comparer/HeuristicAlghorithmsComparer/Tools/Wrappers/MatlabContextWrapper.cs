using System.IO;
using System.Linq;
using System.Reflection;

namespace HeuristicAlghorithmsComparer.Model.Wrappers
{

    public class MatlabContextWrapper : IMatlabContextWrapper
    {
        private MLApp.MLApp _matlabContext;

        public MatlabContextWrapper()
        {
            InitializeMatlabContext();
        }

        private void InitializeMatlabContext()
        {
            if (_matlabContext != null) return;

            _matlabContext = new MLApp.MLApp();
            var test = string.Concat("cd ",
                Directory.GetParent(Path.GetDirectoryName(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location))),
                "\\Matlab");
            //_matlabContext.Execute(test);
            _matlabContext.Execute(@"cd 'C:\Users\Sebastian Nalepka\Documents\HeuristicAlghorithmsComparer\Heuristic Comparer\HeuristicAlghorithmsComparer\Matlab'");

        }

        public MLApp.MLApp GetMatlabContext()
        {
            return _matlabContext;
        }
    }
}
