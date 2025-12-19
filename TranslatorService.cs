using System.Collections.Generic;
using System.Threading.Tasks;

namespace MLTranslatorWinForms
{
    public class TranslatorService
    {
        private Dictionary<string, Dictionary<string, string>> trToEn =
            new Dictionary<string, Dictionary<string, string>>()
            {
                {
                    "tr", new Dictionary<string, string>()
                    {
                        { "merhaba", "hello" },
                        { "nasılsın", "how are you" },
                        { "günaydın", "good morning" },
                        { "iyi geceler", "good night" }
                    }
                }
            };

        private Dictionary<string, Dictionary<string, string>> enToTr =
            new Dictionary<string, Dictionary<string, string>>()
            {
                {
                    "en", new Dictionary<string, string>()
                    {
                        { "hello", "merhaba" },
                        { "how are you", "nasılsın" },
                        { "good morning", "günaydın" },
                        { "good night", "iyi geceler" }
                    }
                }
            };

        public Task<string> TranslateAsync(string text, string targetLanguage)
        {
            text = text.ToLower().Trim();

            // Türkçe → İngilizce
            if (targetLanguage == "en")
            {
                if (trToEn["tr"].ContainsKey(text))
                    return Task.FromResult(trToEn["tr"][text]);
            }

            // İngilizce → Türkçe
            if (targetLanguage == "tr")
            {
                if (enToTr["en"].ContainsKey(text))
                    return Task.FromResult(enToTr["en"][text]);
            }

            return Task.FromResult("[Çeviri bulunamadı]");
        }
    }
}
