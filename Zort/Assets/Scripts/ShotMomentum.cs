using UnityEngine;
using System.Collections;

public class ShotMomentum : MonoBehaviour {
    public float speed;
    public float lifetime;
    public Vector3 dir;

    [Space]
    [Header("Shot Parameters")]

    public int damage;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, lifetime);
	}
	
	// Update is called once per frame
	void Update () {
        //Vector3 dir = new Vector3(transform.position.x, transform.position.y + lifetime, transform.position.z);
        transform.Translate(dir * Time.deltaTime * speed);
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
            Debug.Log("Colliding");
        if (collision.gameObject.tag == "Enemy")
        {
            GameObject enemyInst = collision.gameObject;
            enemyInst.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
