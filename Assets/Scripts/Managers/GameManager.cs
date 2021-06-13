using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : SingletonComponent<GameManager>
{
    public Player player;
    public bool isRandomSim = true;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        if (scene.name == "GameEmployee" && player.isTrainer == 0)
        {
            player.Spawn();
            MusicManager.instance.PlayAudio(MusicManager.instance.audioClips[1]);
        } else if (scene.name == "GameEmployee" && player.isTrainer == 1)
        {
            SimulationManager.instance.ChangeGameToTrainer();
            UIManager.instance.ChangeSimulationUI();
        }
        if (scene.name == "FeedBackScreen")
        {
            //ScrollRect scroll = Instantiate(FeedBackManager.instance.feedbackScrollView, transform.position, transform.rotation);
            //FeedBackManager.instance.feedbackScrollView = scroll;
            //FeedBackManager.instance.PopulateScrollView();
        }
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
