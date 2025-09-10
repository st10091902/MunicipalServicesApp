using System.IO;

namespace MunicipalServicesApp
{
    public class Attachment
    {
        public string FilePath { get; set; }
        public string FileName => Path.GetFileName(FilePath);
    }
}
