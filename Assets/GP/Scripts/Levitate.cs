using UnityEngine;
using System.Collections;

public class Levitate : MonoBehaviour {

	public float speed = 0.8f;
	public float amplitude = 0.05f;
	private Transform _transform;
	private Vector3 startPos;

	// Use this for initialization
	void Start () {
		_transform = GetComponent<Transform>();
		startPos = _transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		_transform.position = startPos + new Vector3(0.0f, Mathf.Sin(Time.time * speed) + 1, 0.0f) * amplitude;
	}
}
