using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transitionManager : MonoBehaviour
{
    public enum state { fadeIn, fadeOut, idle, load};
    public state transitionState;
    public Animator anim;
    public string nextLevel;

    void Start()
    {
        anim = GetComponent<Animator>();
        //nextLevel = GameObject.Find("Player").GetComponent<characterController>().nextLevel;
    }

    // Update is called once per frame
    void Update()
    {
        switch (transitionState)
        {
            case state.fadeIn:
                anim.SetBool("in", true);
                anim.SetBool("out", false);
                anim.SetBool("idle", false);
                anim.SetBool("load", false);
                break;

            case state.fadeOut:
                anim.SetBool("in", false);
                anim.SetBool("out", true);
                anim.SetBool("idle", false);
                anim.SetBool("load", false);
                break;

            case state.idle:
                anim.SetBool("in", false);
                anim.SetBool("out", false);
                anim.SetBool("idle", true);
                anim.SetBool("load", false);
                break;

            case state.load:
                GameManager.gameManager.loadLevel(nextLevel);
                break;

        }
    }

    public void setState(state newState)
    {
        transitionState = newState;
        for (int i = 0; i < 5; i++)
        {
            print(gameObject.name + " " + newState + " " + transitionState);
        }
    }

    public void setNextLevel(string level)
    {
        nextLevel = level;
    }
}
