using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class S_unicornMovement : MonoBehaviour
{

    public Rigidbody unicornBody;
    public float minDurationBetweenBounces;
    public float maxDurationBetweenBounces;
    private float currentDurationBetweenBounces;
    private float bounceTimer;
    public float bounceForce;

    public float unicornGravity;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Bounce();

        currentDurationBetweenBounces = Random.Range(minDurationBetweenBounces, maxDurationBetweenBounces);
    }

    private void FixedUpdate()
    {
        unicornBody.AddForce(Vector3.down * (unicornGravity ));
    }

    void Update()
    {
        bounceTimer += Time.deltaTime;

        if (bounceTimer >= currentDurationBetweenBounces)
        {
            Bounce();
            bounceTimer = 0;
            currentDurationBetweenBounces = Random.Range(minDurationBetweenBounces, maxDurationBetweenBounces);
        }
    }

    void Bounce()
    {
        unicornBody.AddForce((Vector3.up + new Vector3(Random.Range(-1f, 1f),0,0)) * bounceForce, ForceMode.VelocityChange);
    }
}
