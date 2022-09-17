using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonDely : MonoBehaviour
{
    public GameObject Summon;
    private void OnEnable()
    {
        Summon.SetActive(false);
        Summon.transform.localPosition = new Vector3(0, -0.3f, 0);
    }

    public void Summon_Ative()
    {
        Summon.SetActive(true);
        Summon.transform.localPosition = new Vector3(0, -0.3f, 0);
    }
}
