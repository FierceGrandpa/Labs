using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using Microsoft.Win32;

namespace Lab4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> Words;
        private ObservableCollection<string> FindWords = new ObservableCollection<string>();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            FindWordsListBox.ItemsSource = FindWords;
        }

        private double ReadFile(string path)
        {
            var stopWatch = new Stopwatch();

            stopWatch.Start();

            var text = File.ReadAllText(path, Encoding.Default);
            Words = text.Split(new[] { ' ', ',', ':', '?', '!', '\n', '\t', '\r', '—' }, StringSplitOptions.RemoveEmptyEntries).Distinct().ToList();

            stopWatch.Stop();

            return Math.Round(new TimeSpan(stopWatch.ElapsedTicks).TotalMilliseconds, 2);
        }

        private void OpenFileButton_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog()
            {
                CheckFileExists = false,
                CheckPathExists = true,
                Multiselect = false,
                Filter = "txt files (*.txt)|*.txt",
                Title  = "Выберите файл"
            };

            if (openFileDialog.ShowDialog() != true) return;

            var time = ReadFile(openFileDialog.FileName);
            TimeLabel.Content = $"Время открытия и записи: {time} ms.";
        }

        private void FindWordButton_Click(object sender, RoutedEventArgs e)
        {
            if (FindWordTextBox.Text == string.Empty ||
                Words == null                        ||
                FindWordTextBox.Text == "") return;
            var searchWord = FindWordTextBox.Text.ToLower();
            foreach (var word in Words.Where(word => word.ToLower().Contains(searchWord)))
            {
                FindWords.Add(word);
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            Words = new List<string>();
            FindWords = new ObservableCollection<string>();
            FindWordsListBox.ItemsSource = FindWords;
        }
    }
}
