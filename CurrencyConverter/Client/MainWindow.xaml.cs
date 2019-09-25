using Client.Services;
using System.ComponentModel;
using System.Windows;

namespace Client
{
    class Model : INotifyPropertyChanged
    {
        private bool _isEnabled = true;
        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                _isEnabled = value;
                OnPropertyChanged(nameof(IsEnabled));
            }
        }

        private string _input;
        public string Input
        {
            get { return _input; }
            set
            {
                _input = value;
                OnPropertyChanged(nameof(Input));
            }
        }

        private string _output;
        public string Output
        {
            get { return _output; }
            set
            {
                _output = value;
                OnPropertyChanged(nameof(Output));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    public partial class MainWindow : Window
    {
        private Model _model;
        private ICurrencyConverterService _currencyConverterService;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = _model = new Model();

            _currencyConverterService = new CurrencyConverterService();
        }

        private async void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            _model.IsEnabled = false;
            try
            {
                _model.Output = await _currencyConverterService.Convert(_model.Input);
            }
            catch (ClientException cex)
            {
                MessageBox.Show(cex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                _model.IsEnabled = true;
            }
        }
    }
}
