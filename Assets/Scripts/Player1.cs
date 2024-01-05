using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public Transform aimTarget1; // the target where we aim to land the ball
    float speed1 = 7f; // move speed
    float force = 13; // ball impact force
    public Rigidbody rb11;
    public Vector3 movement1;
    bool hitting1; // boolean to know if we are hitting the ball or not 
    public AudioClip hitsounds;
    public AudioSource hitsoundd;
    public Transform ball1; // the ball 
    Animator animator1;

    Vector3 aimTargetInitialPosition1; // initial position of the aiming gameObject which is the center of the opposite court

    ShotManager shotManager1; // reference to the shotmanager component
    Shot currentShot1; // the current shot we are playing to acces it's attributes

    private void Start()
    {
        animator1 = GetComponent<Animator>(); // referennce out animator
        aimTargetInitialPosition1 = aimTarget1.position; // initialise the aim position to the center( where we placed it in the editor )
        shotManager1 = GetComponent<ShotManager>(); // accesing our shot manager component 
        currentShot1 = shotManager1.topSpin; // defaulting our current shot as topspin
        rb11 = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal1"); // get the horizontal axis of the keyboard
        float v = Input.GetAxisRaw("Vertical1"); // get the vertical axis of the keyboard

        if (Input.GetKeyDown(KeyCode.F))
        {
            hitting1 = true; // we are trying to hit the ball and aim where to make it land
            currentShot1 = shotManager1.topSpin; // set our current shot to top spin
        }
        else if (Input.GetKeyUp(KeyCode.F))
        {
            hitting1 = false; // we let go of the key so we are not hitting anymore and this 
        }                    // is used to alternate between moving the aim target and ourself

        if (Input.GetKeyDown(KeyCode.E))
        {
            hitting1 = true; // we are trying to hit the ball and aim where to make it land
            currentShot1 = shotManager1.flat; // set our current shot to top spin

        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            hitting1 = false;
        }



        if (hitting1)  // if we are trying to hit the ball
        {
            aimTarget1.Translate(new Vector3(h, 0, 0) * speed1 * 2 * Time.deltaTime); //translate the aiming gameObject on the court horizontallly


        }



        if ((h != 0 || v != 0) && !hitting1) // if we want to move and we are not hitting the ball
        {
            movement1 = new Vector3(Input.GetAxis("Vertical1"), 0, Input.GetAxis("Horizontal1"));

        }
        if ((h != 0 || v != 0)) // if we want to move and we are not hitting the ball
        {
            animator1.SetBool("running", true);

        }
        else
        {
            animator1.SetBool("running", false);
        }


        

       


    }
    void FixedUpdate()
    {
        MovementCharacter1(movement1);
    }
    void MovementCharacter1(Vector3 direction)
    {
        rb11.velocity = direction * speed1;

        if (rb11.velocity.x > 1)
        {
            //animator1.SetBool("running", true);
        }
        else
        {
            //animator1.SetBool("running", false);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball")) // if we collide with the ball 
        {
            Vector3 dir = aimTarget1.position - transform.position; // get the direction to where we want to send the ball
            other.GetComponent<Rigidbody>().velocity = dir.normalized * currentShot1.hitForce + new Vector3(0, currentShot1.upForce, 0);
            //add force to the ball plus some upward force according to the shot being played

            Vector3 ballDir = ball1.position - transform.position; // get the direction of the ball compared to us to know if it is
            if (ballDir.x >= 0)                                   // on out right or left side 
            {
                animator1.Play("forehand");                        // play a forhand animation if the ball is on our right
                hitsoundd.PlayOneShot(hitsounds);
            }
            else                                                  // otherwise play a backhand animation 
            {
                animator1.Play("backhand");
            }

            aimTarget1.position = aimTargetInitialPosition1; // reset the position of the aiming gameObject to it's original position ( center)

        }
    }
}
