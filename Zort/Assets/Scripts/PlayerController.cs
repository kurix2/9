using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public float moveSpeed;
    public float clickMoveSpeed;

    [Space]
    [Header("Control Mode")]
    private Vector2 clickPoint; 
    private bool pointClicked = false;
    [HideInInspector]public bool inDanger = false;

    public static PlayerController Instance { get; set; }
  
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else { Instance = this; }
    }

    void Update()
    {
       
            Controls();
    }

    void Controls()
    {
        if (!inDanger)
        { 

        #region WasdControls
        if (Input.GetKey(KeyCode.W))
        {
            if (pointClicked) { pointClicked = false; }
            Vector2 dirUp = new Vector2(transform.position.x, transform.position.y + 1);
            transform.position = Vector2.MoveTowards(transform.position, dirUp, Time.deltaTime * moveSpeed / 2);
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (pointClicked) { pointClicked = false; }
            Vector2 dirDown = new Vector2(transform.position.x, transform.position.y - 1);
            transform.position = Vector2.MoveTowards(transform.position, dirDown, Time.deltaTime * moveSpeed / 2);
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (pointClicked) { pointClicked = false; }
            Vector2 dirRight = new Vector2(transform.position.x + 1, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, dirRight, Time.deltaTime * moveSpeed / 2);
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (pointClicked) { pointClicked = false; }
            Vector2 dirLeft = new Vector2(transform.position.x - 1, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, dirLeft, Time.deltaTime * moveSpeed/2);
        }
        #endregion

        #region MouseControls
        if (pointClicked)
        {
                // player.transform.position = Vector2.MoveTowards(player.transform.position, clickPoint, Time.deltaTime * clickMoveSpeed); 
                transform.position = Vector2.MoveTowards(transform.position, clickPoint, Time.deltaTime * clickMoveSpeed);
            }
        if (Input.GetMouseButton(0) || Input.GetMouseButton(1)) 
        {
            ClickInteraction();
        }

        }
    }

    void ClickInteraction()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (!pointClicked) { pointClicked = true; }
            clickPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (pointClicked) { pointClicked = false; }
    }

    #endregion

    public void ToggleDanger()
    {
        inDanger = !inDanger;
    }
}
