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
        setanim(num);
    }

    void setanim(int no)
    {
        switch (no)
        {
            case 1:
                anim.SetBool("Ischeering", true);
                anim.SetBool("Isclapping", false);
                anim.SetBool("IsExcited", false);
                print("cheering");
                break;
            case 2:
                anim.SetBool("Ischeering", false);
                anim.SetBool("Isclapping", true);
                anim.SetBool("IsExcited", false);
                print("clapping");
                break;
            case 3:
                anim.SetBool("Ischeering", false);
                anim.SetBool("Isclapping", false);
                anim.SetBool("IsExcited", true);
                print("excited");
                break;
        }
    }

    void Update()
    {
        timer -= 1 * Time.deltaTime;
        if(timer < 0)
        {
            num = Random.Range(1, 4);
            print(num);
            setanim(num);
            //switch (num)
            //{
            //    case 1:
            //        anim.SetBool("Ischeering", true);
            //        anim.SetBool("Isclapping", false);
            //        anim.SetBool("IsExcited", false);
            //        print("cheering");
            //        break;
            //    case 2:
            //        anim.SetBool("Ischeering", false);
            //        anim.SetBool("Isclapping", true);
            //        anim.SetBool("IsExcited", false);
            //        print("clapping");
            //        break;
            //    case 3:
            //        anim.SetBool("Ischeering", false);
            //        anim.SetBool("Isclapping", false);
            //        anim.SetBool("IsExcited", true);
            //        print("excited");
            //        break;
            //}
            timer = 10;
        }
    }
}
