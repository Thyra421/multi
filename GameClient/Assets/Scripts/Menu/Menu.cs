using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private Button login;
    [SerializeField]
    private Button play;
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private TMP_InputField input;

    private void SetLoading() {
        input.gameObject.SetActive(false);
        slider.gameObject.SetActive(true);
        login.gameObject.SetActive(false);
        play.gameObject.SetActive(false);
    }

    private void SetPlay() {
        input.gameObject.SetActive(false);
        slider.gameObject.SetActive(false);
        login.gameObject.SetActive(false);
        play.gameObject.SetActive(true);
    }

    private void SetLogin() {
        input.gameObject.SetActive(true);
        slider.gameObject.SetActive(false);
        login.gameObject.SetActive(true);
        play.gameObject.SetActive(false);
    }

    private void SetSliderValue(int value) {
        slider.value = value;
    }

    private void Login() {
        SetLoading();
        SetSliderValue(0);
        StartCoroutine(HTTPClient.Login(new MessageLogin(input.text), OnLoggedIn, OnError));
    }

    private void OnLoggedIn(MessageSecret messageSecret) {
        SetSliderValue(1);
        NetworkManager.Secret = messageSecret.secret;
        Connect();
    }

    private void OnError() {
        Debug.Log("Authentication server is offline");
        SetLogin();
    }

    private void Connect() {
        try {
            SetSliderValue(2);
            TCPClient.Connect();
            Authenticate();
        } catch (Exception e) {
            Debug.LogException(e);
            SetLogin();
        }
    }

    private void Authenticate() {
        try {
            SetSliderValue(3);
            UDPClient.Connect();
            TCPClient.Send(new MessageAuthenticate(NetworkManager.Secret, UDPClient.Address, UDPClient.Port));
            SetPlay();
        } catch (Exception e) {
            Debug.LogException(e);
            SetLogin();
        }
    }

    private void Play() => SceneLoader.Current.LoadGameAsync();

    private void Awake() {
        Application.targetFrameRate = 100;
        QualitySettings.vSyncCount = 0;
        slider.minValue = 0;
        slider.maxValue = 3;
        login.onClick.AddListener(Login);
        play.onClick.AddListener(Play);
    }
}