using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public GameObject redScreen;
    public bool isDead = false;
    [Space]
    [Header("DeBug用")]
    public float moveSpeed = 4;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
    }

	// Update is called once per frame
	void Update () {
        if (isDead == true)
        {
            StartCoroutine(DeadTime());
        }

        //for playtesting Without VR
        /*if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.LeftShift))
        {
            rb.isKinematic = true;
            rb.detectCollisions = false;
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.Space) || Input.GetKeyDown(KeyCode.LeftShift))
        {
            rb.isKinematic = true;
            rb.detectCollisions = false;
        }*/
        if (Input.GetKey(KeyCode.W))
        {
            rb.isKinematic = true;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.isKinematic = true;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.Translate(-Vector3.up * moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.isKinematic = true;
            
                transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.isKinematic = true;

                transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.R))
        {
            rb.isKinematic = true;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
            }
        }
        if (Input.GetKey(KeyCode.F))
        {
            rb.isKinematic = true;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(-Vector3.up * moveSpeed * Time.deltaTime);
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            transform.rotation = Quaternion.Euler(90, 0, 0);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            rb.isKinematic = false;
        }

    }

    void OnCollisionEnter (Collision other){
		if (other.transform.tag == "Lava") {
            isDead = true;
        }
	}

    IEnumerator DeadTime() {
        SpriteRenderer n = redScreen.GetComponent<SpriteRenderer>();
        n.enabled = true;
        yield return new WaitForSeconds(3);
        Die();
    }


	void Die(){
        GameManager.RestartLevel ();
	}
}
