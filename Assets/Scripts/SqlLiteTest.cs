using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using System;

public class SqlLiteTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SqlLiteInfo info = new SqlLiteInfo();
        info.connect();
        IDbCommand dbcmd = info.dbconn.CreateCommand();
        string sqlQuery = "SELECT value, name " + "FROM info";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            int value = reader.GetInt32(0);
            string name = reader.GetString(1);

            Debug.Log("value= " + value + "  name =" + name);
        }

        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        info.disconnect();
    }
}