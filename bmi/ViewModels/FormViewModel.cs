using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace BMICalc.ViewModels;

public class FormViewModel : INotifyPropertyChanged
{
    private string weight = string.Empty;
    public string Weight
    {
        get => weight;
        set
        {
            if (weight != value)
            {
                weight = value;
                OnPropertyChanged();
                ((Command)CalculateCommand).ChangeCanExecute();
            }
        }
    }

    private string height = string.Empty;
    public string Height
    {
        get => height;
        set
        {
            if (height != value)
            {
                height = value;
                OnPropertyChanged();
                ((Command)CalculateCommand).ChangeCanExecute();
            }
        }
    }

    public ICommand CalculateCommand { get; }

    public FormViewModel()
    {
        CalculateCommand = new Command(
            execute: async () => await Calculate(),
            canExecute: () => CanCalculate()
        );
    }

    private async Task Calculate()
    {
        double w = double.Parse(Weight);
        double h = double.Parse(Height) / 100.0;

        double bmi = w / (h * h);

        await Shell.Current.GoToAsync($"ResultPage?bmi={bmi}");
    }

    private bool CanCalculate()
    {
        return !string.IsNullOrWhiteSpace(Weight)
            && !string.IsNullOrWhiteSpace(Height);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string? name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}

