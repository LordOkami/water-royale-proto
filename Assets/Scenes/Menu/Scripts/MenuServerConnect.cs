using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MenuServerConnect : MonoBehaviour
{
    public TMP_InputField hostname_input;
    public TMP_InputField username_input;
    public Button button;
    public Toggle toggleWss;
    public GameObject errorLabel;

    public GameObject serverLobby;

    public static string username;

    public static bool connectionDone = false;
    public static bool serverLobbyLoaded = false;
    public static bool connectedSuccessfully;
    public static string joinError;

    void Start()
    {
        button.onClick.AddListener(() => {
            errorLabel.SetActive(false);

            string hostname = hostname_input.text;
            username = username_input.text;

            SetMessage("Connecting to server...", false);
            NetworkManager.Connect(hostname, username, toggleWss.isOn);
            //SceneManager.LoadScene(2);
        });
    }

    private void SetMessage(string text, bool error)
    {
        TextMeshProUGUI tmp = errorLabel.GetComponent<TextMeshProUGUI>();
        if(error)
        {
            tmp.color = new Color32(255, 0, 0, 255);
        }
        else
        {
            tmp.color = new Color32(255, 255, 0, 255);
        }
        tmp.text = text;
        errorLabel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (connectionDone)
        { 
            connectionDone = false;
            if (connectedSuccessfully)
            {
                SetMessage("Connected! Loading server lobby...", false);
            }
            else
            {
                if (joinError == "error_connecting")
                {
                    SetMessage("Error: Unable to connect to server.", true);
                }
                else if (joinError == "username_not_available")
                {
                    SetMessage(string.Format("Username '{0}' is already in use", username), true);
                }
                else
                {
                    SetMessage("Error: Unable to join server lobby.", true);
                }
            }
        }
        if (serverLobbyLoaded)
        {
            serverLobbyLoaded = false;
            gameObject.SetActive(false);
            serverLobby.SetActive(true);
        }
    }
}
