using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Data;
using Mono.Data.Sqlite;
using System;

public class LoginManager : SingletonComponent<LoginManager>
{
    [SerializeField]
    private TMP_InputField emailInputField;
    [SerializeField]
    private TMP_InputField passwordInputField;

    [SerializeField]
    private TMP_Text loginErrorText;


    [SerializeField]
    private TMP_InputField emailInputFieldRegister;

    [SerializeField]
    private TMP_InputField passwordInputFieldRegister;

    [SerializeField]
    private TMP_Text registerErrorText;
    [SerializeField]
    private TMP_Text registerSuccesText;

    [SerializeField]
    private Toggle toggleTrainer;

    SqlLiteInfo info;

    // Start is called before the first frame update
    void Start()
    {
        info = new SqlLiteInfo();
        info.connect();
        Debug.Log("Connecting");
    }

    public void Login()
    {
        info.connect();
        if (emailInputField.text != "" || passwordInputField.text != "")
        {
            IDbCommand dbcmd = info.dbconn.CreateCommand();
            string sqlQuery = "SELECT userID, email, password, isTrainer FROM users";
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();
            while (reader.Read())
            {
                int userID = reader.GetInt32(0);
                string email = reader.GetString(1);
                string password = reader.GetString(2);
                int isTrainer = reader.GetInt32(3);

                if (email.Contains(emailInputField.text) && password.Contains(passwordInputField.text))
                {
                    Debug.Log("Logging in");
                    GameManager.instance.player.id = userID;
                    GameManager.instance.player.email = emailInputField.text;
                    GameManager.instance.player.isTrainer = isTrainer;
                    reader.Close();
                    reader = null;
                    dbcmd.Dispose();
                    dbcmd = null;
                    info.disconnect();
                    UIManager.instance.NextPanel(UIManager.instance.selectionScreen);
                    if (isTrainer == 1)
                    {
                        //GameManager.instance.LoadScene("GameEmployee");
                        UIManager.instance.selectionTrainerScreen.gameObject.SetActive(true);
                    }
                    return;

                }
            }
            loginErrorText.text = "Wachtwoord of email is incorrect";
        }
        else
        {
            loginErrorText.text = "Email of wachtwoord is niet ingevuld";
        }
    }

    public void LogOut()
    {
        Destroy(GameManager.instance.gameObject);
    }
    public void Register()
    {
        if (emailInputFieldRegister.text != "" || passwordInputFieldRegister.text != "")
        {
            info.connect();
            IDbCommand dbcmd = info.dbconn.CreateCommand();
            string sqlQuery = "INSERT INTO users (email, password, isTrainer) " + "VALUES (@Email, @Password, @IsTrainer);";
            dbcmd.Parameters.Add(new SqliteParameter
            {
                ParameterName = "Email",
                Value = emailInputFieldRegister.text
            });
            dbcmd.Parameters.Add(new SqliteParameter
            {
                ParameterName = "Password",
                Value = passwordInputFieldRegister.text
            });
            dbcmd.Parameters.Add(new SqliteParameter
            {
                ParameterName = "IsTrainer",
                Value = toggleTrainer.isOn
            });
            dbcmd.CommandText = sqlQuery;
            int result = dbcmd.ExecuteNonQuery();
            Debug.Log(result);
            dbcmd.Dispose();
            dbcmd = null;
            info.disconnect();
            registerSuccesText.text = "Account geregistreerd, je kunt nu inloggen";
        }
        else
        {
            registerErrorText.text = "Email of wachtwoord is niet ingevuld";
        }
    }

}
