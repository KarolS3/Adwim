using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BMICalc.ViewModels;

public class ResultViewModel : INotifyPropertyChanged
{
    private double bmi;
    public double Bmi
    {
        get => bmi;
        set
        {
            if (bmi != value)
            {
                bmi = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Category));
                OnPropertyChanged(nameof(CategoryColor));
            }
        }
    }

    public string Category =>
        bmi < 18.5 ? "Niedowaga" :
        bmi < 25 ? "W normie" :
        bmi < 30 ? "Nadwaga" :
        "Otyłość";

    public string CategoryColor =>
        bmi >= 30 ? "Red" :
        bmi < 18.5 || bmi >= 25 ? "Orange" :
        "Green";

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string? name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
