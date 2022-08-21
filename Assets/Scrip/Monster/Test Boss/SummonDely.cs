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
        StartCoroutine(Summon_Ative());
    }
    private void Awake()
    {
        StartCoroutine(Summon_Ative());
    }

    IEnumerator Summon_Ative()
    {
        yield return new WaitForSeconds(0.2f);
        Summon.SetActive(true);
    }
}
