using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace de.fhb.oll.mediacategorizer.settings
{
    #region Scaleton Model Designer generated code
    
    public partial class Setup : INotifyPropertyChanged, IChangeTracking, IEquatable<Setup>
    {
        public Setup()
        {
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
                (!ReferenceEquals(this._ffmpeg, null) ? this._ffmpeg.GetHashCode() : 0) ^ 
                (!ReferenceEquals(this._waveViz, null) ? this._waveViz.GetHashCode() : 0) ^ 
                (!ReferenceEquals(this._transcripter, null) ? this._transcripter.GetHashCode() : 0) ^ 
                (!ReferenceEquals(this._distillery, null) ? this._distillery.GetHashCode() : 0));
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
        [Category(@"Tools")]
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
        [Category(@"Tools")]
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
        [Category(@"Tools")]
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
        [Category(@"Tools")]
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