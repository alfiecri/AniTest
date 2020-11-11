using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Animator playerAnim;

    float speed = 20.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            playerAnim.SetBool("ifStrafe", true);
        }
        if (Input.GetKeyUp(KeyCode.W))
        { 
            playerAnim.SetBool("ifStrafe", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerAnim.SetTrigger("triggerAttack");
        }   
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cube"))
        {
            playerAnim.SetTrigger("triggerDeath");
        }
    }
}
