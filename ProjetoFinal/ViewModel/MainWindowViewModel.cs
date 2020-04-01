using System;
using System.Drawing;
using Microsoft.Win32;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ProjetoFinal
{
    public class MainWindowViewModel : BaseViewModel
    {
        private string imagemOriginalSource;
        private string efeitoSelecionado;

        public string ImagemOriginalSource
        {
            get => imagemOriginalSource;
            set
            {
                imagemOriginalSource = value;
                AplicarCommand.RaiseCanExecuteChanged();
            }
        }
        public string EfeitoSelecionado
        {
            get => efeitoSelecionado;
            set
            {
                efeitoSelecionado = value;
                AplicarCommand.RaiseCanExecuteChanged();
            }
        }
        public bool IsLoadingPanelVisible { get; set; } = false;
        public string ParametroSelecionado { get; set; }
        public string ImagemOriginalResolucao { get; set; } = "0x0";
        public string ImagemProcessadaResolucao { get; set; } = "0x0";
        public List<string> EfeitoItens { get; set; }
        public Bitmap ImagemProcessadaSource { get; set; }
        public RelayCommand AplicarCommand { get; set; }
        public RelayCommand AbrirImagemCommand { get; set; }
        public RelayCommand AlterarTemaCommand { get; set; }

        public MainWindowViewModel()
        {
            EfeitoItens = ReflectionHelper.GetTypesAssignableFrom<IEfeito>();         

            AplicarCommand = new RelayCommand(AplicarEfeito, () => 
                !string.IsNullOrEmpty(ImagemOriginalSource) && 
                !string.IsNullOrEmpty(EfeitoSelecionado));
            AbrirImagemCommand = new RelayCommand(AbrirImagem);
            AlterarTemaCommand = new RelayCommand(AlterarTema);
        }

        private void AplicarEfeito()
        {
            var tipo = ReflectionHelper.GetTypeByName(EfeitoSelecionado);
            AplicarEfeito((IEfeito)Activator.CreateInstance(tipo), ParametroSelecionado);
            AplicarCommand.RaiseCanExecuteChanged();
        }

        private async void AplicarEfeito(IEfeito efeito, object parameter)
        {
            IsLoadingPanelVisible = true;
            await Task.Run(() => 
            {
                ImagemProcessadaSource = efeito.AplicarEfeito(ImagemHelper.ToBitmap(ImagemOriginalSource), parameter);
            });
            ImagemProcessadaResolucao = $"{ImagemProcessadaSource.Width}x{ImagemProcessadaSource.Height}";
            IsLoadingPanelVisible = false;
        }

        private void DefinirPropriedadesOriginal()
        {
            var bmp = ImagemHelper.ToBitmap(ImagemOriginalSource);
            ImagemOriginalResolucao = $"{bmp.Width}x{bmp.Height}";
            bmp.Dispose();
        }

        private void AbrirImagem()
        {
            OpenFileDialog open = new OpenFileDialog
            {
                Filter = "Arquivos de Imagens|*.png;*.jpg;*.jpeg;*.gif|Todos os Arquivos|*.*"
            };
            bool result = open.ShowDialog() ?? false;
            if (!result)
                return;
            ImagemOriginalSource = open.FileName;
            DefinirPropriedadesOriginal();
        }

        private void AlterarTema()
        {
            var tema = AppThemeHelper.GetTemaAtual();
            if (tema == AppTheme.Light)
                tema = AppTheme.Dark;
            else
                tema = AppTheme.Light;
            AppThemeHelper.MudarTema(tema);
        }
    }
}