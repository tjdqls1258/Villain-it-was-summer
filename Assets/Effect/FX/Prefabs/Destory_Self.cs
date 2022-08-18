using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destory_Self : MonoBehaviour
{
    Animator self;
    void Start()
    {
        self = GetComponent<Animator>();
    }

    private void Update()
    {
        if(self.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            Destroy(gameObject);
        }
    }
}
