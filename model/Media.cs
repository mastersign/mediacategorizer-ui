using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace de.fhb.oll.mediacategorizer.model
{
    class Media : ModelBase
    {
        private string id;
        private string name;
        private string mediaFile;
        private string audioFile;
        private string resultsFile;

        public string Id
        {
            get { return id; }
            set
            {
                if (value == id) return;
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (value == name) return;
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public string MediaFile
        {
            get { return mediaFile; }
            set
            {
                if (value == mediaFile) return;
                mediaFile = value; 
                OnPropertyChanged("MediaFile");
            }
        }

        public string AudioFile
        {
            get { return audioFile; }
            set
            {
                if (value == audioFile) return;
                audioFile = value;
                OnPropertyChanged("AudioFile");
            }
        }

        public string ResultsFile
        {
            get { return resultsFile; }
            set
            {
                if (value == resultsFile) return;
                resultsFile = value;
                OnPropertyChanged("ResultsFile");
            }
        }
    }
}
