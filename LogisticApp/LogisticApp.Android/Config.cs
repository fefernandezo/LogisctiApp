﻿using LogisticApp.Interfaces;
using SQLite.Net.Interop;
using Xamarin.Forms;


[assembly: Dependency(typeof(LogisticApp.Android.Config))]
namespace LogisticApp.Android
{
    public class Config : IConfig
    {
        private string directoryDB;
        private ISQLitePlatform platform;

        public string DirectoryDB
        {
            get
            {
                if(string.IsNullOrEmpty(directoryDB))
                {
                    directoryDB = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                }
                return directoryDB;
            }

        }

        public ISQLitePlatform Platform
        {
            get
            {
                if(platform == null)
                {
                    platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
                }
                return platform;
            }
        }
    }
}