using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetDamage_Text : MonoBehaviour
{
    public float UpSpeed = 10.0f;
    public float LRSpeed = 1.0f;
    public float alphaSpeed = 2.0f;
    public float gravity = -1.0f;
    public float Destory_Time = 1.0f;
    [SerializeField] private Text TDamage;
    public Color alpha;

    private Vector3 MoveForce;

    void Awake()
    {
        TDamage = GetComponentInChildren<Text>();
        alpha = TDamage.color;

        alphaSpeed *= Time.deltaTime;
        LRSpeed = Random.Range(1.0f, -1.0f) * Time.deltaTime;

        Destroy(gameObject, Destory_Time);
    }

    void Update()
    {
        UpSpeed = (UpSpeed + gravity);
        transform.position += Vector3.up * UpSpeed * Time.deltaTime;
        transform.position += Vector3.right * LRSpeed;
        alpha.a = Mathf.Lerp(alpha.a, 0, alphaSpeed);
        TDamage.color = alpha;
    }

    public void SetDamageText(int Damage)
    {
        TDamage.text = Damage.ToString();
    }
}
