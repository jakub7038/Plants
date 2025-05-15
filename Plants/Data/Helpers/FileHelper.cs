using System.IO;

namespace Plants.Data.Helpers
{
    public static class FileHelper
    {
        public static byte[] LoadPhoto(string filePath, int maxBytes = 1_048_576)
        {
            var fileBytes = File.ReadAllBytes(filePath);
            if (fileBytes.Length > maxBytes)
            {
                throw new InvalidOperationException("Plik jest za duży (max 1 MB).");
            }
            return fileBytes;
        }
    }
}
