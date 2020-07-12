using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonController : MonoBehaviour
{
    public menuAnimationController menuA;
    public menuAnimationController menuB;
    public menuAnimationController.state menuANewState;
    public menuAnimationController.state menuBNewState;
    public transitionManager.state newTransitionState;
    public string nextLevel;
    public GameObject transitionImage;

    public void transitionMenus()
    {
        menuA.setState(menuANewState);
        menuB.setState(menuBNewState);
    }

    public void loadLevel()
    {
        //transitionImage.SetActive(true);
        transitionImage.GetComponent<transitionManager>().setNextLevel(nextLevel);
        transitionImage.GetComponent<transitionManager>().setState(newTransitionState);
    }

    public void Quit()
    {
        Application.Quit(0);
    }
}
