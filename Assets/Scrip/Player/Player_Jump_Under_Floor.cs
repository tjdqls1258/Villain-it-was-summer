using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Jump_Under_Floor : MonoBehaviour
{
    [SerializeField] private GameObject Parent;
    // Start is called before the first frame update

    public void ChangeLayer()
    {
        Parent.gameObject.layer = 7;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Floor")
        {
            ChangeLayer();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Floor")
        {
            Parent.gameObject.layer = 6;
        }
    }
}
