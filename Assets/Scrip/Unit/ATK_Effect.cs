using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATK_Effect : MonoBehaviour
{
    public GameObject Effect;
    private GameObject EffectAtive;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Hit>())
        {
            if (!other.gameObject.GetComponent<Hit>().Is_Hit)
            {
                EffectAtive = Instantiate(Effect, other.bounds.ClosestPoint(transform.position), Quaternion.identity);
            }
        }
    }
}
