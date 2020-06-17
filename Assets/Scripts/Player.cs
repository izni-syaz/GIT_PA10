using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public float force = 200;
    private Rigidbody thisRigidbody = null;
    private Animation thisAnimation;

    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
        thisRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            thisRigidbody.AddForce(Vector3.up * force);
            thisAnimation.Play();           
        }        
        
        if(transform.position.y <= -5)
        {
            GameManager.thisManager.GameOver();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Rock")
        {
            GameManager.thisManager.GameOver();    

        }
    }
}
