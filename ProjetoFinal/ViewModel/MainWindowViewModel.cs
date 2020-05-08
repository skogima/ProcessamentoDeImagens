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
        private Bitmap originalBitmap, processadaBitmap;
        private string efeitoSelecionado;
        private bool isLoadingPanelVisibile = false;

        public Bitmap ImagemOriginal
        {
            get => originalBitmap;
            set
            {
                originalBitmap = value;
                ImagemOriginalResolucao = $"{originalBitmap.Width}x{originalBitmap.Height}";
                AplicarCommand.RaiseCanExecuteChanged();
            }
        }
        public Bitmap ImagemProcessada 
        {
            get => processadaBitmap;
            set
            {
                processadaBitmap = value;
                EnviarImagemCommand.RaiseCanExecuteChanged();
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
        public bool IsLoadingPanelVisible
        {
            get => isLoadingPanelVisibile;
            set
            {
                isLoadingPanelVisibile = value;
                AplicarCommand.RaiseCanExecuteChanged();
            }
        }
        private bool calcularHistograma = false;
        public bool CalcularHistograma 
        {
            get => calcularHistograma; 
            set 
            { 
                calcularHistograma = value;
                if (value && ExibirHistograma && HistogramaOriginal.EstaVazio() && HistogramaProcessado.EstaVazio())
                    GerarHistograma();
            } 
        }
        public bool ExibirHistograma { get; set; }
        public string ParametroSelecionado { get; set; }
        public string ImagemOriginalResolucao { get; set; } = "0x0";
        public string ImagemProcessadaResolucao { get; set; } = "0x0";
        public List<string> EfeitoItens { get; set; }
        public RelayCommand AplicarCommand { get; set; }
        public RelayCommand AbrirImagemCommand { get; set; }
        public RelayCommand AlterarTemaCommand { get; set; }
        public RelayCommand SalvarImagemCommand { get; set; }
        public RelayCommand EnviarImagemCommand { get; set; }
        public ParamCommand GirarImagemCommand { get; set; }
        public HistogramaHelper HistogramaOriginal { get; set; }
        public HistogramaHelper HistogramaProcessado { get; set; }

        public MainWindowViewModel()
        {
            EfeitoItens = ReflectionHelper.GetTypesAssignableFrom<IEfeito>();
            HistogramaOriginal = new HistogramaHelper();
            HistogramaProcessado = new HistogramaHelper();

            AplicarCommand = new RelayCommand(AplicarEfeito, () => 
                originalBitmap != null && 
                !string.IsNullOrEmpty(EfeitoSelecionado) &&
                !IsLoadingPanelVisible);

            AbrirImagemCommand = new RelayCommand(AbrirImagem);
            AlterarTemaCommand = new RelayCommand(AlterarTema);
            SalvarImagemCommand = new RelayCommand(SalvarImagem);
            EnviarImagemCommand = new RelayCommand(TrocarImagem, () => ImagemProcessada != null);
            GirarImagemCommand = new ParamCommand(GirarImagem);
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
            HistogramaOriginal.Limpar();
            HistogramaProcessado.Limpar();
            Bitmap processada = null;
            await Task.Run(() =>
            {
                processada = efeito.AplicarEfeito(originalBitmap, parameter);
            });
            ImagemProcessada = processada;
            if (CalcularHistograma)
                await GerarHistograma();
            ImagemProcessadaResolucao = $"{ImagemProcessada.Width}x{ImagemProcessada.Height}";
            IsLoadingPanelVisible = false;
            ExibirHistograma = true;
        }

        private async Task GerarHistograma()
        {
            bool aposEfeito = IsLoadingPanelVisible;
            if (!aposEfeito)
                IsLoadingPanelVisible = true;

            await Task.Run(() =>
            {
                HistogramaOriginal.Calcular(originalBitmap);
                HistogramaProcessado.Calcular(processadaBitmap);
            });

            if (!aposEfeito)
                IsLoadingPanelVisible = false;
        }

        private async void GirarImagem(object obj)
        {
            IsLoadingPanelVisible = true;
            Bitmap bitmap = null;
            await Task.Run(() =>
            {
                bitmap = Girar.AplicarEfeito(originalBitmap, obj);
            });
            ImagemOriginal = bitmap;
            IsLoadingPanelVisible = false;
        }

        private void AbrirImagem()
        {
            OpenFileDialog open = new OpenFileDialog
            {
                Filter = "Arquivos de Imagens|*.png;*.jpg;*.jpeg;*.gif;*.bmp|Todos os Arquivos|*.*"
            };
            bool result = open.ShowDialog() ?? false;
            if (!result)
                return;

            ImagemOriginal = ImagemHelper.ToBitmap(open.FileName);
            ExibirHistograma = false;
            open.Reset();
        }

        private void TrocarImagem()
        {
            ImagemOriginal.Dispose();
            ImagemOriginal = ImagemProcessada;
            CalcularHistograma = false;
            ImagemProcessada = null;
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
                ImagemProcessada.Save(stream, format);
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