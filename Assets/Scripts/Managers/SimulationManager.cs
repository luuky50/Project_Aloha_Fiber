using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mono.Data.Sqlite;
using System.Data;

public class SimulationManager : SingletonComponent<SimulationManager>
{
    [SerializeField]
    private TMP_InputField nameInputField;

    public Simulation simulation;

    SqlLiteInfo info;

    public void Init()
    {
        simulation = new Simulation();
        CreateNew(simulation);
    }

    public void LoadSimulations()
    {
        info = new SqlLiteInfo();
        info.connect();
        IDbCommand dbcmd = info.dbconn.CreateCommand();
        string sqlQuery = "SELECT id, name, spawnposition, alarmlocation, hazardlocation, winddirection FROM simulations";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            int id = reader.GetInt32(0);
            string name = reader.GetString(1);
            string spawnposition = reader.GetString(2);
            string alarmlocation = reader.GetString(3);
            string hazardlocation = reader.GetString(4);
            string winddirection = reader.GetString(5);

            for (int i = 0; i < id; i++)
            {
                Debug.Log("Insert simulation");

                id--;
            }
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            info.disconnect();

        }
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
