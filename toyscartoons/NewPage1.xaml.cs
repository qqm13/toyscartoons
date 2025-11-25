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
   

    public List<Doll> Dolls
    {
        get => dolls;
        set { dolls = value; OnPropertyChanged(); }
    }
    public NewPage1()
    {
        InitializeComponent();
        LoadList();
        BindingContext = this;

    }


    public async void LoadList()
    {       
        Dolls = await (await DB.GetDBAsync()).GetDolls();
        Cartoons = await (await DB.GetDBAsync()).GetCartoons();
        await (await DB.GetDBAsync()).LoadAutoIncr();
    }
    private async void Save(object sender, EventArgs e)
    {
       
        //DollHere.Image = File.ReadAllBytes(DollHere.ImagePath);
        await(await DB.GetDBAsync()).AddDoll(DollHere);                               
        LoadList();
    }

    private async void Deleted(object sender, EventArgs e)
    {
        await (await DB.GetDBAsync()).DeleteToy(DeleteId);
        LoadList();
    }

    private async void Update(object sender, EventArgs e)
    {
        await(await DB.GetDBAsync()).UpdateToy(DeleteId, DollHere);       
        LoadList();

    }

  
}
