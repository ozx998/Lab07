using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;
    public GameObject player;
    private Rigidbody rgby;
    public float jumpForce;
    void Start()
    {
        rgby = GetComponent<Rigidbody>();
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
    }

    void Update()
    {
        float yVelocity = 0;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            thisAnimation.Play();
            yVelocity = jumpForce;

        }
        rgby.velocity = new Vector3(rgby.velocity.x, rgby.velocity.y + yVelocity, rgby.velocity.z);

    }
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene("LoseScene");
        }
        
    }

}
