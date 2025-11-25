using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;


namespace toyscartoons;

public partial class Auth : ContentPage
{
    public User UserHere { get; set; } = new User();
    public List<User> Users { get; set; }
    public Auth()
    {
        InitializeComponent();
        BindingContext = this;
    }
    private async void Autho(object sender, EventArgs e)
    {
        Users = await (await DB.GetDBAsync()).GetUsers();
        foreach (var user in Users)
        {
            if (user.Login == UserHere.Login&&user.Password == UserHere.Password) 
            {
                await Shell.Current.GoToAsync("///MainPage");
                break;
            }
        }
       // await DisplayAlert("Alert", "Incorrect Login or Password", "OK")
    }

    private async void Registration(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///Register");
    }
}