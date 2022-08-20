using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target;
    public float speed;

    public Vector2 Center;
    public Vector2 Size;

    float Heigtht;
    float Width;

    private void Start()
    {
        Heigtht = Camera.main.orthographicSize;
        Width = Heigtht * Screen.width / Screen.height;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(Center, Size);
    }

    void LateUpdate()
    {
        //transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, target.position.y, transform.position.z), Time.deltaTime * speed);
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);

        float lx = Size.x * 0.5f - Width;
        float clamX = Mathf.Clamp(transform.position.x, -lx + Center.x, lx + Center.x);

        float ly = Size.y * 0.5f - Heigtht;
        float clamY = Mathf.Clamp(transform.position.y, -ly + Center.y, ly + Center.y);

        transform.position = new Vector3(clamX, clamY, transform.position.z);
    }
}
