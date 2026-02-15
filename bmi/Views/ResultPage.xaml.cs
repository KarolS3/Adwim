using BMICalc.ViewModels;
using System.Collections.Generic;

namespace BMICalc.Views;

public partial class ResultPage : ContentPage
{
    public ResultPage(ResultViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        if (Shell.Current?.CurrentState is { } state
            && state.Location is Uri uri)
        {
            string queryString = string.Empty;

            if (uri.IsAbsoluteUri)
            {
                queryString = uri.Query;
            }
            else
            {
                var s = uri.OriginalString ?? string.Empty;
                var idx = s.IndexOf('?');
                queryString = idx >= 0 ? s.Substring(idx) : string.Empty;
            }

            if (!string.IsNullOrEmpty(queryString))
            {
                var query = ParseQueryString(queryString);
                if (query.TryGetValue("bmi", out var bmiString)
                    && double.TryParse(bmiString, out var bmi)
                    && BindingContext is ResultViewModel vm)
                {
                    vm.Bmi = bmi;
                }
            }
        }
    }

    private static Dictionary<string, string> ParseQueryString(string qs)
    {
        var result = new Dictionary<string, string>();
        var s = (qs ?? string.Empty).TrimStart('?');
        var pairs = s.Split(new[] { '&' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (var p in pairs)
        {
            var idx = p.IndexOf('=');
            if (idx >= 0)
            {
                var k = Uri.UnescapeDataString(p.Substring(0, idx));
                var v = Uri.UnescapeDataString(p.Substring(idx + 1));
                result[k] = v;
            }
            else
            {
                var k = Uri.UnescapeDataString(p);
                result[k] = string.Empty;
            }
        }
        return result;
    }
}