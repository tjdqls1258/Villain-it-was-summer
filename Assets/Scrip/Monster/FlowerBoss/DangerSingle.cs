using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerSingle : MonoBehaviour
{
    private Animator animator;
    private void OnEnable()
    {
        animator = GetComponent<Animator>();
        GetComponent<Collider2D>().enabled = false;
    }

    public void SetDamage()
    {
        animator.SetTrigger("ATK");
        GetComponent<Collider2D>().enabled = true;
    }

    public void DisAbleSelf()
    {
        gameObject.SetActive(false);
        GetComponent<Collider2D>().enabled = false;
    }
}
