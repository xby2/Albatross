using UnityEngine;
using System.Collections;
using System;

public class StormSpiritController : MonoBehaviour {

    Animator animator;
    float speed = 0.10f;
    public float rspeed = 5.0f;
    public float h;
    public float v;

    public float rotationSpeed = 30;
    public facing currentFacing;
    public Vector3 dir;

    public enum facing
    {
        up = 0,
        right = 30,
        down = 120,
        left = 180
    };


    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        rotationSpeed = 30;
    }
	
	// Update is called once per frame
	void Update () {
        bool jump = Input.GetButtonDown("Jump");
        animator.SetBool("jump", jump);
       
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");


        dir.x = h;
        dir.z = v;


        transform.position += new Vector3(h * speed, 0, v * speed);

        if (!jump)
        {
            if (Math.Abs(h) > 0 || Math.Abs(v) > 0)
            {
                animator.SetBool("isWalking", true);
            }
            else
            {
                animator.SetBool("isWalking", false);
            }
        }




        if (dir != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.LookRotation(dir),
                Time.deltaTime * rotationSpeed
            );
        }




    }


    void ChangeDirection(facing f) {
        if (f == currentFacing) return;
        transform.localEulerAngles = new Vector3(0, (float)f, 0);


        currentFacing = f;

    }

}
