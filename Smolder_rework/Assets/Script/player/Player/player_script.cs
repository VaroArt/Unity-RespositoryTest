using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_script : MonoBehaviour
{
   
    Rigidbody2D myrg;
    public Vector2 input;
    float shipAngle;
    [Header("Variables Movimiento y rotacion")]
    public float speed;
    public float speedInitial;
    public float rotationInterpolation = 0.4f;
    public bool isMoving;
    public int vida;
    public Animator anim;
    public UI_ControlNaveSc HUD;
    public TutorialDialogue_Manager tuto;
    [Header("Variables turbo")]
    [Range(0,100)]
    public float cantidadTurbo;
    public float turbospeed;
    public bool isTurboActivate;
    [Header("Particulas")]
    public bool canMoveStars;
    public stardust_System stardust;
    [Header("Audios")]
    public bool repbool;
    public AudioClip recuperar;
    public AudioSource audioNave;
    public player_interactions interaction;


    void Start()
    {
        audioNave = GetComponent<AudioSource>();
        canMoveStars = true;
        myrg = GetComponent<Rigidbody2D>();
        input.x = 0;
        input.y = 0;
       // vida = 2;
       
    }

    // Update is called once per frame
    void Update()
    {
        if(repbool == false) //Bool para la reparacion
        {
            input.x = Input.GetAxis("Horizontal");
            input.y = Input.GetAxis("Vertical");
        }

        
        if (input.x != 0 || input.y != 0)
        {
            isMoving = true;
            rotationInterpolation = 0.4f;
        }
        else
        {
            isMoving = false;
        }
        Rotation();

        if(vida <= 1)
        {
            HUD.ControlEstadoNave.VidaBaja = true;
        }
       if(vida <= 0)
        {

           input.x = 0f;
           input.y = 0f;

        }

        UseTurbo();

        
    }
    private void FixedUpdate()
    {
         myrg.velocity = input * speed * Time.fixedDeltaTime;

    }
   

    public void UseTurbo()

    {
        HUD.Turbo.TurboBar.fillAmount = cantidadTurbo / 100f;
        if (Input.GetKey(KeyCode.LeftShift)&& cantidadTurbo !=0)
        {
            speed = turbospeed;
            cantidadTurbo -= 1 * Time.deltaTime;


            if (cantidadTurbo < 0)
            {
                cantidadTurbo = 0;
            }
        }
        else
        {
            speed = speedInitial;
        }
    }
    void Rotation()
    {
        Vector2 lookDir = new Vector2(-input.x, input.y);

        if (isMoving)
        {
            shipAngle = Mathf.Atan2(lookDir.x, lookDir.y) * Mathf.Rad2Deg;
        }
        if(myrg.rotation <= -90 && shipAngle >= 90)
        {
            myrg.rotation += 360;
            myrg.rotation = Mathf.Lerp(myrg.rotation, shipAngle, rotationInterpolation);
        }
        else if  (myrg.rotation >= 90 && shipAngle <= -90)
        {
            myrg.rotation -= 360;
            myrg.rotation = Mathf.Lerp(myrg.rotation, shipAngle, rotationInterpolation);
        }
        else
        {
            myrg.rotation = Mathf.Lerp(myrg.rotation, shipAngle, rotationInterpolation);
        } 
    }

    public void Reparar()
    {
        if (vida != 2)
        {
            StartCoroutine("Reparacion");
            audioNave.clip = recuperar;
            audioNave.Play();
        }
    }

    IEnumerator Reparacion()
    {
        print("rep");
        anim.SetBool("rep", true); //Se activa la animacion de rep
        repbool = true; //Con este bool se bloquea el audio de movimiento 
        speedInitial = 0; //Se desactiva el movimiento sacando la velocidad
        canMoveStars = false; //Se bloquea el movimiento de las estrellas
        input = new Vector2(0, 0); //El input queda en 0 para que no sea posible nisiquiera rotar
        yield return new WaitForSeconds(1.5f); //Pequeño delay para la duracion de la rep
        print("rep finalizado");
        anim.SetBool("rep", false); //Todo se resetea a su estado original, antes de la rep
        audioNave.clip = interaction.movimiento; //Le damos denuevo el audio de movimiento a la nave
        canMoveStars = true; //Se mueven las estrellas again
        repbool = false; // Se puede reproducir denuevo el audio de movimiento
        speedInitial = 60f; //Velocidad normal
        vida++; //Aqui da la vida reparada
        audioNave.Stop(); //Y se detiene el audio de rep
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("obstacule"))
        {
            //Aqui para cuando la nave colisiona con obstaculos, detengo el movimiento de las estrellas y el audio de movimiento de la nave
            canMoveStars = false;
            audioNave.Stop();
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("obstacule"))
        {
            //Aqui vuelve todo a la normalidad, dah
            canMoveStars = true;
            audioNave.Play();  
        }
    }
}
