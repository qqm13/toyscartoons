using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;


namespace toyscartoons;

public partial class N3 : ContentPage
{
    public int RequestId { get; set; } = 0;
    
         public int RequestIdDoll { get; set; } = 0;

    private List<Cartoon> cartoons = new List<Cartoon>();
    public List<Cartoon> Cartoons
    {
        get => cartoons;
        set { cartoons = value; OnPropertyChanged(); }
    }

    private List<Cartoon> cartoonsShow = new List<Cartoon>();
    public List<Cartoon> CartoonsShow
    {
        get => cartoonsShow;
        set { cartoonsShow = value; OnPropertyChanged(); }
    }
    private List<Doll> dollsShow = new List<Doll>();
    public List<Doll> DollsShow
    {
        get => dollsShow;
        set { dollsShow = value; OnPropertyChanged(); }
    }
    private List<Doll> dolls = new List<Doll>();
    public DB Db { get; set; } = new DB();


    public List<Doll> Dolls
    {
        get => dolls;
        set { dolls = value; OnPropertyChanged(); }
    }

    public N3(DB dB)
    {
        InitializeComponent();
        Db = dB;
        LoadList();
        BindingContext = this;

    }

    private async void Show(object sender, EventArgs e)
    {
        CartoonsShow = Cartoons.Where(s => s.Id == RequestId).ToList();
    }
    public async void LoadList()
    {
        Dolls = await Db.LoadDoll();
        Cartoons = await Db.LoadCartoons();
    }

    private void ShowDoll(object sender, EventArgs e)
    {
        DollsShow = Dolls.Where(s => s.Id == RequestIdDoll).ToList();
    }
}