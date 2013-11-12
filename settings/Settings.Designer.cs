using System;
using System.Collections.Generic;
using System.ComponentModel;

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
            _cleanupOutputDir = DEF_CLEANUPOUTPUTDIR;
            _ffmpeg = DEF_FFMPEG;
            _waveViz = DEF_WAVEVIZ;
            _transcripter = DEF_TRANSCRIPTER;
            _distillery = DEF_DISTILLERY;
            
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
        
        private bool _isChanged = false;
        
        [Browsable(false)]
        [global::System.Xml.Serialization.XmlIgnoreAttribute]
        
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
                (Environment.NewLine + @"    CleanupOutputDir = " + _cleanupOutputDir.ToString(formatProvider).Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    Ffmpeg = " + (!ReferenceEquals(_ffmpeg, null) ? _ffmpeg.ToString(formatProvider) : @"null").Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    WaveViz = " + (!ReferenceEquals(_waveViz, null) ? _waveViz.ToString(formatProvider) : @"null").Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    Transcripter = " + (!ReferenceEquals(_transcripter, null) ? _transcripter.ToString(formatProvider) : @"null").Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    Distillery = " + (!ReferenceEquals(_distillery, null) ? _distillery.ToString(formatProvider) : @"null").Replace("\n", "\n    "))));
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
                this._cleanupOutputDir.Equals(o._cleanupOutputDir) && 
                object.Equals(this._ffmpeg, o._ffmpeg) && 
                object.Equals(this._waveViz, o._waveViz) && 
                object.Equals(this._transcripter, o._transcripter) && 
                object.Equals(this._distillery, o._distillery));
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
                this._cleanupOutputDir.GetHashCode() ^ 
                (!ReferenceEquals(this._ffmpeg, null) ? this._ffmpeg.GetHashCode() : 0) ^ 
                (!ReferenceEquals(this._waveViz, null) ? this._waveViz.GetHashCode() : 0) ^ 
                (!ReferenceEquals(this._transcripter, null) ? this._transcripter.GetHashCode() : 0) ^ 
                (!ReferenceEquals(this._distillery, null) ? this._distillery.GetHashCode() : 0));
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
        [DisplayName(@"ffmpeg")]
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
    }
    
    #endregion
}