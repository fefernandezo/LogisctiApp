using SQLite.Net.Interop;

namespace LogisticApp.Interfaces
{
    public interface IConfig
    {
        string DirectoryDB { get; }

        ISQLitePlatform Platform { get; }
    }
}
