using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction{up,down,right,left}

public class Euler_Movement : MonoBehaviour {

	Animator anim;
	Vector3 targetposition;
	Direction direction;
	public float speed = 2f;
	public LayerMask obstacles;

	void Start () {
		anim = GetComponent<Animator>();
		direction = Direction.down;

	}
	
	void Update () {
		Vector2 axisDirection = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));
		if (axisDirection != Vector2.zero && targetposition == transform.position) {
			if (Mathf.Abs (axisDirection.x) > Mathf.Abs (axisDirection.y)) {
				if (axisDirection.x > 0) {
					direction = Direction.right;
					if (!CheckCollision)
						targetposition += Vector3.right;
				} else {
					direction = Direction.left;
					if (!CheckCollision)
						targetposition -= Vector3.right;
				}
			}else{
				if (axisDirection.y > 0) {
					direction = Direction.up;
					if (!CheckCollision)
						targetposition += Vector3.up;
				}else{
					direction = Direction.down;
					if (!CheckCollision)
						targetposition -= Vector3.up;
				}
			}
		}

		transform.position = Vector3.MoveTowards(transform.position,targetposition,speed*Time.deltaTime);
	}

	bool CheckCollision{
		get{
			RaycastHit2D rh;
			Vector2 dir = Vector2.zero;
			if (direction == Direction.down) {
				dir = Vector2.down;
			}
			if (direction == Direction.up) {
				dir = Vector2.up;
			}
			if (direction == Direction.left) {
				dir = Vector2.left;
			}
			if (direction == Direction.right) {
				dir = Vector2.right;
			}
			rh = Physics2D.Raycast (transform.position,dir,1,obstacles);
			return rh.collider != null;
		}
	}
}