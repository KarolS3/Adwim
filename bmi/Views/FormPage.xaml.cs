using BMICalc.ViewModels;

namespace BMICalc.Views;

public partial class FormPage : ContentPage
{
    public FormPage(FormViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
    
}