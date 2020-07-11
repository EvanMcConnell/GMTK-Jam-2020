using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuAnimationController : MonoBehaviour
{
    public enum state { enterLeft, enterRight, exitLeft, exitRight, idle };
    public state menuState;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (menuState)
        {
            case state.enterLeft:
                anim.SetBool("enterLeft", true);
                anim.SetBool("enterRight", false);
                anim.SetBool("exitLeft", false);
                anim.SetBool("exitRight", false);
                anim.SetBool("idle", false);
                break;

            case state.enterRight:
                anim.SetBool("enterLeft", false);
                anim.SetBool("enterRight", true);
                anim.SetBool("exitLeft", false);
                anim.SetBool("exitRight", false);
                anim.SetBool("idle", false);
                break;

            case state.exitLeft:
                anim.SetBool("enterLeft", false);
                anim.SetBool("enterRight", false);
                anim.SetBool("exitLeft", true);
                anim.SetBool("exitRight", false);
                anim.SetBool("idle", false);
                break;

            case state.exitRight:
                anim.SetBool("enterLeft", false);
                anim.SetBool("enterRight", false);
                anim.SetBool("exitLeft", false);
                anim.SetBool("exitRight", true);
                anim.SetBool("idle", false);
                break;

            case state.idle:
                anim.SetBool("enterLeft", false);
                anim.SetBool("enterRight", false);
                anim.SetBool("exitLeft", false);
                anim.SetBool("exitRight", false);
                anim.SetBool("idle", true);
                break;
        }
    }

    public void setState(state newState)
    {
        menuState = newState;
    }
}


