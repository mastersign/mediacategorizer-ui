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
            _configuration = new Configuration();
            _categories = new global::System.Collections.ObjectModel.ObservableCollection<Category>();
            _media = new global::System.Collections.ObjectModel.ObservableCollection<Media>();
            this.Initialize();
        }
        
        public override string ToString()
        {
            return (this.GetType().FullName + @": " + (
                (Environment.NewLine + @"    Name = " + ((_name != null) ? _name.ToString() : @"null").Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    Description = " + ((_description != null) ? _description.ToString() : @"null").Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    OutputDir = " + ((_outputDir != null) ? _outputDir.ToString() : @"null").Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    Configuration = " + ((_configuration != null) ? _configuration.ToString() : @"null").Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    Categories = " + ((_categories != null) ? _categories.ToString() : @"null").Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    Media = " + ((_media != null) ? _media.ToString() : @"null").Replace("\n", "\n    "))));
        }
        
        public bool Equals(Project o)
        {
            if ((o == null))
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
            if ((o == null))
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
                ((this._name != null) ? this._name.GetHashCode() : 0) ^ 
                ((this._description != null) ? this._description.GetHashCode() : 0) ^ 
                ((this._outputDir != null) ? this._outputDir.GetHashCode() : 0) ^ 
                ((this._configuration != null) ? this._configuration.GetHashCode() : 0) ^ 
                ((this._categories != null) ? this._categories.GetHashCode() : 0) ^ 
                ((this._media != null) ? this._media.GetHashCode() : 0));
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged(string name)
        {
            if ((PropertyChanged != null))
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        
        private bool _isChanged = false;
        
        public bool IsChanged
        {
            get { return this._isChanged; }
            protected set { this._isChanged = value; }
        }
        
        public void AcceptChanges()
        {
            this.IsChanged = false;
        }
        
        private string _name;
        
        public event EventHandler NameChanged;
        
        protected virtual void OnNameChanged()
        {
            this.IsChanged = true;
            if ((NameChanged != null))
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
        
        private string _description;
        
        public event EventHandler DescriptionChanged;
        
        protected virtual void OnDescriptionChanged()
        {
            this.IsChanged = true;
            if ((DescriptionChanged != null))
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
        
        private string _outputDir;
        
        public event EventHandler OutputDirChanged;
        
        protected virtual void OnOutputDirChanged()
        {
            this.IsChanged = true;
            if ((OutputDirChanged != null))
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
        
        private Configuration _configuration;
        
        public event EventHandler ConfigurationChanged;
        
        protected virtual void OnConfigurationChanged()
        {
            this.IsChanged = true;
            if ((ConfigurationChanged != null))
            {
                ConfigurationChanged(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"Configuration");
        }
        
        public virtual Configuration Configuration
        {
            get { return _configuration; }
            set
            {
                if ((value == _configuration))
                {
                    return;
                }
                _configuration = value;
                this.OnConfigurationChanged();
            }
        }
        
        private global::System.Collections.ObjectModel.ObservableCollection<Category> _categories;
        
        public event EventHandler CategoriesChanged;
        
        protected virtual void OnCategoriesChanged()
        {
            this.IsChanged = true;
            if ((CategoriesChanged != null))
            {
                CategoriesChanged(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"Categories");
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
                _categories = value;
                this.OnCategoriesChanged();
            }
        }
        
        private global::System.Collections.ObjectModel.ObservableCollection<Media> _media;
        
        public event EventHandler MediaChanged;
        
        protected virtual void OnMediaChanged()
        {
            this.IsChanged = true;
            if ((MediaChanged != null))
            {
                MediaChanged(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"Media");
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
                _media = value;
                this.OnMediaChanged();
            }
        }
    }
    
    public partial class Configuration : IEquatable<Configuration>, INotifyPropertyChanged, IChangeTracking
    {
        public Configuration()
        {
            _minConfidence = DEF_MINCONFIDENCE;
            _goodConfidence = DEF_GOODCONFIDENCE;
            _minRelativeAppearance = DEF_MINRELATIVEAPPEARANCE;
            _minMatchScore = DEF_MINMATCHSCORE;
            _indexFilter = new FilterParameter();
            _mainCloud = new CloudParameter();
            _mediaCloud = new CloudParameter();
            _categoryCloud = new CloudParameter();
            _parallelProc = DEF_PARALLELPROC;
            _skipWordClouds = DEF_SKIPWORDCLOUDS;
            _skipWordIncludes = DEF_SKIPWORDINCLUDES;
            _skipMatchIncludes = DEF_SKIPMATCHINCLUDES;
            _skipMediaCopy = DEF_SKIPMEDIACOPY;
        }
        
        public override string ToString()
        {
            return (this.GetType().FullName + @": " + (
                (Environment.NewLine + @"    MinConfidence = " + _minConfidence.ToString().Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    GoodConfidence = " + _goodConfidence.ToString().Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    MinRelativeAppearance = " + _minRelativeAppearance.ToString().Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    MinMatchScore = " + _minMatchScore.ToString().Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    IndexFilter = " + ((_indexFilter != null) ? _indexFilter.ToString() : @"null").Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    MainCloud = " + ((_mainCloud != null) ? _mainCloud.ToString() : @"null").Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    MediaCloud = " + ((_mediaCloud != null) ? _mediaCloud.ToString() : @"null").Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    CategoryCloud = " + ((_categoryCloud != null) ? _categoryCloud.ToString() : @"null").Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    ParallelProc = " + _parallelProc.ToString().Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    SkipWordClouds = " + _skipWordClouds.ToString().Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    SkipWordIncludes = " + _skipWordIncludes.ToString().Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    SkipMatchIncludes = " + _skipMatchIncludes.ToString().Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    SkipMediaCopy = " + _skipMediaCopy.ToString().Replace("\n", "\n    "))));
        }
        
        public bool Equals(Configuration o)
        {
            if ((o == null))
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
            if ((o == null))
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
                ((this._indexFilter != null) ? this._indexFilter.GetHashCode() : 0) ^ 
                ((this._mainCloud != null) ? this._mainCloud.GetHashCode() : 0) ^ 
                ((this._mediaCloud != null) ? this._mediaCloud.GetHashCode() : 0) ^ 
                ((this._categoryCloud != null) ? this._categoryCloud.GetHashCode() : 0) ^ 
                this._parallelProc.GetHashCode() ^ 
                this._skipWordClouds.GetHashCode() ^ 
                this._skipWordIncludes.GetHashCode() ^ 
                this._skipMatchIncludes.GetHashCode() ^ 
                this._skipMediaCopy.GetHashCode());
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged(string name)
        {
            if ((PropertyChanged != null))
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        
        private bool _isChanged = false;
        
        public bool IsChanged
        {
            get { return this._isChanged; }
            protected set { this._isChanged = value; }
        }
        
        public void AcceptChanges()
        {
            this.IsChanged = false;
        }
        
        private float _minConfidence;
        
        public event EventHandler MinConfidenceChanged;
        
        protected virtual void OnMinConfidenceChanged()
        {
            this.IsChanged = true;
            if ((MinConfidenceChanged != null))
            {
                MinConfidenceChanged(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"MinConfidence");
        }
        
        private const float DEF_MINCONFIDENCE = 0.4F;
        
        [DefaultValue(DEF_MINCONFIDENCE)]
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
        
        private float _goodConfidence;
        
        public event EventHandler GoodConfidenceChanged;
        
        protected virtual void OnGoodConfidenceChanged()
        {
            this.IsChanged = true;
            if ((GoodConfidenceChanged != null))
            {
                GoodConfidenceChanged(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"GoodConfidence");
        }
        
        private const float DEF_GOODCONFIDENCE = 0.7F;
        
        [DefaultValue(DEF_GOODCONFIDENCE)]
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
        
        private float _minRelativeAppearance;
        
        public event EventHandler MinRelativeAppearanceChanged;
        
        protected virtual void OnMinRelativeAppearanceChanged()
        {
            this.IsChanged = true;
            if ((MinRelativeAppearanceChanged != null))
            {
                MinRelativeAppearanceChanged(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"MinRelativeAppearance");
        }
        
        private const float DEF_MINRELATIVEAPPEARANCE = 0.25F;
        
        [DefaultValue(DEF_MINRELATIVEAPPEARANCE)]
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
        
        private float _minMatchScore;
        
        public event EventHandler MinMatchScoreChanged;
        
        protected virtual void OnMinMatchScoreChanged()
        {
            this.IsChanged = true;
            if ((MinMatchScoreChanged != null))
            {
                MinMatchScoreChanged(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"MinMatchScore");
        }
        
        private const float DEF_MINMATCHSCORE = 0.0F;
        
        [DefaultValue(DEF_MINMATCHSCORE)]
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
        
        private FilterParameter _indexFilter;
        
        public event EventHandler IndexFilterChanged;
        
        protected virtual void OnIndexFilterChanged()
        {
            this.IsChanged = true;
            if ((IndexFilterChanged != null))
            {
                IndexFilterChanged(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"IndexFilter");
        }
        
        public virtual FilterParameter IndexFilter
        {
            get { return _indexFilter; }
            set
            {
                if ((value == _indexFilter))
                {
                    return;
                }
                _indexFilter = value;
                this.OnIndexFilterChanged();
            }
        }
        
        private CloudParameter _mainCloud;
        
        public event EventHandler MainCloudChanged;
        
        protected virtual void OnMainCloudChanged()
        {
            this.IsChanged = true;
            if ((MainCloudChanged != null))
            {
                MainCloudChanged(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"MainCloud");
        }
        
        public virtual CloudParameter MainCloud
        {
            get { return _mainCloud; }
            set
            {
                if ((value == _mainCloud))
                {
                    return;
                }
                _mainCloud = value;
                this.OnMainCloudChanged();
            }
        }
        
        private CloudParameter _mediaCloud;
        
        public event EventHandler MediaCloudChanged;
        
        protected virtual void OnMediaCloudChanged()
        {
            this.IsChanged = true;
            if ((MediaCloudChanged != null))
            {
                MediaCloudChanged(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"MediaCloud");
        }
        
        public virtual CloudParameter MediaCloud
        {
            get { return _mediaCloud; }
            set
            {
                if ((value == _mediaCloud))
                {
                    return;
                }
                _mediaCloud = value;
                this.OnMediaCloudChanged();
            }
        }
        
        private CloudParameter _categoryCloud;
        
        public event EventHandler CategoryCloudChanged;
        
        protected virtual void OnCategoryCloudChanged()
        {
            this.IsChanged = true;
            if ((CategoryCloudChanged != null))
            {
                CategoryCloudChanged(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"CategoryCloud");
        }
        
        public virtual CloudParameter CategoryCloud
        {
            get { return _categoryCloud; }
            set
            {
                if ((value == _categoryCloud))
                {
                    return;
                }
                _categoryCloud = value;
                this.OnCategoryCloudChanged();
            }
        }
        
        private bool _parallelProc;
        
        public event EventHandler ParallelProcChanged;
        
        protected virtual void OnParallelProcChanged()
        {
            this.IsChanged = true;
            if ((ParallelProcChanged != null))
            {
                ParallelProcChanged(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"ParallelProc");
        }
        
        private const bool DEF_PARALLELPROC = true;
        
        [DefaultValue(DEF_PARALLELPROC)]
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
        
        private bool _skipWordClouds;
        
        public event EventHandler SkipWordCloudsChanged;
        
        protected virtual void OnSkipWordCloudsChanged()
        {
            this.IsChanged = true;
            if ((SkipWordCloudsChanged != null))
            {
                SkipWordCloudsChanged(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"SkipWordClouds");
        }
        
        private const bool DEF_SKIPWORDCLOUDS = false;
        
        [DefaultValue(DEF_SKIPWORDCLOUDS)]
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
        
        private bool _skipWordIncludes;
        
        public event EventHandler SkipWordIncludesChanged;
        
        protected virtual void OnSkipWordIncludesChanged()
        {
            this.IsChanged = true;
            if ((SkipWordIncludesChanged != null))
            {
                SkipWordIncludesChanged(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"SkipWordIncludes");
        }
        
        private const bool DEF_SKIPWORDINCLUDES = false;
        
        [DefaultValue(DEF_SKIPWORDINCLUDES)]
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
        
        private bool _skipMatchIncludes;
        
        public event EventHandler SkipMatchIncludesChanged;
        
        protected virtual void OnSkipMatchIncludesChanged()
        {
            this.IsChanged = true;
            if ((SkipMatchIncludesChanged != null))
            {
                SkipMatchIncludesChanged(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"SkipMatchIncludes");
        }
        
        private const bool DEF_SKIPMATCHINCLUDES = false;
        
        [DefaultValue(DEF_SKIPMATCHINCLUDES)]
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
        
        private bool _skipMediaCopy;
        
        public event EventHandler SkipMediaCopyChanged;
        
        protected virtual void OnSkipMediaCopyChanged()
        {
            this.IsChanged = true;
            if ((SkipMediaCopyChanged != null))
            {
                SkipMediaCopyChanged(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"SkipMediaCopy");
        }
        
        private const bool DEF_SKIPMEDIACOPY = false;
        
        [DefaultValue(DEF_SKIPMEDIACOPY)]
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
        }
        
        public override string ToString()
        {
            return (this.GetType().FullName + @": " + (
                (Environment.NewLine + @"    BlacklistResource = " + ((_blacklistResource != null) ? _blacklistResource.ToString() : @"null").Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    BlacklistMaxSize = " + _blacklistMaxSize.ToString().Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    FilterNotShort = " + _filterNotShort.ToString().Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    FilterNoun = " + _filterNoun.ToString().Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    FilterMinConfidence = " + _filterMinConfidence.ToString().Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    FilterGoodConfidence = " + _filterGoodConfidence.ToString().Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    FilterNoPunctuation = " + _filterNoPunctuation.ToString().Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    FilterNotInBlacklist = " + _filterNotInBlacklist.ToString().Replace("\n", "\n    "))));
        }
        
        public bool Equals(FilterParameter o)
        {
            if ((o == null))
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
            if ((o == null))
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
                ((this._blacklistResource != null) ? this._blacklistResource.GetHashCode() : 0) ^ 
                this._blacklistMaxSize.GetHashCode() ^ 
                this._filterNotShort.GetHashCode() ^ 
                this._filterNoun.GetHashCode() ^ 
                this._filterMinConfidence.GetHashCode() ^ 
                this._filterGoodConfidence.GetHashCode() ^ 
                this._filterNoPunctuation.GetHashCode() ^ 
                this._filterNotInBlacklist.GetHashCode());
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged(string name)
        {
            if ((PropertyChanged != null))
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        
        private bool _isChanged = false;
        
        public bool IsChanged
        {
            get { return this._isChanged; }
            protected set { this._isChanged = value; }
        }
        
        public void AcceptChanges()
        {
            this.IsChanged = false;
        }
        
        private string _blacklistResource;
        
        public event EventHandler BlacklistResourceChanged;
        
        protected virtual void OnBlacklistResourceChanged()
        {
            this.IsChanged = true;
            if ((BlacklistResourceChanged != null))
            {
                BlacklistResourceChanged(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"BlacklistResource");
        }
        
        private const string DEF_BLACKLISTRESOURCE = @"top10000de.txt";
        
        [DefaultValue(DEF_BLACKLISTRESOURCE)]
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
        
        private int _blacklistMaxSize;
        
        public event EventHandler BlacklistMaxSizeChanged;
        
        protected virtual void OnBlacklistMaxSizeChanged()
        {
            this.IsChanged = true;
            if ((BlacklistMaxSizeChanged != null))
            {
                BlacklistMaxSizeChanged(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"BlacklistMaxSize");
        }
        
        private const int DEF_BLACKLISTMAXSIZE = 2000;
        
        [DefaultValue(DEF_BLACKLISTMAXSIZE)]
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
        
        private bool _filterNotShort;
        
        public event EventHandler FilterNotShortChanged;
        
        protected virtual void OnFilterNotShortChanged()
        {
            this.IsChanged = true;
            if ((FilterNotShortChanged != null))
            {
                FilterNotShortChanged(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"FilterNotShort");
        }
        
        private const bool DEF_FILTERNOTSHORT = true;
        
        [DefaultValue(DEF_FILTERNOTSHORT)]
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
        
        private bool _filterNoun;
        
        public event EventHandler FilterNounChanged;
        
        protected virtual void OnFilterNounChanged()
        {
            this.IsChanged = true;
            if ((FilterNounChanged != null))
            {
                FilterNounChanged(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"FilterNoun");
        }
        
        private const bool DEF_FILTERNOUN = true;
        
        [DefaultValue(DEF_FILTERNOUN)]
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
        
        private bool _filterMinConfidence;
        
        public event EventHandler FilterMinConfidenceChanged;
        
        protected virtual void OnFilterMinConfidenceChanged()
        {
            this.IsChanged = true;
            if ((FilterMinConfidenceChanged != null))
            {
                FilterMinConfidenceChanged(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"FilterMinConfidence");
        }
        
        private const bool DEF_FILTERMINCONFIDENCE = true;
        
        [DefaultValue(DEF_FILTERMINCONFIDENCE)]
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
        
        private bool _filterGoodConfidence;
        
        public event EventHandler FilterGoodConfidenceChanged;
        
        protected virtual void OnFilterGoodConfidenceChanged()
        {
            this.IsChanged = true;
            if ((FilterGoodConfidenceChanged != null))
            {
                FilterGoodConfidenceChanged(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"FilterGoodConfidence");
        }
        
        private const bool DEF_FILTERGOODCONFIDENCE = false;
        
        [DefaultValue(DEF_FILTERGOODCONFIDENCE)]
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
        
        private bool _filterNoPunctuation;
        
        public event EventHandler FilterNoPunctuationChanged;
        
        protected virtual void OnFilterNoPunctuationChanged()
        {
            this.IsChanged = true;
            if ((FilterNoPunctuationChanged != null))
            {
                FilterNoPunctuationChanged(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"FilterNoPunctuation");
        }
        
        private const bool DEF_FILTERNOPUNCTUATION = true;
        
        [DefaultValue(DEF_FILTERNOPUNCTUATION)]
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
        
        private bool _filterNotInBlacklist;
        
        public event EventHandler FilterNotInBlacklistChanged;
        
        protected virtual void OnFilterNotInBlacklistChanged()
        {
            this.IsChanged = true;
            if ((FilterNotInBlacklistChanged != null))
            {
                FilterNotInBlacklistChanged(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"FilterNotInBlacklist");
        }
        
        private const bool DEF_FILTERNOTINBLACKLIST = true;
        
        [DefaultValue(DEF_FILTERNOTINBLACKLIST)]
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
    }
    
    public partial class ColorRGBA : IEquatable<ColorRGBA>, INotifyPropertyChanged, IChangeTracking
    {
        public ColorRGBA()
        {
            _r = DEF_R;
            _g = DEF_G;
            _b = DEF_B;
            _a = DEF_A;
        }
        
        public override string ToString()
        {
            return (this.GetType().FullName + @": " + (
                (Environment.NewLine + @"    R = " + _r.ToString().Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    G = " + _g.ToString().Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    B = " + _b.ToString().Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    A = " + _a.ToString().Replace("\n", "\n    "))));
        }
        
        public bool Equals(ColorRGBA o)
        {
            if ((o == null))
            {
                return false;
            }
            return (
                (this._r == o._r) && 
                (this._g == o._g) && 
                (this._b == o._b) && 
                (this._a == o._a));
        }
        
        public override bool Equals(object o)
        {
            if ((o == null))
            {
                return false;
            }
            if ((!(o.GetType() == typeof(ColorRGBA))))
            {
                return false;
            }
            return this.Equals(((ColorRGBA)o));
        }
        
        public override int GetHashCode()
        {
            return (this.GetType().GetHashCode() ^ 
                this._r.GetHashCode() ^ 
                this._g.GetHashCode() ^ 
                this._b.GetHashCode() ^ 
                this._a.GetHashCode());
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged(string name)
        {
            if ((PropertyChanged != null))
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        
        private bool _isChanged = false;
        
        public bool IsChanged
        {
            get { return this._isChanged; }
            protected set { this._isChanged = value; }
        }
        
        public void AcceptChanges()
        {
            this.IsChanged = false;
        }
        
        private float _r;
        
        public event EventHandler RChanged;
        
        protected virtual void OnRChanged()
        {
            this.IsChanged = true;
            if ((RChanged != null))
            {
                RChanged(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"R");
        }
        
        private const float DEF_R = 0.0F;
        
        [DefaultValue(DEF_R)]
        public virtual float R
        {
            get { return _r; }
            set
            {
                if ((Math.Abs(value - _r) < float.Epsilon))
                {
                    return;
                }
                _r = value;
                this.OnRChanged();
            }
        }
        
        private float _g;
        
        public event EventHandler GChanged;
        
        protected virtual void OnGChanged()
        {
            this.IsChanged = true;
            if ((GChanged != null))
            {
                GChanged(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"G");
        }
        
        private const float DEF_G = 0.5F;
        
        [DefaultValue(DEF_G)]
        public virtual float G
        {
            get { return _g; }
            set
            {
                if ((Math.Abs(value - _g) < float.Epsilon))
                {
                    return;
                }
                _g = value;
                this.OnGChanged();
            }
        }
        
        private float _b;
        
        public event EventHandler BChanged;
        
        protected virtual void OnBChanged()
        {
            this.IsChanged = true;
            if ((BChanged != null))
            {
                BChanged(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"B");
        }
        
        private const float DEF_B = 1.0F;
        
        [DefaultValue(DEF_B)]
        public virtual float B
        {
            get { return _b; }
            set
            {
                if ((Math.Abs(value - _b) < float.Epsilon))
                {
                    return;
                }
                _b = value;
                this.OnBChanged();
            }
        }
        
        private float _a;
        
        public event EventHandler AChanged;
        
        protected virtual void OnAChanged()
        {
            this.IsChanged = true;
            if ((AChanged != null))
            {
                AChanged(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"A");
        }
        
        private const float DEF_A = 1.0F;
        
        [DefaultValue(DEF_A)]
        public virtual float A
        {
            get { return _a; }
            set
            {
                if ((Math.Abs(value - _a) < float.Epsilon))
                {
                    return;
                }
                _a = value;
                this.OnAChanged();
            }
        }
    }
    
    public partial class CloudParameter : IEquatable<CloudParameter>, INotifyPropertyChanged, IChangeTracking
    {
        public CloudParameter()
        {
            _width = DEF_WIDTH;
            _height = DEF_HEIGHT;
            _precision = DEF_PRECISION;
            _orderPriority = DEF_ORDERPRIORITY;
            _fontFamily = DEF_FONTFAMILY;
            _fontBold = DEF_FONTBOLD;
            _fontItalic = DEF_FONTITALIC;
            _minFontSize = DEF_MINFONTSIZE;
            _maxFontSize = DEF_MAXFONTSIZE;
            _color = new ColorRGBA();
            _backgroundColor = new ColorRGBA();
            this.Initialize();
        }
        
        public override string ToString()
        {
            return (this.GetType().FullName + @": " + (
                (Environment.NewLine + @"    Width = " + _width.ToString().Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    Height = " + _height.ToString().Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    Precision = " + _precision.ToString().Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    OrderPriority = " + _orderPriority.ToString().Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    FontFamily = " + ((_fontFamily != null) ? _fontFamily.ToString() : @"null").Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    FontBold = " + _fontBold.ToString().Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    FontItalic = " + _fontItalic.ToString().Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    MinFontSize = " + _minFontSize.ToString().Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    MaxFontSize = " + _maxFontSize.ToString().Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    Color = " + ((_color != null) ? _color.ToString() : @"null").Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    BackgroundColor = " + ((_backgroundColor != null) ? _backgroundColor.ToString() : @"null").Replace("\n", "\n    "))));
        }
        
        public bool Equals(CloudParameter o)
        {
            if ((o == null))
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
                object.Equals(this._color, o._color) && 
                object.Equals(this._backgroundColor, o._backgroundColor));
        }
        
        public override bool Equals(object o)
        {
            if ((o == null))
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
                ((this._fontFamily != null) ? this._fontFamily.GetHashCode() : 0) ^ 
                this._fontBold.GetHashCode() ^ 
                this._fontItalic.GetHashCode() ^ 
                this._minFontSize.GetHashCode() ^ 
                this._maxFontSize.GetHashCode() ^ 
                ((this._color != null) ? this._color.GetHashCode() : 0) ^ 
                ((this._backgroundColor != null) ? this._backgroundColor.GetHashCode() : 0));
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged(string name)
        {
            if ((PropertyChanged != null))
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        
        private bool _isChanged = false;
        
        public bool IsChanged
        {
            get { return this._isChanged; }
            protected set { this._isChanged = value; }
        }
        
        public void AcceptChanges()
        {
            this.IsChanged = false;
        }
        
        private int _width;
        
        public event EventHandler WidthChanged;
        
        protected virtual void OnWidthChanged()
        {
            this.IsChanged = true;
            if ((WidthChanged != null))
            {
                WidthChanged(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"Width");
        }
        
        private const int DEF_WIDTH = 640;
        
        [DefaultValue(DEF_WIDTH)]
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
        
        private int _height;
        
        public event EventHandler HeightChanged;
        
        protected virtual void OnHeightChanged()
        {
            this.IsChanged = true;
            if ((HeightChanged != null))
            {
                HeightChanged(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"Height");
        }
        
        private const int DEF_HEIGHT = 480;
        
        [DefaultValue(DEF_HEIGHT)]
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
        
        private CloudPrecision _precision;
        
        public event EventHandler PrecisionChanged;
        
        protected virtual void OnPrecisionChanged()
        {
            this.IsChanged = true;
            if ((PrecisionChanged != null))
            {
                PrecisionChanged(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"Precision");
        }
        
        private const CloudPrecision DEF_PRECISION = CloudPrecision.Medium;
        
        [DefaultValue(DEF_PRECISION)]
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
        
        private float _orderPriority;
        
        public event EventHandler OrderPriorityChanged;
        
        protected virtual void OnOrderPriorityChanged()
        {
            this.IsChanged = true;
            if ((OrderPriorityChanged != null))
            {
                OrderPriorityChanged(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"OrderPriority");
        }
        
        private const float DEF_ORDERPRIORITY = 0.6F;
        
        [DefaultValue(DEF_ORDERPRIORITY)]
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
        
        private string _fontFamily;
        
        public event EventHandler FontFamilyChanged;
        
        protected virtual void OnFontFamilyChanged()
        {
            this.IsChanged = true;
            if ((FontFamilyChanged != null))
            {
                FontFamilyChanged(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"FontFamily");
        }
        
        private const string DEF_FONTFAMILY = @"Arial";
        
        [DefaultValue(DEF_FONTFAMILY)]
        public virtual string FontFamily
        {
            get { return _fontFamily; }
            set
            {
                if (string.Equals(value, _fontFamily))
                {
                    return;
                }
                _fontFamily = value;
                this.OnFontFamilyChanged();
            }
        }
        
        private bool _fontBold;
        
        public event EventHandler FontBoldChanged;
        
        protected virtual void OnFontBoldChanged()
        {
            this.IsChanged = true;
            if ((FontBoldChanged != null))
            {
                FontBoldChanged(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"FontBold");
        }
        
        private const bool DEF_FONTBOLD = true;
        
        [DefaultValue(DEF_FONTBOLD)]
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
        
        private bool _fontItalic;
        
        public event EventHandler FontItalicChanged;
        
        protected virtual void OnFontItalicChanged()
        {
            this.IsChanged = true;
            if ((FontItalicChanged != null))
            {
                FontItalicChanged(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"FontItalic");
        }
        
        private const bool DEF_FONTITALIC = false;
        
        [DefaultValue(DEF_FONTITALIC)]
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
        
        private float _minFontSize;
        
        public event EventHandler MinFontSizeChanged;
        
        protected virtual void OnMinFontSizeChanged()
        {
            this.IsChanged = true;
            if ((MinFontSizeChanged != null))
            {
                MinFontSizeChanged(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"MinFontSize");
        }
        
        private const float DEF_MINFONTSIZE = 13.0F;
        
        [DefaultValue(DEF_MINFONTSIZE)]
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
        
        private float _maxFontSize;
        
        public event EventHandler MaxFontSizeChanged;
        
        protected virtual void OnMaxFontSizeChanged()
        {
            this.IsChanged = true;
            if ((MaxFontSizeChanged != null))
            {
                MaxFontSizeChanged(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"MaxFontSize");
        }
        
        private const float DEF_MAXFONTSIZE = 80.0F;
        
        [DefaultValue(DEF_MAXFONTSIZE)]
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
        
        private ColorRGBA _color;
        
        public event EventHandler ColorChanged;
        
        protected virtual void OnColorChanged()
        {
            this.IsChanged = true;
            if ((ColorChanged != null))
            {
                ColorChanged(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"Color");
        }
        
        public virtual ColorRGBA Color
        {
            get { return _color; }
            set
            {
                if ((value == _color))
                {
                    return;
                }
                _color = value;
                this.OnColorChanged();
            }
        }
        
        private ColorRGBA _backgroundColor;
        
        public event EventHandler BackgroundColorChanged;
        
        protected virtual void OnBackgroundColorChanged()
        {
            this.IsChanged = true;
            if ((BackgroundColorChanged != null))
            {
                BackgroundColorChanged(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"BackgroundColor");
        }
        
        public virtual ColorRGBA BackgroundColor
        {
            get { return _backgroundColor; }
            set
            {
                if ((value == _backgroundColor))
                {
                    return;
                }
                _backgroundColor = value;
                this.OnBackgroundColorChanged();
            }
        }
    }
    
    public partial class CategoryResource : IEquatable<CategoryResource>, INotifyPropertyChanged, IChangeTracking
    {
        public CategoryResource()
        {
            _type = DEF_TYPE;
            _url = DEF_URL;
        }
        
        public override string ToString()
        {
            return (this.GetType().FullName + @": " + (
                (Environment.NewLine + @"    Type = " + _type.ToString().Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    Url = " + ((_url != null) ? _url.ToString() : @"null").Replace("\n", "\n    "))));
        }
        
        public bool Equals(CategoryResource o)
        {
            if ((o == null))
            {
                return false;
            }
            return (
                (this._type == o._type) && 
                object.Equals(this._url, o._url));
        }
        
        public override bool Equals(object o)
        {
            if ((o == null))
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
                ((this._url != null) ? this._url.GetHashCode() : 0));
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged(string name)
        {
            if ((PropertyChanged != null))
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        
        private bool _isChanged = false;
        
        public bool IsChanged
        {
            get { return this._isChanged; }
            protected set { this._isChanged = value; }
        }
        
        public void AcceptChanges()
        {
            this.IsChanged = false;
        }
        
        private CategoryResourceType _type;
        
        public event EventHandler TypeChanged;
        
        protected virtual void OnTypeChanged()
        {
            this.IsChanged = true;
            if ((TypeChanged != null))
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
        
        private string _url;
        
        public event EventHandler UrlChanged;
        
        protected virtual void OnUrlChanged()
        {
            this.IsChanged = true;
            if ((UrlChanged != null))
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
    }
    
    public partial class Category : IEquatable<Category>, INotifyPropertyChanged, IChangeTracking
    {
        public Category()
        {
            _id = DEF_ID;
            _name = DEF_NAME;
            _resources = new global::System.Collections.ObjectModel.ObservableCollection<CategoryResource>();
        }
        
        public override string ToString()
        {
            return (this.GetType().FullName + @": " + (
                (Environment.NewLine + @"    Id = " + ((_id != null) ? _id.ToString() : @"null").Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    Name = " + ((_name != null) ? _name.ToString() : @"null").Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    Resources = " + ((_resources != null) ? _resources.ToString() : @"null").Replace("\n", "\n    "))));
        }
        
        public bool Equals(Category o)
        {
            if ((o == null))
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
            if ((o == null))
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
                ((this._id != null) ? this._id.GetHashCode() : 0) ^ 
                ((this._name != null) ? this._name.GetHashCode() : 0) ^ 
                ((this._resources != null) ? this._resources.GetHashCode() : 0));
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged(string name)
        {
            if ((PropertyChanged != null))
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        
        private bool _isChanged = false;
        
        public bool IsChanged
        {
            get { return this._isChanged; }
            protected set { this._isChanged = value; }
        }
        
        public void AcceptChanges()
        {
            this.IsChanged = false;
        }
        
        private string _id;
        
        public event EventHandler IdChanged;
        
        protected virtual void OnIdChanged()
        {
            this.IsChanged = true;
            if ((IdChanged != null))
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
        
        private string _name;
        
        public event EventHandler NameChanged;
        
        protected virtual void OnNameChanged()
        {
            this.IsChanged = true;
            if ((NameChanged != null))
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
        
        private global::System.Collections.ObjectModel.ObservableCollection<CategoryResource> _resources;
        
        public event EventHandler ResourcesChanged;
        
        protected virtual void OnResourcesChanged()
        {
            this.IsChanged = true;
            if ((ResourcesChanged != null))
            {
                ResourcesChanged(this, EventArgs.Empty);
            }
            this.OnPropertyChanged(@"Resources");
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
                _resources = value;
                this.OnResourcesChanged();
            }
        }
    }
    
    public partial class Media : IEquatable<Media>, INotifyPropertyChanged, IChangeTracking
    {
        public Media()
        {
        }
        
        public override string ToString()
        {
            return (this.GetType().FullName + @": " + (
                (Environment.NewLine + @"    Id = " + ((_id != null) ? _id.ToString() : @"null").Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    Name = " + ((_name != null) ? _name.ToString() : @"null").Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    MediaFile = " + ((_mediaFile != null) ? _mediaFile.ToString() : @"null").Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    AudioFile = " + ((_audioFile != null) ? _audioFile.ToString() : @"null").Replace("\n", "\n    ")) + 
                (Environment.NewLine + @"    ResultsFile = " + ((_resultsFile != null) ? _resultsFile.ToString() : @"null").Replace("\n", "\n    "))));
        }
        
        public bool Equals(Media o)
        {
            if ((o == null))
            {
                return false;
            }
            return (
                object.Equals(this._id, o._id));
        }
        
        public override bool Equals(object o)
        {
            if ((o == null))
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
                ((this._id != null) ? this._id.GetHashCode() : 0));
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged(string name)
        {
            if ((PropertyChanged != null))
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        
        private bool _isChanged = false;
        
        public bool IsChanged
        {
            get { return this._isChanged; }
            protected set { this._isChanged = value; }
        }
        
        public void AcceptChanges()
        {
            this.IsChanged = false;
        }
        
        private string _id;
        
        public event EventHandler IdChanged;
        
        protected virtual void OnIdChanged()
        {
            this.IsChanged = true;
            if ((IdChanged != null))
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
        
        private string _name;
        
        public event EventHandler NameChanged;
        
        protected virtual void OnNameChanged()
        {
            this.IsChanged = true;
            if ((NameChanged != null))
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
        
        private string _mediaFile;
        
        public event EventHandler MediaFileChanged;
        
        protected virtual void OnMediaFileChanged()
        {
            this.IsChanged = true;
            if ((MediaFileChanged != null))
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
        
        private string _audioFile;
        
        public event EventHandler AudioFileChanged;
        
        protected virtual void OnAudioFileChanged()
        {
            this.IsChanged = true;
            if ((AudioFileChanged != null))
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
        
        private string _resultsFile;
        
        public event EventHandler ResultsFileChanged;
        
        protected virtual void OnResultsFileChanged()
        {
            this.IsChanged = true;
            if ((ResultsFileChanged != null))
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
    }
    
    #endregion
}
