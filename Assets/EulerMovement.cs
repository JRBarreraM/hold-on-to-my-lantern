using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EulerMovement : MonoBehaviour {

	public float speed;

	public Sprite Up;
	public Sprite Down;
	public Sprite Left;
	public Sprite Right;

	private Sprite facetowards;

	Animator anim;

	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	void Update () {

		Vector3 mov = new Vector3 (
			Input.GetAxisRaw("Horizontal"),
			Input.GetAxisRaw("Vertical"),
			0
		);
		
		this.GetComponent<SpriteRenderer>().sprite=Up;
		this.GetComponent<SpriteRenderer>().sprite=Down;
		this.GetComponent<SpriteRenderer>().sprite=Left;
		this.GetComponent<SpriteRenderer>().sprite=Right;

		transform.position = Vector3.MoveTowards (
			transform.position,
			transform.position + mov,
			speed * Time.deltaTime
		);
	}
}