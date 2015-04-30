using UnityEngine;
using System.Collections;

//Se empleara este script para hacer titilar las luces del escenario.
//Asimismo, para causar un ambiente mas realista, se hara incrementar
//y decrementar el radio de proyeccion de las luces con la misma cadencia
//que la intensidad.

public class lightController : MonoBehaviour {

	private Light the_light;
	private bool incremento = true;

	public float max_intensity = 8f;
	public float min_intensity = 2f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		the_light = gameObject.GetComponent<Light>();

		//Si la luz incrementa
		if (incremento) {
			the_light.intensity += 0.1f;
		//Si la luz decrementa
		} else {
			the_light.intensity -= 0.1f;
		}

		//Si se ha llegado a los limites maximos de intensidad de luz y rango, la luz decrementara: esta calculado para que lleguen a la vez
		if (the_light.intensity >= max_intensity){
			incremento = false;
		}

		//Si se ha llegado a los limites minimos de intensidad de luz y rango, la luz incrementara: esta calculado para que lleguen a la vez
		if (the_light.intensity <= min_intensity) {
			incremento = true;
		}
	
	}
}
