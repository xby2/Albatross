using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class PlayerController: MonoBehaviour {


    public delegate void PlayerDead(int instaceID);
    public static event PlayerDead OnPlayerDead;

    Animator animator;
    float speed = 0.10f;
    public float rspeed = 5.0f;
    public float h;
    public float v;
    public Image icon;
    public int lives = 3;
	public int playerId = 0;

    enum State { v, h, none };
    private State previous;

    public float rotationSpeed = 30;
    public facing currentFacing;
    public Vector3 dir;

	private InputManager inputManager;
	private PlayerInput playerInput;

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
		inputManager = InputManager.getCurrentInputManager();
		if (!inputManager.playerControls.ContainsKey(playerId)) return;
		playerInput = inputManager.playerControls[playerId];
       
    }
	
	// Update is called once per frame
	void Update () {
        
		if (playerInput == null) return;
		h = playerInput.getHorizontalAxis();
		v =  playerInput.getVerticalAxis();
 
        if (h != 0 && (previous == State.h || previous == State.none)) 
        {
            dir.x = h;
            transform.position += new Vector3(h * speed, 0, 0);
            previous = State.h;
        }

        if (v != 0 && (previous == State.v || previous == State.none))
        {
            dir.z = v;
            transform.position += new Vector3(0, 0, v * speed);
            previous = State.v;
        }

        if ((h == 0 && previous == State.h) || (v == 0 && previous == State.v))
        {
            previous = State.none;
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

    public void Die() {
        lives--;
    }

    void ChangeDirection(facing f) {
        if (f == currentFacing) return;
        transform.localEulerAngles = new Vector3(0, (float)f, 0);


        currentFacing = f;

    }

}
