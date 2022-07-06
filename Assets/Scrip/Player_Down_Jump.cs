using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Down_Jump : MonoBehaviour
{
    private bool Is_Down_Jump = true;
    [SerializeField] private GameObject Parent;

    public void ChangeLayer()
    {
        if (Is_Down_Jump && Parent.GetComponent<Rigidbody2D>().velocity.y == 0)
        {
            Parent.gameObject.layer = 7;
            StartCoroutine(Return_Layer());
        }
    }

    private IEnumerator Return_Layer()
    {
        yield return new WaitForSeconds(1.0f);
        Parent.gameObject.layer = 6;
    }
}
