using UnityEngine;
using System.Collections;

public class EnemyPatrol : MonoBehaviour {

	public float moveSpeed;
	public float jumpSpeed;
	public float accel;
	public float airAccel;

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
			height = enemy.GetComponent<Collider2D>().bounds.extents.y + 0.2f;
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

	private GroundState groundState;

	// Use this for initialization
	void Start () {
		groundState = new GroundState(transform.gameObject);
	}
	
	// Update is called once per frame
	void Update () {

		//GetComponent<Rigidbody2D>().AddForce(new Vector2(((moveSpeed) - GetComponent<Rigidbody2D>().velocity.x) * (groundState.isGround() ? accel : airAccel), 0));

		if(player.transform.position.x > enemy.transform.position.x)
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
			//GetComponent<Rigidbody2D>().AddForce(new Vector2(((moveSpeed) - GetComponent<Rigidbody2D>().velocity.x) * (groundState.isGround() ? accel : airAccel), GetComponent<Rigidbody2D>().velocity.y));

		}
		else
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
			//GetComponent<Rigidbody2D>().AddForce(new Vector2(((moveSpeed) - GetComponent<Rigidbody2D>().velocity.x) * (groundState.isGround() ? accel : airAccel), GetComponent<Rigidbody2D>().velocity.y));

		}

		if((player.transform.position.y > enemy.transform.position.y) && groundState.isGround())
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpSpeed);
		}

		if(groundState.isWall())
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(((-groundState.wallDirection() * moveSpeed * 2f) - GetComponent<Rigidbody2D>().velocity.x) * airAccel, jumpSpeed * 0.8f);
			//GetComponent<Rigidbody2D>().AddForce(new Vector2(((-groundState.wallDirection() * moveSpeed * 2f) - GetComponent<Rigidbody2D>().velocity.x) * airAccel, jumpSpeed));

		}
	
	}
}
