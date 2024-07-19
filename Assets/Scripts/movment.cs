using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class movment : MonoBehaviour 
{ 

    public Rigidbody2D myRigidbody2d;
    public SpriteRenderer mySpriteRenderer;
   // public AudioSource myAudioSource;
    public int moveSpeed = 0;
    public float jumpSpeed;

    public Transform groundCheckPoint;
    private bool onGround;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 currentVelocity = myRigidbody2d.velocity;
        Vector2 newVelocity = currentVelocity;

        bool pressedRight = Input.GetKey(KeyCode.RightArrow);
        bool pressedLeft = Input.GetKey(KeyCode.LeftArrow);

        if (pressedRight) {

            //myAudioSource.Play();
            newVelocity.x = moveSpeed;
            mySpriteRenderer.flipX = false;
        }
        
        //myAudioSource.Stop();

        if (pressedLeft)
        {
            newVelocity.x = -moveSpeed;
            mySpriteRenderer.flipX = true;
        }

        myRigidbody2d.velocity = newVelocity;

        onGround = IsOnGround();

        bool pressedJump = Input.GetKeyDown(KeyCode.Space);
        if(pressedJump && onGround)
        {
            Jump(jumpSpeed);

        }
    }

    void Jump(float JumpSpeed)
    {
        Vector2 newVelocity = myRigidbody2d.velocity;
        newVelocity.y = JumpSpeed;
        myRigidbody2d.velocity = newVelocity;
    }

    bool IsOnGround()
    {
        Vector2 checkPosition = groundCheckPoint.position;
        bool hitACollider = Physics2D.OverlapPoint(checkPosition);
        return hitACollider;
    }

    public void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}



