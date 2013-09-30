using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace de.fhb.oll.mediacategorizer.model
{
    class Configuration : ModelBase
    {
        private const float DEF_MIN_CONFIDENCE = 0.4f;
        private const float DEF_GOOD_CONFIDENCE = 0.7f;
        private const float DEF_MIN_RELATIVE_APPEARANCE = 0.25f;
        private const float DEF_MIN_MATCH_SCORE = 0.0f;
        private const bool DEF_PARALLEL_PROC = true;
        private const bool DEF_SKIP_WORD_CLOUDS = false;
        private const bool DEF_SKIP_WORD_INCLUDES = false;
        private const bool DEF_SKIP_MATCH_INCLUDES = false;
        private const bool DEF_SKIP_MEDIA_COPY = false;

        private float minConfidence;
        private float goodConfidence;
        private float minRelativeAppearance;
        private float minMatchScore;
        private bool parallelProc;
        private FilterParameter indexFilter;
        private bool skipWordClouds;
        private bool skipWordIncludes;
        private bool skipMatchIncludes;
        private bool skipMediaCopy;
        private CloudParameter mainCloud;
        private CloudParameter mediaCloud;
        private CloudParameter categoryCloud;

        public Configuration()
        {
            minConfidence = DEF_MIN_CONFIDENCE;
            goodConfidence = DEF_GOOD_CONFIDENCE;
            minRelativeAppearance = DEF_MIN_RELATIVE_APPEARANCE;
            minMatchScore = DEF_MIN_MATCH_SCORE;
            parallelProc = DEF_PARALLEL_PROC;
            skipWordClouds = DEF_SKIP_WORD_CLOUDS;
            skipWordIncludes = DEF_SKIP_WORD_INCLUDES;
            skipMatchIncludes = DEF_SKIP_MATCH_INCLUDES;
            skipMediaCopy = DEF_SKIP_MEDIA_COPY;

            IndexFilter = new FilterParameter();
            MainCloud = new CloudParameter();
            MediaCloud = new CloudParameter();
            CategoryCloud = new CloudParameter();
        }

        [DefaultValue(DEF_MIN_CONFIDENCE)]
        public float MinConfidence
        {
            get { return minConfidence; }
            set
            {
                if (Math.Abs(value - minConfidence) < float.Epsilon) return;
                minConfidence = value;
                OnPropertyChanged("MinConfidence");
            }
        }

        [DefaultValue(DEF_GOOD_CONFIDENCE)]
        public float GoodConfidence
        {
            get { return goodConfidence; }
            set
            {
                if (Math.Abs(value - goodConfidence) < float.Epsilon) return;
                goodConfidence = value;
                OnPropertyChanged("GoodConfidence");
            }
        }

        [DefaultValue(DEF_MIN_RELATIVE_APPEARANCE)]
        public float MinRelativeAppearance
        {
            get { return minRelativeAppearance; }
            set
            {
                if (Math.Abs(value - minRelativeAppearance) < float.Epsilon) return;
                minRelativeAppearance = value;
                OnPropertyChanged("MinRelativeAppearance");
            }
        }

        [DefaultValue(DEF_MIN_MATCH_SCORE)]
        public float MinMatchScore
        {
            get { return minMatchScore; }
            set
            {
                if (Math.Abs(value - minMatchScore) < float.Epsilon) return;
                minMatchScore = value;
                OnPropertyChanged("MinMatchScore");
            }
        }

        [DefaultValue(DEF_PARALLEL_PROC)]
        public bool ParallelProc
        {
            get { return parallelProc; }
            set
            {
                if (value == parallelProc) return;
                parallelProc = value;
                OnPropertyChanged("ParallelProc");
            }
        }

        public FilterParameter IndexFilter
        {
            get { return indexFilter; }
            set
            {
                if (value == indexFilter) return;
                if (indexFilter != null)
                {
                    indexFilter.PropertyChanged -= ChildPropertyChangedHandler;
                }
                indexFilter = value;
                if (indexFilter != null)
                {
                    indexFilter.PropertyChanged += ChildPropertyChangedHandler;
                }
                OnPropertyChanged("IndexFilter");
            }
        }

        [DefaultValue(DEF_SKIP_WORD_CLOUDS)]
        public bool SkipWordClouds
        {
            get { return skipWordClouds; }
            set
            {
                if (value == skipWordClouds) return;
                skipWordClouds = value;
                OnPropertyChanged("SkipWordClouds");
            }
        }

        [DefaultValue(DEF_SKIP_WORD_INCLUDES)]
        public bool SkipWordIncludes
        {
            get { return skipWordIncludes; }
            set
            {
                if (value == skipWordIncludes) return;
                skipWordIncludes = value;
                OnPropertyChanged("SkipWordIncludes");
            }
        }

        [DefaultValue(DEF_SKIP_MATCH_INCLUDES)]
        public bool SkipMatchIncludes
        {
            get { return skipMatchIncludes; }
            set
            {
                if (value == skipMatchIncludes) return;
                skipMatchIncludes = value;
                OnPropertyChanged("SkipMatchIncludes");
            }
        }

        [DefaultValue(DEF_SKIP_MEDIA_COPY)]
        public bool SkipMediaCopy
        {
            get { return skipMediaCopy; }
            set
            {
                if (value == skipMediaCopy) return;
                skipMediaCopy = value;
                OnPropertyChanged("SkipMediaCopy");
            }
        }

        public CloudParameter MainCloud
        {
            get { return mainCloud; }
            set
            {
                if (value == mainCloud) return;
                if (mainCloud != null)
                {
                    mainCloud.PropertyChanged -= ChildPropertyChangedHandler;
                }
                mainCloud = value;
                if (mainCloud != null)
                {
                    mainCloud.PropertyChanged += ChildPropertyChangedHandler;
                }
                OnPropertyChanged("MainCloud");
            }
        }

        public CloudParameter MediaCloud
        {
            get { return mediaCloud; }
            set
            {
                if (value == mediaCloud) return;
                if (mediaCloud != null)
                {
                    mediaCloud.PropertyChanged -= ChildPropertyChangedHandler;
                }
                mediaCloud = value;
                if (mediaCloud != null)
                {
                    mediaCloud.PropertyChanged += ChildPropertyChangedHandler;
                }
                OnPropertyChanged("MediaCloud");
            }
        }

        public CloudParameter CategoryCloud
        {
            get { return categoryCloud; }
            set
            {
                if (value == categoryCloud) return;
                if (categoryCloud != null)
                {
                    categoryCloud.PropertyChanged -= ChildPropertyChangedHandler;
                }
                categoryCloud = value;
                if (categoryCloud != null)
                {
                    categoryCloud.PropertyChanged += ChildPropertyChangedHandler;
                }
                OnPropertyChanged("CategoryCloud");
            }
        }
    }
}
