using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_ATK : MonoBehaviour
{
    [SerializeReference] private GameObject ATK_Aera, ATK_Aera_Parent;
    Vector3 This_And_Player_Distance;
    Vector3 ATK_Fower;

    private void Awake()
    {
        ATK_Fower = transform.position;
    }

    public void Monster_ATK_Start()
    {
        This_And_Player_Distance = GetComponentInParent<Monster_Move>().This_And_Player_Distance;

        if (This_And_Player_Distance.x > 0.0f)
        {
            ATK_Aera_Parent.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (This_And_Player_Distance.x < 0.0f)
        {
            ATK_Aera_Parent.transform.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        StartCoroutine(ATK());
    }
    IEnumerator ATK()
    {
        ATK_Aera.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        ATK_Aera.SetActive(false);
    }

}
