using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonController : MonoBehaviour
{
    public menuAnimationController menuA;
    public menuAnimationController menuB;
    public menuAnimationController.state menuANewState;
    public menuAnimationController.state menuBNewState;

    public void transitionMenus()
    {
        menuA.setState(menuANewState);
        menuB.setState(menuBNewState);
    }
}
