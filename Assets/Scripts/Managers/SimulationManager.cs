using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SimulationManager : SingletonComponent<SimulationManager>
{
    [SerializeField]
    private TMP_InputField nameInputField;

    public Simulation simulation;

    public void Init()
    {
        simulation = new Simulation();
        CreateNew(simulation);
    }
    void CreateNew(Simulation simulation)
    {
        simulation.simulationName = nameInputField.text;
        GameManager.instance.LoadScene("GameEmployee");


        //GameManager.instance.LoadSceneCreation(simulation);
    }

    public void ChangeGameToTrainer()
    {
        PointManager.instance.safetyObjects.SetActive(false);
        PointManager.instance.spawnObjects.SetActive(true);
    }

    public void CompleteSimulation()
    {
        Debug.Log(simulation.GetInfo());
        GameManager.instance.LoadScene("FeedBackScreen");
        GenerateResult();
    }

    public void GenerateResult()
    {

    }

}
