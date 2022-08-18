using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetData : MonoBehaviour
{
    public CSV_Data CSV_Hero;
    [SerializeField] private Gogle_Seet Seet_data;

    public void CSV_set_Data(CSV_Data Hero)
    {
        CSV_Hero = Hero;
        Debug.Log(CSV_Hero.ITEAM_NAME);
    }

    public void Find(int _ID)
    {
        CSV_set_Data(Seet_data.Find_Hero(_ID));
    }
}
