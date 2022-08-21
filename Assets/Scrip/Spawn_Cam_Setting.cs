using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Cam_Setting : MonoBehaviour
{
    private GameObject Player;
    private GameObject Camera;

    public Vector2 Center;
    public Vector2 Size;

    private IEnumerator Start()
    {
        yield return null;
        Destroy(GameObject.Find("Main Camera"));
        Camera = GameObject.Find("Cam");
        Player = GameObject.Find("Player");

        Camera.GetComponent<CameraMove>().Set_Box(Center, Size);
        Player.transform.position = transform.position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(Center, Size);
    }
}
