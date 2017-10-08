using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public GameObject player;
    public float moveSpeed;
    public float maxSpeed;

    [Space]
    [Header("Shot Parameters")]
    public GameObject shot;
    public float fireRate;
    public Transform shotSpawner;
    private float nextFire = 0.0f;

    [Space]
    [Header("Control Mode")]
    public bool pathType;
    public bool flightAssist;

    private Vector2 clickPoint;
    private Vector3 mousePos;
    private Vector3 enemyPos;
    private bool pointClicked = false;
    private bool lockedOn = false;

    void Update()
    {
        if (pathType)
        {
            PathControls();
        }
        else
        {
            WasdControls();
        }
    }

    void WasdControls()
    {
        //WASD

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //mouse rotation
        Vector3 dir = (mousePos - player.transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        player.transform.rotation = Quaternion.AngleAxis(angle -90, Vector3.forward);

        if (flightAssist)
        { 
            #region Flight Assist On
        if (Input.GetKey(KeyCode.W))
        {
            Vector2 dirUp = new Vector2(player.transform.position.x, player.transform.position.y+1);
            player.transform.position = Vector2.MoveTowards(player.transform.position, dirUp, Time.deltaTime * moveSpeed/2);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector2 dirDown = new Vector2(player.transform.position.x, player.transform.position.y - 1);
            player.transform.position = Vector2.MoveTowards(player.transform.position, dirDown, Time.deltaTime * moveSpeed/2);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector2 dirRight = new Vector2(player.transform.position.x+1, player.transform.position.y);
            player.transform.position = Vector2.MoveTowards(player.transform.position, dirRight, Time.deltaTime * moveSpeed/2);
        }
            if (Input.GetKey(KeyCode.A))
            {
                Vector2 dirLeft = new Vector2(player.transform.position.x - 1, player.transform.position.y);
                player.transform.position = Vector2.MoveTowards(player.transform.position, dirLeft, Time.deltaTime * moveSpeed/2);
            }
                #endregion
        }
            else
        {
          #region Flight Assist Off
                Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
                Rigidbody2D playerRb = player.GetComponent<Rigidbody2D>();
                if (playerRb.velocity.magnitude < maxSpeed) //non-flight assist mode
                {
                    playerRb.AddForce(movement * moveSpeed);
                }
                #endregion
        }
        //Mouse Fire
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
                nextFire = Time.time + fireRate;
                Instantiate(shot, shotSpawner.position, shotSpawner.rotation);
        }
    }

    void PathControls()
    {
        //ongoing movement
        if (pointClicked)
        {
            Vector2 dir = clickPoint - new Vector2(player.transform.position.x, player.transform.position.y);
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            player.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            if (Input.GetKey(KeyCode.LeftShift) != true)
            {
                player.transform.position = Vector2.MoveTowards(player.transform.position, clickPoint, Time.deltaTime * moveSpeed);
            }
        }

        //ongoing Lockon
        if (lockedOn)
        {
            Vector3 dir = enemyPos - player.transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            player.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward); //lock on rotation
            //basic fire 
            if(Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Instantiate(shot, shotSpawner.position, shotSpawner.rotation);
            }
            
        }

        if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
        {
            ClickInteraction();
        }
        if (Input.GetMouseButtonDown(0))
        {
            TargetScanners();
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (lockedOn) { lockedOn = false; }
        }
    }

    void ClickInteraction()
    {
        if (!pointClicked) { pointClicked = true; }
        clickPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void TargetScanners()
    {
        Ray scan = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D scanObj = Physics2D.Raycast(scan.origin, scan.direction);

        if (scanObj.collider != null)
        {
            enemyPos = scanObj.collider.transform.position;
            lockedOn = true;
        }
    }
 
	
}
