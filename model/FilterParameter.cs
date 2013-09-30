using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace de.fhb.oll.mediacategorizer.model
{
    class FilterParameter : ModelBase
    {
        private const string DEF_BLACKLIST_RESOURCE = "top10000de.txt";
        private const int DEF_BLACKLIST_MAX_SIZE = 2000;
        private const bool DEF_FILTER_NOT_SHORT = true;
        private const bool DEF_FILTER_NOUN = true;
        private const bool DEF_FILTER_MIN_CONFIDENCE = true;
        private const bool DEF_FILTER_GOOD_CONFIDENCE = false;
        private const bool DEF_FILTER_NO_PUNCTUATION = true;
        private const bool DEF_FILTER_NOT_IN_BLACKLIST = true;

        private string blacklistResource;
        private int blacklistMaxSize;
        private bool filterNotShort;
        private bool filterNoun;
        private bool filterMinConfidence;
        private bool filterGoodConfidence;
        private bool filterNoPunctuation;
        private bool filterNotInBlacklist;

        public FilterParameter()
        {
            blacklistResource = DEF_BLACKLIST_RESOURCE;
            blacklistMaxSize = DEF_BLACKLIST_MAX_SIZE;
            filterNotShort = DEF_FILTER_NOT_SHORT;
            filterNoun = DEF_FILTER_NOUN;
            filterMinConfidence = DEF_FILTER_MIN_CONFIDENCE;
            filterGoodConfidence = DEF_FILTER_GOOD_CONFIDENCE;
            filterNoPunctuation = DEF_FILTER_NO_PUNCTUATION;
            filterNotInBlacklist = DEF_FILTER_NOT_IN_BLACKLIST;
        }

        [DefaultValue(DEF_BLACKLIST_RESOURCE)]
        public string BlacklistResource
        {
            get { return blacklistResource; }
            set
            {
                if (value == blacklistResource) return;
                blacklistResource = value; 
                OnPropertyChanged("BlacklistResource");
            }
        }

        [DefaultValue(DEF_BLACKLIST_MAX_SIZE)]
        public int BlacklistMaxSize
        {
            get { return blacklistMaxSize; }
            set
            {
                if (value == blacklistMaxSize) return;
                blacklistMaxSize = value; 
                OnPropertyChanged("BlacklistMaxSize");
            }
        }

        [DefaultValue(DEF_FILTER_NOT_SHORT)]
        public bool FilterNotShort
        {
            get { return filterNotShort; }
            set
            {
                if (value == filterNotShort) return;
                filterNotShort = value; 
                OnPropertyChanged("FilterNotShort");
            }
        }

        [DefaultValue(DEF_FILTER_NOUN)]
        public bool FilterNoun
        {
            get { return filterNoun; }
            set
            {
                if (value == filterNoun) return;
                filterNoun = value; 
                OnPropertyChanged("FilterNoun");
            }
        }

        [DefaultValue(DEF_FILTER_MIN_CONFIDENCE)]
        public bool FilterMinConfidence
        {
            get { return filterMinConfidence; }
            set
            {
                if (value == filterMinConfidence) return;
                filterMinConfidence = value;
                OnPropertyChanged("FilterMinConfidence");
            }
        }

        [DefaultValue(DEF_FILTER_GOOD_CONFIDENCE)]
        public bool FilterGoodConfidence
        {
            get { return filterGoodConfidence; }
            set
            {
                if (value == filterGoodConfidence) return;
                filterGoodConfidence = value;
                OnPropertyChanged("FilterGoodConfidence");
            }
        }

        [DefaultValue(DEF_FILTER_NO_PUNCTUATION)]
        public bool FilterNoPunctuation
        {
            get { return filterNoPunctuation; }
            set
            {
                if (value == filterNoPunctuation) return;
                filterNoPunctuation = value;
                OnPropertyChanged("FilterNoPunctuation");
            }
        }

        [DefaultValue(DEF_FILTER_NOT_IN_BLACKLIST)]
        public bool FilterNotInBlacklist
        {
            get { return filterNotInBlacklist; }
            set
            {
                if (value == filterNotInBlacklist) return;
                filterNotInBlacklist = value; 
                OnPropertyChanged("FilterNotInBlacklist");
            }
        }
    }
}
