using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
   public float jump;
   private Rigidbody2D rb;
   private bool isGrounded;

   public Animator ani;

   void Awake()
   {
    rb = GetComponent<Rigidbody2D>();
   }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump") && isGrounded){
            rb.AddForce(Vector2.up * jump);
        }

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            ani.SetTrigger("Slide");
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            ani.SetTrigger("Idle");
        }
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Ground")){
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D other){
        if(other.gameObject.CompareTag("Ground")){
            isGrounded = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Enemy")){
            SceneManager.LoadScene(0);
        }
    }
}
