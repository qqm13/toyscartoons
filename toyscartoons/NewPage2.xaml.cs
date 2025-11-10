using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace toyscartoons;

public partial class NewPage2 : ContentPage

{
    public int DeleteId { get; set; } = 0;

    private List<Cartoon> cartoons = new List<Cartoon>();
    public DB Db { get; set; } = new DB();

    public Cartoon CartoonHere { get; set; } = new Cartoon();
    public List<Cartoon> Cartoons
    {
        get => cartoons;
        set { cartoons = value; OnPropertyChanged(); }
    }
    public NewPage2(DB dB)
	{
		InitializeComponent();
        Db = dB;
        LoadList();
        BindingContext = this;
	}

    public async void LoadList()
    {
        Cartoons = await Db.LoadCartoons();
        Db.LoadAutoIncr();
    }

   
    private void Save(object sender, EventArgs e)
    {
        Db.AddCartoon(CartoonHere);
        LoadList(); 
    }

 

    private void Deleted(object sender, EventArgs e)
    {
        Db.DeleteCartoon(DeleteId);
        LoadList();
    }

    private void Update(object sender, EventArgs e)
    {
        Db.UpdateCartoon(DeleteId, CartoonHere);
        LoadList();
    }
}