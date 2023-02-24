using Firebase.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
/*
public class AppManager : MonoBehaviour
{
    // Account creation
   // public TMP_InputField nameProfil;
   // public TMP_InputField photoProfile;

    // Info on profil page
    //public TMP_Text nameTxt;
    //public Sprite photoProfil;
    //public TMP_Text NFTValue;
    /** NFT grid **
    /** Filter Bar **
    /** Fav Artist **

    private string userID;
    private DatabaseReference dbReference;

    //Profil Pictuure 
    public GameObject profileUpdatePanel;
    public Image profileImage;
    public TMP_InputField urlInputField;


    private string defaultUserImage = "https://cdn.icon-icons.com/icons2/1378/PNG/512/avatardefault_92824.png";


   
        // Start is called before the first frame update
        void Start()
        {
            // Get ID after log in
            userID = "chloe001";
            // Get the root reference location of the database.
            dbReference = FirebaseDatabase.GetInstance("https://runart-63f6b-default-rtdb.europe-west1.firebasedatabase.app/").RootReference;
        }

        //Add data on database : Register 

        public void CreateUser()
        {
     //   User newUser = new User(name.text, int.Parse(Gold.text));
            User newUser = new User(name.text, PhotoUrl = new Uri(defaultUserImage));
            string json = JsonUtility.ToJson(newUser);

            dbReference.Child("users").Child(userID).SetRawJsonValueAsync(json);
        }

        // Get data 

        public IEnumerator GetName(Action<string> onCallback)
        {
            var userNameData = dbReference.Child("users").Child(userID).Child("name").GetValueAsync();
            yield return new WaitUntil(predicate: () => userNameData.IsCompleted);

            if(userNameData != null)
            {
                DataSnapshot snapshot = userNameData.Result;
                onCallback.Invoke(snapshot.Value.ToString());
            }
        }


        public void GetUserInfo()
        {
            StartCoroutine(GetName((string name) =>
            {
                NameTxt.text = name;
            }));

            StartCoroutine(GetGold((int gold) =>
            {
                GoldTxt.text = gold.ToString();
            }));
            if (!string.IsNullOrEmpty(users.PhotoUrl.ToString()))
            {
                LoadProfileImage(users.PhotoUrl.ToString());
            }
        }
    
 

    public void OpenCloseProfileUpdatePanel()
    {
        profileUpdatePanel.SetActive(!profileUpdatePanel.activeSelf);
    }

    public void LoadProfileImage(string url)
    {
        StartCoroutine(LoadProfileImageIE(url));
    }

    public IEnumerator LoadProfileImageIE(string url)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();

        if(www.isNetworkError || www.isHttpError)
        {
            Debug.LogError(www.error);
        }
        else
        {
            Texture2D texture = ((DownloadHandlerTexture)www.downloadHandler).texture;

            Sprite sprite = Sprite.Create(texture, new Rect(0,0,texture.width, texture.height), new Vector2());
            profileImage.sprite = sprite;
        }
    }

    public string GetProfilUpdateURL()
    {
        return urlInputField.text;
    }


    public void UpdateProfilePicture()
    {
        StartCoroutine(UpdateProfilePictureIE());
    }
    /*
    public IEnumerator UpdateProfilePictureIE()
    {
        if (userID != null)
        {
            string url = GetProfilUpdateURL();
            UserProfile profile = new UserProfile() { PhotoUrl = new Uri(url) };

            var profileUpdateTask = userID.UpdateUserProfileAsync(profile);
            yield return new WaitUntil(() => profileUpdateTask.IsCompleted);

            if (profileUpdateTask.Exception != null)
            {
                Debug.LogError(profileUpdateTask.Exception);
            }
            else
            {
                LoadProfileImage(userID.PhotoUrl.ToString());
            }
            
        }
    }
}

//var userGoldData = dbReference.Child("users").Child(userID).Child("photo").GetValueAsync();



/* public IEnumerator GetNFTValue(Action<int> onCallback)
      {
          var userGoldData = dbReference.Child("users").Child(userID).Child("gold").GetValueAsync();
          yield return new WaitUntil(predicate: () => userGoldData.IsCompleted);

          if (userGoldData != null)
          {
              DataSnapshot snapshot = userGoldData.Result;
              onCallback.Invoke(int.Parse(snapshot.Value.ToString()));
          }
      }

      public IEnumerator GetPhoto(Action<string> onCallback)
      {
          var userGoldData = dbReference.Child("users").Child(userID).Child("gold").GetValueAsync();
          yield return new WaitUntil(predicate: () => userGoldData.IsCompleted);

          if (userGoldData != null)
          {
              DataSnapshot snapshot = userGoldData.Result;
              onCallback.Invoke(int.Parse(snapshot.Value.ToString()));
          }
      }
     */