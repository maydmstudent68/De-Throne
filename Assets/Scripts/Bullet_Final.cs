using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Bullet_Final : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    // Remove bullets that are off screen
    private void Update()
    {
        Vector3 currentPos = Camera.main.WorldToScreenPoint(transform.position);
        bool outOfBounds = !Screen.safeArea.Contains(currentPos);

        if (outOfBounds)
        {
            Destroy(this.gameObject);
        }
    }
}