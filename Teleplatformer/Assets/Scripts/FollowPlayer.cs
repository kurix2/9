using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {
	public Transform[] patrolPoints;
	public Transform prey;
	public bool pursuePrey=false;
	public float moveSpeed=1f;
    public float rotSpeed = 2f; //may need to change to a percent

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
                //rotation Experiment (Probably can Delete)
                /*if (currentPoint != patrolPoints.Length-1 && currentPoint != 0){
                    if (Vector3.Distance(patrolPoints[currentPoint].position, transform.position) <= 10)
                    {
                        RotateToPoint();
                    }
                }*/

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
     /*void RotateToPoint()
    {
        Vector3 targetDir = patrolPoints[currentPoint + 1].position - transform.position;
        Quaternion newDir = Quaternion.LookRotation(-targetDir);
        transform.rotation = Quaternion.Lerp(transform.rotation, newDir, rotSpeed * Time.deltaTime);
    }*/
}