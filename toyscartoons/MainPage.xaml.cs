using System.Threading.Tasks;

namespace toyscartoons
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        public DB Db { get; set; } = new DB();
        public MainPage()
        {
            InitializeComponent();
            
        }


       

        private async void Button_Clicked_AddCartoon(object sender, EventArgs e)
        {
            NewPage2 AddToy = new NewPage2(Db);
            await Navigation.PushAsync(AddToy);
        }

        private async void Button_Clicked_Programm(object sender, EventArgs e)
        {
            N3 show = new N3(Db);
            await Navigation.PushAsync(show);
        }

        public async void Button_Clicked_AddToy(object sender, EventArgs e)
        {
            NewPage1 AddToy = new NewPage1(Db);
            await Navigation.PushAsync(AddToy);

        }
    }
}
