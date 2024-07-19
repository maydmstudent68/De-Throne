using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;

public class FireProjectile_Final : MonoBehaviour
{
    public Transform spawnPoint;
    public Bullet_Final bulletPrefab;
    private void Start() { }

    // Update is called once per frame
    void Update()
    {

        // Use this line instead for the Platformer Toolkit
        //if (Keyboard.current[Key.Q].wasPressedThisFrame) {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}