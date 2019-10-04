using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace SinglePage.ViewModels
{
    public class NotesViewModel : INotifyPropertyChanged
    {
        public NotesViewModel()
        {
            AllNotes = new ObservableCollection<string>();

            SaveCommand = new Command(() =>
            {
                AllNotes.Add(TheNote);

                TheNote = string.Empty;
            });

            ClearCommand = new Command(() => {
                TheNote = string.Empty;
            });

        }

        string theNote;

        public string TheNote
        {
            get => theNote;
            set
            {
                theNote = value;

                var args = new PropertyChangedEventArgs(nameof(TheNote));

                PropertyChanged?.Invoke(this, args);
            }
        }

        public ObservableCollection<string> AllNotes { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public Command SaveCommand {get; }
        public Command ClearCommand { get; }
    }
}
