using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	//Create floats to be used through out the scripts
	float timer = 0;
	float timeToWaitRoll= 2.0f;

	public float runSpeed = 5;
	public float verticalVelocity;
	private float gravity = 5.0f;
	public float jumpPower = 40.0f;

	bool checkingTime;
	bool timerDone;
	public bool jump;
	public bool sliding;
	public bool dead;

	public GameObject ragdoll;

	CharacterController controller;
	Animator animator;

	public Vector3 move;

	public DeathMenu death;
	public Score score;

	public AudioSource jumpSound;
	// Use this for initialization
	void Start () {

		controller = GetComponent<CharacterController> ();
		animator = GetComponent<Animator> ();
	}	
 		
	
	// Update is called once per frame
	void Update () {
		
		runSpeed = runSpeed + 0.001f;

		if (dead) {
			death.ToggleEndMenu (score.score);
			dead = false;
			Instantiate(ragdoll, transform.position, transform.rotation);
			Destroy (gameObject);
		}

		move = Vector3.zero;

		if (controller.isGrounded) {
			verticalVelocity = -0.5f;

			if (Input.GetAxisRaw ("Vertical") > 0 || Input.GetMouseButton (0) && Input.mousePosition.x > Screen.width /2) {
				jump = true;
				jumpSound.Play ();
				sliding = false;
			}
			else{

				jump = false;

			}

		} else {
			
				verticalVelocity -= gravity * Time.deltaTime;
		}

		if (Input.GetAxisRaw ("Vertical") < 0 || Input.GetMouseButton (0) && Input.mousePosition.x < Screen.width /2) {
			sliding = true;
			jump = false;

		} else {
			WaitTime (timeToWaitRoll);
		}

		if(jump){
			verticalVelocity = jumpPower;
		}

		if (sliding) {
			controller.height = 1.0f;
		} else {
			controller.height = 1.3f;
		}

			move.x = runSpeed;
		move.y = verticalVelocity;

		animator.SetBool ("Jump", jump);
		animator.SetFloat ("verticalVelocity", verticalVelocity);
		animator.SetBool("Roll",sliding);


		controller.Move (move * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other){

		if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Fence") {
			
			dead = true;
		}
			if (other.gameObject.tag == "Slideable") {
			if (sliding) {
				dead = false;
			} else {
				dead = true;
			}
			}

		}

	void WaitTime(float timeToWait){

			timer += Time.deltaTime;
		if (timer >= timeToWait) {
			timerDone = true;
			timer = 0;
		}
		if (timerDone)
		{
			timerDone = false;
			sliding = false;
		}
	}
	}
