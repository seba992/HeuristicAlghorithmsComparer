using System.Windows;
using HeuristicAlghorithmsComparer.ViewModel;

namespace HeuristicAlghorithmsComparer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Closing += (s, e) => ViewModelLocator.Cleanup();
        }

        private void NumericOnly(System.Object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = IsTextPositiveNumeric(e.Text);
        }


        private static bool IsTextPositiveNumeric(string str)
        {
            int num;
            int.TryParse(str, out num);

            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("[^0-9]");
            return reg.IsMatch(str) && num > 0;

        }
    }
}