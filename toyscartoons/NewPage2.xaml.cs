
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;


namespace toyscartoons;

public partial class NewPage2 : ContentPage

{
    public int DeleteId { get; set; } = 0;

    private List<Cartoon> cartoons = new List<Cartoon>();

    public Cartoon CartoonHere { get; set; } = new Cartoon();
    public List<Cartoon> Cartoons
    {
        get => cartoons;
        set { cartoons = value; OnPropertyChanged(); }
    }
    public NewPage2()
	{
        
		InitializeComponent();
        LoadList();
        BindingContext = this;
	}

    public async void LoadList()
    {
        Cartoons = await (await DB.GetDBAsync()).GetCartoons();
        await (await DB.GetDBAsync()).LoadAutoIncr();
    }

   
    private async void Save(object sender, EventArgs e)
    {
        await (await DB.GetDBAsync()).AddCartoon(CartoonHere);
        LoadList(); 
    }

 

    private async void Deleted(object sender, EventArgs e)
    {
        await(await DB.GetDBAsync()).DeleteCartoon(DeleteId);
        LoadList();
    }

    private async void Update(object sender, EventArgs e)
    {
        await(await DB.GetDBAsync()).UpdateCartoon(DeleteId, CartoonHere);        
        LoadList();
    }

  
}