
namespace ForeCast.Common
{
    public interface IAccessData
    {
        string Folder { get; set; }
        string Address { get; set; }
        string AccessKey { get; set; }
        string PrivateKey { get; set; }
        bool IsValid();
    }
}
