using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using System;

public class AuthAPI : MonoBehaviour {
    Firebase.Auth.FirebaseAuth auth;

    public string userName;
    public string email;
    public System.Uri photo_url;
    public string uid;
    private void Start() {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
        .RequestEmail()
        .RequestIdToken()
        .Build();

        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();

        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
    }
    private void AuthGoogle(Action callback, Action<String> fallback) {
        PlayGamesPlatform.Instance.Authenticate(SignInInteractivity.CanPromptOnce, (result) => {
            if (result == SignInStatus.Failed || result == SignInStatus.Canceled) {
                fallback("Fail");
                Debug.LogError($"Fail...");
            }
            else {
                callback();
                Debug.Log($"SignIn Success");
            }
        });
    }

    public void SignOutGoogle() {
        PlayGamesPlatform.Instance.SignOut();
    }

    public void SignInGoogle(Action callback, Action<String> fallback) {
        AuthGoogle(
            () => {
                String token = PlayGamesPlatform.Instance.GetIdToken();

                Firebase.Auth.Credential credential =
                    Firebase.Auth.GoogleAuthProvider.GetCredential(token, null);
                auth.SignInWithCredentialAsync(credential).ContinueWith(task => {
                    if (task.IsCanceled || task.IsFaulted) {
                        fallback("Fail");
                    }

                    //Firebase 인증 성공
                    Firebase.Auth.FirebaseUser newUser = task.Result;
                    Debug.LogFormat("User signed in successfully: {0} ({1})",
                        newUser.DisplayName, newUser.UserId);
                    callback();
                });

                Firebase.Auth.FirebaseUser user = auth.CurrentUser;
                if (user != null) {
                    userName = user.DisplayName;
                    email = user.Email;
                    photo_url = user.PhotoUrl;
                    uid = user.UserId;
                }
            },
            fallback
        );
    }
}
