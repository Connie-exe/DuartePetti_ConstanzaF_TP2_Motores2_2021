using UnityEngine;

public class Controller_Player : MonoBehaviour
{
    public Camera cam;//se declara la cam de unity
    private Rigidbody rb;//se declara el rigid body
    private Renderer render;//se declara el renderer
    public static Controller_Player _Player;//se llama a _Player de Controller_Player
    private Vector3 movement;//se declara un vector3 para el movimiento
    private Vector3 mousePos;//se declara un vector3 para la posición del mouse
    internal Vector3 shootAngle;//se declara un vector3 para el ángulo del disparo
    private Vector3 startPos;//se declara un vector3 para la posición inicial
    private bool started = false;//un bool que comieza siendo false
    public float speed = 5;//un float speed que vale 5 y el public para poder modificarlo desde unity
    public GameObject supportGamer;//se declara el objeto supportgamer
    private bool _secondGamerActivated = false;//se declara un bool para saber si el support gamer fue activado o no

    private void Start()
    {
        if (_Player == null)//si _Player no se encuentra
        {
            _Player = this.gameObject.GetComponent<Controller_Player>(); //player es igual al gameobject del script Controller_Player
        }
        startPos = this.transform.position;//la posición inicial es igual a en la que se encuentra el objeto del script
        rb = GetComponent<Rigidbody>();//se llama al rigidbody 
        render = GetComponent<Renderer>();//se llama al renderer
        Restart._Restart.OnRestart += Reset;
        started = true;//el bool started ahora es true
        Controller_Shooting._ShootingPlayer.OnShooting += Shoot;
        _secondGamerActivated = false;
    }

    private void OnEnable()//si el objeto no ha sido destruído
    {
        if (started)//si el bool started es true
            Restart._Restart.OnRestart += Reset;
    }

    private void Reset()
    {
        this.transform.position = startPos;//mover el objeto a su posición inicial
    }

    private void Update()
    {
        movement.x = Input.GetAxis("Horizontal");//el movimiento en el eje x va a ser controlado por los comandos axis "horizontal" (a,d)
        movement.z = Input.GetAxis("Vertical");//el movimiento en el eje x va a ser controlado por los comandos axis "horizontal" (w,s)
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//permite que el mouse se mueva en el mundo

        if (Input.GetKeyDown(KeyCode.P) && _secondGamerActivated == false)//si se toca la tecla p y el bool del segundo player es false
        {
            Debug.Log("Second Gamer Activated");//se escribe en consola que el segundo player ha sido activado
            supportGamer.SetActive(true);//se activa en unity al gameobject
            _secondGamerActivated = true;//se cambia el valor del bool de confirmación a true
        }
        else if (Input.GetKeyDown(KeyCode.P) && _secondGamerActivated == true)//si se toca la tecla p y el bool del segundo player es true
        {
            Debug.Log("Second Gamer Desactivated");//se escribe en consola que el segundo player se ha desactivado
            supportGamer.SetActive(false);//se desactiva en unity al gameobject
            _secondGamerActivated = false;//se cambia el valor del bool de confirmación a false
        }
    }

    public virtual void FixedUpdate()
    {
        Movement(); //llama a la clase Movement
    }

    private void Movement()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);//el rigidbody se moverá a cierta velocidad relacionada también con el tiempo en unity
        transform.LookAt(new Vector3(mousePos.x, 1, mousePos.z));//permite al rigidbody rotar sobre el eje y
    }

    public Vector3 GetLastAngle()
    {
        if (Input.GetKey(KeyCode.W))//si el usuario apreta la tecla w
        {
            shootAngle = Vector3.forward;//el ángulo del disparo a hacia adelante
        }
        if (Input.GetKey(KeyCode.A))//si el usuario apreta la tecla a
        {
            shootAngle = Vector3.left;//el ángulo del disparo a hacia la izquierda
        }
        if (Input.GetKey(KeyCode.S))//si el usuario apreta la tecla s
        {
            shootAngle = Vector3.back;//el ángulo del disparo a hacia abajo
        }
        if (Input.GetKey(KeyCode.D))//si el usuario apreta la tecla d
        {
            shootAngle = Vector3.right;//el ángulo del disparo a hacia la derecha
        }
        return shootAngle;//devuelve el valor de shootAngle
    }

    public virtual void OnCollisionEnter(Collision collision)//si el objeto colisiona con...
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("EnemyProjectile"))//si el player colisiona con el el objeto con etiqueta "enmy" o con la etiqueta "enemyprojectile"
        {
            gameObject.SetActive(false);//el player se desactiva
            Controller_Hud.gameOver = true;//el bool gameover del script Controller_Hud se vuelve true
        }
        if (collision.gameObject.CompareTag("PowerUp"))//si el player colisiona con un objeto de etiqueta "powerup" 
        {
            int rnd = UnityEngine.Random.Range(1, 3);//se genera un número random entre 1 hasta 3
            if (rnd == 1)//si el número random es 1
            {
                Controller_Shooting.ammo = Ammo.Shotgun;//la munición del numerador ammo del script Controller_Shooting es igual a Shotgun del numerador ammo
                Controller_Shooting.ammunition = 5;//y el valor de la variable munición del script Controller_Shooting pasa a valer 5
            }
            else if (rnd == 2)//si el número random vale 2
            {
                Controller_Shooting.ammo = Ammo.Cannon;//la munición del numerador ammo del script Controller_Shooting es igual a Cannon del numerador ammo
                Controller_Shooting.ammunition = 5;//y el valor de la variable munición del script Controller_Shooting pasa a valer 5
            }
            else //en caso contrario
            {
                Controller_Shooting.ammo = Ammo.Bumeran;//la munición del numerador ammo del script Controller_Shooting es igual a Bumeran del numerador ammo
                Controller_Shooting.ammunition = 1;//y el valor de la variable munición del script Controller_Shooting pasa a valer 1
            }
            Destroy(collision.gameObject); //se destruye el objeto con el que se hizo colisión
        }

        if (collision.gameObject.CompareTag("Bumeran"))//si se colisiona con el objeto con etiqueta "Bumeran"
        {
            Controller_Shooting.ammo = Ammo.Bumeran;//la munición del numerador ammo del script Controller_Shooting es igual a Bumeran del numerador ammo
            Controller_Shooting.ammunition = 1;//y el valor de la variable munición del script Controller_Shooting pasa a valer 1
            Destroy(collision.gameObject);//se destruye el objeto con el que se hizo colisión
        }
    }



    void OnDisable()//si el objeto se destruye
    {
        Controller_Shooting._ShootingPlayer.OnShooting -= Shoot;
        Restart._Restart.OnRestart -= Reset;
    }

    private void Shoot()
    {
        if (Controller_Shooting.ammo == Ammo.Cannon)//si la munición pasa a ser cannon
        {
            rb.AddForce(this.transform.forward * -4f, ForceMode.Impulse);//el rigidbody se impulsa 4f hacia atrás
        }
    }
}
