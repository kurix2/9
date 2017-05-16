using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {
	public Transform[] patrolPoints;
	public Transform prey;
	public bool pursuePrey=false;
	public float moveSpeed=1f;

	private int currentPoint;

	// Use this for initialization
	void Start () {
		transform.position = patrolPoints [0].position;
		currentPoint = 0;

	}

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.Paused)
        {
            if (pursuePrey == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, prey.position, moveSpeed * Time.deltaTime);
            }
            else
            {

                if (transform.position == patrolPoints[currentPoint].position)
                {
                    currentPoint++;
                }

                if (currentPoint == patrolPoints.Length)
                {
                    currentPoint = 0;
                    pursuePrey = true;
                }

                transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPoint].position, moveSpeed * Time.deltaTime);
            }
        }
    }
}