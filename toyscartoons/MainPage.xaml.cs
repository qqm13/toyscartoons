namespace toyscartoons
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {           
            InitializeComponent();
        }       

        private async void Button_Clicked_AddCartoon(object sender, EventArgs e)
        {
            //NewPage2 AddToy = new NewPage2(Db);
            //await Navigation.PushAsync(AddToy);

        
            await Shell.Current.GoToAsync("//NewPage2");
        }

        private async void Button_Clicked_Programm(object sender, EventArgs e)
        {
            //N3 show = new N3(Db);
            //await Navigation.PushAsync(show);
            
            await Shell.Current.GoToAsync("//N3");
        }

        public async void Button_Clicked_AddToy(object sender, EventArgs e)
        {
            //NewPage1 AddToy = new NewPage1(Db);
            //await Navigation.PushAsync(AddToy);
           
            await Shell.Current.GoToAsync("//NewPage1");
        }       
    }
}
