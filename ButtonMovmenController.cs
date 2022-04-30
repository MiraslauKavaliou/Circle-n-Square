using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMovmenController : MonoBehaviour
{
    public Square_Movment square;
    public Circle_Movement circle;
    // Start is called before the first frame update
    void Start()
    {
        square.jumpButton = false;
    }

    public void OnJumpButton()
    {
        square.jumpButton = true;
    }
    public void OnLeftButton()
    {
        circle.leftButton = true;
    }

    public void OnRightButton()
    {
        circle.rightButton = true;
    }
    public void OnLeftReleaseButton()
    {
        circle.leftButton = false;
    }

    public void OnRightReleaseButton()
    {
        circle.rightButton = false;
    }
}
