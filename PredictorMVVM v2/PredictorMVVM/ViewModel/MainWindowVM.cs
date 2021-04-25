using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PredictorMVVM.ViewModel
{
    public class MainWindowVM : BaseVM
    {
        public int ProgressBarValue { get; set; }

        public string TextBlockValue { get; set; }

        public ICommand ButtonClick { get; set; }

        public ICommand CloseApp { get; set; }

        public string Prediction { get; set; }

        public double OpacityTB { get; set; } = 0;

        private string PredictionsFromFile { get; set; }

        private string[] predictions;

        private bool IsLoaded { get; set; }
        private readonly Random randomNumber = new Random();

        public MainWindowVM()
        {
            ButtonClick = new RelayCommand(Click);
            CloseApp = new RelayCommand(Close);
            WindowLoaded();         
        }

        private void Close()
        {
            Application.Current.Shutdown();
        }

        private void WindowLoaded()
        {
            PredictionsFromFile = File.ReadAllText(Environment.CurrentDirectory + Properties.Settings.Default.PredictionsPath);
        }

        private async void Click()
        {

            await Task.Run(() =>
            {
                Prediction = "";
                OpacityTB = 0;
                Thread.Sleep(500);
            });

            IsLoaded = false;

            if (PredictionsFromFile.Length == 0)
            {
                MessageBox.Show("Шар сломан :(", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (!IsLoaded)
            {
                predictions = JsonConvert.DeserializeObject<string[]>(PredictionsFromFile);                
                IsLoaded = true;
            }
                var index = randomNumber.Next(predictions.Length);
                Prediction = predictions[index];
        }
    }
}
