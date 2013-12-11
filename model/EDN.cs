using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Media;
using System.Xml.Serialization;
using de.fhb.oll.mediacategorizer.edn;

namespace de.fhb.oll.mediacategorizer.model
{
    partial class Project : IEdnWritable
    {
        public void WriteTo(EdnWriter w)
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            w.WriteMap(new object[]
            {
                new Keyword("media-categorizer-version"), version.ToString(3),
                new Keyword("job-name"), Name,
                new Keyword("job-description"), Description,
                new Keyword("output-dir"), GetOutputDir(),
                new Keyword("result-file"), ResultFile,
                new Keyword("configuration"), Configuration,
                new Keyword("categories"), new EdnVector(Categories, true),
                new Keyword("videos"), new EdnVector(Media, true),
            });
        }
    }

    partial class Configuration : IEdnWritable
    {
        [NonSerialized]
        private IDictionary<string, object> volatileProperties;

        [Browsable(false)]
        [XmlIgnore]
        public IDictionary<string, object> VolatileProperties
        {
            get { return volatileProperties ?? (volatileProperties = new Dictionary<string, object>()); }
        }

        private IEnumerable<object> GetVolatilePropertyPairs()
        {
            foreach (var vp in VolatileProperties)
            {
                yield return new Keyword(vp.Key);
                yield return vp.Value;
            }
        }

        public void WriteTo(EdnWriter w)
        {
            w.WriteMap(GetVolatilePropertyPairs()
                .Concat(new object[]
                    {
                        new Keyword("blacklist-resource"), IndexFilter.BlacklistResource,
                        new Keyword("blacklist-max-size"), IndexFilter.BlacklistMaxSize,
                        new Keyword("min-confidence"), MinConfidence,
                        new Keyword("good-confidence"), GoodConfidence,
                        new Keyword("min-relative-appearance"), MinRelativeAppearance,
                        new Keyword("min-match-score"), MinMatchScore,
                        new Keyword("index-filter"), IndexFilter,
                        new Keyword("visualize-result"), VisualizeResult,
                        new Keyword("show-result"), ShowResult,
                        new Keyword("skip-media-copy"), SkipMediaCopy,
                        new Keyword("skip-wordclouds"), SkipWordClouds,
                        new Keyword("skip-word-includes"), SkipWordIncludes,
                        new Keyword("skip-match-includes"), SkipMatchIncludes,
                        new Keyword("main-cloud"), MainCloud,
                        new Keyword("video-cloud"), MediaCloud,
                        new Keyword("category-cloud"), CategoryCloud,
                    }));
        }
    }

    partial class FilterParameter : IEdnWritable
    {
        public void WriteTo(EdnWriter w)
        {
            var l = new List<Keyword>();
            if (FilterNotShort) l.Add(new Keyword("not-short"));
            if (FilterNoun) l.Add(new Keyword("noun"));
            if (FilterMinConfidence) l.Add(new Keyword("min-confidence"));
            if (FilterGoodConfidence) l.Add(new Keyword("good-confidence"));
            if (FilterNoPunctuation) l.Add(new Keyword("no-punctuation"));
            if (FilterNotInBlacklist) l.Add(new Keyword("not-in-blacklist"));
            w.WriteVector(l);
        }
    }

    partial class CloudParameter : IEdnWritable
    {
        public void WriteTo(EdnWriter w)
        {
            w.WriteMap(new object[]
            {
                new Keyword("width"), Width,
                new Keyword("height"), Height,
                new Keyword("precision"), CloudPrecisionAsEdn(),
                new Keyword("order-priority"), OrderPriority,
                new Keyword("min-occurrence"), MinOccurence,
                new Keyword("font-family"), FontFamily.Source,
                new Keyword("font-style"), FontStyleAsEdn(),
                new Keyword("min-font-size"), MinFontSize,
                new Keyword("max-font-size"), MaxFontSize,
                new Keyword("color"), ColorToEdn(Color),
                new Keyword("background-color"), ColorToEdn(BackgroundColor),
            });
        }

        private Keyword CloudPrecisionAsEdn()
        {
            return new Keyword(Precision.ToString().ToLowerInvariant());
        }

        private EdnVector FontStyleAsEdn()
        {
            var l = new List<Keyword>();
            if (FontBold) l.Add(new Keyword("bold"));
            if (FontItalic) l.Add(new Keyword("italic"));
            return new EdnVector(l);
        }

        private static EdnVector ColorToEdn(Color color)
        {
            return new EdnVector(new[]
            {
                (color.R / 255f),
                (color.G / 255f),
                (color.B / 255f),
                (color.A / 255f),
            });
        }
    }

    partial class Media : IEdnWritable
    {
        public void WriteTo(EdnWriter w)
        {
            w.WriteMap(new object[]
            {
                new Keyword("id"), Id,
                new Keyword("name"), Name,
                new Keyword("video-file"), MediaFile,
                new Keyword("recognition-profile"), RecognitionProfile.ToString("D"),
                new Keyword("recognition-profile-name"), RecognitionProfileName,
                new Keyword("audio-file"), AudioFile,
                new Keyword("duration"), Duration,
                new Keyword("waveform-file"), WaveformFile,
                new Keyword("results-file"), ResultsFile,
            });
        }
    }

    partial class Category : IEdnWritable
    {
        public void WriteTo(EdnWriter w)
        {
            w.WriteMap(new object[]
            {
                new Keyword("id"), Id,
                new Keyword("name"), Name,
                new Keyword("resources"), new EdnVector(Resources, true),
            });
        }
    }

    partial class CategoryResource : IEdnWritable
    {
        public void WriteTo(EdnWriter w)
        {
            w.WriteMap(new object[]
            {
                new Keyword("type"), TypeAsEdn(),
                new Keyword("url"), Url,
            }, false);
        }

        private Keyword TypeAsEdn()
        {
            return new Keyword(Type.ToString().ToLowerInvariant());
        }
    }
}
