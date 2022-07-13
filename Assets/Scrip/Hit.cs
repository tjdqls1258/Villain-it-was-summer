using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    [SerializeField] private float Swap_Speed = 0.05f;
    [SerializeField] private float Hit_Invincible_Time = 0.5f;
    [SerializeField] private Color Hit_Color;

    public bool Is_Hit = false;
    public float Reset_Hit_Time = 0.5f;
    private SpriteRenderer sprite;
    private Unit Data;

    private void Awake()
    {
        Data = GetComponent<Unit>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void GetDamage(float Damage)
    {
        Data.iHP -= Damage;
        if (Data.iHP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Drop_Item();
        Destroy(gameObject);
    }

    private void Drop_Item()
    {
        if(gameObject.tag == "Player")
        {
            return;
        }
        Debug.Log("아이템 드랍");
    }

    public void Player_Is_Hit(float Damage)
    {
        if (!Is_Hit)
        {
            StartCoroutine(Reset_Hit());
            GetDamage(Damage);
            Is_Hit = true;
        }
    }

    IEnumerator Reset_Hit()
    {
        float Gone_Time = 0.0f;
        while (Gone_Time <= Hit_Invincible_Time)
        {
            if (sprite.color == Hit_Color)
            {
                sprite.color = Color.white;
            }
            else
            {
                sprite.color = Hit_Color;
            }
            Gone_Time += Swap_Speed;
            yield return new WaitForSeconds(Swap_Speed);
        }
        sprite.color = Color.white;
        Is_Hit = false;
        Debug.Log(gameObject.name + " : 복귀");
    }

}
