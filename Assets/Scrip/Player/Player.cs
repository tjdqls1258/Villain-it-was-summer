using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public float Jump_Power = 5.0f;
}
