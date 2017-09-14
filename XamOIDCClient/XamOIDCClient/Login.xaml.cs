using IdentityModel.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamOIDCClient
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private AuthorizeResponse _authResponse;
        private string _currentCSRFToken;
        public Login()
        {
            InitializeComponent();
            btnGetIdToken.Clicked += GetIdToken;
            btnGetAccessToken.Clicked += GetAccessToken;
            btnGetIdTokenAndAccessToken.Clicked += GetIdTokenAndAccessToken;
            wvLogin.Navigating += WvLogin_Navigating;
        }

        private void WvLogin_Navigating(object sender, WebNavigatingEventArgs e)
        {
            if (e.Url.Contains("https://xamarin-oidc-sample/redirect"))
            {
                wvLogin.IsVisible = false;

                // parse response
                _authResponse = new AuthorizeResponse(e.Url);

                // CSRF check
                var state = _authResponse.Values["state"];
                if (state != _currentCSRFToken)
                {
                    txtResult.Text = "CSRF token doesn't match";
                    return;
                }

                string decodedTokens = "";
                // decode tokens
                if (!string.IsNullOrWhiteSpace(_authResponse.IdentityToken))
                {
                    decodedTokens += "Identity token \r\n";
                    decodedTokens += DecodeToken(_authResponse.IdentityToken) + "\r\n";
                }

                if (!string.IsNullOrWhiteSpace(_authResponse.AccessToken))
                {
                    decodedTokens += "Access token \r\n";
                    decodedTokens += DecodeToken(_authResponse.AccessToken);
                }

                txtResult.Text = decodedTokens;
            }
        }

        private void GetIdTokenAndAccessToken(object sender, EventArgs e)
        {
            StartFlow("id_token token", "openid profile read write");
        }

        private void GetAccessToken(object sender, EventArgs e)
        {
            StartFlow("token", "read write");
        }

        private void GetIdToken(object sender, EventArgs e)
        {
            StartFlow("id_token", "openid profile");
        }

        public void StartFlow(string responseType, string scope)
        {
            // create URI to authorize endpoint - use WebHost or SelfHost from the 
            // samples solution.
            var authorizeRequest =
                new AuthorizeRequest("https://localhost:44333/core/connect/authorize");

            // dictionary with values for the authorize request
            var dic = new Dictionary<string, string>();
            dic.Add("client_id", "implicitclient");
            dic.Add("response_type", responseType);
            dic.Add("scope", scope);
            dic.Add("redirect_uri", "https://xamarin-oidc-sample/redirect");
            dic.Add("nonce", Guid.NewGuid().ToString("N"));

            // add CSRF token to protect against cross-site request forgery attacks.
            _currentCSRFToken = Guid.NewGuid().ToString("N");
            dic.Add("state", _currentCSRFToken);

            var authorizeUri = authorizeRequest.Create(dic);

            // or use CreateAuthorizeUrl, passing in the values we defined in the dictionary. 
            // authorizeRequest.CreateAuthorizeUrl("implicitclient", ...);

            wvLogin.Source = authorizeUri;
            wvLogin.IsVisible = true;
        }

        public static string DecodeToken(string token)
        {
            var parts = token.Split('.');

            string partToConvert = parts[1];
            partToConvert = partToConvert.Replace('-', '+');
            partToConvert = partToConvert.Replace('_', '/');
            switch (partToConvert.Length % 4)
            {
                case 0:
                    break;
                case 2:
                    partToConvert += "==";
                    break;
                case 3:
                    partToConvert += "=";
                    break;
            }

            var partAsBytes = Convert.FromBase64String(partToConvert);
            var partAsUTF8String = Encoding.UTF8.GetString(partAsBytes, 0, partAsBytes.Count());

            return JObject.Parse(partAsUTF8String).ToString();
        }


    }
}