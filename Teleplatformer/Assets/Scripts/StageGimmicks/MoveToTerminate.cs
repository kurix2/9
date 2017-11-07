using UnityEngine;
using System.Collections;

public class MoveToTerminate : MonoBehaviour {

    public float moveSpeed = 1;
    public Transform terminationPoint;
    public string findTermination;

    // Use this for initialization
    void Start()
    {
        if (terminationPoint == null)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb.isKinematic == true)
            {
                rb.isKinematic = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (terminationPoint != null && GameManager.Instance.Paused != true)
        {
            transform.position = Vector3.MoveTowards(transform.position, terminationPoint.position, moveSpeed * Time.deltaTime);
            if (transform.position == terminationPoint.position)
            {
                Destroy(gameObject);
            }
        }
    }
}
