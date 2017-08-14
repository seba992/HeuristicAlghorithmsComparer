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
            _matlabContext.Execute(string.Concat("cd ", Directory.GetParent(Path.GetDirectoryName(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location))), "\\Matlab"));
        }

        public MLApp.MLApp GetMatlabContext()
        {
            return _matlabContext;
        }
    }
}
