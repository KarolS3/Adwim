using BMICalc.Views;

namespace BMICalc
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            var services = Application.Current?.Services;
            if (services != null)
            {
                var formPage = services.GetService<FormPage>();
                if (formPage != null)
                {
                    Items.Add(new ShellContent { Content = formPage, Route = "FormPage" });
                }
            }
        }
    }
}

