using UnityEngine;
using System.Collections;

public class ShatterExplosive : MonoBehaviour {

    public float radius = 1.0f;
    public float power = 5.0f;
    public float lifetime = 2.0f;

    void Start()
    {
            Vector3 explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if (rb != null)
                    rb.AddExplosionForce(power, explosionPos, radius);
            }

            Destroy(gameObject,lifetime);
    }
}
