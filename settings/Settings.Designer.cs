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
    
    public partial class Setup : INotifyPropertyChanged, IChangeTracking, IEquatable<Setup>
    {
        public Setup()
        {
            _parallelization = DEF_PARALLELIZATION;
            _parallelTasks = DEF_PARALLELTASKS;
            _compatibleMediaFileExtensions = DEF_COMPATIBLEMEDIAFILEEXTENSIONS;
            _rejectExistingIntermediates = DEF_REJECTEXISTINGINTERMEDIATES;
            _cleanupOutputDir = DEF_CLEANUPOUTPUTDIR;
            _ffmpeg = DEF_FFMPEG;
            _ffprobe = DEF_FFPROBE;
            _waveViz = DEF_WAVEVIZ;
            _transcripter = DEF_TRANSCRIPTER;
            _distillery = DEF_DISTILLERY;
            _confidenceTestDuration = DEF_CONFIDENCETESTDURATION;
            
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
                (Environment.NewLine + @"    CompatibleMediaFileExtensions = " + (!ReferenceEquals(_compatibleMediaFileExtensions, null) ? _compatibleMediaFileExtensions.ToString(formatProvider) : @"null").Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    RejectExistingIntermediates = " + _rejectExistingIntermediates.ToString(formatProvider).Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    CleanupOutputDir = " + _cleanupOutputDir.ToString(formatProvider).Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    Ffmpeg = " + (!ReferenceEquals(_ffmpeg, null) ? _ffmpeg.ToString(formatProvider) : @"null").Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    Ffprobe = " + (!ReferenceEquals(_ffprobe, null) ? _ffprobe.ToString(formatProvider) : @"null").Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    WaveViz = " + (!ReferenceEquals(_waveViz, null) ? _waveViz.ToString(formatProvider) : @"null").Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    Transcripter = " + (!ReferenceEquals(_transcripter, null) ? _transcripter.ToString(formatProvider) : @"null").Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    Distillery = " + (!ReferenceEquals(_distillery, null) ? _distillery.ToString(formatProvider) : @"null").Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    JavaRuntime = " + (!ReferenceEquals(_javaRuntime, null) ? _javaRuntime.ToString(formatProvider) : @"null").Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    ConfidenceTestDuration = " + _confidenceTestDuration.ToString(formatProvider).Replace("\n", "\n    "))));
        }
        
        #endregion
        
        #region Equatability
        
        public bool Equals(Setup o)
        {
            if (ReferenceEquals(o, null))
            {
                return false;
            }
            return (
                (this._parallelization == o._parallelization) && 
                (this._parallelTasks == o._parallelTasks) && 
                object.Equals(this._compatibleMediaFileExtensions, o._compatibleMediaFileExtensions) && 
                this._rejectExistingIntermediates.Equals(o._rejectExistingIntermediates) && 
                this._cleanupOutputDir.Equals(o._cleanupOutputDir) && 
                object.Equals(this._ffmpeg, o._ffmpeg) && 
                object.Equals(this._ffprobe, o._ffprobe) && 
                object.Equals(this._waveViz, o._waveViz) && 
                object.Equals(this._transcripter, o._transcripter) && 
                object.Equals(this._distillery, o._distillery) && 
                object.Equals(this._javaRuntime, o._javaRuntime) && 
                (this._confidenceTestDuration == o._confidenceTestDuration));
        }
        
        public override bool Equals(object o)
        {
            if (ReferenceEquals(o, null))
            {
                return false;
            }
            if (!(o.GetType() == typeof(Setup)))
            {
                return false;
            }
            return this.Equals((Setup)o);
        }
        
        public override int GetHashCode()
        {
            return (this.GetType().GetHashCode() ^ 
                this._parallelization.GetHashCode() ^ 
                this._parallelTasks.GetHashCode() ^ 
                (!ReferenceEquals(this._compatibleMediaFileExtensions, null) ? this._compatibleMediaFileExtensions.GetHashCode() : 0) ^ 
                this._rejectExistingIntermediates.GetHashCode() ^ 
                this._cleanupOutputDir.GetHashCode() ^ 
                (!ReferenceEquals(this._ffmpeg, null) ? this._ffmpeg.GetHashCode() : 0) ^ 
                (!ReferenceEquals(this._ffprobe, null) ? this._ffprobe.GetHashCode() : 0) ^ 
                (!ReferenceEquals(this._waveViz, null) ? this._waveViz.GetHashCode() : 0) ^ 
                (!ReferenceEquals(this._transcripter, null) ? this._transcripter.GetHashCode() : 0) ^ 
                (!ReferenceEquals(this._distillery, null) ? this._distillery.GetHashCode() : 0) ^ 
                (!ReferenceEquals(this._javaRuntime, null) ? this._javaRuntime.GetHashCode() : 0) ^ 
                this._confidenceTestDuration.GetHashCode());
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
        
        #region Property CompatibleMediaFileExtensions
        
        private string _compatibleMediaFileExtensions;
        
        public event EventHandler CompatibleMediaFileExtensionsChanged;
        
        protected virtual void OnCompatibleMediaFileExtensionsChanged()
        {
            this.IsChanged = true;
            EventHandler handler = CompatibleMediaFileExtensionsChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"CompatibleMediaFileExtensions");
        }
        
        private const string DEF_COMPATIBLEMEDIAFILEEXTENSIONS = @"mp4";
        
        [DefaultValue(DEF_COMPATIBLEMEDIAFILEEXTENSIONS)]
        [Category(@"Verarbeitung")]
        [DisplayName(@"Mediendateiendungen")]
        [Description(@"Eine Liste mit Dateiendungen für unterstützte Mediendateien. Die Endungen werden ohne führenden Punkt angegeben und durch Leerzeichen getrennt.")]
        public virtual string CompatibleMediaFileExtensions
        {
            get { return _compatibleMediaFileExtensions; }
            set
            {
                if (string.Equals(value, _compatibleMediaFileExtensions))
                {
                    return;
                }
                _compatibleMediaFileExtensions = value;
                this.OnCompatibleMediaFileExtensionsChanged();
            }
        }
        
        #endregion
        
        #region Property RejectExistingIntermediates
        
        private bool _rejectExistingIntermediates;
        
        public event EventHandler RejectExistingIntermediatesChanged;
        
        protected virtual void OnRejectExistingIntermediatesChanged()
        {
            this.IsChanged = true;
            EventHandler handler = RejectExistingIntermediatesChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"RejectExistingIntermediates");
        }
        
        private const bool DEF_REJECTEXISTINGINTERMEDIATES = true;
        
        [DefaultValue(DEF_REJECTEXISTINGINTERMEDIATES)]
        [Category(@"Verarbeitung")]
        [DisplayName(@"Zwischenergebnisse verwerfen")]
        [Description(@"Gibt an, ob existierende temporäre Ressourcen vor Start des Projektes verworfen werden sollen.")]
        public virtual bool RejectExistingIntermediates
        {
            get { return _rejectExistingIntermediates; }
            set
            {
                if ((value == _rejectExistingIntermediates))
                {
                    return;
                }
                _rejectExistingIntermediates = value;
                this.OnRejectExistingIntermediatesChanged();
            }
        }
        
        #endregion
        
        #region Property CleanupOutputDir
        
        private bool _cleanupOutputDir;
        
        public event EventHandler CleanupOutputDirChanged;
        
        protected virtual void OnCleanupOutputDirChanged()
        {
            this.IsChanged = true;
            EventHandler handler = CleanupOutputDirChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"CleanupOutputDir");
        }
        
        private const bool DEF_CLEANUPOUTPUTDIR = true;
        
        [DefaultValue(DEF_CLEANUPOUTPUTDIR)]
        [Category(@"Verarbeitung")]
        [DisplayName(@"Arbeitsverzeichnis aufräumen")]
        [Description(@"Gibt an, ob das temporäre Arbeitsverzeichnis nach Abschluss des Projektes gelöscht werden soll.")]
        public virtual bool CleanupOutputDir
        {
            get { return _cleanupOutputDir; }
            set
            {
                if ((value == _cleanupOutputDir))
                {
                    return;
                }
                _cleanupOutputDir = value;
                this.OnCleanupOutputDirChanged();
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
        
        #region Property ConfidenceTestDuration
        
        private float _confidenceTestDuration;
        
        public event EventHandler ConfidenceTestDurationChanged;
        
        protected virtual void OnConfidenceTestDurationChanged()
        {
            this.IsChanged = true;
            EventHandler handler = ConfidenceTestDurationChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"ConfidenceTestDuration");
        }
        
        private const float DEF_CONFIDENCETESTDURATION = 180F;
        
        [DefaultValue(DEF_CONFIDENCETESTDURATION)]
        [Category(@"Spracherkennung")]
        [DisplayName(@"Dauer des Profiltests (sec)")]
        [Description(@"Die Dauer des Auswahltests für Spracherkennungsprofile in Sekunden.")]
        public virtual float ConfidenceTestDuration
        {
            get { return _confidenceTestDuration; }
            set
            {
                if ((Math.Abs(value - _confidenceTestDuration) < float.Epsilon))
                {
                    return;
                }
                _confidenceTestDuration = value;
                this.OnConfidenceTestDurationChanged();
            }
        }
        
        #endregion
    }
    
    #endregion
}