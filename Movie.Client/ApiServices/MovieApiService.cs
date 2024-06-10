//using IdentityModel.Client;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Movies.Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace Movies.Client.ApiServices
{ 
    public class MovieApiService : Movies.Client.ApiServices.IMovieApiService
    {
        //private readonly IHttpClientFactory _httpClientFactory;
        //private readonly IHttpContextAccessor _httpContextAccessor;
       // IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor
        public MovieApiService()
        {
           // _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            //_httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public async Task<IEnumerable<Movies.Client.Models.Movie>> GetMovies()
        {
            return movies;
            ////////////////////////
            // WAY 1 :

            //var httpClient = _httpClientFactory.CreateClient("MovieAPIClient");

            //var request = new HttpRequestMessage(
            //    HttpMethod.Get,
            //    "/movies");

            //var response = await httpClient.SendAsync(
            //    request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

            //response.EnsureSuccessStatusCode();

            //var content = await response.Content.ReadAsStringAsync();
            //var movieList = JsonConvert.DeserializeObject<List<Movies.Client.Models.Movie>>(content);
            //return movieList;

            ////////////////////////// //////////////////////// ////////////////////////
            //// WAY 2 :

            //// 1. "retrieve" our api credentials. This must be registered on Identity Server!
            //var apiClientCredentials = new ClientCredentialsTokenRequest
            //{
            //    Address = "https://localhost:5005/connect/token",

            //    ClientId = "movieClient",
            //    ClientSecret = "secret",

            //    // This is the scope our Protected API requires. 
            //    Scope = "movieAPI"
            //};

            //// creates a new HttpClient to talk to our IdentityServer (localhost:5005)
            //var client = new HttpClient();

            //// just checks if we can reach the Discovery document. Not 100% needed but..
            //var disco = await client.GetDiscoveryDocumentAsync("https://localhost:5005");
            //if (disco.IsError)
            //{
            //    return null; // throw 500 error
            //}

            //// 2. Authenticates and get an access token from Identity Server
            //var tokenResponse = await client.RequestClientCredentialsTokenAsync(apiClientCredentials);            
            //if (tokenResponse.IsError)
            //{
            //    return null;
            //}

            //// Another HttpClient for talking now with our Protected API
            //var apiClient = new HttpClient();

            //// 3. Set the access_token in the request Authorization: Bearer <token>
            //client.SetBearerToken(tokenResponse.AccessToken);

            //// 4. Send a request to our Protected API
            //var response = await client.GetAsync("https://localhost:5001/api/movies");
            //response.EnsureSuccessStatusCode();

            //var content = await response.Content.ReadAsStringAsync();

            //var movieList = JsonConvert.DeserializeObject<List<Movie>>(content);
            //return movieList;


        }

        public Task<Movies.Client.Models.Movie> GetMovie(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Movies.Client.Models.Movie> CreateMovie(Movies.Client.Models.Movie movie)
        {
            throw new NotImplementedException();
        }

        public Task<Movies.Client.Models.Movie> UpdateMovie(Movies.Client.Models.Movie movie)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMovie(int id)
        {
            throw new NotImplementedException();
        }



        //public async Task<UserInfoViewModel> GetUserInfo()
        //{           
        //    var idpClient = _httpClientFactory.CreateClient("IDPClient");

        //    var metaDataResponse = await idpClient.GetDiscoveryDocumentAsync();

        //    if (metaDataResponse.IsError)
        //    {
        //        throw new HttpRequestException("Something went wrong while requesting the access token");
        //    }

        //    var accessToken = await _httpContextAccessor
        //        .HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);

        //    var userInfoResponse = await idpClient.GetUserInfoAsync(
        //       new UserInfoRequest
        //       {
        //           Address = metaDataResponse.UserInfoEndpoint,
        //           Token = accessToken
        //       });

        //    if (userInfoResponse.IsError)
        //    {
        //        throw new HttpRequestException("Something went wrong while getting user info");
        //    }

        //    var userInfoDictionary = new Dictionary<string, string>();

        //    foreach (var claim in userInfoResponse.Claims)
        //    {
        //        userInfoDictionary.Add(claim.Type, claim.Value);
        //    }

        //    return new UserInfoViewModel(userInfoDictionary);
        //}
        List<Movies.Client.Models.Movie> movies = new List<Movies.Client.Models.Movie>
        {
            new Movies.Client.Models.Movie
            {
                Id = 1,
                Title = "Inception",
                Genre = "Sci-Fi",
                Rating = "PG-13",
                ReleaseDate = new DateTime(2010, 7, 16),
                ImageUrl = "https://example.com/inception.jpg",
                Owner = "Warner Bros."
            },
            new Movies.Client.Models.Movie
            {
                Id = 2,
                Title = "The Shawshank Redemption",
                Genre = "Drama",
                Rating = "R",
                ReleaseDate = new DateTime(1994, 9, 23),
                ImageUrl = "https://example.com/shawshank.jpg",
                Owner = "Columbia Pictures"
            },
            new Movies.Client.Models.Movie
            {
                Id = 3,
                Title = "The Godfather",
                Genre = "Crime",
                Rating = "R",
                ReleaseDate = new DateTime(1972, 3, 24),
                ImageUrl = "https://example.com/godfather.jpg",
                Owner = "Paramount Pictures"
            },
            new Movies.Client.Models.Movie
            {
                Id = 4,
                Title = "The Dark Knight",
                Genre = "Action",
                Rating = "PG-13",
                ReleaseDate = new DateTime(2008, 7, 18),
                ImageUrl = "https://example.com/darkknight.jpg",
                Owner = "Warner Bros."
            },
            new Movies.Client.Models.Movie
            {
                Id = 5,
                Title = "Pulp Fiction",
                Genre = "Crime",
                Rating = "R",
                ReleaseDate = new DateTime(1994, 10, 14),
                ImageUrl = "https://example.com/pulpfiction.jpg",
                Owner = "Miramax"
            }
        };
    }
    
}
