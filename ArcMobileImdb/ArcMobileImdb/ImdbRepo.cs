using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;

namespace ArcMobileImdb
{
    public class ImdbRepo
    {
        private static ImdbRepo _current;
        public static ImdbRepo Current => _current ?? (_current = new ImdbRepo());
        private const string API_KEY = "1f54bd990f1cdfb230adb312546d765d";
        private const string BASE_URL = "https://api.themoviedb.org/";
        private const string VERSION = "3";

        private RestClient CreateRestClient()
        {
            return new RestClient(BASE_URL);
        }

        public async Task<GetMovieListReturn> GetMovies(int page)
        {
            var c = CreateRestClient();
            var r = new RestRequest("movies");
            r.AddQueryParameter("api_key", API_KEY);
            r.AddQueryParameter("language", CultureInfo.CurrentUICulture.Name);
            r.AddQueryParameter("page", page);
            var response = await c.Execute(r);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var list = JsonConvert.DeserializeObject<GetMovieListReturn>(response.Content);
                return list;
            }
            if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.Unauthorized)
            {
                var errorInfo = JsonConvert.DeserializeObject<ErrorResponse>(response.Content);
                var errorReturn = new GetMovieListReturn { error = errorInfo };
                return errorReturn;
            }
            throw new Exception($"Unexpected response {response.StatusCode} for {response.ResponseUri}");
        }

        public async Task<MovieDetailResponse> GetMovieDetails(string id)
        {
            var c = CreateRestClient();
            var r = new RestRequest("movies");
            r.AddQueryParameter("api_key", API_KEY);
            r.AddQueryParameter("language", CultureInfo.CurrentUICulture.Name);
            r.AddParameter("movie_id",id);
            var response = await c.Execute(r);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var list = JsonConvert.DeserializeObject<MovieDetailResponse>(response.Content);
                return list;
            }
            if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.Unauthorized)
            {
                var errorInfo = JsonConvert.DeserializeObject<ErrorResponse>(response.Content);
                var errorReturn = new MovieDetailResponse { error = errorInfo };
                return errorReturn;
            }
            throw new Exception($"Unexpected response {response.StatusCode} for {response.ResponseUri}");
        }
    }



    public class MovieDetailResponse
    {
        public bool adult { get; set; }
        public string backdrop_path { get; set; }
        public object belongs_to_collection { get; set; }
        public int budget { get; set; }
        public List<Genre> genres { get; set; }
        public string homepage { get; set; }
        public int id { get; set; }
        public string imdb_id { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public string overview { get; set; }
        public float popularity { get; set; }
        public string poster_path { get; set; }
        public List<Production_Companies> production_companies { get; set; }
        public List<Production_Countries> production_countries { get; set; }
        public string release_date { get; set; }
        public int revenue { get; set; }
        public int runtime { get; set; }
        public List<Spoken_Languages> spoken_languages { get; set; }
        public string status { get; set; }
        public string tagline { get; set; }
        public string title { get; set; }
        public bool video { get; set; }
        public float vote_average { get; set; }
        public int vote_count { get; set; }
        public ErrorResponse error { get; set; }
    }

    public class Genre
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Production_Companies
    {
        public string name { get; set; }
        public int id { get; set; }
    }

    public class Production_Countries
    {
        public string iso_3166_1 { get; set; }
        public string name { get; set; }
    }

    public class Spoken_Languages
    {
        public string iso_639_1 { get; set; }
        public string name { get; set; }
    }


    public class ErrorResponse
    {
        public string status_message { get; set; }
        public bool success { get; set; }
        public int status_code { get; set; }
    }


    public class GetMovieListReturn
    {
        public int page { get; set; }
        public int total_results { get; set; }
        public int total_pages { get; set; }
        public List<Result> results { get; set; }
        public ErrorResponse error { get; set; }
    }

    public class Result
    {
        public int vote_count { get; set; }
        public int id { get; set; }
        public bool video { get; set; }
        public float vote_average { get; set; }
        public string title { get; set; }
        public float popularity { get; set; }
        public string poster_path { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public List<int?> genre_ids { get; set; }
        public string backdrop_path { get; set; }
        public bool adult { get; set; }
        public string overview { get; set; }
        public string release_date { get; set; }
    }


}
