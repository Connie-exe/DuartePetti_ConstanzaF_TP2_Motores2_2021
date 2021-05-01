using UnityEngine;

public class Controller_Bumeran : MonoBehaviour
{
    private Controller_Player parent;//se declara una variable del script Controller_Player
    private Rigidbody rb;//se declara el rigidbody
    private CapsuleCollider collider;//se declara el collider
    private Vector3 direction;//se declara el vector3 que representa dirección
    public Vector3 startPos;//se declara el vector3 que representa la posición de inicio
    public float maxDistance;//un float para la distancia máxima
    public float bumeranSpeed;//un float para la velocidad del bumeran
    private float travelDistance;//un float para la distancia de travel
    private float colliderTimer = 0.07f;//el tiempo del collider dura 0.07f
    private bool going;//un bool going
    public Transform ObjectToFollow = null;

    void Start()
    {
        ObjectToFollow = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        parent = Controller_Player._Player;//parent es igual a _Player de +l script Controller_Player
        rb = GetComponent<Rigidbody>();//se llama al rigidbody
        Restart._Restart.OnRestart += Reset;
        collider = GetComponent<CapsuleCollider>();//se llama al CapsuleCollider
        collider.enabled = false;//el collider es false
        going = true;//going es true
    }

    private void Reset()
    {
        Destroy(this.gameObject);//se destruye este objeto
    }

    private void FixedUpdate()
    {
        Rotate();//llama a la clase Rotate
        if (going)//si going es true
        {
            travelDistance = (startPos - transform.position).magnitude;// la distancia de travel es igual a la posición de inicio menos la posición del objeto
            if (travelDistance > maxDistance)//si la distancia de travel es mayor que la distancia máxima
            {
                CheckDirection();//llama a la clase CheckDirection
            }
        }
        else//de lo contrario
        {
            ReturnToPlayer();//se llama a la clase ReturnToPlayer
        }
    }

    void Update()
    {
        colliderTimer -= Time.deltaTime;//el tiempo del collider va disminuyendo a medida que pasa el tiempo en unity
        if (colliderTimer < 0)//si el tiempo del collider es menor a 0
        {
            collider.enabled = true;//el collider se activa y es true
        }
        if (going)//si going es true
        {
            travelDistance = (startPos - transform.position).magnitude;//la distancia de travel es igual a la posición de inicio menos la posición del objeto
        }
    }

    private void CheckDirection()
    {
        going = false;//going es false
        rb.velocity = Vector3.zero;//el la velocidad del rigidbody vale 0 en todos los valores del vector3
        if (Controller_Player._Player != null)//si el _Player del script Controller_Player es distinto de null
        {

            //direction = (Controller_Player._Player.transform.position);
            direction = -(this.transform.localPosition - parent.transform.localPosition).normalized;//dirección es igual a la posición del objeto menos la posición de parent
        }
    }

    private void Rotate()
    {
        transform.Rotate(new Vector3(10, 0, 0));//el objeto rota o se mueve en el eje x
    }

    private void ReturnToPlayer()
    {
        ObjectToFollow = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        transform.position = Vector3.MoveTowards(transform.position, ObjectToFollow.transform.position, 7 * Time.deltaTime);
        //this.transform.LookAt(direction);
        //rb.AddForce(direction * bumeranSpeed);//el ridigbody se mueve en con la variable dirección a la velocidad de bumeranSpeed
    }

    private void OnDisable()
    {
        Restart._Restart.OnRestart -= Reset;
    }
}
