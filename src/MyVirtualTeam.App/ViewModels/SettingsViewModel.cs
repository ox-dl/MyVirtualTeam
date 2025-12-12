using Microsoft.Win32;
using System;
using System.Windows;
using System.Diagnostics;
using System.Runtime.Versioning;

namespace MyVirtualTeam.App.ViewModels
{
    [SupportedOSPlatform("windows")]
    public class SettingsViewModel : BaseViewModel
    {
        private class ThemeManager
        {
            public string CurrentTheme { get; private set; }

            public ThemeManager()
            {
                CurrentTheme = GetSystemTheme();
                ApplyTheme(CurrentTheme);
            }

            private static string GetSystemTheme()
            {
                var registryKey = Registry.CurrentUser.OpenSubKey(
                    @"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize");

                if (registryKey != null)
                {
                    var value = registryKey.GetValue("AppsUseLightTheme");
                    if (value != null && (int)value == 1)
                        return "Light";
                }

                return "Light";
            }

            public void ChangeTheme(string theme)
            {
                ApplyTheme(theme);
                CurrentTheme = theme;
            }

            private static void ApplyTheme(string theme)
            {
                var currentResources = Application.Current.Resources.MergedDictionaries;

                var themeDictionary = currentResources
                    .FirstOrDefault(d => d.Source != null
                    && (d.Source.OriginalString.EndsWith("LightTheme.xaml")
                    || d.Source.OriginalString.EndsWith("DarkTheme.xaml"))
                    );

                if (themeDictionary != null)
                    currentResources.Remove(themeDictionary);

                string uri = theme == "Light"
                    ? "/Style/LightTheme.xaml"
                    : "/Style/DarkTheme.xaml";

                Debug.WriteLine($"The current theme is : {theme}");

                currentResources.Add(new ResourceDictionary
                {
                    Source = new Uri(uri, UriKind.RelativeOrAbsolute)
                });
            }
        }

        private readonly ThemeManager _themeManager;
        private string _currentTheme;

        public string CurrentTheme
        {
            get => _currentTheme;
            set
            {
                if (_currentTheme != value)
                {
                    _currentTheme = value;
                    OnPropertyChanged(nameof(CurrentTheme));
                    _themeManager.ChangeTheme(_currentTheme);
                }
            }
        }

        public SettingsViewModel()
        {
            _themeManager = new ThemeManager();
            _currentTheme = _themeManager.CurrentTheme;
        }
    }
}
