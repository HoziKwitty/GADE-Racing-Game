using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    float timer = 5f;
    int num = 0;

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();

        num = Random.Range(1, 4);
        SetState(num);
    }

    void SetState(int inNum)
    {
        switch (inNum)
        {
            case 1:
                anim.SetBool("IsCheering", true);
                anim.SetBool("IsClapping", false);
                anim.SetBool("IsExcited", false);

                break;
            case 2:
                anim.SetBool("IsCheering", false);
                anim.SetBool("IsClapping", true);
                anim.SetBool("IsExcited", false);

                break;
            case 3:
                anim.SetBool("IsCheering", false);
                anim.SetBool("IsClapping", false);
                anim.SetBool("IsExcited", true);

                break;
        }
    }

    void Update()
    {
        timer -= 1 * Time.deltaTime;

        if (timer < 0)
        {
            num = Random.Range(1, 4);

            SetState(num);

            timer = 10;
        }
    }
}
