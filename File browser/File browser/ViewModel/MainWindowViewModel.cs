using File_browser.Model;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Data;
using System.Xml.Serialization;

namespace File_browser.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            ChoosenFiles = new ObservableCollection<File>();
        }

        private ObservableCollection<File> choosenFiles;

        public ObservableCollection<File> ChoosenFiles
        {
            get { return choosenFiles; }
            set 
            { 
                choosenFiles = value;
                OnPropertyChanged();
            }
        }

        private int[] selectedItem;

        public int[] SelectedItem
        {
            get { return selectedItem; }
            set 
            { 
                selectedItem = value; 
                OnPropertyChanged();
            }
        }


        public RelayCommand FileChooserCommand => new RelayCommand(execute => FileChooser());

        public RelayCommand SearchCommand => new RelayCommand(execute => SearchWords());

        public RelayCommand DeleteCommand => new RelayCommand(execute => Delete());

        private void SearchWords()
        {
            foreach (var file in ChoosenFiles)
            {
                Debug.WriteLine(file);
            }
        }

        private void FileChooser()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Title = "Please pick a file...";
            openFileDialog.Filter = "All Files|*.*|Text Files|*.txt|Word File|*.docx|PDF file|*.pdf|Document|*.doc";

            bool? success = openFileDialog.ShowDialog();

            if (success == true)
            {
                string[] fileNames = openFileDialog.SafeFileNames;
                string[] paths = openFileDialog.FileNames;

                for (int i = 0; i < paths.Length; i++)
                {
                    File file = new File{
                        Path = paths[i],
                        FileName = fileNames[i]
                    };
                    ChoosenFiles.Add(file);
                }   
            }
        }

        private void Delete()
        {
            foreach(var i in SelectedItem)
            {
                Debug.WriteLine(i);
            }
        }
    }
}
