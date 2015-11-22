using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class PlayerScript : MonoBehaviour {

    Animator animator;
    float speed;
    public bool isWalking;

    public float smooth = 2.0F;
    public float tiltAngle = 30.0F;
    public float h;
    public float v;

    // Use this for initialization
    void Start () {


        animator = GetComponent<Animator>();
        speed = 0.1f;
        smooth = 2.0F;
        tiltAngle = 90f;
    }
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Move(h, v);
        Animation(h, v);

    }

    void FixedUpdate() {

  
    }

    void Move (float h, float v)
    {
        this.h = h;
        this.v = v;
        Vector3 moveVec;

        if (v == 0 && h == 0) return;
        if (Math.Abs(h) > Math.Abs(v))
        {
            var tiltAroundZ = 0;
            if (h > 0)
            {
                tiltAroundZ = 90;
            }
            else {
                tiltAroundZ = -90;
            }

            Quaternion target = Quaternion.Euler(0, tiltAroundZ, 0);
            transform.rotation = target;
            moveVec = new Vector3(h * speed, 0, 0);
        }
        else {
            if (v < 0)
            {
                float tiltAroundZ = 180;
                Quaternion target = Quaternion.Euler(0, tiltAroundZ, 0);
                transform.rotation = target;
            }
            else {
                float tiltAroundZ = 0;
                Quaternion target = Quaternion.Euler(0, tiltAroundZ, 0);
                transform.rotation = target;

            }

            moveVec = new Vector3(0, 0, v * speed);
        }

        transform.position += moveVec;






    }

    void Animation(float h, float v)
    {
        bool walking = h != 0f || v != 0f;
        animator.SetBool("IsWalking", walking);
        isWalking = walking;
    }




}
