using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbiter : MonoBehaviour
{
    //https://www.youtube.com/watch?v=E6n-8jp-ZAY
    //Youtube video used for BlackHole script

    public Transform player;

    Rigidbody playerBody;

    public float influenceRange;
    public float intensity;
    public float distanceToPlayer;

    Vector3 pullForce;

    void Start()
    {
        playerBody = player.GetComponent<Rigidbody>();
    }

    void Update()
    {
        distanceToPlayer = Vector3.Distance(player.position, transform.position);
        if (distanceToPlayer <= influenceRange)
        {
            pullForce = (transform.position - player.position).normalized / distanceToPlayer * intensity;
            playerBody.AddForce(pullForce, ForceMode.Force);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            intensity = 400f;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            intensity = 200f;
        }
    }
}