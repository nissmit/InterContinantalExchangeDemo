
namespace ForeCast.Common
{
    public class AccessData : IAccessData
    {
        public string Folder { get; set; }
        public string Address { get; set; }
        public string AccessKey { get; set; }
        public string PrivateKey { get; set; }

        public bool IsValid()
        {
            return string.IsNullOrEmpty(Folder) ||
                string.IsNullOrEmpty(Address) ||
                string.IsNullOrEmpty(AccessKey) ||
                string.IsNullOrEmpty(PrivateKey);
        }
    }
}
