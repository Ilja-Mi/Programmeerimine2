using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
namespace KooliProjekt.Application.Infrastructure.Files
{
    public class LocalFileClient : IFileClient
    {
        private readonly string _filesRoot;
        public LocalFileClient(string filesRoot)
        {
            if (string.IsNullOrWhiteSpace(filesRoot)) throw new ArgumentException("FilesRoot is required.");
            _filesRoot = Path.GetFullPath(filesRoot);
        }
        private string Folder(string store)
        {
            if (string.IsNullOrWhiteSpace(store) || Path.IsPathRooted(store)
                || store.Split('/', '\\').Any(x => !FileRules.SafeName(x)))
                throw new ArgumentException("Invalid file store.");
            return Path.Combine(_filesRoot, store);
        }
        private string FilePath(string name, string store)
        {
            if (!FileRules.SafeName(name)) throw new ArgumentException("Invalid filename.");
            return Path.Combine(Folder(store), name);
        }
        public async Task Save(string fileName, string fileStore, Stream inputStream)
        {
            var path = FilePath(fileName, fileStore);
            Directory.CreateDirectory(Folder(fileStore));
            var temporary = path + "." + Guid.NewGuid().ToString("N") + ".tmp";
            try
            {
                using (var output = new FileStream(temporary, FileMode.CreateNew, FileAccess.Write))
                    await inputStream.CopyToAsync(output);
                File.Move(temporary, path, true);
            }
            finally { if (File.Exists(temporary)) File.Delete(temporary); }
        }
        public Task<bool> Delete(string fileName, string fileStore)
        {
            var path = FilePath(fileName, fileStore);
            if (!File.Exists(path)) return Task.FromResult(false);
            File.Delete(path);
            return Task.FromResult(true);
        }
        public async Task<byte[]> Get(string fileName, string fileStore)
        {
            try { return await File.ReadAllBytesAsync(FilePath(fileName, fileStore)); }
            catch (FileNotFoundException) { return null; }
            catch (DirectoryNotFoundException) { return null; }
        }
        public Task<string[]> List(string fileStore)
        {
            var folder = Folder(fileStore);
            var files = Directory.Exists(folder) ? Directory.GetFiles(folder)
                .Select(Path.GetFileName).Where(FileRules.ImageName).OrderBy(x => x).ToArray() : Array.Empty<string>();
            return Task.FromResult(files);
        }
    }
}
