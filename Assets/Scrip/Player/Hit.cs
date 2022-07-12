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

    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    public void Player_Is_Hit()
    {
        if (!Is_Hit)
        {
            StartCoroutine(Reset_Hit());
            Debug.Log(gameObject.name + " : ¸ÂÀ½");
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
        Debug.Log(gameObject.name + " : º¹±Í");
    }

}
