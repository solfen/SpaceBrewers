using UnityEngine;
using System.Collections;

public class Asteroids : MonoBehaviour {

	private Transform _transform;
	private float alpha;
	private float xRotated;
	private float yRotated;
	private float zRotated;

	public float speed = 0.15f;
	public float rotationSpeed = 4;
	public float semimajor;
	public float semiminor;

	// Use this for initialization
	void Start () {
		_transform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		//_transform.position += _transform.forward * speed;
		_transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed);

		alpha += speed * 0.1f;

		xRotated = semiminor * Mathf.Cos (alpha);
		yRotated = semimajor * Mathf.Sin (alpha);

		_transform.localPosition = new Vector3 (xRotated, 0, yRotated);
	}
}
