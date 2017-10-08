using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public GameObject redScreen;
    public bool isDead = false;
    public float speedIfPushed = 1.0f;
    public GameManager gameManager;
    [Space]
    [Header("For Debug")]
    public float moveSpeed = 4;
    public Rigidbody teleSphere;
    public float mouseToss = 1000;
    public GameObject reticuleDisplay;
    public Transform fireDirection;
    public float heightAdjust = 10;
    private Rigidbody rb;
    public int setPlayerProgress;
    //public bool fpsMouse = false;

    // Use this for initialization
    private void Awake()
    {
        if (GameObject.FindGameObjectWithTag("GameController")==null)
        {
            Vector3 origin = new Vector3(0, 0, 0);
            Instantiate(gameManager, origin, Quaternion.identity);
        }
        if(setPlayerProgress != 0) {
            GameManager.SetProgress(setPlayerProgress);
        }//for debugging
    }

	void Start () {
        reticuleDisplay = GameObject.Find("fpsReticule");
        reticuleDisplay.SetActive(false);
        rb = GetComponent<Rigidbody>();
        //bool isFirstTime = GameObject.Find("GameManager").GetComponent<GameManager>().firstTime;
        //For Tutorial on First Spawn.
        /*if (isFirstTime)
        {
            Transform newSpawn = GameObject.Find("First Time Player Spawn").transform;
            transform.position = newSpawn.position;
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
        //Rotation with arrow controls
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.isKinematic = true;
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                transform.Rotate(Vector3.down*moveSpeed/2);
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.isKinematic = true;
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                transform.Rotate(Vector3.up*moveSpeed/2);
            }
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(Vector3.right * moveSpeed / 2);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(Vector3.left * moveSpeed / 2);
        }
        // Only Shift
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
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.RightShift))
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
            reticuleDisplay.SetActive(true);
            
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            rb.isKinematic = false;
            //SpriteRenderer n = reticuleDisplay.GetComponent<SpriteRenderer>();
            //n.enabled = false;
            reticuleDisplay.SetActive(false);
        }

        //Quit Game
        if (Input.GetKeyDown("escape")) //Quit is ignored in the editor apparently
        {
            Debug.Log("escape pressed, playerProgress is " + GameManager.playerProgress);
            Debug.Log("currentLevel is " + GameManager.currentLevel);
            PlayerPrefs.SetInt("savedProgress", GameManager.playerProgress);
            Application.Quit();
        }

        //for Debugging
        if (Input.GetKeyDown(KeyCode.F6))
        {
            GameManager.CompleteLevel();
        }
        if (Input.GetKeyDown(KeyCode.F7))
        {
            GameManager.CompleteGame();
        }



    }

    void OnCollisionEnter (Collision other){
		if (other.transform.tag == "Lava") {
            isDead = true;
        }
        if (other.transform.tag == "Push")
        {
            Transform pushDir = other.transform; 
            transform.position = Vector3.MoveTowards(transform.position, -pushDir.position, speedIfPushed * Time.deltaTime);
            print("added force?");
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
