
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace toyscartoons
{
    public class DB
    {

        private List<Cartoon> Cartoons;
        private List<Doll> Dolls;
        private List<int> AutoIncr { get; set; } = new List<int> { 1, 1 };


        public async Task AddCartoon(Cartoon cartoon)
        {

            LoadAutoIncr();
             AutoIncr[1]++;
                cartoon.Id = AutoIncr[1];
                SaveAutoIncr();
            Cartoons.Add(cartoon);
            SaveCartoons();
        }
        public async void SaveCartoons()
        {
            string filepath = Path.Combine(FileSystem.Current.AppDataDirectory, "dbCartoon.json");

            using FileStream fileStream = File.Create(filepath);
            JsonSerializer.Serialize(fileStream, Cartoons);

        }

        public async Task<List<Cartoon>> LoadCartoons()
        {

            string filepath = Path.Combine(FileSystem.Current.AppDataDirectory, "dbCartoon.json");
            if (!File.Exists(filepath))
            {
                Cartoons = new List<Cartoon>();
                return new List<Cartoon>();
            }
            var data1 = await File.ReadAllTextAsync(filepath);
            Cartoons = JsonSerializer.Deserialize<List<Cartoon>>(data1);
            return new List<Cartoon>(Cartoons);
        }


        public async Task AddDoll(Doll doll)
        {
                LoadAutoIncr();
                AutoIncr[0]++;
                doll.Id = AutoIncr[0];
                SaveAutoIncr();
            Dolls.Add(doll);
            SaveDoll();
        }
        public async void SaveDoll()
        {

            string filepath = Path.Combine(FileSystem.Current.AppDataDirectory, "dbDoll.json");

            using FileStream fileStream = File.Create(filepath);
            JsonSerializer.Serialize(fileStream, Dolls);
        }

        public async Task<List<Doll>> LoadDoll()
        {
            string filepath = Path.Combine(FileSystem.Current.AppDataDirectory, "dbDoll.json");
            if (!File.Exists(filepath))
            {
                Dolls = new List<Doll>();
                return new List<Doll>();
            }
            var data1 = await File.ReadAllTextAsync(filepath);
            Dolls = JsonSerializer.Deserialize<List<Doll>>(data1);
            return new List<Doll>(Dolls);
        }
        public async void DeleteCartoon(int cartoonId)
            {
            Cartoon cartoonDel = new Cartoon();
            foreach (Cartoon cartoon in Cartoons)
            {
                if (cartoon.Id == cartoonId)
                {
                    cartoonDel = cartoon;
                }
            }
            Cartoons.Remove(cartoonDel);
            SaveCartoons();
            }

        public async void DeleteToy(int dollId)
        {
            Doll dollDel = new Doll();
            foreach (Doll doll in Dolls)
            {
                if (doll.Id == dollId)
                {
                    dollDel = doll;
                }
            }
            Dolls.Remove(dollDel);
            SaveDoll();
        }

        public async void UpdateToy(int dollId, Doll upddoll)
        {
            foreach (Doll doll in Dolls)
            {
                if (doll.Id == dollId)
                {
                    doll.Articul = upddoll.Articul;
                    doll.Collection = upddoll.Collection;
                    doll.Cartoon = upddoll.Cartoon;
                    doll.Description = upddoll.Description;
                    doll.PublichDate = upddoll.PublichDate;
                    doll.Name = upddoll.Name;
                    SaveDoll();
                    break;
                }
            }
        }

        public async void UpdateCartoon(int newcartoonsId, Cartoon cartoonupd)
        {
            foreach(Cartoon cartoon in Cartoons)
            {
                if(cartoon.Id == newcartoonsId)
                {
                    cartoon.Title = cartoonupd.Title;
                    cartoon.YearPubliched = cartoonupd.YearPubliched;
                    cartoon.Author = cartoonupd.Author;
                    cartoon.Genre = cartoonupd.Genre;
                    cartoon.Description = cartoonupd.Description;
                    SaveCartoons();
                    break;
                }
            }    
         
        }

        public async void SaveAutoIncr()
        {
            string filepath = Path.Combine(FileSystem.Current.AppDataDirectory, "dbAutoIncr.json");

            using FileStream fileStream = File.Create(filepath);
            JsonSerializer.Serialize(fileStream, AutoIncr);
        }

        public async void LoadAutoIncr()
        {
            string filepath = Path.Combine(FileSystem.Current.AppDataDirectory, "dbAutoIncr.json");
            if (!File.Exists(filepath))
            {
                AutoIncr = new List<int> {0, 0 };
               
            }
            var data1 = await File.ReadAllTextAsync(filepath);
            AutoIncr = JsonSerializer.Deserialize<List<int>>(data1);
           
        }
    }
}
