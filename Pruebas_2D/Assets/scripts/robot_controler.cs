using UnityEngine;
using System.Collections;

public class robot_controler : MonoBehaviour {

    //COMPONENTES
    //-----------

    //Variables lógicas para llevar cuenta del estado de los controles
    //del personaje.

    //MOVERSE A LA DERECHA
    private bool move_right = false;

    //MOVERSE A LA IZQUIERDA
    private bool move_left = false;

    //SALTAR
    private bool is_jumping = false;
    private bool is_jumping_up = true;

    //**********************************************************************

    //Variables de componentes del objeto de juego
    private Transform trans;

    //**********************************************************************

    //Variables adicionales.

    private float speed = 3f;
    private float jump_speed = 8f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (!move_left&&!move_right)
        {
            GetComponent<Animator>().Play("standing_robot");
        }

        //Se obtiene la transformada del personaje, por si
        //hubiera que afectar su posición.
        trans = GetComponent<Transform>();
	    
        //Se comprueba el estado del personaje y se
        //actualiza sus componentes lógicas asociadas
        //en consecuencia.

        float axis = Input.GetAxisRaw("Horizontal");
        if (axis == -1)
        {
            move_left = true;
        }
        else
        {
            if (axis == 1)
            {
                move_right = true;
            }
            else
            {
                move_right = move_left = false;
            }
        }

        //Actualización de otros valores
        is_jumping = Input.GetButtonDown("Jump");
        is_jumping_up = Input.GetButtonUp("Jump");


        //Se actúa sobre la transformada de manera coherente al estado del personaje.
        if (move_right)
        {
            GetComponent<Animator>().Play("running_robot");
            trans.position += new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
        }

        if (move_left)
        {
            GetComponent<Animator>().Play("running_robot");
            trans.position -= new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
        }

        if (is_jumping)
        {
            GetComponent<Rigidbody2D>().velocity +=  new Vector2(transform.up.x, transform.up.y)*jump_speed;
            //GetComponent<Rigidbody2D>().AddForce(trans.up*jump_speed, ForceMode2D.Impulse);
            //trans.Translate(Vector3.up * jump_speed * Time.deltaTime, Space.World);
        }

        if (is_jumping_up)
        {
            GetComponent<Rigidbody2D>().velocity +=  new Vector2(0, 0);
        }
	}
}
