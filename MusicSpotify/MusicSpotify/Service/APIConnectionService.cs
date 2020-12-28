using System;
using System.Threading.Tasks;

using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;

namespace MusicSpotify.Service
{
    public class APIConnectionService
    {
        private static readonly string clientId = Environment.GetEnvironmentVariable("e260c04c8d644b239d8ffc02b3b90a3a");
        private static readonly string clientSecret = Environment.GetEnvironmentVariable("e57e3550d7074d57ae8d2a5698a41c69");

        public static async Task GetAlbumsAsync()
        {
            var config = SpotifyClientConfig.CreateDefault();
            var request = new ClientCredentialsRequest(clientId, clientSecret);
            var response = await new OAuthClient(config).RequestToken(request);
            var spotify = new SpotifyClient(config.WithToken(response.AccessToken));

            var albums = await spotify.Artists.GetAlbums("23fqKkggKUBHNkbKtXEls4");
        }
    }

}
