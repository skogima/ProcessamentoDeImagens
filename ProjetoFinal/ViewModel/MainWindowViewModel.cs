using System;
using System.Drawing;
using Microsoft.Win32;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;

namespace ProjetoFinal
{
    public class MainWindowViewModel : BaseViewModel
    {
        private Bitmap originalBitmap;
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
        public string ParametroSelecionado { get; set; }
        public bool IsLoadingPanelVisible { get; set; } = false;
        public string ImagemOriginalResolucao { get; set; } = "0x0";
        public string ImagemProcessadaResolucao { get; set; } = "0x0";
        public List<string> EfeitoItens { get; set; }
        public Bitmap ImagemProcessadaSource { get; set; }
        public RelayCommand AplicarCommand { get; set; }
        public RelayCommand AbrirImagemCommand { get; set; }
        public RelayCommand AlterarTemaCommand { get; set; }
        public RelayCommand SalvarImagemCommand { get; set; }
        public MainWindowViewModel()
        {
            EfeitoItens = ReflectionHelper.GetTypesAssignableFrom<IEfeito>();         

            AplicarCommand = new RelayCommand(AplicarEfeito, () => 
                !string.IsNullOrEmpty(ImagemOriginalSource) && 
                !string.IsNullOrEmpty(EfeitoSelecionado));


            AbrirImagemCommand = new RelayCommand(AbrirImagem);
            AlterarTemaCommand = new RelayCommand(AlterarTema);
            SalvarImagemCommand = new RelayCommand(SalvarImagem);
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
                ImagemProcessadaSource = efeito.AplicarEfeito(originalBitmap, parameter);
            });
            ImagemProcessadaResolucao = $"{ImagemProcessadaSource.Width}x{ImagemProcessadaSource.Height}";
            IsLoadingPanelVisible = false;
        }

        private void DefinirPropriedadesOriginal()
        {
            ImagemOriginalResolucao = $"{originalBitmap.Width}x{originalBitmap.Height}";
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
            originalBitmap = ImagemHelper.ToBitmap(ImagemOriginalSource);
            DefinirPropriedadesOriginal();
            open.Reset();
        }

        private void SalvarImagem()
        {
            var save = new SaveFileDialog
            {
                Filter = "Imagem JPG|*.jpg|Imagem PNG|*.png|Imagem Bitmap|*.bmp|Todos os Arquivos|*.*"
            };
            bool result = save.ShowDialog() ?? false;
            if (!result)
                return;
            ImageFormat format;
            switch (save.FilterIndex)
            {
                case 0:
                    format = ImageFormat.Jpeg;
                    break;     
                case 1:
                    format = ImageFormat.Png;
                    break;
                case 2:
                    format = ImageFormat.Bmp;
                    break;
                default:
                    format = ImageFormat.Jpeg;
                    break;
            }
            using (var stream = new FileStream(save.FileName, FileMode.Create, FileAccess.Write, FileShare.Write))
            {
                ImagemProcessadaSource.Save(stream, format);
            }
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