using UnityEngine;
using System.Collections;

// A script written by me.
// I took aspects from Nyero's ground/wall functions.
// This script acts as the basic AI for the first boss.
public class BossThree : MonoBehaviour {

	public GameObject enemy;
	public GameObject player;

	public class GroundState
	{
		private GameObject enemy;
		private float  width;
		private float height;
		private float length;

		// GroundState constructor.  Sets offsets for raycasting.
		public GroundState(GameObject enemyRef)
		{
			enemy = enemyRef;
			width = enemy.GetComponent<Collider2D>().bounds.extents.x + 0.1f;
			height = enemy.GetComponent<Collider2D>().bounds.extents.y + 0.01f;
			length = 0.05f;
		}

		// Returns whether or not enemy is touching wall.
		public bool isWall()
		{
			bool left = Physics2D.Raycast(new Vector2(enemy.transform.position.x - width, enemy.transform.position.y), -Vector2.right, length);
			bool right = Physics2D.Raycast(new Vector2(enemy.transform.position.x + width, enemy.transform.position.y), Vector2.right, length);

			if ( left || right )
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		// Returns whether or not enemy is touching ground.
		public bool isGround()
		{
			bool bottom1 = Physics2D.Raycast(new Vector2(enemy.transform.position.x, enemy.transform.position.y - height), -Vector2.up, length);
			bool bottom2 = Physics2D.Raycast(new Vector2(enemy.transform.position.x + (width - 0.2f), enemy.transform.position.y - height), -Vector2.up, length);
			bool bottom3 = Physics2D.Raycast(new Vector2(enemy.transform.position.x - (width - 0.2f), enemy.transform.position.y - height), -Vector2.up, length);
			if ( bottom1 || bottom2 || bottom3 )
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		// Returns whether or not enemy is touching wall or ground.
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
			bool left = Physics2D.Raycast(new Vector2(enemy.transform.position.x - width, enemy.transform.position.y), -Vector2.right, length);
			bool right = Physics2D.Raycast(new Vector2(enemy.transform.position.x + width, enemy.transform.position.y), Vector2.right, length);

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

	public float    speed = 3.5f;			// Running speed.
	public float    accel = 3000f;			// Acceleration on the ground.
	public float airAccel = 200f;				// How fast can you turn around in air.
	public float jumpSpeed = 16f;			// Velocity for the highest jump.

	private GroundState groundState;
	private Vector2 input;
	bool jump = false;						// Jump is held.
	bool jumpWall = false;					// Jump is held on wall.
	bool jumpSuper = false;

	private float startTime;

	void Start()
	{
		startTime = Time.time;
		groundState = new GroundState(transform.gameObject);
	}

	void Update()
	{
		if ((Time.time - startTime) > 20f)
		{
			speed = 4f;
		}

		if ((Time.time - startTime) > 40f)
		{
			speed = 4.5f;
		}

		if ((Time.time - startTime) > 60f)
		{
			speed = 5f;
		}

        if ((Time.time - startTime) > 70f)
        {
            if(enemy.transform.position.x < 0f)
            {
                if (enemy.transform.position.x > -3.9f)
                {
                    input.x = -1;
                }
                else if(enemy.transform.position.x < -4.1f)
                {
                    input.x = 1;
                }
                else
                {
                    GetComponent<BoxCollider2D>().isTrigger = false;
                    speed = 0f;
                    jump = false;
                }
            }
            else if(enemy.transform.position.x > 0f)
            {
                if (enemy.transform.position.x > 4.1f)
                {
                    input.x = -1;
                }
                else if(enemy.transform.position.x < 3.9f)
                {
                    input.x = 1;
                }
                else
                {
                    GetComponent<BoxCollider2D>().isTrigger = false;
                    speed = 0f;
                    jump = false;
                }
            }
        }

		// If the player is to the right of the enemy, it will go right and vice versa.
		if(-8f < enemy.transform.position.x && enemy.transform.position.x < -5f && Mathf.Abs(enemy.transform.position.x - player.transform.position.x) < 1.5f)
		{
			if(Mathf.Abs(player.transform.position.x + 6.8f) < Mathf.Abs(player.transform.position.x + 6.2f))
			{
				input.x = -1;			
			}
			else
			{
				input.x = 1;	
			}
		}
		else if(8f > enemy.transform.position.x && enemy.transform.position.x > 5f && Mathf.Abs(enemy.transform.position.x - player.transform.position.x) < 1.5f)
		{
			if(Mathf.Abs(player.transform.position.x - 6.2f) < Mathf.Abs(player.transform.position.x - 6.8f))
			{
				input.x = -1;			
			}	
			else
			{
				input.x = 1;	
			}
		}
		else if(-2.5f < enemy.transform.position.x && enemy.transform.position.x < 2.5f && Mathf.Abs(enemy.transform.position.x - player.transform.position.x) < 2.5f && (enemy.transform.position.y < -3f || enemy.transform.position.y > 4f))
		{
			if(player.transform.position.x < 0f)
			{
				input.x = -1;
			}
			else if(player.transform.position.x > 0f)
			{
				input.x = 1;
			}
		}
		else if(player.transform.position.x < enemy.transform.position.x)
		{
			input.x = -1;						
		}
		else if(player.transform.position.x > enemy.transform.position.x)
		{
			input.x = 1;			
		}

		if ((Mathf.Abs (2.5f - enemy.transform.position.x) < 1f || Mathf.Abs (enemy.transform.position.x + 2.5f) < 1f) && groundState.isGround() && Mathf.Abs(enemy.transform.position.x - player.transform.position.x) < 2.5f && (Time.time - startTime) < 71f)
		{ //&& Mathf.Abs(player.transform.position.x - enemy.transform.position.x) < 6f)
			input.y = 1;
			jumpSuper = true;
		}
		else if(-2.5f < enemy.transform.position.x && enemy.transform.position.x < 2.5f && -3f < enemy.transform.position.y && enemy.transform.position.y < 3f && groundState.isWall() && enemy.transform.position.y > player.transform.position.y)
		{
			input.y = 1;
			//jump = true;
			jumpWall = true;
		}
		else if((((13f - enemy.transform.position.x) < 9f) || ((enemy.transform.position.x + 13f) < 9f)) && groundState.isTouching())
		{
			input.y = 1;
			jump = true;
			jumpWall = true;
		}
		else if(enemy.transform.position.y > player.transform.position.y)
		{
			input.y = 0;
			jump = false;
			jumpWall = false;
		}
		else if(groundState.isTouching() && (Time.time - startTime) < 71f)
		{
			input.y = 1;
			jump = true;
			jumpWall = true;
		}

		// Reverse player if going different direction.
		transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, (input.x == 0) ? transform.localEulerAngles.y : (input.x + 1) * 90, transform.localEulerAngles.z);
	}

	void FixedUpdate()
	{	

		// Move player left or right.
		GetComponent<Rigidbody2D>().AddForce(new Vector2(((input.x * speed) - GetComponent<Rigidbody2D>().velocity.x) * (groundState.isGround() ? accel : airAccel), 0));

		// Stop the player when input.x is 0
		GetComponent<Rigidbody2D>().velocity = new Vector2((input.x == 0 && groundState.isGround()) ? 0 : GetComponent<Rigidbody2D>().velocity.x, GetComponent<Rigidbody2D>().velocity.y);

		// Normal jump. (full speed.)
		if ( jump )
		{
			airAccel = 200f;
			//jumpSpeed = 22f;
			input.y = 0;
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x * 1.5f, jumpSpeed);
			jump = false;
		}

		// Wall jump. (pushes the player away from the wall at 1.5 times normal speed.)
		if ( jumpWall )
		{
			airAccel = 1000f;
			//jumpSpeed = 1f;
			input.y = 0;
			GetComponent<Rigidbody2D>().velocity = new Vector2(-groundState.wallDirection() * speed * 3f, GetComponent<Rigidbody2D>().velocity.y);
			jumpWall = false;
		}

		if ( jumpSuper )
		{
			airAccel = 1000f;
			//jumpSpeed = 22f;
			input.y = 0;
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x * 1f, jumpSpeed * 1.5f);
			jumpSuper = false;
		}
	}
}
