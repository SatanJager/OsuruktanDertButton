using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace OsuruktanDertButton
{
    public enum Language
    {
        Turkish,
        English,
        German
        // enum (enumeration / numaralandırma) — sabit, önceden bilinen bir seçenekler kümesini temsil eder. Arka planda aslında birer sayıdır: Turkish = 0, English = 1, German = 2 (biz elle yazmadık ama C# otomatik böyle numaralandırır, sırayla). MainForm'da SelectedIndex switch { 0 => Language.Turkish, ... } yazarken bu sıralamayı kullanmıştık — o yüzden enum'daki sıra önemli, ComboBox'a eklediğimiz "Türkçe", "English", "Deutsch" sırasıyla birebir eşleşiyor olmalı.
        //string yerine neden enum kullandık? Çünkü Language.German yazınca derleyici yazım hatalarını ("german", "Almanca", "DE" gibi tutarsızlıkları) daha yazarken yakalar. String kullansaydık, bir yerde "German" bir yerde "Deutsch" yazıp fark etmeyebilirdik.
    }
    public static class Localization
    {
        public static readonly Dictionary<Language, string> WindowTitle = new()
        {
            [Language.Turkish] = "Osuruktan Dert Buttonu",
            [Language.English] = "Fart-Grade Problem Button",
            [Language.German] = "Furzhafter-Problem-Knopf"
        };
        public static readonly Dictionary<Language, string> PromptLabel = new()
        {
            [Language.Turkish] = "Derdinizi buraya yazın:",
            [Language.English] = "Type your problem here:",
            [Language.German] = "Schreiben Sie Ihr Problem hier:"
        };
        public static readonly Dictionary<Language, string> SolveButton = new()
        {
            [Language.Turkish] = "Çözüm",
            [Language.English] = "Solve",
            [Language.German] = "Lösung"
        };
        public static readonly Dictionary<Language, string> ResultMessage = new()
        {
            [Language.Turkish] = "Derdiniz çok osuruktan bulundu. Çözüm gerekmiyor.",
            [Language.English] = "Your problem has been classified as fart-grade trivial. No solution requied.",
            [Language.German] = "Ihr Problem wurde als furzig unbedeutend eingestuft. Keine Lösung nötig."
        };
        public static readonly Dictionary<Language, string> EmptyInputWarning = new()
        {
            [Language.Turkish] = "Önce bir dert yazmalısınız",
            [Language.English] = "You need to type a problem first.",
            [Language.German] = "Sie müssen zuerst ein Problem eingeben."
        };
        public static readonly Dictionary<Language, string> HistoryButton = new()
        {
            [Language.Turkish] = "Önceki Dertlerim",
            [Language.English] = "My Previous Problems",
            [Language.German] = "Meine bisherige Sorgen"
        };
        public static readonly Dictionary<Language, string> HistoryWindowTitle = new()
        {
            [Language.Turkish] = "Önceki Dertlerim",
            [Language.English] = "My Previous Problems",
            [Language.German ] = "Meine bisherigen Sorgen"
        };
        public static readonly Dictionary<Language, string> HistoryEmpty = new()
        {
            [Language.Turkish] = "Henüz kayıtlı bir derdiniz yok.",
            [Language.English] = "You have no recorded problems yet.",
            [Language.German] = "Sie haben noch keine gespeicherten Probleme."
        };
        public static readonly Dictionary<Language, string> ClearHistoryButton = new()
        {
            [Language.Turkish] = "Geçmişi Temizle",
            [Language.English] = "Clear History",
            [Language.German] = "Verlauf löschen"
        };
        public static readonly Dictionary<Language, string> LanguageLabel = new()
        {
            [Language.Turkish] = "Dil:",
            [Language.English] = "Language:",
            [Language.German] = "Sprache:"
        };
        public static readonly Dictionary<Language, string> CloseHistoryButton = new()
        {
            [Language.Turkish] = "Kapat",
            [Language.English] = "Close",
            [Language.German] = "Schließen"
        };


        public static string Get(Dictionary<Language, string> dict, Language lang) => dict.TryGetValue(lang, out var value) ? value : dict[Language.English];

        //public static string Get(...) — bu, MainForm'da defalarca çağırdığımız Localization.Get(Localization.WindowTitle, _currentLanguage) metodu. İki parametre alıyor: hangi sözlükten bakacağımız (dict) ve hangi dilde istediğimiz (lang).=> ile başlayan gövde — bu bir expression - bodied member, yani { return ...; }
        //yazmak yerine kısaltılmış tek satırlık metot yazımı. public static string Get(...) => ifade; ile public static string Get(...) { return ifade; } tamamen aynı işi yapar. dict.TryGetValue(lang, out var value) — sözlükte lang anahtarını arar.Bulursa true döner ve bulduğu değeri value değişkenine yazar (bu out parametresi — metodun "ayrıca bir değer daha döndürmesini" sağlıyor). Bulamazsa false döner, value boş kalır.
        //? value : dict[Language.English] — bu bir ternary operator (üçlü koşul operatörü): "eğer bulunduysa value'yu kullan, bulunamadıysa dict[Language.English]'i kullan" demek.Yani ileride 4.bir dil eklersen ve o dilin çevirisini bir sözlüğe eklemeyi unutursan, program çökmez — İngilizce'ye otomatik "geri düşer" (fallback). Bu küçük ama önemli bir güvenlik önlemi.
    }
}
