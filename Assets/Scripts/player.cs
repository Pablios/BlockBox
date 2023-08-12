using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class player : MonoBehaviour
{
    public float forceMultiplier = 3f;
    public float maximumVelocity = 3f;
    public ParticleSystem deathParticles;
    private Rigidbody rb;
    private CinemachineImpulseSource cinemachineImpulseSource;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cinemachineImpulseSource = GetComponent<CinemachineImpulseSource>();
    }

    void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
     
        if (rb.velocity.magnitude <= maximumVelocity)
        rb.AddForce(new Vector3(horizontalInput * forceMultiplier, 0, 0));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hazard"))
        {
            GameManager.GameOver();
            Destroy(gameObject);
            Instantiate(deathParticles, transform.position, Quaternion.identity);
            cinemachineImpulseSource.GenerateImpulse();
        }
    }

}
