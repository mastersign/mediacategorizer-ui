using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace de.fhb.oll.mediacategorizer.settings
{
    #region Scaleton Model Designer generated code
    
    public enum ParallelizationMode
    {
        None,
        Auto,
        Manual,
    }
    
    public partial class Setup : INotifyPropertyChanged, IChangeTracking
    {
        public Setup()
        {
            this._parallelization = DEF_PARALLELIZATION;
            this._parallelTasks = DEF_PARALLELTASKS;
            this._downloadTimeout = DEF_DOWNLOADTIMEOUT;
            this._compatibleAudioFileExtensions = DEF_COMPATIBLEAUDIOFILEEXTENSIONS;
            this._compatibleVideoFileExtensions = DEF_COMPATIBLEVIDEOFILEEXTENSIONS;
            this._ffmpeg = DEF_FFMPEG;
            this._ffprobe = DEF_FFPROBE;
            this._waveViz = DEF_WAVEVIZ;
            this._transcripter = DEF_TRANSCRIPTER;
            this._distillery = DEF_DISTILLERY;
            
            this.IsChanged = false;
        }
        
        #region Change Tracking
        
        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        
        [NonSerialized]
        private bool _isChanged = false;
        
        [Browsable(false)]
        [XmlIgnore]
        public bool IsChanged
        {
            get { return this._isChanged; }
            protected set { this._isChanged = value; }
        }
        
        public void AcceptChanges()
        {
            this.IsChanged = false;
        }
        
        #endregion
        
        #region String Representation
        
        public override string ToString()
        {
            return this.ToString(global::System.Globalization.CultureInfo.CurrentUICulture);
        }
        
        public string ToString(IFormatProvider formatProvider)
        {
            return (this.GetType().FullName + @": " + (
                (Environment.NewLine + @"    Parallelization = " + _parallelization.ToString().Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    ParallelTasks = " + _parallelTasks.ToString(formatProvider).Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    DownloadTimeout = " + _downloadTimeout.ToString(formatProvider).Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    CompatibleAudioFileExtensions = " + (!ReferenceEquals(_compatibleAudioFileExtensions, null) ? _compatibleAudioFileExtensions.ToString(formatProvider) : @"null").Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    CompatibleVideoFileExtensions = " + (!ReferenceEquals(_compatibleVideoFileExtensions, null) ? _compatibleVideoFileExtensions.ToString(formatProvider) : @"null").Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    Ffmpeg = " + (!ReferenceEquals(_ffmpeg, null) ? _ffmpeg.ToString(formatProvider) : @"null").Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    Ffprobe = " + (!ReferenceEquals(_ffprobe, null) ? _ffprobe.ToString(formatProvider) : @"null").Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    WaveViz = " + (!ReferenceEquals(_waveViz, null) ? _waveViz.ToString(formatProvider) : @"null").Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    Transcripter = " + (!ReferenceEquals(_transcripter, null) ? _transcripter.ToString(formatProvider) : @"null").Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    Distillery = " + (!ReferenceEquals(_distillery, null) ? _distillery.ToString(formatProvider) : @"null").Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    JavaRuntime = " + (!ReferenceEquals(_javaRuntime, null) ? _javaRuntime.ToString(formatProvider) : @"null").Replace("\n", "\n    "))));
        }
        
        #endregion
        
        #region Property Parallelization
        
        private ParallelizationMode _parallelization;
        
        public event EventHandler ParallelizationChanged;
        
        protected virtual void OnParallelizationChanged()
        {
            this.IsChanged = true;
            EventHandler handler = ParallelizationChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"Parallelization");
        }
        
        private const ParallelizationMode DEF_PARALLELIZATION = ParallelizationMode.Auto;
        
        [DefaultValue(DEF_PARALLELIZATION)]
        [Category(@"Verarbeitung")]
        [DisplayName(@"Parallelisierung")]
        [Description(@"Gibt an, ob die Anzahl der parallelen Aufgaben je Prozess automatisch ermittelt werden soll, oder ob der Wert von 'Parallele Aufgaben' verwendet werden soll.")]
        public virtual ParallelizationMode Parallelization
        {
            get { return _parallelization; }
            set
            {
                if ((value == _parallelization))
                {
                    return;
                }
                _parallelization = value;
                this.OnParallelizationChanged();
            }
        }
        
        #endregion
        
        #region Property ParallelTasks
        
        private int _parallelTasks;
        
        public event EventHandler ParallelTasksChanged;
        
        protected virtual void OnParallelTasksChanged()
        {
            this.IsChanged = true;
            EventHandler handler = ParallelTasksChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"ParallelTasks");
        }
        
        private const int DEF_PARALLELTASKS = 2;
        
        [DefaultValue(DEF_PARALLELTASKS)]
        [Category(@"Verarbeitung")]
        [DisplayName(@"Parallele Aufgaben")]
        [Description(@"Die manuelle Angabe für die maximale Anzahl von parallelen Aufgaben in einem Prozess.")]
        public virtual int ParallelTasks
        {
            get { return _parallelTasks; }
            set
            {
                if ((value == _parallelTasks))
                {
                    return;
                }
                _parallelTasks = value;
                this.OnParallelTasksChanged();
            }
        }
        
        #endregion
        
        #region Property DownloadTimeout
        
        private int _downloadTimeout;
        
        public event EventHandler DownloadTimeoutChanged;
        
        protected virtual void OnDownloadTimeoutChanged()
        {
            this.IsChanged = true;
            EventHandler handler = DownloadTimeoutChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"DownloadTimeout");
        }
        
        private const int DEF_DOWNLOADTIMEOUT = 30;
        
        [DefaultValue(DEF_DOWNLOADTIMEOUT)]
        [Category(@"Ressourcen")]
        [DisplayName(@"Download-Timeout")]
        [Description(@"Die Anzahl der Sekunden, nach denen der Versuch, eine Kategorie-Ressource herunterzuladen, abgebrochen werden soll.")]
        public virtual int DownloadTimeout
        {
            get { return _downloadTimeout; }
            set
            {
                if ((value == _downloadTimeout))
                {
                    return;
                }
                _downloadTimeout = value;
                this.OnDownloadTimeoutChanged();
            }
        }
        
        #endregion
        
        #region Property CompatibleAudioFileExtensions
        
        private string _compatibleAudioFileExtensions;
        
        public event EventHandler CompatibleAudioFileExtensionsChanged;
        
        protected virtual void OnCompatibleAudioFileExtensionsChanged()
        {
            this.IsChanged = true;
            EventHandler handler = CompatibleAudioFileExtensionsChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"CompatibleAudioFileExtensions");
        }
        
        private const string DEF_COMPATIBLEAUDIOFILEEXTENSIONS = @"wav mp3 wma ogg ac3 acc aif mp1 mp2 mpa m2a m4a ra";
        
        [DefaultValue(DEF_COMPATIBLEAUDIOFILEEXTENSIONS)]
        [Category(@"Ressourcen")]
        [DisplayName(@"Audiodateiendungen")]
        [Description(@"Eine Liste mit Dateiendungen für unterstützte Audiodateien. Die Endungen werden ohne führenden Punkt angegeben und durch Leerzeichen getrennt.")]
        public virtual string CompatibleAudioFileExtensions
        {
            get { return _compatibleAudioFileExtensions; }
            set
            {
                if (string.Equals(value, _compatibleAudioFileExtensions))
                {
                    return;
                }
                _compatibleAudioFileExtensions = value;
                this.OnCompatibleAudioFileExtensionsChanged();
            }
        }
        
        #endregion
        
        #region Property CompatibleVideoFileExtensions
        
        private string _compatibleVideoFileExtensions;
        
        public event EventHandler CompatibleVideoFileExtensionsChanged;
        
        protected virtual void OnCompatibleVideoFileExtensionsChanged()
        {
            this.IsChanged = true;
            EventHandler handler = CompatibleVideoFileExtensionsChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"CompatibleVideoFileExtensions");
        }
        
        private const string DEF_COMPATIBLEVIDEOFILEEXTENSIONS = @"avi mpg wmv ogv webm mov mkv 3gp mpv m2v mp4 m4v";
        
        [DefaultValue(DEF_COMPATIBLEVIDEOFILEEXTENSIONS)]
        [Category(@"Ressourcen")]
        [DisplayName(@"Videodateiendungen")]
        [Description(@"Eine Liste mit Dateiendungen für unterstützte Videodateien. Die Endungen werden ohne führenden Punkt angegeben und durch Leerzeichen getrennt.")]
        public virtual string CompatibleVideoFileExtensions
        {
            get { return _compatibleVideoFileExtensions; }
            set
            {
                if (string.Equals(value, _compatibleVideoFileExtensions))
                {
                    return;
                }
                _compatibleVideoFileExtensions = value;
                this.OnCompatibleVideoFileExtensionsChanged();
            }
        }
        
        #endregion
        
        #region Property Ffmpeg
        
        private string _ffmpeg;
        
        public event EventHandler FfmpegChanged;
        
        protected virtual void OnFfmpegChanged()
        {
            this.IsChanged = true;
            EventHandler handler = FfmpegChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"Ffmpeg");
        }
        
        private const string DEF_FFMPEG = @"tools/ffmpeg/bin/ffmpeg.exe";
        
        [DefaultValue(DEF_FFMPEG)]
        [Category(@"Hilfsprogramme")]
        [DisplayName(@"FFmpeg")]
        [Description(@"Der Pfad von ffmpeg.exe.")]
        public virtual string Ffmpeg
        {
            get { return _ffmpeg; }
            set
            {
                if (string.Equals(value, _ffmpeg))
                {
                    return;
                }
                _ffmpeg = value;
                this.OnFfmpegChanged();
            }
        }
        
        #endregion
        
        #region Property Ffprobe
        
        private string _ffprobe;
        
        public event EventHandler FfprobeChanged;
        
        protected virtual void OnFfprobeChanged()
        {
            this.IsChanged = true;
            EventHandler handler = FfprobeChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"Ffprobe");
        }
        
        private const string DEF_FFPROBE = @"tools/ffmpeg/bin/ffprobe.exe";
        
        [DefaultValue(DEF_FFPROBE)]
        [Category(@"Hilfsprogramme")]
        [DisplayName(@"FFprobe")]
        [Description(@"Der Pfad von ffprobe.exe.")]
        public virtual string Ffprobe
        {
            get { return _ffprobe; }
            set
            {
                if (string.Equals(value, _ffprobe))
                {
                    return;
                }
                _ffprobe = value;
                this.OnFfprobeChanged();
            }
        }
        
        #endregion
        
        #region Property WaveViz
        
        private string _waveViz;
        
        public event EventHandler WaveVizChanged;
        
        protected virtual void OnWaveVizChanged()
        {
            this.IsChanged = true;
            EventHandler handler = WaveVizChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"WaveViz");
        }
        
        private const string DEF_WAVEVIZ = @"tools/WaveViz/WaveViz.exe";
        
        [DefaultValue(DEF_WAVEVIZ)]
        [Category(@"Hilfsprogramme")]
        [DisplayName(@"WaveViz")]
        [Description(@"Der Pfad von WaveViz.exe.")]
        public virtual string WaveViz
        {
            get { return _waveViz; }
            set
            {
                if (string.Equals(value, _waveViz))
                {
                    return;
                }
                _waveViz = value;
                this.OnWaveVizChanged();
            }
        }
        
        #endregion
        
        #region Property Transcripter
        
        private string _transcripter;
        
        public event EventHandler TranscripterChanged;
        
        protected virtual void OnTranscripterChanged()
        {
            this.IsChanged = true;
            EventHandler handler = TranscripterChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"Transcripter");
        }
        
        private const string DEF_TRANSCRIPTER = @"tools/Transcripter/Transcripter.exe";
        
        [DefaultValue(DEF_TRANSCRIPTER)]
        [Category(@"Hilfsprogramme")]
        [DisplayName(@"Transcripter")]
        [Description(@"Der Pfad von Transcripter.exe.")]
        public virtual string Transcripter
        {
            get { return _transcripter; }
            set
            {
                if (string.Equals(value, _transcripter))
                {
                    return;
                }
                _transcripter = value;
                this.OnTranscripterChanged();
            }
        }
        
        #endregion
        
        #region Property Distillery
        
        private string _distillery;
        
        public event EventHandler DistilleryChanged;
        
        protected virtual void OnDistilleryChanged()
        {
            this.IsChanged = true;
            EventHandler handler = DistilleryChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"Distillery");
        }
        
        private const string DEF_DISTILLERY = @"tools/distillery.jar";
        
        [DefaultValue(DEF_DISTILLERY)]
        [Category(@"Hilfsprogramme")]
        [DisplayName(@"distillery")]
        [Description(@"Der Pfad von distillery.jar.")]
        public virtual string Distillery
        {
            get { return _distillery; }
            set
            {
                if (string.Equals(value, _distillery))
                {
                    return;
                }
                _distillery = value;
                this.OnDistilleryChanged();
            }
        }
        
        #endregion
        
        #region Property JavaRuntime
        
        private string _javaRuntime;
        
        public event EventHandler JavaRuntimeChanged;
        
        protected virtual void OnJavaRuntimeChanged()
        {
            this.IsChanged = true;
            EventHandler handler = JavaRuntimeChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"JavaRuntime");
        }
        
        [Category(@"Hilfsprogramme")]
        [DisplayName(@"JRE")]
        [Description(@"Der Pfad zu java.exe oder leer wenn die Java-Laufzeitumgebung automatisch ermittelt werden soll.")]
        public virtual string JavaRuntime
        {
            get { return _javaRuntime; }
            set
            {
                if (string.Equals(value, _javaRuntime))
                {
                    return;
                }
                _javaRuntime = value;
                this.OnJavaRuntimeChanged();
            }
        }
        
        #endregion
    }
    
    #endregion
}