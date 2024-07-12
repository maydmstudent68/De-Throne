using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movment : MonoBehaviour { 
    public Rigidbody2D myRigidbody2d;
    public SpriteRenderer mySpriteRenderer;
    public int moveSpeed = 0;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        Vector2 currentVelocity = myRigidbody2d.velocity;
        Vector2 newVelocity = currentVelocity;

        bool pressedRight = Input.GetKey(KeyCode.RightArrow);
        bool pressedLeft = Input.GetKey(KeyCode.LeftArrow);

        if (pressedRight) {
            newVelocity.x = moveSpeed;
        }

        if (pressedLeft)
        {
            newVelocity.x = -moveSpeed;
        }

        myRigidbody2d.velocity = newVelocity;
    }
}

