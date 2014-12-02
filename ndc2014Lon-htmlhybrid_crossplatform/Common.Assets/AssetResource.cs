using System.IO;
using System.Text;

namespace Common.Assets
{
    public class AssetResource
    {
        public string MimeType { get; set; }
        public MemoryStream Resource { get; set; }
        
        public AssetResource(string mimeType, string content)
        {
            this.MimeType = mimeType;
            Resource = new MemoryStream(Encoding.ASCII.GetBytes(content));
        }
    }
}