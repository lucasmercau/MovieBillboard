using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieBillboard.Data;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Linq;

namespace MovieBillboard.Models;

public static class SeedData
{
    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        using (var context = new MovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MovieContext>>()))
        {
            // Look for any movies.
            if (context.Movie.Any())
            {
                return;   // DB has been seeded
            }

            var movies = await FetchMoviesFromApiAsync();

            context.Movie.AddRange(movies);
            context.SaveChanges();
        }
    }

    private static async Task<List<Movie>> FetchMoviesFromApiAsync()
    {
            var client = new HttpClient();
            var response = await client.GetStringAsync("https://www.deployvision.com/api/omdb/search?title=harry%20potter");
            var moviesApi = JsonConvert.DeserializeObject<List<MovieApi>>(response);

            var movies = moviesApi.Select(api => new Movie
                {
                    Title = api.Title,
                    Rated = api.Rated,
                    Released = ParseDate(api.Released),
                    Runtime = api.Runtime,
                    Genre = api.Genre,
                    Director = api.Director,
                    Actors = api.Actors,
                    Plot = api.Plot,
                    Poster = api.Poster,
                    ImdbRating = ParseDouble(api.ImdbRating),
                    BoxOffice = api.BoxOffice
                }).ToList();

                return movies;
    }

    public class MovieApi
    {
        public string? Title { get; set; }
        public string? Rated { get; set; }
        public string? Released { get; set; }
        public string? Runtime { get; set; }
        public string? Genre { get; set; }
        public string? Director { get; set; }
        public string? Actors { get; set; }
        public string? Plot { get; set; }
        public string? Poster { get; set; }
        public string? ImdbRating { get; set; }
        public string? BoxOffice { get; set; }
    }

    private static DateTime ParseDate(string dateString)
    {
        DateTime date = DateTime.ParseExact(dateString, "dd MMM yyyy", CultureInfo.InvariantCulture);
        Console.WriteLine(date);
        return date;
    }

    private static double ParseDouble(string value)
    {
        return double.TryParse(value, out var result) ? result : 0.0;
    }
}
