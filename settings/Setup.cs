using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace de.fhb.oll.mediacategorizer.settings
{
    partial class Setup
    {
        private static readonly char[] separator = { ' ' };

        public string[] GetAudioFileExtensions()
        {
            var audioExts = CompatibleAudioFileExtensions
                .Split(separator, StringSplitOptions.RemoveEmptyEntries)
                .Select(e => e.ToLowerInvariant())
                .ToArray();
            return audioExts;
        }

        public string[] GetVideoFileExtensions()
        {
            var audioExts = CompatibleVideoFileExtensions
                .Split(separator, StringSplitOptions.RemoveEmptyEntries)
                .Select(e => e.ToLowerInvariant())
                .ToArray();
            return audioExts;
        }
    }
}
