using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ControlDisparo : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Eliminamos el objeto si se sale de la pantalla
		if (transform.position.y > 10) {
			Destroy (gameObject);
		}	

		if (cantAliens == 0) {
		
			SceneManager.LoadScene ("Nivel2");
		}
	}
}
