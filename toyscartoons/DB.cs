
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace toyscartoons
{
    public class DB
    {
        private static DB _data;
        
        private List<Cartoon> Cartoons;
        private List<Doll> Dolls;
        private List<int> AutoIncr { get; set; } = new List<int> { 1, 1, 1 };
        private List<User> Users;

        public static async Task<DB> GetDBAsync()
        {
            if(_data == null)
            {
                _data = new DB();
                await _data.LoadCartoons();
                await _data.LoadDoll();
                await _data.LoadAutoIncr();
                await _data.LoadUser();
            }
            return _data;
        }
       
       
        public async Task<List<Cartoon>> GetCartoons()
        {
            await Task.Delay(1000);
            return Cartoons?.Select(c => new Cartoon
            {
              Id = c.Id,
              Title = c.Title,
              Description = c.Description,
              YearPubliched = c.YearPubliched,
             Genre = c.Genre,
              Author = c.Author,
    }).ToList() ?? new List<Cartoon>();
        }

        public async Task<List<Doll>> GetDolls()
        {
            await Task.Delay(1000);
            return Dolls?.Select(d => new Doll
            {
                Id = d.Id,
                Articul = d.Articul,
                Name = d.Name,
                Collection  = d.Collection,
                PublichDate = d.PublichDate,
                Description = d.Description,
                Cartoon = d.Cartoon,
     
    }).ToList() ?? new List<Doll>();
        }

        public async Task<List<User>> GetUsers()
        {
            await Task.Delay(1000);
            return Users?.Select(u => new User
            {
                Id = u.Id,
                Login = u.Login,
                Password = u.Password,

            }).ToList() ?? new List<User>();
        }



        public async Task AddCartoon(Cartoon cartoon)
        {

          
             AutoIncr[1]++;
                cartoon.Id = AutoIncr[1];
                SaveAutoIncr();
            Cartoons.Add(cartoon);
            SaveCartoons();
        }
        public async Task SaveCartoons()
        {
            string filepath = Path.Combine(FileSystem.Current.AppDataDirectory, "dbCartoon.json");

            using FileStream fileStream = File.Create(filepath);
            JsonSerializer.Serialize(fileStream, Cartoons);

        }

        public async Task LoadCartoons()
        {

            string filepath = Path.Combine(FileSystem.Current.AppDataDirectory, "dbCartoon.json");
            if (!File.Exists(filepath))
            {
                Cartoons = new List<Cartoon>();
            }
            var data1 = await File.ReadAllTextAsync(filepath);
            Cartoons = JsonSerializer.Deserialize<List<Cartoon>>(data1);

        }


        public async Task AddDoll(Doll doll)
        {
               
                AutoIncr[0]++;
                doll.Id = AutoIncr[0];
                SaveAutoIncr();
            Dolls.Add(doll);
            SaveDoll();
        }
        public async Task SaveDoll()
        {

            string filepath = Path.Combine(FileSystem.Current.AppDataDirectory, "dbDoll.json");

            using FileStream fileStream = File.Create(filepath);
            JsonSerializer.Serialize(fileStream, Dolls);
        }

        public async Task LoadDoll()
        {
            string filepath = Path.Combine(FileSystem.Current.AppDataDirectory, "dbDoll.json");
            if (!File.Exists(filepath))
            {
                Dolls = new List<Doll>();
            }
            var data1 = await File.ReadAllTextAsync(filepath);
            Dolls = JsonSerializer.Deserialize<List<Doll>>(data1);
            
        }
        public async Task DeleteCartoon(int cartoonId)
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

        public async Task DeleteToy(int dollId)
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

        public async Task UpdateToy(int dollId, Doll upddoll)
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

        public async Task UpdateCartoon(int newcartoonsId, Cartoon cartoonupd)
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

        public async Task SaveAutoIncr()
        {
            string filepath = Path.Combine(FileSystem.Current.AppDataDirectory, "dbAutoIncr.json");

            using FileStream fileStream = File.Create(filepath);
            JsonSerializer.Serialize(fileStream, AutoIncr);
        }

        public async Task LoadAutoIncr()
        {
            string filepath = Path.Combine(FileSystem.Current.AppDataDirectory, "dbAutoIncr.json");
            if (!File.Exists(filepath))
            {
                AutoIncr = new List<int> {1, 4, 1 };
            }
            else
            {
                var data1 = await File.ReadAllTextAsync(filepath);
                AutoIncr = JsonSerializer.Deserialize<List<int>>(data1);

            }
        }

        public async Task AddUser(User user)
        {
            AutoIncr[2]++;
            user.Id = AutoIncr[2];
            SaveAutoIncr();
            Users.Add(user);
            SaveUser();
        }

        public async Task SaveUser()
        {
            string filepath = Path.Combine(FileSystem.Current.AppDataDirectory, "dbUser.json");

            using FileStream fileStream = File.Create(filepath);
            JsonSerializer.Serialize(fileStream, Users);
        }

        public async Task LoadUser()
        {
            string filepath = Path.Combine(FileSystem.Current.AppDataDirectory, "dbUser.json");
            if (!File.Exists(filepath))
            {
                Users = new List<User>();
            }
            else
            {
                var data1 = await File.ReadAllTextAsync(filepath);
                Users = JsonSerializer.Deserialize<List<User>>(data1);

            }


        }
    }

}
