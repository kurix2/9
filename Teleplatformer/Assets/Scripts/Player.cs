using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public GameObject redScreen;
    public bool isDead = false;
    [Space]
    [Header("DeBug用")]
    public float moveSpeed = 4;
    public Rigidbody teleSphere;
    public float mouseToss = 1000;
    public GameObject reticuleDisplay;
    public Transform fireDirection;
    public float heightAdjust =10;
    private Rigidbody rb;
    //public bool fpsMouse = false;

	// Use this for initialization
	void Start () {
        reticuleDisplay = GameObject.Find("fpsReticule");
        reticuleDisplay.SetActive(false);
        rb = GetComponent<Rigidbody>();
        /*if (fpsMouse == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }*/
    }

	// Update is called once per frame
	void Update () {
        if (isDead == true)
        {
            StartCoroutine(DeadTime());
        }

        //if (fpsMouse == false)
        {
            Cursor.lockState = CursorLockMode.None;
        }
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

        //Mouse Firing
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Rigidbody sphereInstance = Instantiate(teleSphere, transform.position, Quaternion.identity)as Rigidbody;
            sphereInstance.AddForce(fireDirection.forward * mouseToss);
            
        }
        //Raise off the ground with Mouse2
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            rb.isKinematic = true;
            Vector3 pos = transform.position;
            pos.y += heightAdjust;
            transform.position = pos;
            //SpriteRenderer n = reticuleDisplay.GetComponent<SpriteRenderer>();
            reticuleDisplay.SetActive(true);
            //n.enabled = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            rb.isKinematic = false;
            //SpriteRenderer n = reticuleDisplay.GetComponent<SpriteRenderer>();
            //n.enabled = false;
            reticuleDisplay.SetActive(false);
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
