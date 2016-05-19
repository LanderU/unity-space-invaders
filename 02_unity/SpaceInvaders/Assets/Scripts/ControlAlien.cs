using UnityEngine;
using System.Collections;

public class ControlAlien : MonoBehaviour
{
	// Conexión al marcador, para poder actualizarlo
	public GameObject marcador;

	// Por defecto, 100 puntos por cada alien
	public int puntos = 100;

	//private bool frozen = false;

	// Use this for initialization
	void Start ()
	{
		// Localizamos el objeto que contiene el marcador
		marcador = GameObject.Find ("Marcador");
	}
	
	// Update is called once per frame
	void Update ()
	{


		// Calculamos el límite de la pantalla
		float distanciaHorizontal = Camera.main.orthographicSize * Screen.width / Screen.height;
		// Variables con los límites
		float limiteIzq = -1.0f * distanciaHorizontal;
		float limiteDer = 1.0f * distanciaHorizontal;

		//if (!frozen) {
			if (this.transform.position.x < limiteDer) {
				// Movemos los marcianos
				this.transform.position = new Vector2 (this.transform.position.x + 1.01f, this.transform.position.y);
			} else {
				// Bajamos uno en el eje Z
				this.transform.position = new Vector2 (limiteIzq, this.transform.position.y - 1.0f);
		
			}
		//}

	
	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		// Detectar la colisión entre el alien y otros elementos

		// Necesitamos saber contra qué hemos chocado
		if (coll.gameObject.tag == "disparo") {

			// Sonido de explosión
			GetComponent<AudioSource> ().Play ();

			// Sumar la puntuación al marcador
			marcador.GetComponent<ControlMarcador> ().puntos += puntos;

			// El disparo desaparece (cuidado, si tiene eventos no se ejecutan)
			Destroy (coll.gameObject);

			// El alien desaparece (hay que añadir un retraso, si no, no se oye la explosión)

			// Lo ocultamos...
			GetComponent<Renderer> ().enabled = false;
			GetComponent<Collider2D> ().enabled = false;

			// ... y lo destruímos al cabo de 5 segundos, para dar tiempo al efecto de sonido
			Destroy (gameObject, 5f);

		} else if (coll.gameObject.tag == "nave"){

			// Sonido de explosión
			GetComponent<AudioSource> ().Play ();

			// Ponemos a 0 la puntiación
			marcador.GetComponent<ControlMarcador> ().puntos = 0;

			//Parar
			//GetComponent<ControlAlien> ().enabled = false;
			//frozen = true;

		}
	}
}
