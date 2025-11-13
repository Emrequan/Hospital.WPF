using HospitalIntegrationApp.Application;
using HospitalIntegrationApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace HospitalIntegrationApp
{
    public partial class MainWindow : Window
    {
        private readonly IIntegrationService _integrationService = new IntegrationService();
        public MainWindow()
        {
            InitializeComponent();
        }



        private void BtnGetir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
        
                var allPatients = _integrationService.GetAllPatients();
                dataGrid.ItemsSource = allPatients;
                StatusText.Text = $"Toplam {allPatients.Count} hasta getirildi";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                StatusText.Text = "Hata oluştu";
            }
        }

        private void BtnToMaster_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StatusText.Text = "Master DB'ye aktarılıyor...";

                var items = dataGrid.ItemsSource as IEnumerable<Hasta> ?? Enumerable.Empty<Hasta>();
                var list = items.ToList();
                if (!list.Any())
                {
                    MessageBox.Show("Aktarılacak kayıt bulunamadı.", "Bilgi", MessageBoxButton.OK, MessageBoxImage.Information);
                    StatusText.Text = "Aktarılacak kayıt yok";
                    return;
                }

                _integrationService.SavePatientsToMaster(list);

                MessageBox.Show($"{list.Count} kayıt Master DB'ye aktarıldı.", "Bilgi", MessageBoxButton.OK, MessageBoxImage.Information);
                StatusText.Text = "Master DB'ye aktarım tamamlandı";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                StatusText.Text = "Hata oluştu";
            }
        }

        private void BtnTemizle_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = null;
            StatusText.Text = "Temizlendi";
        }

        private void BtnCks_Click(object sender, RoutedEventArgs e)
        {
            StatusText.Text = "Çıkış";
            var loginWindow = new LoginWindow();
            loginWindow.Show();

            // WPF Application sınıfını tam nitelikli kullanarak MainWindow'u güncelle
            System.Windows.Application.Current.MainWindow = loginWindow;

            this.Close();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
