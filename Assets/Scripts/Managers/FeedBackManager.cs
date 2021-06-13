using Mono.Data.Sqlite;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FeedBackManager : SingletonComponent<FeedBackManager>
{

    public ScrollRect feedbackScrollView;

    public Vector3 spawnPosition;
    public GameObject nearestSafeZn;
    public GameObject chosenSafeZn;

    public UserObject userObject;


    SqlLiteInfo info;

    private void Start()
    {
        //spawnPosition = GameManager.instance.player.currentPosition;
        info = new SqlLiteInfo();
        info.connect();
        Debug.Log("Connecting");
    }

     public IEnumerator PopulateUserResult(GameObject chosenSafe)
     {
        info.connect();
        IDbCommand dbcmd = info.dbconn.CreateCommand();
        string sqlQuery = "UPDATE users " + "SET safetypoint = @Safetypoint, position = @Position " + "WHERE userID = " + GameManager.instance.player.id;
        dbcmd.Parameters.Add(new SqliteParameter
        {
            ParameterName = "Position",
            Value = GameManager.instance.player.currentPosition.ToString()
        });
        dbcmd.Parameters.Add(new SqliteParameter
        {
            ParameterName = "Safetypoint",
            Value = chosenSafe.name
        }) ;
        //dbcmd.Parameters.Add(new SqliteParameter
        //{
        //ParameterName = "Points",
        //Value = toggleTrainer.isOn
        //});
        Debug.Log(chosenSafe);
        dbcmd.CommandText = sqlQuery;
        int result = dbcmd.ExecuteNonQuery();
        Debug.Log(result);
        dbcmd.Dispose();
        dbcmd = null;


        userObject.namePlayer.text = "Naam: " + GameManager.instance.player.email;
        userObject.position.text = "Positie: " + spawnPosition.ToString();
        userObject.safeLocation.text = "Veilige plek: " + chosenSafe.name;
        yield return new WaitForSeconds(0.2f);
        Instantiate(userObject, UIManager.instance.rect.transform);
        yield return null;
    }

    public void CompareSafeZone(GameObject nearestSafe, GameObject chosenSafe)
    {
        StartCoroutine(PopulateUserResult(chosenSafe));
        if (nearestSafe == chosenSafe)
        {
            GameManager.instance.player.points += 10;
        }
        else
        {
            GameManager.instance.player.points += 5;
        }
    }

    public void PopulateScrollView()
    {
        /*info.connect();
        IDbCommand dbcmd = info.dbconn.CreateCommand();
        string sqlQuery = "SELECT email, position, safetypoint " + "FROM users";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            string email = reader.GetString(1);
            string position = reader.GetString(4);
            string safetypoint = reader.GetString(5);

            if(position != "" && safetypoint != "")
            {
                Instantiate(userObject, feedbackScrollView.content);
                userObject.namePlayer.text = "Naam: " + email;
                userObject.position.text = "Positie: " + position.ToString();
                userObject.safeLocation.text = "Veilige plek: " + safetypoint;
            }
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            info.disconnect();
            return;


        }*/

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
