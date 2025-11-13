using System;
using System.Windows;
using HospitalIntegrationApp.Services;
using HospitalIntegrationApp.Factory;

namespace HospitalIntegrationApp
{
    public partial class LoginWindow : Window
    {
        private readonly HospitalIntegrationApp.Services.AuthenticationService _auth;

        public LoginWindow()
        {
            InitializeComponent();
            _auth = new HospitalIntegrationApp.Services.AuthenticationService(new MasterDbFactory());
            txtUsername.Focus();
        }


        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Password;

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Kullanıcı adı ve şifre boş olamaz!", "Uyarı", 
                                  MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (_auth.ValidateUser(username, password, out var user))
                {
                    StatusText.Text = "Giriş başarılı, ana sayfa açılıyor...";
                    
                    
                    var mainWindow = new MainWindow();
                    System.Windows.Application.Current.MainWindow = mainWindow;
                    mainWindow.Show();
                    
                    
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı!", "Hata", 
                                  MessageBoxButton.OK, MessageBoxImage.Error);
                    StatusText.Text = "Giriş başarısız";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Giriş sırasında hata oluştu: {ex.Message}", "Hata", 
                              MessageBoxButton.OK, MessageBoxImage.Error);
                StatusText.Text = "Hata oluştu";
            }
        }

        // DB tabanlı doğrulama LoginWindow dışına taşındı (AuthenticationService)
    }
}
