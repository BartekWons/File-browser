using File_browser.Model;
using File_browser.Model.Reader;
using File_browser.Model.Utils;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.DirectoryServices;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;
using System.Windows;

namespace File_browser.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            ChoosenFiles = new ObservableCollection<FileReader>();
            FinalFiles = new ObservableCollection<FileReader>();
        }

        private ObservableCollection<FileReader> choosenFiles;

        public ObservableCollection<FileReader> ChoosenFiles
        {
            get { return choosenFiles; }
            set 
            { 
                choosenFiles = value;
                OnPropertyChanged();
            }
        }

        private string textToSearch;

        public string TextToSearch
        {
            get { return textToSearch; }
            set { textToSearch = value; }
        }

        private ObservableCollection<FileReader> finalFiles;

        public ObservableCollection<FileReader> FinalFiles
        {
            get { return finalFiles; }
            set 
            { 
                finalFiles = value;
                OnPropertyChanged();
            }
        }


        public RelayCommand FileChooserCommand => new RelayCommand(execute => FileChooser());

        public RelayCommand SearchCommand => new RelayCommand(execute => SearchWords());

        public RelayCommand DeleteCommand => new RelayCommand(execute => Delete());

        private void SearchWords()
        {
            FinalFiles.Clear();
            Thread.Sleep(500);
            KeyWordsValidation keyWordsTextvalidation = new KeyWordsValidation();
            string validText;
            List<string> text = new List<string>();

            try
            {
                validText = keyWordsTextvalidation.Validate(TextToSearch);

                foreach (var file in ChoosenFiles)
                {
                    text.Add(file.ReadData());
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            catch (NotImplementedException ex)
            {
                var i = MessageBox.Show($"{ex.Message}\nDo you want to omit this file and continue?", "ERROR", MessageBoxButton.YesNo, MessageBoxImage.Question);
                //TODO omit the files
                return;
            }

            List<string> keyWordsList = TextParser.ParseTextToWords(validText);
            List<List<string>> textFromFileAsWords = new List<List<string>>();
            foreach (var t in text)
            {
                textFromFileAsWords.Add(TextParser.ParseTextToWords(t));
            }

            for (int i = 0; i < textFromFileAsWords.Count; i++)
            {
                for (int j = 0; j < keyWordsList.Count; j++) 
                {
                    bool hasKeyWord = textFromFileAsWords[i].Any(t => t.Contains(keyWordsList[j]));
                    if (hasKeyWord)
                    {
                        ++ChoosenFiles[i].MatchingWords;
                        hasKeyWord = false;
                        break;
                    }
                }
            }

            ObservableCollectionExtensions.ExtendCollection(FinalFiles, ChoosenFiles.Where(t => t.MatchingWords > 0));
            

        }

        private void FileChooser()
        {
            OpenFolderDialog fileDialog = new OpenFolderDialog()
            {
                Multiselect = true,
                Title = "Please pick a directory...",
            };

            bool? success = fileDialog.ShowDialog();

            if (success == true)
            {
                string[] path = fileDialog.FolderNames;
                try
                {
                    foreach (var item in path)
                    {
                        var pickedFiles = FileHelper.GetAllFiles(item);
                        ObservableCollectionExtensions.ExtendCollection<FileReader>(ChoosenFiles, pickedFiles);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Delete()
        {
            ChoosenFiles.Clear();
        }


    }
}
