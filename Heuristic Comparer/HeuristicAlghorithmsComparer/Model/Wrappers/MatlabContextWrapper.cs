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
            _matlabContext.Execute(@"cd 'C:\Users\Sebastian Nalepka\Documents\HeuristicAlghorithmsComparer\Heuristic Comparer\HeuristicAlghorithmsComparer\Matlab'");
            //TODO: replace hardcoded path : Directory.GetParent(Path.GetDirectoryName(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)));    
        }

        public MLApp.MLApp GetMatlabContext()
        {
            return _matlabContext;
        }
    }
}
