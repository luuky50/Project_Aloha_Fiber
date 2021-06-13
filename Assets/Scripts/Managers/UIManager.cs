using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : SingletonComponent<UIManager>
{


    [SerializeField]
    private Transform startPanel;

    private Transform currentPanel;

    public ScrollRect rect;

    public Transform selectionScreen;
    public Transform selectionTrainerScreen;

    public Transform simulationScreen;
    public Transform employeeScreen;
    public TMP_Text infoText;
    public Transform windScreen;

    private void Start()
    {
        currentPanel = startPanel;
    }

    public void NextPanel(Transform panel)
    {
        currentPanel.gameObject.SetActive(false);
        panel.gameObject.SetActive(true);
        currentPanel = panel;
    }

    public void StartPanel() 
    {
        currentPanel.gameObject.SetActive(false);
        startPanel.gameObject.SetActive(true);
    }

    public void MakeScenario()
    {
        SimulationManager.instance.Init();
    }

    public void FeedBackButton()
    {
        GameObject _nearestSafeZone = FeedBackManager.instance.nearestSafeZn;
        GameObject _choseSafeZone = FeedBackManager.instance.chosenSafeZn;
        GameManager.instance.LoadScene("FeedBackScreen");
        FeedBackManager.instance.CompareSafeZone(_nearestSafeZone, _choseSafeZone);
    }

    public void ChangeSimulationUI()
    {
        simulationScreen.gameObject.SetActive(true);
        employeeScreen.gameObject.SetActive(false);
    }

    public void LoginButton()
    {
        LoginManager.instance.Login();
    }

    public void LogoutButton()
    {
        GameManager.instance.LoadScene("MainMenu");
        LoginManager.instance.LogOut();
    }
    public void RegisterButton()
    {
        LoginManager.instance.Register();
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

}
