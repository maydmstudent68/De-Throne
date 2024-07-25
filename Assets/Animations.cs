using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    public Animator playerAnimator;

    // Update is called once per frame
    void Update()
    {

        bool pressedRight = Input.GetKey(KeyCode.RightArrow);
        bool pressedLeft = Input.GetKey(KeyCode.LeftArrow);  
    bool pressedUp = Input.GetKey(KeyCode.Space);

        if (pressedRight)
        {
            playerAnimator.SetInteger("State", 1);
        }

        if (pressedLeft)
        {
            playerAnimator.SetInteger("State", 1);
        }
        if (pressedUp)
        {
            playerAnimator.SetInteger("State", 0);
        }
    }
}
