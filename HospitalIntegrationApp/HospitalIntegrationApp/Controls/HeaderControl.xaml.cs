using System.Windows;
using System.Windows.Controls;

namespace HospitalIntegrationApp.Controls
{
    public partial class HeaderControl : UserControl
    {
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
            name: "Title",
            propertyType: typeof(string),
            ownerType: typeof(HeaderControl),
            typeMetadata: new PropertyMetadata(""));

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public HeaderControl()
        {
            InitializeComponent();
        }
    }
}






