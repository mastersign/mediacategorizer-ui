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
                new Keyword("media"), new EdnVector(GetMedia(), true),
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
                        //new Keyword("min-relative-appearance"), MinRelativeAppearance,
                        new Keyword("min-match-score"), MinMatchScore,
                        new Keyword("index-filter"), IndexFilter,
                        new Keyword("visualize-result"), VisualizeResult,
                        new Keyword("show-result"), ShowResult,
                        new Keyword("skip-media-copy"), SkipMediaCopy,
                        new Keyword("skip-wordclouds"), SkipWordClouds,
                        new Keyword("skip-word-includes"), SkipWordIncludes,
                        new Keyword("skip-match-includes"), SkipMatchIncludes,
                        new Keyword("main-cloud"), MainCloud,
                        new Keyword("medium-cloud"), MediaCloud,
                        new Keyword("category-cloud"), CategoryCloud,
                        new Keyword("waveform"), Waveform,
                        new Keyword("matrix"), Matrix,
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
                new Keyword("font-style"), EdnHelper.FontStyleAsEdn(FontBold, FontItalic),
                new Keyword("min-font-size"), MinFontSize,
                new Keyword("max-font-size"), MaxFontSize,
                new Keyword("color"), EdnHelper.ColorToEdn(Color),
                new Keyword("background-color"), EdnHelper.ColorToEdn(BackgroundColor),
            });
        }

        private Keyword CloudPrecisionAsEdn()
        {
            return new Keyword(Precision.ToString().ToLowerInvariant());
        }
    }

    partial class WaveformParameter : IEdnWritable
    {
        public void WriteTo(EdnWriter w)
        {
            w.WriteMap(new object[]
            {
                new Keyword("width"), Width,
                new Keyword("height"), Height,
            }, false);
        }
    }

    partial class MatrixParameter : IEdnWritable
    {
        public void WriteTo(EdnWriter w)
        {
            w.WriteMap(new object[]
            {
                new Keyword("color"), EdnHelper.ColorToEdn(Color),
            }, false);
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
                new Keyword("medium-file"), MediaFile,
                new Keyword("medium-type"), new Keyword(MediaType.ToString().ToLowerInvariant()),
                new Keyword("encoded-media-files"), new EdnVector(EncodedMediaFiles, true),
                new Keyword("recognition-profile"), RecognitionProfile.ToString("D"),
                new Keyword("recognition-profile-name"), RecognitionProfileName,
                new Keyword("extracted-audio-file"), ExtractedAudioFile,
                new Keyword("duration"), Duration,
                new Keyword("waveform-file"), WaveformFile,
                new Keyword("waveform-file-bg"), WaveformFileBackground,
                new Keyword("results-file"), ResultsFile,
            });
        }
    }

    partial class MediaFile : IEdnWritable
    {
        public void WriteTo(EdnWriter w)
        {
            w.WriteMap(new object[]
            {
                new Keyword("mime-type"), MimeType,
                new Keyword("path"), Path,
            }, false);
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
                new Keyword("file"), CachedFile,
            }, false);
        }

        private Keyword TypeAsEdn()
        {
            return new Keyword(Type.ToString().ToLowerInvariant());
        }
    }

    static class EdnHelper
    {
        public static EdnVector ColorToEdn(Color color)
        {
            return new EdnVector(new[]
            {
                (color.R / 255f),
                (color.G / 255f),
                (color.B / 255f),
                (color.A / 255f),
            });
        }

        public static EdnVector FontStyleAsEdn(bool bold, bool italic)
        {
            var l = new List<Keyword>();
            if (bold) l.Add(new Keyword("bold"));
            if (italic) l.Add(new Keyword("italic"));
            return new EdnVector(l);
        }
    }
}
