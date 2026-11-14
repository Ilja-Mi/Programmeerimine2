using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
namespace KooliProjekt.Application.Infrastructure.Files
{
    public static class FileRules
    {
        public const long MaxBytes = 10 * 1024 * 1024;
        public static bool SafeName(string name) => !string.IsNullOrWhiteSpace(name)
            && name.Length <= 150 && Regex.IsMatch(name, @"\A[a-zA-Z0-9][a-zA-Z0-9_.-]*\z")
            && !name.Contains("..") && !name.EndsWith(".")
            && !Regex.IsMatch(name, @"\A(CON|PRN|AUX|NUL|COM[1-9]|LPT[1-9])(\.|$)", RegexOptions.IgnoreCase);
        public static bool ImageName(string name) => SafeName(name)
            && new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp" }.Contains(Path.GetExtension(name).ToLowerInvariant());
        public static string ContentType(string name) => Path.GetExtension(name).ToLowerInvariant() switch
        {
            ".jpg" or ".jpeg" => "image/jpeg", ".png" => "image/png",
            ".gif" => "image/gif", ".webp" => "image/webp", _ => "application/octet-stream"
        };
        public static bool ValidStream(Stream stream) => stream != null && stream.CanRead && stream.CanSeek
            && stream.Length > 0 && stream.Length <= MaxBytes && stream.Position == 0;
    }
}
