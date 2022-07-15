using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    [SerializeField] private float Swap_Speed = 0.05f;
    [SerializeField] private float Hit_Invincible_Time = 0.5f;
    [SerializeField] private Color[] Hit_Color;

    public bool Is_Hit = false;
    public float Reset_Hit_Time = 0.5f;
    [SerializeField] private SpriteRenderer[] sprite;
    private Unit Data;

    private void Awake()
    {
        Data = GetComponent<Unit>();
        sprite = GetComponentsInChildren<SpriteRenderer>();
        Hit_Color = new Color[sprite.Length];

        for(int count = 0; count < sprite.Length; count++)
        {
            Hit_Color[count] = sprite[count].color;
        }
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
            for (int count = 0; count < sprite.Length; count++)
            {
                if (sprite[count].color.a == 1.0f)
                {
                    Hit_Color[count] = sprite[count].color;
                    Hit_Color[count].a = 0.3f;
                    sprite[count].color = Hit_Color[count];
                }
                else
                {
                    Hit_Color[count] = sprite[count].color;
                    Hit_Color[count].a = 1.0f;
                    sprite[count].color = Hit_Color[count];
                }
            }
            Gone_Time += Swap_Speed;
            yield return new WaitForSeconds(Swap_Speed);
        }
        for (int count = 0; count < sprite.Length; count++)
        {
            Hit_Color[count] = sprite[count].color;
            Hit_Color[count].a = 1.0f;
            sprite[count].color = Hit_Color[count];
        }
        
        Is_Hit = false;
        Debug.Log(gameObject.name + " : 복귀");
    }

}
