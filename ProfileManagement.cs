using System;
using System.Linq;
using Microsoft.Win32;

namespace de.fhb.oll.mediacategorizer
{
    class ProfileManagement
    {
        public static Tuple<Guid, string>[] GetSpeechRecognitionProfiles()
        {
            var tokensKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Speech\RecoProfiles\Tokens");
            if (tokensKey == null) throw new ApplicationException("Could not find any speech recognition profiles.");
            var tokens = tokensKey.GetSubKeyNames();
            return tokens
                .Select(tn => Tuple.Create(
                    Guid.Parse(tn),
                    tokensKey.OpenSubKey(tn).GetValue(string.Empty) as string))
                .ToArray();
        }

        public static Guid GetCurrentSpeechRecognitionProfileId()
        {
            var recoProfilesKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Speech\RecoProfiles");
            if (recoProfilesKey == null) throw new ApplicationException("Could not find a default speech recognition profile.");
            var path = recoProfilesKey.GetValue("DefaultTokenId") as string;
            var guid = path.Substring(path.LastIndexOf('\\') + 1);
            return Guid.Parse(guid);
        }

        public static void SetCurrentSpeechRecognitionProfile(Guid id)
        {
            var recoProfilesKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Speech\RecoProfiles", true);
            if (recoProfilesKey == null) throw new ApplicationException("Could not find a default speech recognition profile.");
            var path = string.Format(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Speech\RecoProfiles\Tokens\{0:B}", id);
            recoProfilesKey.SetValue("DefaultTokenId", path);
            recoProfilesKey.Flush();
        }
    }
}