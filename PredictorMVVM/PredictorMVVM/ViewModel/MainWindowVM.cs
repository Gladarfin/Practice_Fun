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

        public bool IsEnable { get; set; }

        private string PredictionsFromFile { get; set; }

        private string MessagesFromFile { get; set; }

        private string[] predictions;
        private string[] messages;
        private bool IsLoaded { get; set; }
        private readonly Random randomNumber = new Random();

        public MainWindowVM()
        {
            ButtonClick = new RelayCommand(Click);
            WindowLoaded();         
        }

        private void WindowLoaded()
        {
            SetDefaultValues();
            PredictionsFromFile = File.ReadAllText(Environment.CurrentDirectory + Properties.Settings.Default.PredictionsPath);
            MessagesFromFile = File.ReadAllText(Environment.CurrentDirectory + Properties.Settings.Default.PBMessagesPath);
        }

        private async void Click()
        {
            SetDefaultValues();
            if (PredictionsFromFile.Length == 0 || MessagesFromFile.Length == 0)
            {
                MessageBox.Show("Один из файлов отсутствует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (!IsLoaded)
            {
                predictions = JsonConvert.DeserializeObject<string[]>(PredictionsFromFile);
                messages = JsonConvert.DeserializeObject<string[]>(MessagesFromFile);
                IsLoaded = true;
            }
            
            IsEnable = false;

            await Task.Run(() =>
            {
                for (int i=0; i<=6; i++)
                {
                    for (int j = 0; j<=14;j++)
                    {
                        Thread.Sleep(80);
                        ProgressBarValue++;
                    }
                    TextBlockValue = messages[i];
                }
            });

            IsEnable = true;

            var index = randomNumber.Next(predictions.Length);
            MessageBox.Show(predictions[index], "Ваше предсказание", MessageBoxButton.OK, MessageBoxImage.Question);            
        }

        private void SetDefaultValues()
        {
            ProgressBarValue = 0;
            TextBlockValue = "Ожидайте ответа...";
            IsEnable = true;
            IsLoaded = false;
        }


    }
}
