using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Danger_Singe : MonoBehaviour
{
    public GameObject CamParent;
    public PostProcessVolume post;
    public Player player;
    Color color = Color.red;
    public Color color_mid;

    void Awake()
    {
        post = CamParent.GetComponent<PostProcessVolume>();
        player = GetComponentInParent<Player>();
        color_mid = Color.white * 0.1f;
        color_mid.r = 1.0f;
    }

    void FixedUpdate()
    {
        if (post.profile.GetSetting<Vignette>().color == color_mid) { color = Color.red; }
        else if (post.profile.GetSetting<Vignette>().color == Color.red) 
        {
            color = color_mid;
        }
        post.profile.GetSetting<Vignette>().color.value =
            Color.LerpUnclamped(post.profile.GetSetting<Vignette>().color, color, Time.deltaTime * 20.0f);
    }

    private void OnDisable()
    {
        post.profile.GetSetting<Vignette>().color.value = Color.white;
    }
}
