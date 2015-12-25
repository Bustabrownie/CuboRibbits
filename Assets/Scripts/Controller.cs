using UnityEngine;
using System.Collections;

// A beautiful script written mostly by Nyero Faulitahs.
// I have made some modifications:
// Added the jumpLeeway function.
// Added a variable jump height.
// Changed constants for better feel and control.
// Changed accel and airAccel values when touching ground/walls.
// Here is a message from Nyero:

/********************************************************
 * Thank you for using this script, it makes me feel all
 * warm and happy inside. ;)
 *                             -Nyero
 ********************************************************/

public class Controller : MonoBehaviour
{	
	public class GroundState
	{
		private GameObject player;
		private float  width;
		private float height;
		private float length;

		// GroundState constructor.  Sets offsets for raycasting.
		public GroundState(GameObject playerRef)
		{
			player = playerRef;
			width = player.GetComponent<Collider2D>().bounds.extents.x + 0.1f;
			height = player.GetComponent<Collider2D>().bounds.extents.y + 0.2f;
			length = 0.05f;
		}
		
		// Returns whether or not player is touching wall.
		public bool isWall()
		{
			bool left = Physics2D.Raycast(new Vector2(player.transform.position.x - width, player.transform.position.y), -Vector2.right, length);
			bool right = Physics2D.Raycast(new Vector2(player.transform.position.x + width, player.transform.position.y), Vector2.right, length);
			
			if ( left || right )
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		
		// Returns whether or not player is touching ground.
		public bool isGround()
		{
			bool bottom1 = Physics2D.Raycast(new Vector2(player.transform.position.x, player.transform.position.y - height), -Vector2.up, length);
			bool bottom2 = Physics2D.Raycast(new Vector2(player.transform.position.x + (width - 0.2f), player.transform.position.y - height), -Vector2.up, length);
			bool bottom3 = Physics2D.Raycast(new Vector2(player.transform.position.x - (width - 0.2f), player.transform.position.y - height), -Vector2.up, length);
			if ( bottom1 || bottom2 || bottom3 )
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		
		// Returns whether or not player is touching wall or ground.
		public bool isTouching()
		{
			if ( isGround() || isWall() )
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		
		// Returns direction of wall.
		public int wallDirection()
		{
			bool left = Physics2D.Raycast(new Vector2(player.transform.position.x - width, player.transform.position.y), -Vector2.right, length);
			bool right = Physics2D.Raycast(new Vector2(player.transform.position.x + width, player.transform.position.y), Vector2.right, length);
			
			if ( left )
			{
				return -1;
			}
			else if( right )
			{
				return 1;
			}
			else
			{
				return 0;
			}
		}
	}
	
	public float    speed = 11.25f;			// Running speed.
	public float    accel = 8.75f;			// Acceleration on the ground.
	public float airAccel = 8.75f;			// How fast can you turn around in air.
	public float jumpShortSpeed = 0f;		// Velocity for the lowest jump.
	public float jumpSpeed = 13f;			// Velocity for the highest jump.

	bool jump = false;						// Jump is held.
	bool jumpWall = false;					// Jump is held on wall.
	bool jumpCancel = false;				// Jump is released.

	private Vector2 input;					// Variable to help tell if button was pressed.
	private GroundState groundState;		// Tell if the player is on the ground or wall.

	public float jumpLeeway = 0.15f;		// The amount of time a player can still jump after falling.
	private float jumpTimer;				// Makes the above possible.

	public AudioClip jumpSound;				// Makes the jump sound!
	private AudioSource jumpAudio;			// Makes the above possible.
	
	void Awake()
	{
		// Initializes the audio.
		jumpAudio = GetComponent<AudioSource>();
	}

	void Start()
	{
		// Create an object to check if player is grounded or touching wall.
		groundState = new GroundState(transform.gameObject);
	}

	void Update()
	{

		// Assigns input if player is going left or right.
		if( Input.GetKey(KeyCode.LeftArrow) )
		{
			input.x = -1;
		}
		else if( Input.GetKey(KeyCode.RightArrow) )
		{
			input.x = 1;
		}
		else
		{
			input.x = 0;
		}

		// Jump is set to true when player presses jump key.
		if ( Input.GetKeyDown(KeyCode.Space) && groundState.isTouching() )
		{
			jumpAudio.PlayOneShot(jumpSound);
			input.y = 1;
			jump = true;
			jumpWall = true;
		}

		// Jump Cancel is set to true when jump key is released.
		if (Input.GetKeyUp(KeyCode.Space))
		{
			input.y = 0;
			jumpCancel = true;
		}
		
		// Reverse player if going different direction.
		transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, (input.x == 0) ? transform.localEulerAngles.y : (input.x + 1) * 90, transform.localEulerAngles.z);
	
	}

	void FixedUpdate()
	{	
		// jumpTimer only updates when the player is on the ground.
		if(groundState.isGround())
		{
			jumpTimer = Time.time;
		}
		
		// If the player falls off a platform, they still have a fraction of a second where a jump is still possible.
		if(!groundState.isGround() && Input.GetKeyDown(KeyCode.Space) && ((Time.time - jumpTimer) < jumpLeeway))
		{
			input.y = 0;
			jumpAudio.PlayOneShot(jumpSound);
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpSpeed);
			jump = false;
			jumpTimer = 0f;
		}

		// Move player left or right.
		GetComponent<Rigidbody2D>().AddForce(new Vector2(((input.x * speed) - GetComponent<Rigidbody2D>().velocity.x) * (groundState.isGround() ? accel : airAccel), 0));

		// Stop the player when input.x is 0
		GetComponent<Rigidbody2D>().velocity = new Vector2((input.x == 0 && groundState.isGround()) ? 0 : GetComponent<Rigidbody2D>().velocity.x, GetComponent<Rigidbody2D>().velocity.y);

		// Normal jump. (full speed.)
		if ( jump )
		{
			input.y = 0;
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpSpeed);
			jump = false;
		}

		// Wall jump. (pushes the player away from the wall at 1.5 times normal speed.)
		if ( jumpWall )
		{
			input.y = 0;
			GetComponent<Rigidbody2D>().velocity = new Vector2(-groundState.wallDirection() * speed * 1.4f, GetComponent<Rigidbody2D>().velocity.y);
			jumpWall = false;
		}

		// Cancel the jump when the button is no longer pressed.
		if ( jumpCancel )
		{
			if ( GetComponent<Rigidbody2D>().velocity.y > jumpShortSpeed )
			{
				GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpShortSpeed);
			}

			jumpCancel = false;
			jumpTimer = 0f;

		}

		// Makes airAccel and accel different when touching wall/ground to get more realistic sliding.
		if ( groundState.isGround() )
		{
			airAccel = 3f;
			accel = 8.75f;
		}
		else if ( groundState.isWall() && !groundState.isGround() && input.y == 0 )
		{
				airAccel = 3f;
				accel = 6f;
		}
		else
		{
			airAccel = 8.75f;
			accel = 8.75f;
		}
	}
}