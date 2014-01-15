using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace de.fhb.oll.mediacategorizer.model
{
    #region Scaleton Model Designer generated code
    
    public enum ProfileSelectionCriterion
    {
        PhraseCount,
        PhraseConfidenceSum,
        MaxPhraseConfidence,
        MeanPhraseConfidence,
        MinPhraseConfidence,
        WordCount,
        WordConfidenceSum,
        MaxWordConfidence,
        MeanWordConfidence,
        BestWordConfidence,
    }
    
    public enum CloudPrecision
    {
        Low,
        Medium,
        High,
    }
    
    public enum CategoryResourceType
    {
        Plain,
        Html,
        Wikipedia,
    }
    
    public partial class Project : INotifyPropertyChanged, IChangeTracking
    {
        public Project()
        {
            _name = DEF_NAME;
            _description = DEF_DESCRIPTION;
            _outputDir = DEF_OUTPUTDIR;
            _resultFile = DEF_RESULTFILE;
            Configuration = new Configuration();
            Categories = new global::System.Collections.ObjectModel.ObservableCollection<Category>();
            Media = new global::System.Collections.ObjectModel.ObservableCollection<Media>();
            this.Initialize();
            
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
            if (!ReferenceEquals(_configuration, null))
            {
                _configuration.AcceptChanges();
            }
            this.IsChanged = false;
        }
        
        #endregion
        
        #region Property Name
        
        private string _name;
        
        public event EventHandler NameChanged;
        
        protected virtual void OnNameChanged()
        {
            this.IsChanged = true;
            EventHandler handler = NameChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"Name");
        }
        
        private const string DEF_NAME = @"No Name";
        
        [DefaultValue(DEF_NAME)]
        public virtual string Name
        {
            get { return _name; }
            set
            {
                if (string.Equals(value, _name))
                {
                    return;
                }
                _name = value;
                this.OnNameChanged();
            }
        }
        
        #endregion
        
        #region Property Description
        
        private string _description;
        
        public event EventHandler DescriptionChanged;
        
        protected virtual void OnDescriptionChanged()
        {
            this.IsChanged = true;
            EventHandler handler = DescriptionChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"Description");
        }
        
        private const string DEF_DESCRIPTION = @"No Description";
        
        [DefaultValue(DEF_DESCRIPTION)]
        public virtual string Description
        {
            get { return _description; }
            set
            {
                if (string.Equals(value, _description))
                {
                    return;
                }
                _description = value;
                this.OnDescriptionChanged();
            }
        }
        
        #endregion
        
        #region Property OutputDir
        
        private string _outputDir;
        
        public event EventHandler OutputDirChanged;
        
        protected virtual void OnOutputDirChanged()
        {
            this.IsChanged = true;
            EventHandler handler = OutputDirChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"OutputDir");
        }
        
        private const string DEF_OUTPUTDIR = @"output";
        
        [DefaultValue(DEF_OUTPUTDIR)]
        public virtual string OutputDir
        {
            get { return _outputDir; }
            set
            {
                if (string.Equals(value, _outputDir))
                {
                    return;
                }
                _outputDir = value;
                this.OnOutputDirChanged();
            }
        }
        
        #endregion
        
        #region Property ResultFile
        
        private string _resultFile;
        
        public event EventHandler ResultFileChanged;
        
        protected virtual void OnResultFileChanged()
        {
            this.IsChanged = true;
            EventHandler handler = ResultFileChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"ResultFile");
        }
        
        private const string DEF_RESULTFILE = @"result.xml";
        
        [DefaultValue(DEF_RESULTFILE)]
        public virtual string ResultFile
        {
            get { return _resultFile; }
            set
            {
                if (string.Equals(value, _resultFile))
                {
                    return;
                }
                _resultFile = value;
                this.OnResultFileChanged();
            }
        }
        
        #endregion
        
        #region Property Configuration
        
        private Configuration _configuration;
        
        public event EventHandler ConfigurationChanged;
        
        protected virtual void OnConfigurationChanged()
        {
            this.IsChanged = true;
            EventHandler handler = ConfigurationChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"Configuration");
        }
        
        private void ConfigurationPropertyChangedHandler(object sender, PropertyChangedEventArgs ea)
        {
            this.OnConfigurationChanged();
        }
        
        [global::Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public virtual Configuration Configuration
        {
            get { return _configuration; }
            set
            {
                if ((value == _configuration))
                {
                    return;
                }
                if (!ReferenceEquals(_configuration, null))
                {
                    _configuration.PropertyChanged -= this.ConfigurationPropertyChangedHandler;
                }
                _configuration = value;
                if (!ReferenceEquals(_configuration, null))
                {
                    _configuration.PropertyChanged += this.ConfigurationPropertyChangedHandler;
                }
                this.OnConfigurationChanged();
            }
        }
        
        #endregion
        
        #region Property Categories
        
        private global::System.Collections.ObjectModel.ObservableCollection<Category> _categories;
        
        public event EventHandler CategoriesChanged;
        
        protected virtual void OnCategoriesChanged()
        {
            this.IsChanged = true;
            EventHandler handler = CategoriesChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"Categories");
        }
        
        private void CategoriesItemPropertyChanged(object sender, EventArgs ea)
        {
            this.OnCategoriesChanged();
        }
        
        private void CategoriesCollectionChangedHandler(object sender, global::System.Collections.Specialized.NotifyCollectionChangedEventArgs ea)
        {
            if (!ReferenceEquals(ea.OldItems, null))
            {
                foreach (Category item in ea.OldItems)
                {
                    if (!ReferenceEquals(item, null))
                    {
                        item.PropertyChanged -= this.CategoriesItemPropertyChanged;
                    }
                }
            }
            this.OnCategoriesChanged();
            if (!ReferenceEquals(ea.NewItems, null))
            {
                foreach (Category item in ea.NewItems)
                {
                    if (!ReferenceEquals(item, null))
                    {
                        item.PropertyChanged += this.CategoriesItemPropertyChanged;
                    }
                }
            }
        }
        
        public virtual global::System.Collections.ObjectModel.ObservableCollection<Category> Categories
        {
            get { return _categories; }
            set
            {
                if ((value == _categories))
                {
                    return;
                }
                if (!ReferenceEquals(_categories, null))
                {
                    _categories.CollectionChanged -= this.CategoriesCollectionChangedHandler;
                }
                _categories = value;
                if (!ReferenceEquals(_categories, null))
                {
                    _categories.CollectionChanged += this.CategoriesCollectionChangedHandler;
                }
                this.OnCategoriesChanged();
            }
        }
        
        #endregion
        
        #region Property Media
        
        private global::System.Collections.ObjectModel.ObservableCollection<Media> _media;
        
        public event EventHandler MediaChanged;
        
        protected virtual void OnMediaChanged()
        {
            this.IsChanged = true;
            EventHandler handler = MediaChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"Media");
        }
        
        private void MediaItemPropertyChanged(object sender, EventArgs ea)
        {
            this.OnMediaChanged();
        }
        
        private void MediaCollectionChangedHandler(object sender, global::System.Collections.Specialized.NotifyCollectionChangedEventArgs ea)
        {
            if (!ReferenceEquals(ea.OldItems, null))
            {
                foreach (Media item in ea.OldItems)
                {
                    if (!ReferenceEquals(item, null))
                    {
                        item.PropertyChanged -= this.MediaItemPropertyChanged;
                    }
                }
            }
            this.OnMediaChanged();
            if (!ReferenceEquals(ea.NewItems, null))
            {
                foreach (Media item in ea.NewItems)
                {
                    if (!ReferenceEquals(item, null))
                    {
                        item.PropertyChanged += this.MediaItemPropertyChanged;
                    }
                }
            }
        }
        
        public virtual global::System.Collections.ObjectModel.ObservableCollection<Media> Media
        {
            get { return _media; }
            set
            {
                if ((value == _media))
                {
                    return;
                }
                if (!ReferenceEquals(_media, null))
                {
                    _media.CollectionChanged -= this.MediaCollectionChangedHandler;
                }
                _media = value;
                if (!ReferenceEquals(_media, null))
                {
                    _media.CollectionChanged += this.MediaCollectionChangedHandler;
                }
                this.OnMediaChanged();
            }
        }
        
        #endregion
    }
    
    public partial class Configuration : INotifyPropertyChanged, IChangeTracking
    {
        public Configuration()
        {
            _confidenceTestDuration = DEF_CONFIDENCETESTDURATION;
            _profileSelectionCriterion = DEF_PROFILESELECTIONCRITERION;
            _minConfidence = DEF_MINCONFIDENCE;
            _goodConfidence = DEF_GOODCONFIDENCE;
            _minMatchScore = DEF_MINMATCHSCORE;
            IndexFilter = new FilterParameter();
            Waveform = new WaveformParameter();
            MainCloud = new CloudParameter();
            MediaCloud = new CloudParameter();
            CategoryCloud = new CloudParameter();
            _rejectExistingIntermediates = DEF_REJECTEXISTINGINTERMEDIATES;
            _cleanupOutputDir = DEF_CLEANUPOUTPUTDIR;
            _visualizeResult = DEF_VISUALIZERESULT;
            _showResult = DEF_SHOWRESULT;
            _skipWordClouds = DEF_SKIPWORDCLOUDS;
            _skipWordIncludes = DEF_SKIPWORDINCLUDES;
            _skipMatchIncludes = DEF_SKIPMATCHINCLUDES;
            _skipMediaCopy = DEF_SKIPMEDIACOPY;
            
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
            if (!ReferenceEquals(_indexFilter, null))
            {
                _indexFilter.AcceptChanges();
            }
            if (!ReferenceEquals(_waveform, null))
            {
                _waveform.AcceptChanges();
            }
            if (!ReferenceEquals(_mainCloud, null))
            {
                _mainCloud.AcceptChanges();
            }
            if (!ReferenceEquals(_mediaCloud, null))
            {
                _mediaCloud.AcceptChanges();
            }
            if (!ReferenceEquals(_categoryCloud, null))
            {
                _categoryCloud.AcceptChanges();
            }
            this.IsChanged = false;
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
        
        private const float DEF_CONFIDENCETESTDURATION = 120F;
        
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
        
        #region Property ProfileSelectionCriterion
        
        private ProfileSelectionCriterion _profileSelectionCriterion;
        
        public event EventHandler ProfileSelectionCriterionChanged;
        
        protected virtual void OnProfileSelectionCriterionChanged()
        {
            this.IsChanged = true;
            EventHandler handler = ProfileSelectionCriterionChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"ProfileSelectionCriterion");
        }
        
        private const ProfileSelectionCriterion DEF_PROFILESELECTIONCRITERION = ProfileSelectionCriterion.MeanPhraseConfidence;
        
        [DefaultValue(DEF_PROFILESELECTIONCRITERION)]
        [Category(@"Spracherkennung")]
        [DisplayName(@"Profilauswahlkriterium")]
        [Description(@"Definiert das Auswahlkriterium anhand dessen das optimale Spracherkennungsprofil je Medium ausgewählt wird.")]
        public virtual ProfileSelectionCriterion ProfileSelectionCriterion
        {
            get { return _profileSelectionCriterion; }
            set
            {
                if ((value == _profileSelectionCriterion))
                {
                    return;
                }
                _profileSelectionCriterion = value;
                this.OnProfileSelectionCriterionChanged();
            }
        }
        
        #endregion
        
        #region Property MinConfidence
        
        private float _minConfidence;
        
        public event EventHandler MinConfidenceChanged;
        
        protected virtual void OnMinConfidenceChanged()
        {
            this.IsChanged = true;
            EventHandler handler = MinConfidenceChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"MinConfidence");
        }
        
        private const float DEF_MINCONFIDENCE = 0.4F;
        
        [DefaultValue(DEF_MINCONFIDENCE)]
        [Category(@"Analyse")]
        [DisplayName(@"Minimale Erkennungssicherheit")]
        [Description(@"Die minimale Erkennungssicherheit für Worte die in der Analyse berücksichtigt werden sollen.")]
        public virtual float MinConfidence
        {
            get { return _minConfidence; }
            set
            {
                if ((Math.Abs(value - _minConfidence) < float.Epsilon))
                {
                    return;
                }
                _minConfidence = value;
                this.OnMinConfidenceChanged();
            }
        }
        
        #endregion
        
        #region Property GoodConfidence
        
        private float _goodConfidence;
        
        public event EventHandler GoodConfidenceChanged;
        
        protected virtual void OnGoodConfidenceChanged()
        {
            this.IsChanged = true;
            EventHandler handler = GoodConfidenceChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"GoodConfidence");
        }
        
        private const float DEF_GOODCONFIDENCE = 0.7F;
        
        [DefaultValue(DEF_GOODCONFIDENCE)]
        [Category(@"Analyse")]
        [DisplayName(@"Gute Erkennungssicherheit")]
        [Description(@"Die minimale Erkennungssicherheit für Worte die in der Ausgabe verwendet werden dürfen.")]
        public virtual float GoodConfidence
        {
            get { return _goodConfidence; }
            set
            {
                if ((Math.Abs(value - _goodConfidence) < float.Epsilon))
                {
                    return;
                }
                _goodConfidence = value;
                this.OnGoodConfidenceChanged();
            }
        }
        
        #endregion
        
        #region Property MinMatchScore
        
        private float _minMatchScore;
        
        public event EventHandler MinMatchScoreChanged;
        
        protected virtual void OnMinMatchScoreChanged()
        {
            this.IsChanged = true;
            EventHandler handler = MinMatchScoreChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"MinMatchScore");
        }
        
        private const float DEF_MINMATCHSCORE = 0.02F;
        
        [DefaultValue(DEF_MINMATCHSCORE)]
        [Category(@"Analyse")]
        [DisplayName(@"Minimale Übereinstimmung")]
        [Description(@"Die minimale Übereinstimmung für eine Zuordnung zwischen einem Video und einer Kategorie.")]
        public virtual float MinMatchScore
        {
            get { return _minMatchScore; }
            set
            {
                if ((Math.Abs(value - _minMatchScore) < float.Epsilon))
                {
                    return;
                }
                _minMatchScore = value;
                this.OnMinMatchScoreChanged();
            }
        }
        
        #endregion
        
        #region Property IndexFilter
        
        private FilterParameter _indexFilter;
        
        public event EventHandler IndexFilterChanged;
        
        protected virtual void OnIndexFilterChanged()
        {
            this.IsChanged = true;
            EventHandler handler = IndexFilterChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"IndexFilter");
        }
        
        private void IndexFilterPropertyChangedHandler(object sender, PropertyChangedEventArgs ea)
        {
            this.OnIndexFilterChanged();
        }
        
        [global::Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        [Category(@"Analyse")]
        [DisplayName(@"Wortfilter")]
        public virtual FilterParameter IndexFilter
        {
            get { return _indexFilter; }
            set
            {
                if ((value == _indexFilter))
                {
                    return;
                }
                if (!ReferenceEquals(_indexFilter, null))
                {
                    _indexFilter.PropertyChanged -= this.IndexFilterPropertyChangedHandler;
                }
                _indexFilter = value;
                if (!ReferenceEquals(_indexFilter, null))
                {
                    _indexFilter.PropertyChanged += this.IndexFilterPropertyChangedHandler;
                }
                this.OnIndexFilterChanged();
            }
        }
        
        #endregion
        
        #region Property Waveform
        
        private WaveformParameter _waveform;
        
        public event EventHandler WaveformChanged;
        
        protected virtual void OnWaveformChanged()
        {
            this.IsChanged = true;
            EventHandler handler = WaveformChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"Waveform");
        }
        
        private void WaveformPropertyChangedHandler(object sender, PropertyChangedEventArgs ea)
        {
            this.OnWaveformChanged();
        }
        
        [global::Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        [Category(@"Visualisierung")]
        [DisplayName(@"Wellenformvisualisierung")]
        [Description(@"Die Parameter für die Wellenformvisualisierung.")]
        public virtual WaveformParameter Waveform
        {
            get { return _waveform; }
            set
            {
                if ((value == _waveform))
                {
                    return;
                }
                if (!ReferenceEquals(_waveform, null))
                {
                    _waveform.PropertyChanged -= this.WaveformPropertyChangedHandler;
                }
                _waveform = value;
                if (!ReferenceEquals(_waveform, null))
                {
                    _waveform.PropertyChanged += this.WaveformPropertyChangedHandler;
                }
                this.OnWaveformChanged();
            }
        }
        
        #endregion
        
        #region Property MainCloud
        
        private CloudParameter _mainCloud;
        
        public event EventHandler MainCloudChanged;
        
        protected virtual void OnMainCloudChanged()
        {
            this.IsChanged = true;
            EventHandler handler = MainCloudChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"MainCloud");
        }
        
        private void MainCloudPropertyChangedHandler(object sender, PropertyChangedEventArgs ea)
        {
            this.OnMainCloudChanged();
        }
        
        [global::Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        [Category(@"Visualisierung")]
        [DisplayName(@"Globale Wolke")]
        [Description(@"Die Parameter für die globale Wortwolke für das gesamte Projekt.")]
        public virtual CloudParameter MainCloud
        {
            get { return _mainCloud; }
            set
            {
                if ((value == _mainCloud))
                {
                    return;
                }
                if (!ReferenceEquals(_mainCloud, null))
                {
                    _mainCloud.PropertyChanged -= this.MainCloudPropertyChangedHandler;
                }
                _mainCloud = value;
                if (!ReferenceEquals(_mainCloud, null))
                {
                    _mainCloud.PropertyChanged += this.MainCloudPropertyChangedHandler;
                }
                this.OnMainCloudChanged();
            }
        }
        
        #endregion
        
        #region Property MediaCloud
        
        private CloudParameter _mediaCloud;
        
        public event EventHandler MediaCloudChanged;
        
        protected virtual void OnMediaCloudChanged()
        {
            this.IsChanged = true;
            EventHandler handler = MediaCloudChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"MediaCloud");
        }
        
        private void MediaCloudPropertyChangedHandler(object sender, PropertyChangedEventArgs ea)
        {
            this.OnMediaCloudChanged();
        }
        
        [global::Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        [Category(@"Visualisierung")]
        [DisplayName(@"Medienwolke")]
        [Description(@"Die Parameter für die Wortwolke eines Mediums.")]
        public virtual CloudParameter MediaCloud
        {
            get { return _mediaCloud; }
            set
            {
                if ((value == _mediaCloud))
                {
                    return;
                }
                if (!ReferenceEquals(_mediaCloud, null))
                {
                    _mediaCloud.PropertyChanged -= this.MediaCloudPropertyChangedHandler;
                }
                _mediaCloud = value;
                if (!ReferenceEquals(_mediaCloud, null))
                {
                    _mediaCloud.PropertyChanged += this.MediaCloudPropertyChangedHandler;
                }
                this.OnMediaCloudChanged();
            }
        }
        
        #endregion
        
        #region Property CategoryCloud
        
        private CloudParameter _categoryCloud;
        
        public event EventHandler CategoryCloudChanged;
        
        protected virtual void OnCategoryCloudChanged()
        {
            this.IsChanged = true;
            EventHandler handler = CategoryCloudChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"CategoryCloud");
        }
        
        private void CategoryCloudPropertyChangedHandler(object sender, PropertyChangedEventArgs ea)
        {
            this.OnCategoryCloudChanged();
        }
        
        [global::Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        [Category(@"Visualisierung")]
        [DisplayName(@"Kategoriewolke")]
        [Description(@"Die Parameter für die Wortwolke einer Kategorie.")]
        public virtual CloudParameter CategoryCloud
        {
            get { return _categoryCloud; }
            set
            {
                if ((value == _categoryCloud))
                {
                    return;
                }
                if (!ReferenceEquals(_categoryCloud, null))
                {
                    _categoryCloud.PropertyChanged -= this.CategoryCloudPropertyChangedHandler;
                }
                _categoryCloud = value;
                if (!ReferenceEquals(_categoryCloud, null))
                {
                    _categoryCloud.PropertyChanged += this.CategoryCloudPropertyChangedHandler;
                }
                this.OnCategoryCloudChanged();
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
        
        #region Property VisualizeResult
        
        private bool _visualizeResult;
        
        public event EventHandler VisualizeResultChanged;
        
        protected virtual void OnVisualizeResultChanged()
        {
            this.IsChanged = true;
            EventHandler handler = VisualizeResultChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"VisualizeResult");
        }
        
        private const bool DEF_VISUALIZERESULT = true;
        
        [DefaultValue(DEF_VISUALIZERESULT)]
        [Category(@"Ausgabe")]
        [DisplayName(@"Ergebnis visualisieren")]
        [Description(@"Gibt an, ob eine interaktive Website zur Veranschaulichung des Analyseergebnisses erstellt werden soll.")]
        public virtual bool VisualizeResult
        {
            get { return _visualizeResult; }
            set
            {
                if ((value == _visualizeResult))
                {
                    return;
                }
                _visualizeResult = value;
                this.OnVisualizeResultChanged();
            }
        }
        
        #endregion
        
        #region Property ShowResult
        
        private bool _showResult;
        
        public event EventHandler ShowResultChanged;
        
        protected virtual void OnShowResultChanged()
        {
            this.IsChanged = true;
            EventHandler handler = ShowResultChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"ShowResult");
        }
        
        private const bool DEF_SHOWRESULT = true;
        
        [DefaultValue(DEF_SHOWRESULT)]
        [Category(@"Ausgabe")]
        [DisplayName(@"Ergebnis anzeigen")]
        [Description(@"Gibt an, ob das Ergebnis nach Abschluss der Analyse angezeigt werden soll.")]
        public virtual bool ShowResult
        {
            get { return _showResult; }
            set
            {
                if ((value == _showResult))
                {
                    return;
                }
                _showResult = value;
                this.OnShowResultChanged();
            }
        }
        
        #endregion
        
        #region Property SkipWordClouds
        
        private bool _skipWordClouds;
        
        public event EventHandler SkipWordCloudsChanged;
        
        protected virtual void OnSkipWordCloudsChanged()
        {
            this.IsChanged = true;
            EventHandler handler = SkipWordCloudsChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"SkipWordClouds");
        }
        
        private const bool DEF_SKIPWORDCLOUDS = false;
        
        [DefaultValue(DEF_SKIPWORDCLOUDS)]
        [Category(@"Ausgabe")]
        [DisplayName(@"Keine Wortwolken")]
        [Description(@"Gibt an, ob die zeitaufwändige Erstellung von Wortwolken übersprungen werden soll.")]
        public virtual bool SkipWordClouds
        {
            get { return _skipWordClouds; }
            set
            {
                if ((value == _skipWordClouds))
                {
                    return;
                }
                _skipWordClouds = value;
                this.OnSkipWordCloudsChanged();
            }
        }
        
        #endregion
        
        #region Property SkipWordIncludes
        
        private bool _skipWordIncludes;
        
        public event EventHandler SkipWordIncludesChanged;
        
        protected virtual void OnSkipWordIncludesChanged()
        {
            this.IsChanged = true;
            EventHandler handler = SkipWordIncludesChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"SkipWordIncludes");
        }
        
        private const bool DEF_SKIPWORDINCLUDES = false;
        
        [DefaultValue(DEF_SKIPWORDINCLUDES)]
        [Category(@"Ausgabe")]
        [DisplayName(@"Keine Wortseiten")]
        [Description(@"Gibt an, ob die Erstellung von Detailseiten für jedes erkannte Wort übersprungen werden soll.")]
        public virtual bool SkipWordIncludes
        {
            get { return _skipWordIncludes; }
            set
            {
                if ((value == _skipWordIncludes))
                {
                    return;
                }
                _skipWordIncludes = value;
                this.OnSkipWordIncludesChanged();
            }
        }
        
        #endregion
        
        #region Property SkipMatchIncludes
        
        private bool _skipMatchIncludes;
        
        public event EventHandler SkipMatchIncludesChanged;
        
        protected virtual void OnSkipMatchIncludesChanged()
        {
            this.IsChanged = true;
            EventHandler handler = SkipMatchIncludesChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"SkipMatchIncludes");
        }
        
        private const bool DEF_SKIPMATCHINCLUDES = false;
        
        [DefaultValue(DEF_SKIPMATCHINCLUDES)]
        [Category(@"Ausgabe")]
        [DisplayName(@"Keine Übereinstimmungsdetails")]
        [Description(@"Gibt an, ob die Erstellung von Detailseiten für jede Übereinstimmung zwischen einem Medium und einer Kategorie übersprungen werden soll.")]
        public virtual bool SkipMatchIncludes
        {
            get { return _skipMatchIncludes; }
            set
            {
                if ((value == _skipMatchIncludes))
                {
                    return;
                }
                _skipMatchIncludes = value;
                this.OnSkipMatchIncludesChanged();
            }
        }
        
        #endregion
        
        #region Property SkipMediaCopy
        
        private bool _skipMediaCopy;
        
        public event EventHandler SkipMediaCopyChanged;
        
        protected virtual void OnSkipMediaCopyChanged()
        {
            this.IsChanged = true;
            EventHandler handler = SkipMediaCopyChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"SkipMediaCopy");
        }
        
        private const bool DEF_SKIPMEDIACOPY = false;
        
        [DefaultValue(DEF_SKIPMEDIACOPY)]
        [Category(@"Ausgabe")]
        [DisplayName(@"Mediendateien nicht kopieren")]
        [Description(@"Gibt an, ob das Kopieren der Medien in die Ausgabe übersprungen werden soll.")]
        public virtual bool SkipMediaCopy
        {
            get { return _skipMediaCopy; }
            set
            {
                if ((value == _skipMediaCopy))
                {
                    return;
                }
                _skipMediaCopy = value;
                this.OnSkipMediaCopyChanged();
            }
        }
        
        #endregion
    }
    
    public partial class FilterParameter : INotifyPropertyChanged, IChangeTracking
    {
        public FilterParameter()
        {
            _blacklistResource = DEF_BLACKLISTRESOURCE;
            _blacklistMaxSize = DEF_BLACKLISTMAXSIZE;
            _filterNotShort = DEF_FILTERNOTSHORT;
            _filterNoun = DEF_FILTERNOUN;
            _filterMinConfidence = DEF_FILTERMINCONFIDENCE;
            _filterGoodConfidence = DEF_FILTERGOODCONFIDENCE;
            _filterNoPunctuation = DEF_FILTERNOPUNCTUATION;
            _filterNotInBlacklist = DEF_FILTERNOTINBLACKLIST;
            
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
        
        #region Property BlacklistResource
        
        private string _blacklistResource;
        
        public event EventHandler BlacklistResourceChanged;
        
        protected virtual void OnBlacklistResourceChanged()
        {
            this.IsChanged = true;
            EventHandler handler = BlacklistResourceChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"BlacklistResource");
        }
        
        private const string DEF_BLACKLISTRESOURCE = @"top10000de.txt";
        
        [DefaultValue(DEF_BLACKLISTRESOURCE)]
        [Browsable(false)]
        public virtual string BlacklistResource
        {
            get { return _blacklistResource; }
            set
            {
                if (string.Equals(value, _blacklistResource))
                {
                    return;
                }
                _blacklistResource = value;
                this.OnBlacklistResourceChanged();
            }
        }
        
        #endregion
        
        #region Property BlacklistMaxSize
        
        private int _blacklistMaxSize;
        
        public event EventHandler BlacklistMaxSizeChanged;
        
        protected virtual void OnBlacklistMaxSizeChanged()
        {
            this.IsChanged = true;
            EventHandler handler = BlacklistMaxSizeChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"BlacklistMaxSize");
        }
        
        private const int DEF_BLACKLISTMAXSIZE = 2000;
        
        [DefaultValue(DEF_BLACKLISTMAXSIZE)]
        [DisplayName(@"Blacklist-Worte")]
        [Description(@"Die obere Grenze für die Anzahl der Worte, die vom Anfang der Blacklist für das Filtern verwendet werden. Es wird eine nach Relevanz sortierte Blacklist vorausgesetzt.")]
        public virtual int BlacklistMaxSize
        {
            get { return _blacklistMaxSize; }
            set
            {
                if ((value == _blacklistMaxSize))
                {
                    return;
                }
                _blacklistMaxSize = value;
                this.OnBlacklistMaxSizeChanged();
            }
        }
        
        #endregion
        
        #region Property FilterNotShort
        
        private bool _filterNotShort;
        
        public event EventHandler FilterNotShortChanged;
        
        protected virtual void OnFilterNotShortChanged()
        {
            this.IsChanged = true;
            EventHandler handler = FilterNotShortChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"FilterNotShort");
        }
        
        private const bool DEF_FILTERNOTSHORT = true;
        
        [DefaultValue(DEF_FILTERNOTSHORT)]
        [DisplayName(@"Keine kurzen Worte")]
        [Description(@"Es werden nur Worte mit einer Mindestlänge berücksichtigt.")]
        public virtual bool FilterNotShort
        {
            get { return _filterNotShort; }
            set
            {
                if ((value == _filterNotShort))
                {
                    return;
                }
                _filterNotShort = value;
                this.OnFilterNotShortChanged();
            }
        }
        
        #endregion
        
        #region Property FilterNoun
        
        private bool _filterNoun;
        
        public event EventHandler FilterNounChanged;
        
        protected virtual void OnFilterNounChanged()
        {
            this.IsChanged = true;
            EventHandler handler = FilterNounChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"FilterNoun");
        }
        
        private const bool DEF_FILTERNOUN = true;
        
        [DefaultValue(DEF_FILTERNOUN)]
        [DisplayName(@"Nur Substantive")]
        [Description(@"Es werden nur Substantive berücksichtigt. Die Erkennung von Substantiven findet zur Zeit nur mittels Großschreibung statt.")]
        public virtual bool FilterNoun
        {
            get { return _filterNoun; }
            set
            {
                if ((value == _filterNoun))
                {
                    return;
                }
                _filterNoun = value;
                this.OnFilterNounChanged();
            }
        }
        
        #endregion
        
        #region Property FilterMinConfidence
        
        private bool _filterMinConfidence;
        
        public event EventHandler FilterMinConfidenceChanged;
        
        protected virtual void OnFilterMinConfidenceChanged()
        {
            this.IsChanged = true;
            EventHandler handler = FilterMinConfidenceChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"FilterMinConfidence");
        }
        
        private const bool DEF_FILTERMINCONFIDENCE = true;
        
        [DefaultValue(DEF_FILTERMINCONFIDENCE)]
        [DisplayName(@"Erkennungssicherheit minimal")]
        [Description(@"Es werden nur Worte brücksichtigt, die mit einer minimalen Erkennungssicherheit erkannt wurden.")]
        public virtual bool FilterMinConfidence
        {
            get { return _filterMinConfidence; }
            set
            {
                if ((value == _filterMinConfidence))
                {
                    return;
                }
                _filterMinConfidence = value;
                this.OnFilterMinConfidenceChanged();
            }
        }
        
        #endregion
        
        #region Property FilterGoodConfidence
        
        private bool _filterGoodConfidence;
        
        public event EventHandler FilterGoodConfidenceChanged;
        
        protected virtual void OnFilterGoodConfidenceChanged()
        {
            this.IsChanged = true;
            EventHandler handler = FilterGoodConfidenceChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"FilterGoodConfidence");
        }
        
        private const bool DEF_FILTERGOODCONFIDENCE = false;
        
        [DefaultValue(DEF_FILTERGOODCONFIDENCE)]
        [DisplayName(@"Erkennungssicherheit gut")]
        [Description(@"Es werden nur Worte brücksichtigt, die mit einer guten Erkennungssicherheit erkannt wurden.")]
        public virtual bool FilterGoodConfidence
        {
            get { return _filterGoodConfidence; }
            set
            {
                if ((value == _filterGoodConfidence))
                {
                    return;
                }
                _filterGoodConfidence = value;
                this.OnFilterGoodConfidenceChanged();
            }
        }
        
        #endregion
        
        #region Property FilterNoPunctuation
        
        private bool _filterNoPunctuation;
        
        public event EventHandler FilterNoPunctuationChanged;
        
        protected virtual void OnFilterNoPunctuationChanged()
        {
            this.IsChanged = true;
            EventHandler handler = FilterNoPunctuationChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"FilterNoPunctuation");
        }
        
        private const bool DEF_FILTERNOPUNCTUATION = true;
        
        [DefaultValue(DEF_FILTERNOPUNCTUATION)]
        [DisplayName(@"Keine Sonderzeichen")]
        [Description(@"Es werden keine Satzzeichen, Klammern oder andere Sonderzeichen berücksichtigt.")]
        public virtual bool FilterNoPunctuation
        {
            get { return _filterNoPunctuation; }
            set
            {
                if ((value == _filterNoPunctuation))
                {
                    return;
                }
                _filterNoPunctuation = value;
                this.OnFilterNoPunctuationChanged();
            }
        }
        
        #endregion
        
        #region Property FilterNotInBlacklist
        
        private bool _filterNotInBlacklist;
        
        public event EventHandler FilterNotInBlacklistChanged;
        
        protected virtual void OnFilterNotInBlacklistChanged()
        {
            this.IsChanged = true;
            EventHandler handler = FilterNotInBlacklistChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"FilterNotInBlacklist");
        }
        
        private const bool DEF_FILTERNOTINBLACKLIST = true;
        
        [DefaultValue(DEF_FILTERNOTINBLACKLIST)]
        [DisplayName(@"Blacklist")]
        [Description(@"Es werden nur Worte brücksichtigt, die nicht auf der Blacklist stehen.")]
        public virtual bool FilterNotInBlacklist
        {
            get { return _filterNotInBlacklist; }
            set
            {
                if ((value == _filterNotInBlacklist))
                {
                    return;
                }
                _filterNotInBlacklist = value;
                this.OnFilterNotInBlacklistChanged();
            }
        }
        
        #endregion
    }
    
    public partial class WaveformParameter : INotifyPropertyChanged, IChangeTracking
    {
        public WaveformParameter()
        {
            _width = DEF_WIDTH;
            _height = DEF_HEIGHT;
            this.Initialize();
            
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
        
        #region Property Width
        
        private int _width;
        
        public event EventHandler WidthChanged;
        
        protected virtual void OnWidthChanged()
        {
            this.IsChanged = true;
            EventHandler handler = WidthChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"Width");
        }
        
        private const int DEF_WIDTH = 640;
        
        [DefaultValue(DEF_WIDTH)]
        [DisplayName(@"Breite (px)")]
        [Description(@"Die Breite der Wellenformvisualisierung in Pixel.")]
        public virtual int Width
        {
            get { return _width; }
            set
            {
                if ((value == _width))
                {
                    return;
                }
                _width = value;
                this.OnWidthChanged();
            }
        }
        
        #endregion
        
        #region Property Height
        
        private int _height;
        
        public event EventHandler HeightChanged;
        
        protected virtual void OnHeightChanged()
        {
            this.IsChanged = true;
            EventHandler handler = HeightChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"Height");
        }
        
        private const int DEF_HEIGHT = 80;
        
        [DefaultValue(DEF_HEIGHT)]
        [DisplayName(@"Höhe (px)")]
        [Description(@"Die Höhe der Wellenformvisualisierung in Pixel.")]
        public virtual int Height
        {
            get { return _height; }
            set
            {
                if ((value == _height))
                {
                    return;
                }
                _height = value;
                this.OnHeightChanged();
            }
        }
        
        #endregion
        
        #region Property BackgroundColor
        
        private global::System.Windows.Media.Color _backgroundColor;
        
        public event EventHandler BackgroundColorChanged;
        
        protected virtual void OnBackgroundColorChanged()
        {
            this.IsChanged = true;
            EventHandler handler = BackgroundColorChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"BackgroundColor");
        }
        
        [DisplayName(@"Hintergrund")]
        [Description(@"Die Farbe des Hintergrundes.")]
        public virtual global::System.Windows.Media.Color BackgroundColor
        {
            get { return _backgroundColor; }
            set
            {
                if (value.Equals(_backgroundColor))
                {
                    return;
                }
                _backgroundColor = value;
                this.OnBackgroundColorChanged();
            }
        }
        
        #endregion
        
        #region Property Foreground1Color
        
        private global::System.Windows.Media.Color _foreground1Color;
        
        public event EventHandler Foreground1ColorChanged;
        
        protected virtual void OnForeground1ColorChanged()
        {
            this.IsChanged = true;
            EventHandler handler = Foreground1ColorChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"Foreground1Color");
        }
        
        [DisplayName(@"Wellenform 1")]
        [Description(@"Die erste Farbe der Wellenform.")]
        public virtual global::System.Windows.Media.Color Foreground1Color
        {
            get { return _foreground1Color; }
            set
            {
                if (value.Equals(_foreground1Color))
                {
                    return;
                }
                _foreground1Color = value;
                this.OnForeground1ColorChanged();
            }
        }
        
        #endregion
        
        #region Property Foreground2Color
        
        private global::System.Windows.Media.Color _foreground2Color;
        
        public event EventHandler Foreground2ColorChanged;
        
        protected virtual void OnForeground2ColorChanged()
        {
            this.IsChanged = true;
            EventHandler handler = Foreground2ColorChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"Foreground2Color");
        }
        
        [DisplayName(@"Wellenform 2")]
        [Description(@"Die zweite Farbe der Wellenform.")]
        public virtual global::System.Windows.Media.Color Foreground2Color
        {
            get { return _foreground2Color; }
            set
            {
                if (value.Equals(_foreground2Color))
                {
                    return;
                }
                _foreground2Color = value;
                this.OnForeground2ColorChanged();
            }
        }
        
        #endregion
        
        #region Property LineColor
        
        private global::System.Windows.Media.Color _lineColor;
        
        public event EventHandler LineColorChanged;
        
        protected virtual void OnLineColorChanged()
        {
            this.IsChanged = true;
            EventHandler handler = LineColorChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"LineColor");
        }
        
        [DisplayName(@"Horizontlinie")]
        [Description(@"Die Farbe der Horizontlinie.")]
        public virtual global::System.Windows.Media.Color LineColor
        {
            get { return _lineColor; }
            set
            {
                if (value.Equals(_lineColor))
                {
                    return;
                }
                _lineColor = value;
                this.OnLineColorChanged();
            }
        }
        
        #endregion
    }
    
    public partial class CloudParameter : INotifyPropertyChanged, IChangeTracking
    {
        public CloudParameter()
        {
            _width = DEF_WIDTH;
            _height = DEF_HEIGHT;
            _precision = DEF_PRECISION;
            _orderPriority = DEF_ORDERPRIORITY;
            _minOccurence = DEF_MINOCCURENCE;
            FontFamily = new global::System.Windows.Media.FontFamily();
            _fontBold = DEF_FONTBOLD;
            _fontItalic = DEF_FONTITALIC;
            _minFontSize = DEF_MINFONTSIZE;
            _maxFontSize = DEF_MAXFONTSIZE;
            this.Initialize();
            
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
        
        #region Property Width
        
        private int _width;
        
        public event EventHandler WidthChanged;
        
        protected virtual void OnWidthChanged()
        {
            this.IsChanged = true;
            EventHandler handler = WidthChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"Width");
        }
        
        private const int DEF_WIDTH = 640;
        
        [DefaultValue(DEF_WIDTH)]
        [DisplayName(@"Breite (px)")]
        [Description(@"Die Breite der Wortwolke in Pixel.")]
        public virtual int Width
        {
            get { return _width; }
            set
            {
                if ((value == _width))
                {
                    return;
                }
                _width = value;
                this.OnWidthChanged();
            }
        }
        
        #endregion
        
        #region Property Height
        
        private int _height;
        
        public event EventHandler HeightChanged;
        
        protected virtual void OnHeightChanged()
        {
            this.IsChanged = true;
            EventHandler handler = HeightChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"Height");
        }
        
        private const int DEF_HEIGHT = 480;
        
        [DefaultValue(DEF_HEIGHT)]
        [DisplayName(@"Höhe (px)")]
        [Description(@"Die Höhe der Wortwolke in Pixel.")]
        public virtual int Height
        {
            get { return _height; }
            set
            {
                if ((value == _height))
                {
                    return;
                }
                _height = value;
                this.OnHeightChanged();
            }
        }
        
        #endregion
        
        #region Property Precision
        
        private CloudPrecision _precision;
        
        public event EventHandler PrecisionChanged;
        
        protected virtual void OnPrecisionChanged()
        {
            this.IsChanged = true;
            EventHandler handler = PrecisionChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"Precision");
        }
        
        private const CloudPrecision DEF_PRECISION = CloudPrecision.Medium;
        
        [DefaultValue(DEF_PRECISION)]
        [DisplayName(@"Genauigkeit")]
        [Description(@"Die Genauigkeit ber der Wortwolkengenerierung. Eine hohe Genauigkeit erlaubt das engere Platzieren von Worten an- und ineinander, benötigt jedoch mehr Rechenzeit.")]
        public virtual CloudPrecision Precision
        {
            get { return _precision; }
            set
            {
                if ((value == _precision))
                {
                    return;
                }
                _precision = value;
                this.OnPrecisionChanged();
            }
        }
        
        #endregion
        
        #region Property OrderPriority
        
        private float _orderPriority;
        
        public event EventHandler OrderPriorityChanged;
        
        protected virtual void OnOrderPriorityChanged()
        {
            this.IsChanged = true;
            EventHandler handler = OrderPriorityChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"OrderPriority");
        }
        
        private const float DEF_ORDERPRIORITY = 0.6F;
        
        [DefaultValue(DEF_ORDERPRIORITY)]
        [DisplayName(@"Priorität der Sortierung")]
        [Description(@"Gibt an, wie wichtig die alphabetische sortierung der Worte ist. Ein Wert zwischen 0 und 1. Die 1 steht für sehr strenge Sortierung, die 0 für keine Sortierung.")]
        public virtual float OrderPriority
        {
            get { return _orderPriority; }
            set
            {
                if ((Math.Abs(value - _orderPriority) < float.Epsilon))
                {
                    return;
                }
                _orderPriority = value;
                this.OnOrderPriorityChanged();
            }
        }
        
        #endregion
        
        #region Property MinOccurence
        
        private int _minOccurence;
        
        public event EventHandler MinOccurenceChanged;
        
        protected virtual void OnMinOccurenceChanged()
        {
            this.IsChanged = true;
            EventHandler handler = MinOccurenceChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"MinOccurence");
        }
        
        private const int DEF_MINOCCURENCE = 1;
        
        [DefaultValue(DEF_MINOCCURENCE)]
        [DisplayName(@"Minimales Vorkommen")]
        [Description(@"Die Mindestanzahl für das Auftreten eines Wortes, damit es in der Wortwolke angezeigt wird.")]
        public virtual int MinOccurence
        {
            get { return _minOccurence; }
            set
            {
                if ((value == _minOccurence))
                {
                    return;
                }
                _minOccurence = value;
                this.OnMinOccurenceChanged();
            }
        }
        
        #endregion
        
        #region Property FontFamily
        
        [NonSerialized]
        private global::System.Windows.Media.FontFamily _fontFamily;
        
        public event EventHandler FontFamilyChanged;
        
        protected virtual void OnFontFamilyChanged()
        {
            this.IsChanged = true;
            EventHandler handler = FontFamilyChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"FontFamily");
        }
        
        [DisplayName(@"Schriftfamilie")]
        [Description(@"Der Name der Schriftfamilie für die Worte in der Wolke.")]
        [XmlIgnore]
        public virtual global::System.Windows.Media.FontFamily FontFamily
        {
            get { return _fontFamily; }
            set
            {
                if ((value == _fontFamily))
                {
                    return;
                }
                _fontFamily = value;
                this.OnFontFamilyChanged();
            }
        }
        
        #endregion
        
        #region Property FontBold
        
        private bool _fontBold;
        
        public event EventHandler FontBoldChanged;
        
        protected virtual void OnFontBoldChanged()
        {
            this.IsChanged = true;
            EventHandler handler = FontBoldChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"FontBold");
        }
        
        private const bool DEF_FONTBOLD = true;
        
        [DefaultValue(DEF_FONTBOLD)]
        [DisplayName(@"Schriftstärke (fett)")]
        [Description(@"Ein Wert der angibt, ob die Schrift fett gedruckt werden soll.")]
        public virtual bool FontBold
        {
            get { return _fontBold; }
            set
            {
                if ((value == _fontBold))
                {
                    return;
                }
                _fontBold = value;
                this.OnFontBoldChanged();
            }
        }
        
        #endregion
        
        #region Property FontItalic
        
        private bool _fontItalic;
        
        public event EventHandler FontItalicChanged;
        
        protected virtual void OnFontItalicChanged()
        {
            this.IsChanged = true;
            EventHandler handler = FontItalicChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"FontItalic");
        }
        
        private const bool DEF_FONTITALIC = false;
        
        [DefaultValue(DEF_FONTITALIC)]
        [DisplayName(@"Schriftschnitt (kursiv)")]
        [Description(@"Ein Wert der angibt, ob die Schrift kursiv gedruckt werden soll.")]
        public virtual bool FontItalic
        {
            get { return _fontItalic; }
            set
            {
                if ((value == _fontItalic))
                {
                    return;
                }
                _fontItalic = value;
                this.OnFontItalicChanged();
            }
        }
        
        #endregion
        
        #region Property MinFontSize
        
        private float _minFontSize;
        
        public event EventHandler MinFontSizeChanged;
        
        protected virtual void OnMinFontSizeChanged()
        {
            this.IsChanged = true;
            EventHandler handler = MinFontSizeChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"MinFontSize");
        }
        
        private const float DEF_MINFONTSIZE = 13.0F;
        
        [DefaultValue(DEF_MINFONTSIZE)]
        [DisplayName(@"Schriftgröße (minimal)")]
        [Description(@"Die kleinstmögliche Schriftgröße von Worten in der Wolke.")]
        public virtual float MinFontSize
        {
            get { return _minFontSize; }
            set
            {
                if ((Math.Abs(value - _minFontSize) < float.Epsilon))
                {
                    return;
                }
                _minFontSize = value;
                this.OnMinFontSizeChanged();
            }
        }
        
        #endregion
        
        #region Property MaxFontSize
        
        private float _maxFontSize;
        
        public event EventHandler MaxFontSizeChanged;
        
        protected virtual void OnMaxFontSizeChanged()
        {
            this.IsChanged = true;
            EventHandler handler = MaxFontSizeChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"MaxFontSize");
        }
        
        private const float DEF_MAXFONTSIZE = 80.0F;
        
        [DefaultValue(DEF_MAXFONTSIZE)]
        [DisplayName(@"Schriftgröße (maximal)")]
        [Description(@"Die größtmögliche Schriftgröße von Worten in der Wolke.")]
        public virtual float MaxFontSize
        {
            get { return _maxFontSize; }
            set
            {
                if ((Math.Abs(value - _maxFontSize) < float.Epsilon))
                {
                    return;
                }
                _maxFontSize = value;
                this.OnMaxFontSizeChanged();
            }
        }
        
        #endregion
        
        #region Property Color
        
        private global::System.Windows.Media.Color _color;
        
        public event EventHandler ColorChanged;
        
        protected virtual void OnColorChanged()
        {
            this.IsChanged = true;
            EventHandler handler = ColorChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"Color");
        }
        
        [DisplayName(@"Schriftfarbe")]
        [Description(@"Die Farbe der Worte in der Wortwolke.")]
        public virtual global::System.Windows.Media.Color Color
        {
            get { return _color; }
            set
            {
                if (value.Equals(_color))
                {
                    return;
                }
                _color = value;
                this.OnColorChanged();
            }
        }
        
        #endregion
        
        #region Property BackgroundColor
        
        private global::System.Windows.Media.Color _backgroundColor;
        
        public event EventHandler BackgroundColorChanged;
        
        protected virtual void OnBackgroundColorChanged()
        {
            this.IsChanged = true;
            EventHandler handler = BackgroundColorChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"BackgroundColor");
        }
        
        [DisplayName(@"Hintergrundfarbe")]
        [Description(@"Die Farbe des Hintergrundes.")]
        public virtual global::System.Windows.Media.Color BackgroundColor
        {
            get { return _backgroundColor; }
            set
            {
                if (value.Equals(_backgroundColor))
                {
                    return;
                }
                _backgroundColor = value;
                this.OnBackgroundColorChanged();
            }
        }
        
        #endregion
    }
    
    public partial class CategoryResource : INotifyPropertyChanged, IChangeTracking
    {
        public CategoryResource()
        {
            _type = DEF_TYPE;
            _url = DEF_URL;
            
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
        
        #region Property Type
        
        private CategoryResourceType _type;
        
        public event EventHandler TypeChanged;
        
        protected virtual void OnTypeChanged()
        {
            this.IsChanged = true;
            EventHandler handler = TypeChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"Type");
        }
        
        private const CategoryResourceType DEF_TYPE = CategoryResourceType.Plain;
        
        [DefaultValue(DEF_TYPE)]
        public virtual CategoryResourceType Type
        {
            get { return _type; }
            set
            {
                if ((value == _type))
                {
                    return;
                }
                _type = value;
                this.OnTypeChanged();
            }
        }
        
        #endregion
        
        #region Property Url
        
        private string _url;
        
        public event EventHandler UrlChanged;
        
        protected virtual void OnUrlChanged()
        {
            this.IsChanged = true;
            EventHandler handler = UrlChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"Url");
        }
        
        private const string DEF_URL = @"null";
        
        [DefaultValue(DEF_URL)]
        public virtual string Url
        {
            get { return _url; }
            set
            {
                if (string.Equals(value, _url))
                {
                    return;
                }
                _url = value;
                this.OnUrlChanged();
            }
        }
        
        #endregion
    }
    
    public partial class Category : INotifyPropertyChanged, IChangeTracking
    {
        public Category()
        {
            _id = DEF_ID;
            _name = DEF_NAME;
            Resources = new global::System.Collections.ObjectModel.ObservableCollection<CategoryResource>();
            
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
        
        #region Property Id
        
        private string _id;
        
        public event EventHandler IdChanged;
        
        protected virtual void OnIdChanged()
        {
            this.IsChanged = true;
            EventHandler handler = IdChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"Id");
        }
        
        private const string DEF_ID = @"_empty_";
        
        [DefaultValue(DEF_ID)]
        public virtual string Id
        {
            get { return _id; }
            set
            {
                if (string.Equals(value, _id))
                {
                    return;
                }
                _id = value;
                this.OnIdChanged();
            }
        }
        
        #endregion
        
        #region Property Name
        
        private string _name;
        
        public event EventHandler NameChanged;
        
        protected virtual void OnNameChanged()
        {
            this.IsChanged = true;
            EventHandler handler = NameChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"Name");
        }
        
        private const string DEF_NAME = @"No Name";
        
        [DefaultValue(DEF_NAME)]
        public virtual string Name
        {
            get { return _name; }
            set
            {
                if (string.Equals(value, _name))
                {
                    return;
                }
                _name = value;
                this.OnNameChanged();
            }
        }
        
        #endregion
        
        #region Property Resources
        
        private global::System.Collections.ObjectModel.ObservableCollection<CategoryResource> _resources;
        
        public event EventHandler ResourcesChanged;
        
        protected virtual void OnResourcesChanged()
        {
            this.IsChanged = true;
            EventHandler handler = ResourcesChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"Resources");
        }
        
        private void ResourcesItemPropertyChanged(object sender, EventArgs ea)
        {
            this.OnResourcesChanged();
        }
        
        private void ResourcesCollectionChangedHandler(object sender, global::System.Collections.Specialized.NotifyCollectionChangedEventArgs ea)
        {
            if (!ReferenceEquals(ea.OldItems, null))
            {
                foreach (CategoryResource item in ea.OldItems)
                {
                    if (!ReferenceEquals(item, null))
                    {
                        item.PropertyChanged -= this.ResourcesItemPropertyChanged;
                    }
                }
            }
            this.OnResourcesChanged();
            if (!ReferenceEquals(ea.NewItems, null))
            {
                foreach (CategoryResource item in ea.NewItems)
                {
                    if (!ReferenceEquals(item, null))
                    {
                        item.PropertyChanged += this.ResourcesItemPropertyChanged;
                    }
                }
            }
        }
        
        public virtual global::System.Collections.ObjectModel.ObservableCollection<CategoryResource> Resources
        {
            get { return _resources; }
            set
            {
                if ((value == _resources))
                {
                    return;
                }
                if (!ReferenceEquals(_resources, null))
                {
                    _resources.CollectionChanged -= this.ResourcesCollectionChangedHandler;
                }
                _resources = value;
                if (!ReferenceEquals(_resources, null))
                {
                    _resources.CollectionChanged += this.ResourcesCollectionChangedHandler;
                }
                this.OnResourcesChanged();
            }
        }
        
        #endregion
    }
    
    public partial class Media : INotifyPropertyChanged, IChangeTracking
    {
        public Media()
        {
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
        
        #region Property Id
        
        private string _id;
        
        public event EventHandler IdChanged;
        
        protected virtual void OnIdChanged()
        {
            this.IsChanged = true;
            EventHandler handler = IdChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"Id");
        }
        
        public virtual string Id
        {
            get { return _id; }
            set
            {
                if (string.Equals(value, _id))
                {
                    return;
                }
                _id = value;
                this.OnIdChanged();
            }
        }
        
        #endregion
        
        #region Property Name
        
        private string _name;
        
        public event EventHandler NameChanged;
        
        protected virtual void OnNameChanged()
        {
            this.IsChanged = true;
            EventHandler handler = NameChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"Name");
        }
        
        public virtual string Name
        {
            get { return _name; }
            set
            {
                if (string.Equals(value, _name))
                {
                    return;
                }
                _name = value;
                this.OnNameChanged();
            }
        }
        
        #endregion
        
        #region Property MediaFile
        
        private string _mediaFile;
        
        public event EventHandler MediaFileChanged;
        
        protected virtual void OnMediaFileChanged()
        {
            this.IsChanged = true;
            EventHandler handler = MediaFileChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"MediaFile");
        }
        
        public virtual string MediaFile
        {
            get { return _mediaFile; }
            set
            {
                if (string.Equals(value, _mediaFile))
                {
                    return;
                }
                _mediaFile = value;
                this.OnMediaFileChanged();
            }
        }
        
        #endregion
        
        #region Property AudioFile
        
        [NonSerialized]
        private string _audioFile;
        
        public event EventHandler AudioFileChanged;
        
        protected virtual void OnAudioFileChanged()
        {
            this.IsChanged = true;
            EventHandler handler = AudioFileChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"AudioFile");
        }
        
        [XmlIgnore]
        public virtual string AudioFile
        {
            get { return _audioFile; }
            set
            {
                if (string.Equals(value, _audioFile))
                {
                    return;
                }
                _audioFile = value;
                this.OnAudioFileChanged();
            }
        }
        
        #endregion
        
        #region Property Duration
        
        [NonSerialized]
        private double _duration;
        
        public event EventHandler DurationChanged;
        
        protected virtual void OnDurationChanged()
        {
            this.IsChanged = true;
            EventHandler handler = DurationChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"Duration");
        }
        
        [XmlIgnore]
        public virtual double Duration
        {
            get { return _duration; }
            set
            {
                if ((Math.Abs(value - _duration) < double.Epsilon))
                {
                    return;
                }
                _duration = value;
                this.OnDurationChanged();
            }
        }
        
        #endregion
        
        #region Property WaveformFile
        
        [NonSerialized]
        private string _waveformFile;
        
        public event EventHandler WaveformFileChanged;
        
        protected virtual void OnWaveformFileChanged()
        {
            this.IsChanged = true;
            EventHandler handler = WaveformFileChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"WaveformFile");
        }
        
        [XmlIgnore]
        public virtual string WaveformFile
        {
            get { return _waveformFile; }
            set
            {
                if (string.Equals(value, _waveformFile))
                {
                    return;
                }
                _waveformFile = value;
                this.OnWaveformFileChanged();
            }
        }
        
        #endregion
        
        #region Property RecognitionProfile
        
        [NonSerialized]
        private Guid _recognitionProfile;
        
        public event EventHandler RecognitionProfileChanged;
        
        protected virtual void OnRecognitionProfileChanged()
        {
            this.IsChanged = true;
            EventHandler handler = RecognitionProfileChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"RecognitionProfile");
        }
        
        [XmlIgnore]
        public virtual Guid RecognitionProfile
        {
            get { return _recognitionProfile; }
            set
            {
                if (value.Equals(_recognitionProfile))
                {
                    return;
                }
                _recognitionProfile = value;
                this.OnRecognitionProfileChanged();
            }
        }
        
        #endregion
        
        #region Property RecognitionProfileName
        
        [NonSerialized]
        private string _recognitionProfileName;
        
        public event EventHandler RecognitionProfileNameChanged;
        
        protected virtual void OnRecognitionProfileNameChanged()
        {
            this.IsChanged = true;
            EventHandler handler = RecognitionProfileNameChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"RecognitionProfileName");
        }
        
        [XmlIgnore]
        public virtual string RecognitionProfileName
        {
            get { return _recognitionProfileName; }
            set
            {
                if (string.Equals(value, _recognitionProfileName))
                {
                    return;
                }
                _recognitionProfileName = value;
                this.OnRecognitionProfileNameChanged();
            }
        }
        
        #endregion
        
        #region Property ResultsFile
        
        [NonSerialized]
        private string _resultsFile;
        
        public event EventHandler ResultsFileChanged;
        
        protected virtual void OnResultsFileChanged()
        {
            this.IsChanged = true;
            EventHandler handler = ResultsFileChanged;
            if (!ReferenceEquals(handler, null))
            {
                handler(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"ResultsFile");
        }
        
        [XmlIgnore]
        public virtual string ResultsFile
        {
            get { return _resultsFile; }
            set
            {
                if (string.Equals(value, _resultsFile))
                {
                    return;
                }
                _resultsFile = value;
                this.OnResultsFileChanged();
            }
        }
        
        #endregion
    }
    
    #endregion
}