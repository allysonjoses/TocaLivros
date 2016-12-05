using Plugin.Settings.Abstractions;
using Plugin.Settings;
using System;

namespace TocaLivros.Core.Helpers
{
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private const string SettingsKey = "settings_key";
        private static readonly string SettingsDefault = string.Empty;

        #endregion

        public static string GeneralSettings
        {
            get
            {
                return AppSettings.GetValueOrDefault<string>(SettingsKey, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue<string>(SettingsKey, value);
            }
        }

        public static string Usuario
        {
            get { return AppSettings.GetValueOrDefault<string>("usuario_setting", string.Empty); }
            set { AppSettings.AddOrUpdateValue<string>("usuario_setting", value); }
        }

        public static string Token
        {
            get { return AppSettings.GetValueOrDefault<string>("token_setting", string.Empty); }
            set { AppSettings.AddOrUpdateValue<string>("token_setting", value); }
        }

        public static string AdressAPI
        {
            get { return AppSettings.GetValueOrDefault<string>("adressAPI", "http://192.168.0.212:1234/"); }
            set { AppSettings.AddOrUpdateValue<string>("adressAPI", value); }
        }

        //Armazena a data do login para deslogar a aplicação automaticamente após 1 dia
        public static DateTime DataLogin
        {
            get { return AppSettings.GetValueOrDefault<DateTime>("data_login", DateTime.Now); }
            set { AppSettings.AddOrUpdateValue<DateTime>("data_login", value); }
        }

        public static void Login(string usuario, string token)
        {
            Usuario = usuario;
            Token = token;
            DataLogin = DateTime.Now;
        }

        public static void Logout()
        {
            Usuario = string.Empty;
            Token = string.Empty;
        }

        public static bool IsAuthenticated()
        {
            if (Usuario != string.Empty && Token != string.Empty && DataLogin >= DateTime.Now.AddHours(-24)) return true;
            else
            {
                Logout();
                return false;
            }
        }
    }
}