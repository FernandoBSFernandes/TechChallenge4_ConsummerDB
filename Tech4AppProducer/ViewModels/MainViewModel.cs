using MassTransit;
using Tech4AppProducer.Services;

namespace Tech4AppProducer.ViewModels;

public partial class MainViewModel : INotifyPropertyChanged //BaseViewModel
{
    private string _name;
    private string _email;

    public string Name
    {
        get => _name;
        set
        {
            _name = value; PropertyChanged(this, new PropertyChangedEventArgs("Name"));
        }
    }

    public string Email
    {
        get => _email;
        set
        {
            _email = value; PropertyChanged(this, new PropertyChangedEventArgs("Email"));
        }
    }

    IConnectivity connectivity;    
    public Command SubmitForm => new(async () => await SendInformationsAsync());
    bool IsBusy = false;

    public event PropertyChangedEventHandler? PropertyChanged;

    public MainViewModel()
    {
        connectivity = DependencyService.Get<IConnectivity>();
    }
    [RelayCommand]
    async Task SendInformationsAsync()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;

            await CadastroService.EnviarCadastro(Name, Email);
            await Shell.Current.DisplayAlert("Sucesso!", "Cadastro enviado com sucesso!", "OK");
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Erro!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
}
