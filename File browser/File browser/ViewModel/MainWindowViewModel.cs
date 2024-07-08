using File_browser.Model;
using File_browser.Model.Reader;
using File_browser.Model.Utils;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace File_browser.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            ChoosenFiles = new ObservableCollection<FileReader>();
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



        public RelayCommand FileChooserCommand => new RelayCommand(execute => FileChooser());

        public RelayCommand SearchCommand => new RelayCommand(execute => SearchWords());

        public RelayCommand DeleteCommand => new RelayCommand(execute => Delete());

        private void SearchWords()
        {
            KeyWordsValidation keyWordsTextvalidation = new KeyWordsValidation();
            string text;

            try
            {
                text = keyWordsTextvalidation.Validate(TextToSearch);
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                string path = fileDialog.FolderName;
                try
                {
                    var pickedFiles = FileHelper.GetAllFiles(path);
                    ObservableCollectionExtensions.ExtendCollection<FileReader>(ChoosenFiles, pickedFiles);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Delete()
        {
            ChoosenFiles.Clear();
        }
    }
}
