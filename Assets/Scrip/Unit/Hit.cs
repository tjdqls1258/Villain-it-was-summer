using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    [SerializeField] private float Swap_Speed = 0.05f;
    public float Hit_Invincible_Time = 0.5f;
    [SerializeField] private Color[] Hit_Color;
    [SerializeField] private GameObject Die_Effect;

    public bool Is_Hit = false;
    public float Reset_Hit_Time = 0.5f;
    [SerializeField] private SpriteRenderer[] sprite;
    [SerializeField] private Rigidbody2D rigid;

    [SerializeField] private GameObject DamageText;
    [SerializeField] private Transform DamageTextPos;

    public Animation_Controller animation_Con;
    private Unit Data;
    public GameObject ATK_area;

    private void Awake()
    {
        Data = GetComponent<Unit>();
        sprite = GetComponentsInChildren<SpriteRenderer>();
        Hit_Color = new Color[sprite.Length];
    }

    private void OnEnable()
    {
        for (int count = 0; count < sprite.Length; count++)
        {
            Hit_Color[count] = sprite[count].color;
            Hit_Color[count].a = 1.0f;
            sprite[count].color = Hit_Color[count];
        }

        Is_Hit = false;
        ATK_area.SetActive(true);
    }

    private void GetDamage(float Damage)
    {
        Data.fHP -= Damage;
        if (Data.fHP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Drop_Item();

        if(ATK_area != null)
        {
            ATK_area.SetActive(false);
        }

        if (Die_Effect != null)
        {
            Instantiate(Die_Effect, transform.position, Quaternion.identity);
        }

        animation_Con.Toggle_Die();
        Data.Change_State(Unit.State.DIE);
        StartCoroutine(Destroy_Self());
    }
    //애니메이션 재생후 제거.
    IEnumerator Destroy_Self()
    {
        yield return new WaitForSeconds(animation_Con.CurrentAnimationLength());
        if (transform.parent != null)
        {
            yield return new WaitForSeconds(animation_Con.CurrentAnimationLength());
            transform.position = new Vector3(0, transform.position.y, 0);
            transform.parent.gameObject.SetActive(false);
        }
        else { Destroy(gameObject, animation_Con.CurrentAnimationLength()); }
    }

    private void Drop_Item()
    {
        if(gameObject.tag == "Player")
        {
            return;
        }
        Debug.Log("아이템 드랍");
    }
    //해당 객체가 공격 당했을 경우
    public void Player_Is_Hit(float Damage, Vector2 HitPower, Vector3 HitPos)
    {
        if (!Is_Hit)
        {
            animation_Con.Toggle_Hit();
            rigid.AddForce(HitPower * -3.0f, ForceMode2D.Impulse);

            StartCoroutine(Reset_Hit());
            GetDamage(Damage);
            if (DamageText != null && DamageTextPos != null)
            {
                GameObject Text = Instantiate(DamageText, DamageTextPos.position, Quaternion.identity);
                Text.GetComponent<SetDamage_Text>().SetDamageText((int)Damage);
            }
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
                if(sprite[count] ==null)
                {
                    count++;
                    continue;
                }

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
            if (sprite[count] == null)
            {
                count++;
                continue;
            }
            Hit_Color[count] = sprite[count].color;
            Hit_Color[count].a = 1.0f;
            sprite[count].color = Hit_Color[count];
        }
        Is_Hit = false;
    }

}
