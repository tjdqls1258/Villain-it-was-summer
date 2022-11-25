using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patent2Effect : Skill
{
    public AnimationCurve MoveCurve;
    public Collider2D LeftATK_Area, RightATK_Area;
    public Transform LeftLef, RightLef;
    public Animator Leftanim, Rightanim;

    private Unit Monster;

    public float DownPos;
    public float DownTime;
    public float UpTime;

    public int LoopCount = 1;

    private void Awake()
    {
        Monster = GetComponentInParent<Unit>();

        LeftATK_Area = LeftLef.gameObject.GetComponent<Collider2D>();
        LeftATK_Area.enabled = false;

        RightATK_Area = RightLef.gameObject.GetComponent<Collider2D>();
        RightATK_Area.enabled = false;
    }

    public override void Skill_Ative()
    {
        LeftLef.gameObject.SetActive(true);
        RightLef.gameObject.SetActive(true);
        Monster.Change_State(Unit.State.Skill);
        StartCoroutine(Ation(LoopCount));
    }

    public override void Cancel_Skill()
    {
        LeftLef.gameObject.SetActive(false);
        RightLef.gameObject.SetActive(false);
        Monster.Change_State(Unit.State.IDLE);
    }

    public IEnumerator Ation(int LoopCount)
    {
        for (int Count = 0; Count < LoopCount; Count++)
        {
            StartCoroutine(Move(LeftLef, Leftanim, LeftATK_Area));
            yield return new WaitForSeconds(DownTime);
            StartCoroutine(Move(RightLef, Rightanim, RightATK_Area));
            yield return new WaitForSeconds(UpTime);
        }
        Cancel_Skill();
    }

    public IEnumerator Move(Transform Lef, Animator LefEffect,Collider2D LefCollider)
    {
        Vector3 startPos = Lef.localPosition;
        Vector3 endPos = startPos - new Vector3(0, DownPos, 0);

        float timer = 0.0f;
        LefCollider.enabled = true;
        while (timer < DownTime)
        {
            timer += Time.deltaTime;
            float currentTime = timer / DownTime;
            Lef.localPosition = Vector3.Lerp(startPos, endPos, MoveCurve.Evaluate(currentTime));
            yield return null;
        }
        LefEffect.SetTrigger("Boom");
        timer = 0.0f;
        startPos = Lef.localPosition;
        endPos = startPos + new Vector3(0, DownPos, 0);

        while (timer < UpTime)
        {
            timer += Time.deltaTime;
            float currentTime = timer / UpTime;
            Lef.localPosition = Vector3.Lerp(startPos, endPos, MoveCurve.Evaluate(currentTime));
            yield return null;
        }
        LefCollider.enabled = false;
    }
}
