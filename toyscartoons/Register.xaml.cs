using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;


namespace toyscartoons;

public partial class Register : ContentPage
{

    public User UserHere { get; set; } = new User();

    public Register()
    {
        InitializeComponent();       
        BindingContext = this;
    }

    private async void Registration(object sender, EventArgs e)
    {
        await (await DB.GetDBAsync()).AddUser(UserHere);
        await Shell.Current.GoToAsync("///Auth");
    }
}