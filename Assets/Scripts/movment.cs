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

    private bool canDash = true;
    private bool isDashing;
    public float dashingPower = 24f;
    public float dashingTime = 2f;
    //private float dashingCooldown = 1f;
    public characterRespawn spawnpoint;

    public Transform groundCheckPoint;
    private bool onGround;

    [SerializeField] private TrailRenderer tr;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing)
        {
            return;
        }


        Vector2 currentVelocity = myRigidbody2d.velocity;
        Vector2 newVelocity = currentVelocity;

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            Debug.Log("Player Dashing");
            StartCoroutine(Dash());
        }

        bool pressedRight = Input.GetKey(KeyCode.RightArrow);
        bool pressedLeft = Input.GetKey(KeyCode.LeftArrow);

        if (pressedRight)
        {

            //myAudioSource.Play();
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            newVelocity.x = moveSpeed;
            //   mySpriteRenderer.flipX = false;

        }

        //myAudioSource.Stop();

        if (pressedLeft)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
            newVelocity.x = -moveSpeed;
            //  mySpriteRenderer.flipX = true;
        }

        myRigidbody2d.velocity = newVelocity;

        onGround = IsOnGround();

        bool pressedJump = Input.GetKeyDown(KeyCode.Space);
        if (pressedJump && onGround)
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
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        transform.position = spawnpoint.checkpointFlag;
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = myRigidbody2d.gravityScale;
        myRigidbody2d.gravityScale = 0f;
        
        myRigidbody2d.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);

        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        myRigidbody2d.gravityScale = originalGravity;
        isDashing = false;
        canDash = true;
    }

    private void FixedUpdate()
    {
        //Debug.Log("rb velocity is " + myRigidbody2d.velocity);
        if (isDashing)
        {
            return;
        }
    }
}



