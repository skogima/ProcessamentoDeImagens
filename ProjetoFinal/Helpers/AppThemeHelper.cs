using System;
using System.Linq;
using System.Windows;

namespace ProjetoFinal
{
    public partial class AppThemeHelper
    {
        private static AppTheme defaultTheme = AppTheme.Light;
        public static AppTheme GetTemaAtual()
        {
            AppTheme atual = Application.Current.Resources.MergedDictionaries[0].Source.ToString()
                .Contains(Enum.GetName(typeof(AppTheme), defaultTheme))
                ? AppTheme.Light : AppTheme.Dark; 
            
            return atual;
        }

        public static void MudarTema(AppTheme novoTema)
        {
            AppTheme atual = GetTemaAtual();
            var dictionaries = Application.Current.Resources.MergedDictionaries.
                Where(x => x.Source.ToString().Contains(Enum.GetName(typeof(AppTheme), atual)));
            foreach (var dictionary in dictionaries)
            {
                string s = dictionary.Source.ToString();
                dictionary.Source = new Uri(dictionary.Source.ToString()
                    .Replace(Enum.GetName(typeof(AppTheme), atual), Enum.GetName(typeof(AppTheme), novoTema)));
            }

        }
    }
}
