using SQLite.Net.Interop;

namespace LogisticApp.Interfaces
{
    interface IConfig
    {
        string DirectoryDB { get; }

        ISQLitePlatform Platform { get; }
    }
}
