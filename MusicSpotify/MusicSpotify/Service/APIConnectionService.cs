using System;
using System.Threading.Tasks;

using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;

namespace MusicSpotify.Service
{
    public class APIConnectionService
    {
        private static readonly string clientId = Environment.GetEnvironmentVariable("CLIENT_ID");
        private static readonly string clientSecret = Environment.GetEnvironmentVariable("CLIENT_SECRET");

        public static async Task GetAlbumsAsync()
        {
            var config = SpotifyClientConfig.CreateDefault();
            var request = new ClientCredentialsRequest(clientId, clientSecret);
            var response = await new OAuthClient(config).RequestToken(request);
            var spotify = new SpotifyClient(config.WithToken(response.AccessToken));


        }
    }

}
