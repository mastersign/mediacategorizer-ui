using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace de.fhb.oll.mediacategorizer.model
{
    #region Scaleton Model Designer generated code
    
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
    
    public partial class Project : IEquatable<Project>, INotifyPropertyChanged, IChangeTracking
    {
        public Project()
        {
            _name = DEF_NAME;
            _description = DEF_DESCRIPTION;
            _outputDir = DEF_OUTPUTDIR;
            Configuration = new Configuration();
            Categories = new global::System.Collections.ObjectModel.ObservableCollection<Category>();
            Media = new global::System.Collections.ObjectModel.ObservableCollection<Media>();
            this.Initialize();
            
            this.IsChanged = false;
        }
        
        #region Equatability
        
        public bool Equals(Project o)
        {
            if (ReferenceEquals(o, null))
            {
                return false;
            }
            return (
                object.Equals(this._name, o._name) && 
                object.Equals(this._description, o._description) && 
                object.Equals(this._outputDir, o._outputDir) && 
                object.Equals(this._configuration, o._configuration) && 
                object.Equals(this._categories, o._categories) && 
                object.Equals(this._media, o._media));
        }
        
        public override bool Equals(object o)
        {
            if (ReferenceEquals(o, null))
            {
                return false;
            }
            if ((!(o.GetType() == typeof(Project))))
            {
                return false;
            }
            return this.Equals(((Project)o));
        }
        
        public override int GetHashCode()
        {
            return (this.GetType().GetHashCode() ^ 
                ((!ReferenceEquals(this._name, null)) ? this._name.GetHashCode() : 0) ^ 
                ((!ReferenceEquals(this._description, null)) ? this._description.GetHashCode() : 0) ^ 
                ((!ReferenceEquals(this._outputDir, null)) ? this._outputDir.GetHashCode() : 0) ^ 
                ((!ReferenceEquals(this._configuration, null)) ? this._configuration.GetHashCode() : 0) ^ 
                ((!ReferenceEquals(this._categories, null)) ? this._categories.GetHashCode() : 0) ^ 
                ((!ReferenceEquals(this._media, null)) ? this._media.GetHashCode() : 0));
        }
        
        #endregion
        
        #region Change Tracking
        
        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged(string name)
        {
            if ((!ReferenceEquals(PropertyChanged, null)))
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
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
            if ((!ReferenceEquals(_configuration, null)))
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
            if ((!ReferenceEquals(NameChanged, null)))
            {
                NameChanged(this, EventArgs.Empty);
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
            if ((!ReferenceEquals(DescriptionChanged, null)))
            {
                DescriptionChanged(this, EventArgs.Empty);
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
            if ((!ReferenceEquals(OutputDirChanged, null)))
            {
                OutputDirChanged(this, EventArgs.Empty);
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
        
        #region Property Configuration
        
        private Configuration _configuration;
        
        public event EventHandler ConfigurationChanged;
        
        protected virtual void OnConfigurationChanged()
        {
            this.IsChanged = true;
            if ((!ReferenceEquals(ConfigurationChanged, null)))
            {
                ConfigurationChanged(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"Configuration");
        }
        
        private void ConfigurationPropertyChangedHandler(object sender, PropertyChangedEventArgs ea)
        {
            this.OnConfigurationChanged();
        }
        
        [global::Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObjectAttribute]
        public virtual Configuration Configuration
        {
            get { return _configuration; }
            set
            {
                if ((value == _configuration))
                {
                    return;
                }
                if ((!ReferenceEquals(_configuration, null)))
                {
                    _configuration.PropertyChanged -= this.ConfigurationPropertyChangedHandler;
                }
                _configuration = value;
                if ((!ReferenceEquals(_configuration, null)))
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
            if ((!ReferenceEquals(CategoriesChanged, null)))
            {
                CategoriesChanged(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"Categories");
        }
        
        private void CategoriesItemPropertyChanged(object sender, EventArgs ea)
        {
            this.OnCategoriesChanged();
        }
        
        private void CategoriesCollectionChangedHandler(object sender, global::System.Collections.Specialized.NotifyCollectionChangedEventArgs ea)
        {
            if ((!ReferenceEquals(ea.OldItems, null)))
            {
                foreach (Category item in ea.OldItems)
                {
                    if ((!ReferenceEquals(item, null)))
                    {
                        item.PropertyChanged -= this.CategoriesItemPropertyChanged;
                    }
                }
            }
            this.OnCategoriesChanged();
            if ((!ReferenceEquals(ea.NewItems, null)))
            {
                foreach (Category item in ea.NewItems)
                {
                    if ((!ReferenceEquals(item, null)))
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
                if ((!ReferenceEquals(_categories, null)))
                {
                    _categories.CollectionChanged -= this.CategoriesCollectionChangedHandler;
                }
                _categories = value;
                if ((!ReferenceEquals(_categories, null)))
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
            if ((!ReferenceEquals(MediaChanged, null)))
            {
                MediaChanged(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"Media");
        }
        
        private void MediaItemPropertyChanged(object sender, EventArgs ea)
        {
            this.OnMediaChanged();
        }
        
        private void MediaCollectionChangedHandler(object sender, global::System.Collections.Specialized.NotifyCollectionChangedEventArgs ea)
        {
            if ((!ReferenceEquals(ea.OldItems, null)))
            {
                foreach (Media item in ea.OldItems)
                {
                    if ((!ReferenceEquals(item, null)))
                    {
                        item.PropertyChanged -= this.MediaItemPropertyChanged;
                    }
                }
            }
            this.OnMediaChanged();
            if ((!ReferenceEquals(ea.NewItems, null)))
            {
                foreach (Media item in ea.NewItems)
                {
                    if ((!ReferenceEquals(item, null)))
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
                if ((!ReferenceEquals(_media, null)))
                {
                    _media.CollectionChanged -= this.MediaCollectionChangedHandler;
                }
                _media = value;
                if ((!ReferenceEquals(_media, null)))
                {
                    _media.CollectionChanged += this.MediaCollectionChangedHandler;
                }
                this.OnMediaChanged();
            }
        }
        
        #endregion
    }
    
    public partial class Configuration : IEquatable<Configuration>, INotifyPropertyChanged, IChangeTracking
    {
        public Configuration()
        {
            _minConfidence = DEF_MINCONFIDENCE;
            _goodConfidence = DEF_GOODCONFIDENCE;
            _minRelativeAppearance = DEF_MINRELATIVEAPPEARANCE;
            _minMatchScore = DEF_MINMATCHSCORE;
            IndexFilter = new FilterParameter();
            MainCloud = new CloudParameter();
            MediaCloud = new CloudParameter();
            CategoryCloud = new CloudParameter();
            _parallelProc = DEF_PARALLELPROC;
            _skipWordClouds = DEF_SKIPWORDCLOUDS;
            _skipWordIncludes = DEF_SKIPWORDINCLUDES;
            _skipMatchIncludes = DEF_SKIPMATCHINCLUDES;
            _skipMediaCopy = DEF_SKIPMEDIACOPY;
            
            this.IsChanged = false;
        }
        
        #region Equatability
        
        public bool Equals(Configuration o)
        {
            if (ReferenceEquals(o, null))
            {
                return false;
            }
            return (
                (this._minConfidence == o._minConfidence) && 
                (this._goodConfidence == o._goodConfidence) && 
                (this._minRelativeAppearance == o._minRelativeAppearance) && 
                (this._minMatchScore == o._minMatchScore) && 
                object.Equals(this._indexFilter, o._indexFilter) && 
                object.Equals(this._mainCloud, o._mainCloud) && 
                object.Equals(this._mediaCloud, o._mediaCloud) && 
                object.Equals(this._categoryCloud, o._categoryCloud) && 
                this._parallelProc.Equals(o._parallelProc) && 
                this._skipWordClouds.Equals(o._skipWordClouds) && 
                this._skipWordIncludes.Equals(o._skipWordIncludes) && 
                this._skipMatchIncludes.Equals(o._skipMatchIncludes) && 
                this._skipMediaCopy.Equals(o._skipMediaCopy));
        }
        
        public override bool Equals(object o)
        {
            if (ReferenceEquals(o, null))
            {
                return false;
            }
            if ((!(o.GetType() == typeof(Configuration))))
            {
                return false;
            }
            return this.Equals(((Configuration)o));
        }
        
        public override int GetHashCode()
        {
            return (this.GetType().GetHashCode() ^ 
                this._minConfidence.GetHashCode() ^ 
                this._goodConfidence.GetHashCode() ^ 
                this._minRelativeAppearance.GetHashCode() ^ 
                this._minMatchScore.GetHashCode() ^ 
                ((!ReferenceEquals(this._indexFilter, null)) ? this._indexFilter.GetHashCode() : 0) ^ 
                ((!ReferenceEquals(this._mainCloud, null)) ? this._mainCloud.GetHashCode() : 0) ^ 
                ((!ReferenceEquals(this._mediaCloud, null)) ? this._mediaCloud.GetHashCode() : 0) ^ 
                ((!ReferenceEquals(this._categoryCloud, null)) ? this._categoryCloud.GetHashCode() : 0) ^ 
                this._parallelProc.GetHashCode() ^ 
                this._skipWordClouds.GetHashCode() ^ 
                this._skipWordIncludes.GetHashCode() ^ 
                this._skipMatchIncludes.GetHashCode() ^ 
                this._skipMediaCopy.GetHashCode());
        }
        
        #endregion
        
        #region Change Tracking
        
        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged(string name)
        {
            if ((!ReferenceEquals(PropertyChanged, null)))
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
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
            if ((!ReferenceEquals(_indexFilter, null)))
            {
                _indexFilter.AcceptChanges();
            }
            if ((!ReferenceEquals(_mainCloud, null)))
            {
                _mainCloud.AcceptChanges();
            }
            if ((!ReferenceEquals(_mediaCloud, null)))
            {
                _mediaCloud.AcceptChanges();
            }
            if ((!ReferenceEquals(_categoryCloud, null)))
            {
                _categoryCloud.AcceptChanges();
            }
            this.IsChanged = false;
        }
        
        #endregion
        
        #region Property MinConfidence
        
        private float _minConfidence;
        
        public event EventHandler MinConfidenceChanged;
        
        protected virtual void OnMinConfidenceChanged()
        {
            this.IsChanged = true;
            if ((!ReferenceEquals(MinConfidenceChanged, null)))
            {
                MinConfidenceChanged(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"MinConfidence");
        }
        
        private const float DEF_MINCONFIDENCE = 0.4F;
        
        [DefaultValue(DEF_MINCONFIDENCE)]
        [Category(@"Analyse")]
        [DisplayName(@"Minimale Erkennungssicherheit")]
        [Description(@"Die minimale Erkennungssicherheit für Worte die in die Analyse berücksichtigt werden sollen.")]
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
            if ((!ReferenceEquals(GoodConfidenceChanged, null)))
            {
                GoodConfidenceChanged(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"GoodConfidence");
        }
        
        private const float DEF_GOODCONFIDENCE = 0.7F;
        
        [DefaultValue(DEF_GOODCONFIDENCE)]
        [Category(@"Analyse")]
        [DisplayName(@"Gute Erkennungssicherheit")]
        [Description(@"Die Erkennungssicherheit für Worte die in der Ausgabe erscheinen dürfen.")]
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
        
        #region Property MinRelativeAppearance
        
        private float _minRelativeAppearance;
        
        public event EventHandler MinRelativeAppearanceChanged;
        
        protected virtual void OnMinRelativeAppearanceChanged()
        {
            this.IsChanged = true;
            if ((!ReferenceEquals(MinRelativeAppearanceChanged, null)))
            {
                MinRelativeAppearanceChanged(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"MinRelativeAppearance");
        }
        
        private const float DEF_MINRELATIVEAPPEARANCE = 0.25F;
        
        [DefaultValue(DEF_MINRELATIVEAPPEARANCE)]
        [Category(@"Analyse")]
        [DisplayName(@"Minimales Erscheinen")]
        public virtual float MinRelativeAppearance
        {
            get { return _minRelativeAppearance; }
            set
            {
                if ((Math.Abs(value - _minRelativeAppearance) < float.Epsilon))
                {
                    return;
                }
                _minRelativeAppearance = value;
                this.OnMinRelativeAppearanceChanged();
            }
        }
        
        #endregion
        
        #region Property MinMatchScore
        
        private float _minMatchScore;
        
        public event EventHandler MinMatchScoreChanged;
        
        protected virtual void OnMinMatchScoreChanged()
        {
            this.IsChanged = true;
            if ((!ReferenceEquals(MinMatchScoreChanged, null)))
            {
                MinMatchScoreChanged(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"MinMatchScore");
        }
        
        private const float DEF_MINMATCHSCORE = 0.0F;
        
        [DefaultValue(DEF_MINMATCHSCORE)]
        [Category(@"Analyse")]
        [DisplayName(@"Minimale Übereinstimmung")]
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
            if ((!ReferenceEquals(IndexFilterChanged, null)))
            {
                IndexFilterChanged(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"IndexFilter");
        }
        
        private void IndexFilterPropertyChangedHandler(object sender, PropertyChangedEventArgs ea)
        {
            this.OnIndexFilterChanged();
        }
        
        [global::Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObjectAttribute]
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
                if ((!ReferenceEquals(_indexFilter, null)))
                {
                    _indexFilter.PropertyChanged -= this.IndexFilterPropertyChangedHandler;
                }
                _indexFilter = value;
                if ((!ReferenceEquals(_indexFilter, null)))
                {
                    _indexFilter.PropertyChanged += this.IndexFilterPropertyChangedHandler;
                }
                this.OnIndexFilterChanged();
            }
        }
        
        #endregion
        
        #region Property MainCloud
        
        private CloudParameter _mainCloud;
        
        public event EventHandler MainCloudChanged;
        
        protected virtual void OnMainCloudChanged()
        {
            this.IsChanged = true;
            if ((!ReferenceEquals(MainCloudChanged, null)))
            {
                MainCloudChanged(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"MainCloud");
        }
        
        private void MainCloudPropertyChangedHandler(object sender, PropertyChangedEventArgs ea)
        {
            this.OnMainCloudChanged();
        }
        
        [global::Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObjectAttribute]
        [Category(@"Wortwolken")]
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
                if ((!ReferenceEquals(_mainCloud, null)))
                {
                    _mainCloud.PropertyChanged -= this.MainCloudPropertyChangedHandler;
                }
                _mainCloud = value;
                if ((!ReferenceEquals(_mainCloud, null)))
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
            if ((!ReferenceEquals(MediaCloudChanged, null)))
            {
                MediaCloudChanged(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"MediaCloud");
        }
        
        private void MediaCloudPropertyChangedHandler(object sender, PropertyChangedEventArgs ea)
        {
            this.OnMediaCloudChanged();
        }
        
        [global::Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObjectAttribute]
        [Category(@"Wortwolken")]
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
                if ((!ReferenceEquals(_mediaCloud, null)))
                {
                    _mediaCloud.PropertyChanged -= this.MediaCloudPropertyChangedHandler;
                }
                _mediaCloud = value;
                if ((!ReferenceEquals(_mediaCloud, null)))
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
            if ((!ReferenceEquals(CategoryCloudChanged, null)))
            {
                CategoryCloudChanged(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"CategoryCloud");
        }
        
        private void CategoryCloudPropertyChangedHandler(object sender, PropertyChangedEventArgs ea)
        {
            this.OnCategoryCloudChanged();
        }
        
        [global::Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObjectAttribute]
        [Category(@"Wortwolken")]
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
                if ((!ReferenceEquals(_categoryCloud, null)))
                {
                    _categoryCloud.PropertyChanged -= this.CategoryCloudPropertyChangedHandler;
                }
                _categoryCloud = value;
                if ((!ReferenceEquals(_categoryCloud, null)))
                {
                    _categoryCloud.PropertyChanged += this.CategoryCloudPropertyChangedHandler;
                }
                this.OnCategoryCloudChanged();
            }
        }
        
        #endregion
        
        #region Property ParallelProc
        
        private bool _parallelProc;
        
        public event EventHandler ParallelProcChanged;
        
        protected virtual void OnParallelProcChanged()
        {
            this.IsChanged = true;
            if ((!ReferenceEquals(ParallelProcChanged, null)))
            {
                ParallelProcChanged(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"ParallelProc");
        }
        
        private const bool DEF_PARALLELPROC = true;
        
        [DefaultValue(DEF_PARALLELPROC)]
        [Category(@"Verarbeitung")]
        [DisplayName(@"Mehrprozessorunterstützung")]
        public virtual bool ParallelProc
        {
            get { return _parallelProc; }
            set
            {
                if ((value == _parallelProc))
                {
                    return;
                }
                _parallelProc = value;
                this.OnParallelProcChanged();
            }
        }
        
        #endregion
        
        #region Property SkipWordClouds
        
        private bool _skipWordClouds;
        
        public event EventHandler SkipWordCloudsChanged;
        
        protected virtual void OnSkipWordCloudsChanged()
        {
            this.IsChanged = true;
            if ((!ReferenceEquals(SkipWordCloudsChanged, null)))
            {
                SkipWordCloudsChanged(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"SkipWordClouds");
        }
        
        private const bool DEF_SKIPWORDCLOUDS = false;
        
        [DefaultValue(DEF_SKIPWORDCLOUDS)]
        [Category(@"Ausgabe")]
        [DisplayName(@"Keine Wortwolken")]
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
            if ((!ReferenceEquals(SkipWordIncludesChanged, null)))
            {
                SkipWordIncludesChanged(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"SkipWordIncludes");
        }
        
        private const bool DEF_SKIPWORDINCLUDES = false;
        
        [DefaultValue(DEF_SKIPWORDINCLUDES)]
        [Category(@"Ausgabe")]
        [DisplayName(@"Keine Wortseiten")]
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
            if ((!ReferenceEquals(SkipMatchIncludesChanged, null)))
            {
                SkipMatchIncludesChanged(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"SkipMatchIncludes");
        }
        
        private const bool DEF_SKIPMATCHINCLUDES = false;
        
        [DefaultValue(DEF_SKIPMATCHINCLUDES)]
        [Category(@"Ausgabe")]
        [DisplayName(@"Keine Übereinstimmungsdetails")]
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
            if ((!ReferenceEquals(SkipMediaCopyChanged, null)))
            {
                SkipMediaCopyChanged(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"SkipMediaCopy");
        }
        
        private const bool DEF_SKIPMEDIACOPY = false;
        
        [DefaultValue(DEF_SKIPMEDIACOPY)]
        [Category(@"Ausgabe")]
        [DisplayName(@"Mediendateien nicht kopieren")]
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
    
    public partial class FilterParameter : IEquatable<FilterParameter>, INotifyPropertyChanged, IChangeTracking
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
        
        #region Equatability
        
        public bool Equals(FilterParameter o)
        {
            if (ReferenceEquals(o, null))
            {
                return false;
            }
            return (
                object.Equals(this._blacklistResource, o._blacklistResource) && 
                (this._blacklistMaxSize == o._blacklistMaxSize) && 
                this._filterNotShort.Equals(o._filterNotShort) && 
                this._filterNoun.Equals(o._filterNoun) && 
                this._filterMinConfidence.Equals(o._filterMinConfidence) && 
                this._filterGoodConfidence.Equals(o._filterGoodConfidence) && 
                this._filterNoPunctuation.Equals(o._filterNoPunctuation) && 
                this._filterNotInBlacklist.Equals(o._filterNotInBlacklist));
        }
        
        public override bool Equals(object o)
        {
            if (ReferenceEquals(o, null))
            {
                return false;
            }
            if ((!(o.GetType() == typeof(FilterParameter))))
            {
                return false;
            }
            return this.Equals(((FilterParameter)o));
        }
        
        public override int GetHashCode()
        {
            return (this.GetType().GetHashCode() ^ 
                ((!ReferenceEquals(this._blacklistResource, null)) ? this._blacklistResource.GetHashCode() : 0) ^ 
                this._blacklistMaxSize.GetHashCode() ^ 
                this._filterNotShort.GetHashCode() ^ 
                this._filterNoun.GetHashCode() ^ 
                this._filterMinConfidence.GetHashCode() ^ 
                this._filterGoodConfidence.GetHashCode() ^ 
                this._filterNoPunctuation.GetHashCode() ^ 
                this._filterNotInBlacklist.GetHashCode());
        }
        
        #endregion
        
        #region Change Tracking
        
        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged(string name)
        {
            if ((!ReferenceEquals(PropertyChanged, null)))
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
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
        
        #region Property BlacklistResource
        
        private string _blacklistResource;
        
        public event EventHandler BlacklistResourceChanged;
        
        protected virtual void OnBlacklistResourceChanged()
        {
            this.IsChanged = true;
            if ((!ReferenceEquals(BlacklistResourceChanged, null)))
            {
                BlacklistResourceChanged(this, EventArgs.Empty);
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
            if ((!ReferenceEquals(BlacklistMaxSizeChanged, null)))
            {
                BlacklistMaxSizeChanged(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"BlacklistMaxSize");
        }
        
        private const int DEF_BLACKLISTMAXSIZE = 2000;
        
        [DefaultValue(DEF_BLACKLISTMAXSIZE)]
        [DisplayName(@"Blacklist-Worte")]
        [Description(@"Gibt die Anzahl der Worte an, die vom Anfang der Blacklist für das Filtern verwendet werden. Es wird eine nach Relevanz sortierte Blacklist vorausgesetzt.")]
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
            if ((!ReferenceEquals(FilterNotShortChanged, null)))
            {
                FilterNotShortChanged(this, EventArgs.Empty);
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
            if ((!ReferenceEquals(FilterNounChanged, null)))
            {
                FilterNounChanged(this, EventArgs.Empty);
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
            if ((!ReferenceEquals(FilterMinConfidenceChanged, null)))
            {
                FilterMinConfidenceChanged(this, EventArgs.Empty);
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
            if ((!ReferenceEquals(FilterGoodConfidenceChanged, null)))
            {
                FilterGoodConfidenceChanged(this, EventArgs.Empty);
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
            if ((!ReferenceEquals(FilterNoPunctuationChanged, null)))
            {
                FilterNoPunctuationChanged(this, EventArgs.Empty);
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
            if ((!ReferenceEquals(FilterNotInBlacklistChanged, null)))
            {
                FilterNotInBlacklistChanged(this, EventArgs.Empty);
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
    
    public partial class CloudParameter : IEquatable<CloudParameter>, INotifyPropertyChanged, IChangeTracking
    {
        public CloudParameter()
        {
            _width = DEF_WIDTH;
            _height = DEF_HEIGHT;
            _precision = DEF_PRECISION;
            _orderPriority = DEF_ORDERPRIORITY;
            FontFamily = new global::System.Windows.Media.FontFamily();
            _fontBold = DEF_FONTBOLD;
            _fontItalic = DEF_FONTITALIC;
            _minFontSize = DEF_MINFONTSIZE;
            _maxFontSize = DEF_MAXFONTSIZE;
            this.Initialize();
            
            this.IsChanged = false;
        }
        
        #region Equatability
        
        public bool Equals(CloudParameter o)
        {
            if (ReferenceEquals(o, null))
            {
                return false;
            }
            return (
                (this._width == o._width) && 
                (this._height == o._height) && 
                (this._precision == o._precision) && 
                (this._orderPriority == o._orderPriority) && 
                object.Equals(this._fontFamily, o._fontFamily) && 
                this._fontBold.Equals(o._fontBold) && 
                this._fontItalic.Equals(o._fontItalic) && 
                (this._minFontSize == o._minFontSize) && 
                (this._maxFontSize == o._maxFontSize) && 
                this._color.Equals(o._color) && 
                this._backgroundColor.Equals(o._backgroundColor));
        }
        
        public override bool Equals(object o)
        {
            if (ReferenceEquals(o, null))
            {
                return false;
            }
            if ((!(o.GetType() == typeof(CloudParameter))))
            {
                return false;
            }
            return this.Equals(((CloudParameter)o));
        }
        
        public override int GetHashCode()
        {
            return (this.GetType().GetHashCode() ^ 
                this._width.GetHashCode() ^ 
                this._height.GetHashCode() ^ 
                this._precision.GetHashCode() ^ 
                this._orderPriority.GetHashCode() ^ 
                ((!ReferenceEquals(this._fontFamily, null)) ? this._fontFamily.GetHashCode() : 0) ^ 
                this._fontBold.GetHashCode() ^ 
                this._fontItalic.GetHashCode() ^ 
                this._minFontSize.GetHashCode() ^ 
                this._maxFontSize.GetHashCode() ^ 
                this._color.GetHashCode() ^ 
                this._backgroundColor.GetHashCode());
        }
        
        #endregion
        
        #region Change Tracking
        
        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged(string name)
        {
            if ((!ReferenceEquals(PropertyChanged, null)))
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
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
        
        #region Property Width
        
        private int _width;
        
        public event EventHandler WidthChanged;
        
        protected virtual void OnWidthChanged()
        {
            this.IsChanged = true;
            if ((!ReferenceEquals(WidthChanged, null)))
            {
                WidthChanged(this, EventArgs.Empty);
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
            if ((!ReferenceEquals(HeightChanged, null)))
            {
                HeightChanged(this, EventArgs.Empty);
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
            if ((!ReferenceEquals(PrecisionChanged, null)))
            {
                PrecisionChanged(this, EventArgs.Empty);
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
            if ((!ReferenceEquals(OrderPriorityChanged, null)))
            {
                OrderPriorityChanged(this, EventArgs.Empty);
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
        
        #region Property FontFamily
        
        private global::System.Windows.Media.FontFamily _fontFamily;
        
        public event EventHandler FontFamilyChanged;
        
        protected virtual void OnFontFamilyChanged()
        {
            this.IsChanged = true;
            if ((!ReferenceEquals(FontFamilyChanged, null)))
            {
                FontFamilyChanged(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"FontFamily");
        }
        
        [DisplayName(@"Schriftfamilie")]
        [Description(@"Der Name der Schriftfamilie für die Worte in der Wolke.")]
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
            if ((!ReferenceEquals(FontBoldChanged, null)))
            {
                FontBoldChanged(this, EventArgs.Empty);
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
            if ((!ReferenceEquals(FontItalicChanged, null)))
            {
                FontItalicChanged(this, EventArgs.Empty);
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
            if ((!ReferenceEquals(MinFontSizeChanged, null)))
            {
                MinFontSizeChanged(this, EventArgs.Empty);
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
            if ((!ReferenceEquals(MaxFontSizeChanged, null)))
            {
                MaxFontSizeChanged(this, EventArgs.Empty);
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
            if ((!ReferenceEquals(ColorChanged, null)))
            {
                ColorChanged(this, EventArgs.Empty);
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
            if ((!ReferenceEquals(BackgroundColorChanged, null)))
            {
                BackgroundColorChanged(this, EventArgs.Empty);
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
    
    public partial class CategoryResource : IEquatable<CategoryResource>, INotifyPropertyChanged, IChangeTracking
    {
        public CategoryResource()
        {
            _type = DEF_TYPE;
            _url = DEF_URL;
            
            this.IsChanged = false;
        }
        
        #region Equatability
        
        public bool Equals(CategoryResource o)
        {
            if (ReferenceEquals(o, null))
            {
                return false;
            }
            return (
                (this._type == o._type) && 
                object.Equals(this._url, o._url));
        }
        
        public override bool Equals(object o)
        {
            if (ReferenceEquals(o, null))
            {
                return false;
            }
            if ((!(o.GetType() == typeof(CategoryResource))))
            {
                return false;
            }
            return this.Equals(((CategoryResource)o));
        }
        
        public override int GetHashCode()
        {
            return (this.GetType().GetHashCode() ^ 
                this._type.GetHashCode() ^ 
                ((!ReferenceEquals(this._url, null)) ? this._url.GetHashCode() : 0));
        }
        
        #endregion
        
        #region Change Tracking
        
        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged(string name)
        {
            if ((!ReferenceEquals(PropertyChanged, null)))
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
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
        
        #region Property Type
        
        private CategoryResourceType _type;
        
        public event EventHandler TypeChanged;
        
        protected virtual void OnTypeChanged()
        {
            this.IsChanged = true;
            if ((!ReferenceEquals(TypeChanged, null)))
            {
                TypeChanged(this, EventArgs.Empty);
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
            if ((!ReferenceEquals(UrlChanged, null)))
            {
                UrlChanged(this, EventArgs.Empty);
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
    
    public partial class Category : IEquatable<Category>, INotifyPropertyChanged, IChangeTracking
    {
        public Category()
        {
            _id = DEF_ID;
            _name = DEF_NAME;
            Resources = new global::System.Collections.ObjectModel.ObservableCollection<CategoryResource>();
            
            this.IsChanged = false;
        }
        
        #region Equatability
        
        public bool Equals(Category o)
        {
            if (ReferenceEquals(o, null))
            {
                return false;
            }
            return (
                object.Equals(this._id, o._id) && 
                object.Equals(this._name, o._name) && 
                object.Equals(this._resources, o._resources));
        }
        
        public override bool Equals(object o)
        {
            if (ReferenceEquals(o, null))
            {
                return false;
            }
            if ((!(o.GetType() == typeof(Category))))
            {
                return false;
            }
            return this.Equals(((Category)o));
        }
        
        public override int GetHashCode()
        {
            return (this.GetType().GetHashCode() ^ 
                ((!ReferenceEquals(this._id, null)) ? this._id.GetHashCode() : 0) ^ 
                ((!ReferenceEquals(this._name, null)) ? this._name.GetHashCode() : 0) ^ 
                ((!ReferenceEquals(this._resources, null)) ? this._resources.GetHashCode() : 0));
        }
        
        #endregion
        
        #region Change Tracking
        
        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged(string name)
        {
            if ((!ReferenceEquals(PropertyChanged, null)))
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
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
        
        #region Property Id
        
        private string _id;
        
        public event EventHandler IdChanged;
        
        protected virtual void OnIdChanged()
        {
            this.IsChanged = true;
            if ((!ReferenceEquals(IdChanged, null)))
            {
                IdChanged(this, EventArgs.Empty);
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
            if ((!ReferenceEquals(NameChanged, null)))
            {
                NameChanged(this, EventArgs.Empty);
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
            if ((!ReferenceEquals(ResourcesChanged, null)))
            {
                ResourcesChanged(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"Resources");
        }
        
        private void ResourcesItemPropertyChanged(object sender, EventArgs ea)
        {
            this.OnResourcesChanged();
        }
        
        private void ResourcesCollectionChangedHandler(object sender, global::System.Collections.Specialized.NotifyCollectionChangedEventArgs ea)
        {
            if ((!ReferenceEquals(ea.OldItems, null)))
            {
                foreach (CategoryResource item in ea.OldItems)
                {
                    if ((!ReferenceEquals(item, null)))
                    {
                        item.PropertyChanged -= this.ResourcesItemPropertyChanged;
                    }
                }
            }
            this.OnResourcesChanged();
            if ((!ReferenceEquals(ea.NewItems, null)))
            {
                foreach (CategoryResource item in ea.NewItems)
                {
                    if ((!ReferenceEquals(item, null)))
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
                if ((!ReferenceEquals(_resources, null)))
                {
                    _resources.CollectionChanged -= this.ResourcesCollectionChangedHandler;
                }
                _resources = value;
                if ((!ReferenceEquals(_resources, null)))
                {
                    _resources.CollectionChanged += this.ResourcesCollectionChangedHandler;
                }
                this.OnResourcesChanged();
            }
        }
        
        #endregion
    }
    
    public partial class Media : IEquatable<Media>, INotifyPropertyChanged, IChangeTracking
    {
        public Media()
        {
            this.IsChanged = false;
        }
        
        #region Equatability
        
        public bool Equals(Media o)
        {
            if (ReferenceEquals(o, null))
            {
                return false;
            }
            return (
                object.Equals(this._id, o._id));
        }
        
        public override bool Equals(object o)
        {
            if (ReferenceEquals(o, null))
            {
                return false;
            }
            if ((!(o.GetType() == typeof(Media))))
            {
                return false;
            }
            return this.Equals(((Media)o));
        }
        
        public override int GetHashCode()
        {
            return (this.GetType().GetHashCode() ^ 
                ((!ReferenceEquals(this._id, null)) ? this._id.GetHashCode() : 0));
        }
        
        #endregion
        
        #region Change Tracking
        
        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged(string name)
        {
            if ((!ReferenceEquals(PropertyChanged, null)))
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
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
        
        #region Property Id
        
        private string _id;
        
        public event EventHandler IdChanged;
        
        protected virtual void OnIdChanged()
        {
            this.IsChanged = true;
            if ((!ReferenceEquals(IdChanged, null)))
            {
                IdChanged(this, EventArgs.Empty);
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
            if ((!ReferenceEquals(NameChanged, null)))
            {
                NameChanged(this, EventArgs.Empty);
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
            if ((!ReferenceEquals(MediaFileChanged, null)))
            {
                MediaFileChanged(this, EventArgs.Empty);
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
        
        private string _audioFile;
        
        public event EventHandler AudioFileChanged;
        
        protected virtual void OnAudioFileChanged()
        {
            this.IsChanged = true;
            if ((!ReferenceEquals(AudioFileChanged, null)))
            {
                AudioFileChanged(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"AudioFile");
        }
        
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
        
        #region Property ResultsFile
        
        private string _resultsFile;
        
        public event EventHandler ResultsFileChanged;
        
        protected virtual void OnResultsFileChanged()
        {
            this.IsChanged = true;
            if ((!ReferenceEquals(ResultsFileChanged, null)))
            {
                ResultsFileChanged(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"ResultsFile");
        }
        
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
        
        #region Property WaveformFile
        
        private string _waveformFile;
        
        public event EventHandler WaveformFileChanged;
        
        protected virtual void OnWaveformFileChanged()
        {
            this.IsChanged = true;
            if ((!ReferenceEquals(WaveformFileChanged, null)))
            {
                WaveformFileChanged(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"WaveformFile");
        }
        
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
    }
    
    #endregion
}
