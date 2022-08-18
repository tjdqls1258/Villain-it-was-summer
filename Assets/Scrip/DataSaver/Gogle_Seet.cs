using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Gogle_Seet_Data
{
    public static List<Dictionary<string, object>> data;
}

public class Gogle_Seet : MonoBehaviour
{
    const string URL = "https://docs.google.com/spreadsheets/d/1AUEE8X9m1_rj47ypJ9315nMz2Pg2A_6o988dP50G9tU/edit#gid=0/export?format=csv";
    public List<CSV_Data> Datas = new List<CSV_Data>();
    private IEnumerator Start()
    {
        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();

        string datas = www.downloadHandler.text;
        Gogle_Seet_Data.data = CSVReader.Read(datas);
        Debug.Log((int)Gogle_Seet_Data.data[0]["ITEAM_ID"]);
        for (var i = 0; i < Gogle_Seet_Data.data.Count; i++)
        {
            Datas.Add(new CSV_Data
            {
                ITEAM_ID = (int)Gogle_Seet_Data.data[i]["ITEAM_ID"],
                ITEAM_NAME = (string)Gogle_Seet_Data.data[i]["ITEAM_NAME"],
            });
        }
    }

    public CSV_Data Find_Hero(int _id)
    {
        int data = Datas.FindIndex(Item => _id == Item.ITEAM_ID);
        if (data == -1)
        {
            return null;
        }
        return Datas[data];
    }
}
