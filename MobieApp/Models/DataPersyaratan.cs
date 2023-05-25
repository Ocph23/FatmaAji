using ShareModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobieApp.Models
{
    public class DataPersyaratan  :BaseNotify
    {
        public int Id { get; set; }
        public Persyaratan Persyaratan { get; set; }
        private string fileName;

        public string FileName
        {
            get { return fileName; }
            set { SetProperty(ref fileName , value); 
                OnPropertyChanged("FileIcon");
            }
        }

        public bool Status { get; set; }
        public string ShowFile => Persyaratan != null && Persyaratan.IsUpload ? "1" : "0";
        public ImageSource FileIcon => ImageSource.FromFile(string.IsNullOrEmpty(FileName) ? "documentupload.png" : "documenttext.png");

    }
}
