using ConsoleTools;
using Newtonsoft.Json;
using QERH6L_HFT_2023241.Models;
using QERH6L_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace QERH6L_HFT_2023241.Client
{
    internal class Program
    {
        public static HttpClient httpClient = new HttpClient();
        static void Main(string[] args)
        {
            var menu = new ConsoleMenu()
            .Add("Összes mozi lekérése",async () => await AllCinema())
            .Add("Új mozi létrehozása", async() => await CreateCinema())
            .Add("Mozi módodítása", async() => await UpdateCinema())
            .Add("Mozi törlése", async() => await DeleteCinema())
            .Add("Összes film lekérése",async () => await AllMovie())
            .Add("Új film létrehozása", async () => await CreateMovie())
            .Add("Film módodítása", async () => await UpdateMovie())
            .Add("Film törlése", async() => await DeleteMovie())
            .Add("Összes vetítés lekérése", async() => await AllShowtime())
            .Add("Új vetítés létrehozása",async () => await CreateShowtime())
            .Add("Vetítés módodítása",async () => await UpdateShowtime())
            .Add("Vetítés törlése", async() => await DeleteShowtime())
            .Add("Mozira szűrés város alapján",async () => await CinemasbyCity())
            .Add("Filmre szűrés hossz alapján", async() => await MoviesbyLength())
            .Add("Vetítések szűrése mozi alapján", async() => await ShowtimebyCinema())
            .Add("Vetítések szűrése film alapján", async() => await ShowtimebyMovie())
            .Add("Vetítések szűrése dátum alapján", async() => await ShowtimebyDate())
            .Add("Exit", () => Environment.Exit(0));
                //.Configure(config =>
                //{
                //config.Selector = "--> ";
                //config.EnableFilter = true;
                //config.Title = "Main menu";
                //config.EnableWriteTitle = true;
                //config.EnableBreadcrumb = true;
                //});

                menu.Show();
          
        }
        public static async Task<bool> AllCinema()
        {
           
            using HttpResponseMessage response = await httpClient.GetAsync("http://localhost:22591/cinemas/all");

            response.EnsureSuccessStatusCode();
 
            var jsonResponse = await response.Content.ReadAsStringAsync();
            Console.WriteLine("Összes mozi");
            List<Cinema> list = JsonConvert.DeserializeObject<List<Cinema>>(jsonResponse);
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i].id + " ");
                Console.Write(list[i].name + " ");
                Console.Write(list[i].address + " ");
                Console.WriteLine();
            }
            Console.ReadKey();
            return true;
           
        }
        public static async Task<bool> CreateCinema()
        {
            Cinema cinema = new Cinema();
            cinema.name = Console.ReadLine().Trim();
            cinema.address = Console.ReadLine().Trim();
            cinema.city = Console.ReadLine().Trim();
            string json = JsonConvert.SerializeObject(cinema);
            
            using HttpResponseMessage response = await httpClient.PostAsync("http://localhost:22591/cinemas/create",new StringContent(json,Encoding.UTF8,"application/json"));

            response.EnsureSuccessStatusCode();
            Console.WriteLine("Sikeres mentés !");
            return true;
        }
        public static async Task<bool> UpdateCinema()
        {
            Cinema cinema = new Cinema();
            cinema.id = Int32.Parse(Console.ReadLine().Trim());
            cinema.name = Console.ReadLine().Trim();
            cinema.address = Console.ReadLine().Trim();
            cinema.city = Console.ReadLine().Trim();
            string json = JsonConvert.SerializeObject(cinema);

            using HttpResponseMessage response = await httpClient.PutAsync("http://localhost:22591/cinemas/update", new StringContent(json, Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
            Console.WriteLine("Sikeres módosítás !");
            return true;
        }
        public static async Task<bool> DeleteCinema()
        {
            int id = Int32.Parse(Console.ReadLine().Trim());
            using HttpResponseMessage response = await httpClient.DeleteAsync("http://localhost:22591/cinemas/delete/" + id);

            response.EnsureSuccessStatusCode();
            Console.WriteLine("Sikeres törlés !");
            return true;
        }
        public static async Task<bool> CinemasbyCity()
        {
            string city = Console.ReadLine().Trim();
           
            using HttpResponseMessage response = await httpClient.GetAsync("http://localhost:22591/cinemas/city/" + city);
            var jsonResponse = await response.Content.ReadAsStringAsync();
            List<Cinema> list = JsonConvert.DeserializeObject<List<Cinema>>(jsonResponse);
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i].id + " ");
                Console.Write(list[i].name + " ");
                Console.Write(list[i].address + " ");
                Console.WriteLine();
            }
            Console.ReadKey();
            return true;
        }
        public static async Task<bool> MoviesbyLength()
        {
            int length = Int32.Parse(Console.ReadLine().Trim());

            using HttpResponseMessage response = await httpClient.GetAsync("http://localhost:22591/movie/length/" + length);
            var jsonResponse = await response.Content.ReadAsStringAsync();
            List<Movie> list = JsonConvert.DeserializeObject<List<Movie>>(jsonResponse);
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i].id + " ");
                Console.Write(list[i].name + " ");
                Console.Write(list[i].length + " ");
                Console.Write(list[i].category + " ");
                Console.WriteLine();
            }
            Console.ReadKey();
            return true;
        }
        public static async Task<bool> ShowtimebyMovie()
        {
           string movieName = Console.ReadLine().Trim();

            using HttpResponseMessage response = await httpClient.GetAsync("http://localhost:22591/showtime/movieName/" + movieName);
            var jsonResponse = await response.Content.ReadAsStringAsync();
            List<Showtime> list = JsonConvert.DeserializeObject<List<Showtime>>(jsonResponse);
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i].id + " ");
                Console.Write(list[i].date + " ");
                Console.Write(list[i].movie.name + " ");
                Console.Write(list[i].cinema.name + " ");
                Console.WriteLine();
            }
            Console.ReadKey();
            return true;
        }
        public static async Task<bool> AllMovie()
        {

            using HttpResponseMessage response = await httpClient.GetAsync("http://localhost:22591/movie/all");

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            Console.WriteLine("Összes film");
            List<Movie> list = JsonConvert.DeserializeObject<List<Movie>>(jsonResponse);
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i].id + " ");
                Console.Write(list[i].name + " ");
                Console.Write(list[i].category + " ");
                Console.Write(list[i].length + " ");
                Console.WriteLine();
            }
            Console.ReadKey();
            return true;

        }
        public static async Task<bool> CreateMovie()
        {
            Movie movie = new Movie();
            movie.name = Console.ReadLine().Trim();
            movie.category = Console.ReadLine().Trim();
            movie.length = Int32.Parse(Console.ReadLine().Trim());
            string json = JsonConvert.SerializeObject(movie);

            using HttpResponseMessage response = await httpClient.PostAsync("http://localhost:22591/movie/create", new StringContent(json, Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
            Console.WriteLine("Sikeres mentés !");
            return true;
        }
        public static async Task<bool> UpdateMovie()
        {
            Movie movie = new Movie();
            movie.id = Int32.Parse(Console.ReadLine().Trim());
            movie.name = Console.ReadLine().Trim();
            movie.category = Console.ReadLine().Trim();
            movie.length = Int32.Parse(Console.ReadLine().Trim());
            string json = JsonConvert.SerializeObject(movie);

            using HttpResponseMessage response = await httpClient.PutAsync("http://localhost:22591/movie/update", new StringContent(json, Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
            Console.WriteLine("Sikeres módosítás !");
            return true;
        }
        public static async Task<bool> DeleteMovie()
        {
            int id = Int32.Parse(Console.ReadLine().Trim());
            using HttpResponseMessage response = await httpClient.DeleteAsync("http://localhost:22591/movie/delete/" + id);

            response.EnsureSuccessStatusCode();
            Console.WriteLine("Sikeres törlés !");
            return true;
        }
        public static async Task<bool> AllShowtime()
        {

            using HttpResponseMessage response = await httpClient.GetAsync("http://localhost:22591/showtime/all");

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            Console.WriteLine("Összes vetítés");
            List<Showtime> list = JsonConvert.DeserializeObject<List<Showtime>>(jsonResponse);
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i].id + " ");
                Console.Write(list[i].movieId + " ");
                Console.Write(list[i].cinemaId + " ");
                Console.Write(list[i].date + " ");
                Console.WriteLine();
            }
            Console.ReadKey();
            return true;

        }
        public static async Task<bool> CreateShowtime()
        {
            Showtime showtime = new Showtime();
            showtime.id = Int32.Parse(Console.ReadLine().Trim());
            showtime.cinemaId = Int32.Parse(Console.ReadLine().Trim());
            showtime.movieId = Int32.Parse(Console.ReadLine().Trim());
            showtime.date = DateTime.Parse(Console.ReadLine().Trim());
            string json = JsonConvert.SerializeObject(showtime);

            using HttpResponseMessage response = await httpClient.PostAsync("http://localhost:22591/showtime/create", new StringContent(json, Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
            Console.WriteLine("Sikeres mentés !");
            return true;
        }
        public static async Task<bool> UpdateShowtime()
        {
            Showtime showtime= new Showtime();
            showtime.id = Int32.Parse(Console.ReadLine().Trim());
            showtime.cinemaId = Int32.Parse(Console.ReadLine().Trim());
            showtime.movieId = Int32.Parse(Console.ReadLine().Trim());
            showtime.date = DateTime.Parse(Console.ReadLine().Trim());
            string json = JsonConvert.SerializeObject(showtime);

            using HttpResponseMessage response = await httpClient.PutAsync("http://localhost:22591/showtime/update", new StringContent(json, Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
            Console.WriteLine("Sikeres módosítás !");
            return true;
        }
        public static async Task<bool> DeleteShowtime()
        {
            int id = Int32.Parse(Console.ReadLine().Trim());
            using HttpResponseMessage response = await httpClient.DeleteAsync("http://localhost:22591/showtime/delete/" + id);

            response.EnsureSuccessStatusCode();
            Console.WriteLine("Sikeres törlés !");
            return true;
        }
        public static async Task<bool> ShowtimebyCinema()
        {
            string cinemaName = Console.ReadLine().Trim();

            using HttpResponseMessage response = await httpClient.GetAsync("http://localhost:22591/showtime/cinemaName/" + cinemaName);
            var jsonResponse = await response.Content.ReadAsStringAsync();
            List<Showtime> list = JsonConvert.DeserializeObject<List<Showtime>>(jsonResponse);
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i].id + " ");
                Console.Write(list[i].date + " ");
                Console.Write(list[i].movie.name + " ");
                Console.Write(list[i].cinema.name + " ");
                Console.WriteLine();
            }
            Console.ReadKey();
            return true;
        }
        public static async Task<bool> ShowtimebyDate()
        {
            DateTime date = DateTime.Parse(Console.ReadLine().Trim());

            using HttpResponseMessage response = await httpClient.GetAsync("http://localhost:22591/showtime/date/" + date);
            var jsonResponse = await response.Content.ReadAsStringAsync();
            List<Showtime> list = JsonConvert.DeserializeObject<List<Showtime>>(jsonResponse);
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i].id + " ");
                Console.Write(list[i].date + " ");
                Console.Write(list[i].movie.name + " ");
                Console.Write(list[i].cinema.name + " ");
                Console.WriteLine();
            }
            Console.ReadKey();
            return true;
        }
    }
    
}

