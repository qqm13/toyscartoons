using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace toyscartoons;

public partial class NewPage1 : ContentPage
{
    public int DeleteId { get; set; } = 0;

    private List<Cartoon> cartoons = new List<Cartoon>();
    public List<Cartoon> Cartoons
    {
        get => cartoons;
        set { cartoons = value; OnPropertyChanged(); }
    }
    public Doll DollHere { get; set; } = new Doll();

    private List<Doll> dolls = new List<Doll>();
    public DB Db { get; set; } = new DB();

    
    public List<Doll> Dolls
    {
        get => dolls;
        set { dolls = value; OnPropertyChanged(); }
    }
    public NewPage1(DB dB)
	{
		InitializeComponent();
        Db = dB;
        LoadList();
        BindingContext = this;

    }


    public async void LoadList()
    {
        Dolls = await Db.LoadDoll();
        Cartoons = await Db.LoadCartoons();
        Db.LoadAutoIncr();
    }
    private void Save(object sender, EventArgs e)
    {
        Db.AddDoll(DollHere);
        LoadList();
    }

    private async void Deleted(object sender, EventArgs e)
    {
        Db.DeleteToy(DeleteId);
        LoadList();
    }

    private void Update(object sender, EventArgs e)
    {
        Db.UpdateToy(DeleteId, DollHere);
        LoadList();

    }
}
