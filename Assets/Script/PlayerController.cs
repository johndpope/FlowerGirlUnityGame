using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	private float moveSpeedStore;
	public float speedMultiplier;

	public float speedIncreaseMilestone;
	private float speedIncreaseMilestoneStore;

	private float speedMilestoneCount;
	private float speedMilestoneCountScore;

	public float jumpForce;

	public float jumpTime;
	private float jumpTimeCounter;

	private bool DoubleJump;

	private Rigidbody2D myRigidBody;

	public bool grounded;
	public LayerMask whatIsGround;
	public Transform groundCheck;
	public float groundCheckRadius;

	//private Collider2D myCollider;

	private Animator myAnimator;

	public GameManager theGameManager;

	public AudioSource jumpSound;
	public AudioSource deathSound;

	/*public Transform target;
	Camera cam;
*/

	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D> ();

		//myCollider = GetComponent<Collider2D> ();

		myAnimator = GetComponent<Animator> ();

/*		cam = GetComponent<Camera>();

		Vector3 screenPos = cam.WorldToScreenPoint(target.position);

		transform.position = new Vector3 (screenPos.x +500, transform.position.y, transform.position.z);
*/
		jumpTimeCounter = jumpTime;

		moveSpeedStore = moveSpeed;

		speedMilestoneCount = speedIncreaseMilestone;

		speedMilestoneCountScore = speedMilestoneCount;

		speedIncreaseMilestoneStore = speedIncreaseMilestone;
	}
	
	// Update is called once per frame
	void Update () {
	
		//grounded = Physics2D.IsTouchingLayers (myCollider, whatIsGround);

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);

		if (transform.position.x > speedMilestoneCount) 
		{
			speedMilestoneCount += speedIncreaseMilestone;

			speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;

			moveSpeed = moveSpeed * speedMultiplier;
		}

		myRigidBody.velocity = new Vector2 (moveSpeed, myRigidBody.velocity.y);

		if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetMouseButtonDown(0))
		{
			if (grounded) {
				myRigidBody.velocity = new Vector2 (myRigidBody.velocity.x, jumpForce);
				jumpSound.Play ();
			}

			if (!grounded && DoubleJump) {
				jumpSound.Play ();
				DoubleJump = false;
				jumpTimeCounter = jumpTime;
				myRigidBody.velocity = new Vector2 (myRigidBody.velocity.x, jumpForce);
			}
		}

		if (Input.GetKey (KeyCode.UpArrow) || Input.GetMouseButton (0)) {
		
			if (jumpTimeCounter > 0) {
				myRigidBody.velocity = new Vector2 (myRigidBody.velocity.x, jumpForce);
				jumpTimeCounter -= Time.deltaTime;
			} 
		}

		if (Input.GetKeyUp (KeyCode.UpArrow) || Input.GetMouseButtonUp (0)) {
		
			jumpTimeCounter = 0;
		}

		if (grounded) {
		
			jumpTimeCounter = jumpTime;
			DoubleJump = true;

		}

		myAnimator.SetFloat ("Speed", myRigidBody.velocity.x);
		myAnimator.SetBool ("Grounded", grounded);

	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag=="Respawn")
		{
			deathSound.Play ();
			theGameManager.Restartgame();
			moveSpeed = moveSpeedStore;
			speedMilestoneCount = speedMilestoneCountScore;
			speedIncreaseMilestone = speedIncreaseMilestoneStore;
		}
	}
} 