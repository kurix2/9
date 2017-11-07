using UnityEngine;
using System.Collections;

public class Teleform : MonoBehaviour {
	public GameObject explodeFX;
    public Material material;
    Renderer rend;
    bool warning = false;

    private void Start()
    {
            rend = GetComponent<Renderer>();

    }

    private void Update()
    {
        if (warning == true && material != null)
        {
            Color initColor = material.color;
            Color lerpedColor = initColor;
            lerpedColor = Color.Lerp(initColor, Color.red, Mathf.PingPong(Time.time, 1));
            rend.material.color = lerpedColor;
        }
    }

	void OnTriggerEnter(Collider other){
		if (other.transform.tag == "Minotaur") {
			warn ();
		}
	}
		
	public void warn(){
        //GetComponent<Animation> ().Play ();
        if (material != null)
        {
            rend.material = material;
            warning = true;
        }
		StartCoroutine (Delay ());
		
	}

	IEnumerator Delay(){
		yield return new WaitForSeconds (1);
		Instantiate (explodeFX, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}