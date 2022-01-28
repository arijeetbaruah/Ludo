using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PlayFab;
using PlayFab.ClientModels;

namespace Game.System
{
    public class PlayFabService : MonoBehaviour
    {
        public static PlayFabService instance;

        [SerializeField] private string facebookAccessToken;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void LoginWithEmail(string email, string password)
        {
            var request = new LoginWithEmailAddressRequest
            {
                Email = email,
                Password = password
            };

            PlayFabClientAPI.LoginWithEmailAddress(request, success =>
            {
            }, error =>
            {
            });
        }

        public void LoginViaFacebook()
        {
            var request = new LoginWithFacebookRequest
            {
                AccessToken = facebookAccessToken
            };

            PlayFabClientAPI.LoginWithFacebook(request, success =>
            {
                print("successful");
            }, error =>
            {
                Debug.LogError("Failed");
                Debug.LogError(error.GenerateErrorReport());
            });
        }

        public void Register(string email, string password, string username)
        {
            var request = new RegisterPlayFabUserRequest
            {
                Email = email,
                Password = password,
                Username = username,
                DisplayName = username
            };

            PlayFabClientAPI.RegisterPlayFabUser(request, success =>
            {
            }, error =>
            {
            });
        }
    }
}
