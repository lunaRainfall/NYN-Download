using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public float speed;
    public Transform player;
    public Vector3 offset;

    public Vector2 pos;

	void Start () {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
	}
	
	void FixedUpdate () {
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, speed);
        transform.position = smoothPosition;
	}
}
