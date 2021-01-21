using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInformation : MonoBehaviour
{
    string name, email, uid;
    System.Uri photo_url;

    public Text tName, tEmail, tUid, tPhoto;

    void Start()
    {
        //GetUserInfo();
        //SetTextUserInfo();
    }
    void GetUserInfo() {
        name = GameManager.Instance.AuthAPI.userName;
        email = GameManager.Instance.AuthAPI.email;
        photo_url = GameManager.Instance.AuthAPI.photo_url;
        uid = GameManager.Instance.AuthAPI.uid;
    }
    void SetTextUserInfo() {
        tName.text = name;
        tEmail.text = email;
        tUid.text = uid;
        tPhoto.text = photo_url.ToString();
    }
}
