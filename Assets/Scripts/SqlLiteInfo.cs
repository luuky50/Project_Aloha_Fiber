using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System.IO;
using System;

[System.Serializable]
public class SqlLiteInfo
{
    string connectionPath; //Path to database.
    public IDbConnection dbconn;
    public void connect()
    {
        //connectionPath = "URI=file:" + Application.dataPath + "/" + "New Database.db";
        connectionPath = "URI=file:" + Application.dataPath + "/StreamingAssets/New Database.db";
        dbconn = new SqliteConnection(connectionPath);
        dbconn.Open();
    }
    public void disconnect()
    {
        dbconn.Close();
        dbconn = null;
    }
}
