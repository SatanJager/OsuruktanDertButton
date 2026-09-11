using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OsuruktanDertButton
{
    public static class ComplaintStore
    {
        private static readonly string StorageFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "OsuruktanDertButton");
        private static readonly string StorageFile = Path.Combine(StorageFolder, "complaints.txt");
        private const string RecordSeperator = "-----";

        public static void EnsureStorageExists()
        {
            if (!Directory.Exists(StorageFolder))
            {
                Directory.CreateDirectory(StorageFolder);
            }
            if (!File.Exists(StorageFile))
            {
                File.WriteAllText(StorageFile, string.Empty, Encoding.UTF8);
            }
        }
        public static void AddComplaint(string complaintText)
        {
            EnsureStorageExists();

            var entry = new StringBuilder();
            entry.AppendLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] - {complaintText.Trim()}");
            entry.AppendLine(RecordSeperator);

            File.AppendAllText(StorageFile, entry.ToString(), Encoding.UTF8);
        }
        public static List<string> GetAllComplaints()
        {
            EnsureStorageExists();

            var rawText = File.ReadAllText(StorageFile, Encoding.UTF8);
            if (string.IsNullOrWhiteSpace(rawText)) 
            {
                return new List<string>();
            }

            return rawText
                .Split(RecordSeperator, StringSplitOptions.RemoveEmptyEntries)
                .Select(block => block.Trim())
                .Where(block => !string.IsNullOrWhiteSpace(block))
                .ToList();
        }
        public static void ClearAll()
        {
            EnsureStorageExists();
            File.WriteAllText(StorageFile, string.Empty, Encoding.UTF8);
        }
        //ClearAll() — HistoryForm'daki "Geçmişi Temizle" butonu bunu çağıracak. File.WriteAllText(StorageFile, string.Empty, ...) — dosyanın üzerine boş bir string yazarak içeriği sıfırlıyor (bu, AddComplaint'teki AppendAllText'ten farklı — o sona ekliyordu, bu üzerine yazıyor/temizliyor).
        //GetStorageFilePath() => StorageFile; — dışarıdan (örneğin ileride bir "dosyayı Explorer'da göster" özelliği eklemek istersen) dosya yolunu okuyabilmek için küçük bir yardımcı metot. StorageFile alanı private olduğu için dışarıdan direkt erişilemiyor, bu metot ona kontrollü bir "pencere" açıyor.

        public static string GetStorageFilePath() => StorageFile;
    }
}
