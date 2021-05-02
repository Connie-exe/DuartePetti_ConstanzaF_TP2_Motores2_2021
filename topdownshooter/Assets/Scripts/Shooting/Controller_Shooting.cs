using UnityEngine;

public class Controller_Shooting : MonoBehaviour
{
    public delegate void Shooting();
    public event Shooting OnShooting;
    public static Ammo ammo;//contador ammo    
    public static int ammunition;//int ammunition para usar en todos los scripts
    public static Controller_Shooting _ShootingPlayer;//variable _ShootingPlayer
    public Transform firePoint;//posición de firepoint
    public GameObject bulletPrefab;//declara gameobject bulletPrefab
    public GameObject cannonPrefab;//declara gameobject cannonPrefab
    public GameObject bumeranPrefab;//declara gameobject bumeranPrefab
    public float bulletForce = 20f;//float bulletForce es igual a 20f
    private bool started = false;//el bool started es false

    private void Awake()
    {
        if (_ShootingPlayer == null)//si _ShootingPlayer es igual a null
        {
            _ShootingPlayer = this.gameObject.GetComponent<Controller_Shooting>();//_Shootingplayer es igual a este objeto
            Debug.Log("Shooting es nulo");//en consola se escribe lo que está entre comillas
        }
        else//de lo contrario
        {
            Destroy(this);//esto se destruye
        }
    }

    private void Start()
    {
        if (_ShootingPlayer == null)//si _ShootingPlayer es igual a null
        {
            _ShootingPlayer = this.gameObject.GetComponent<Controller_Shooting>();//_Shootingplayer es igual a este objeto
        }

        Restart._Restart.OnRestart += Reset;
        started = true;//started vale true
        ammo = Ammo.Bumeran;//la munición es Bumeran del numerador Ammo
        ammunition = 1;//munición vale 1
    }

    private void OnEnable()//si el objeto está disponible
    {
        if (started)//si started es true
            Restart._Restart.OnRestart += Reset;
    }

    private void Reset()
    {
        ammo = Ammo.Bumeran;//ammo es igual al bumeran del numerador Ammo
        ammunition = 1;//la munición vale 1
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))//si se presiona el botón
        {
            Shoot();//llama a la clase Shoot
            CheckAmmo();//llama a la clase CheckAmmo
        }
    }

    private void CheckAmmo()
    {
        if (ammunition <= 0)//si la munición es menor o igual a 0
        {
            ammo = Ammo.Normal;//ammo es igual a normal del numerador Ammo
        }
    }

    private void Shoot()
    {
        if (OnShooting != null)//si Onshooting es distinto de null
        {
            OnShooting();//llama ala clase OnShooting
        }
        if (ammo == Ammo.Normal)//si ammo es igual a normal del numerador Ammo
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);//el gameobject bullet es igual a el bullet prefab en la posición del firepoint y con la rotación de firepoint 
            Rigidbody rb = bullet.GetComponent<Rigidbody>();//rigidbody es igual a el rigidbody de bullet
            rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);//el rigidbody se mueve hacia adelante con la fuerza de bullet
        }
        else if (ammo == Ammo.Shotgun) //de lo contrario si ammo es igual a shotgun del numerador Ammo
        {
            Rigidbody rb;
            for (float i = -0.2f; i < 0.2f; i += 0.1f)//i vale 0, hasta que i valga 0.2f i aumentará 0.1f en cads vuelta
            {
                rb = null;//el rigidbody es null
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);//el gamobject bullet se inicializa en el posición de firepoint y se mueve con la rotación de firepoint
                rb = bullet.GetComponent<Rigidbody>();// se llama al rigidbody de bullet
                rb.AddForce(new Vector3(firePoint.forward.x + i, firePoint.forward.y, firePoint.forward.z + i) * bulletForce, ForceMode.Impulse);//bullet se mueve en todos su ejes multiplicando por el valor de i en cada vuelta
            }
            ammunition--;//munición disminuye en 1
        }
        else if (ammo == Ammo.Cannon)//de lo contrario si ammo es igual a cannon en el numerador Ammo
        {
            GameObject bullet = Instantiate(cannonPrefab, firePoint.position, firePoint.rotation);//el gameobject bullet se instancia en la posición firepoint y se mueve con la rotación de firepoint
            Rigidbody rb = bullet.GetComponent<Rigidbody>();//se llama al rigidbody de bullet
            rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);//bullet se mueve en hacia adelante del firepoint con la fuerza de bulletforce
            ammunition--;//munición disminuye en 1
        }
        else if (ammo == Ammo.Bumeran)//de lo contrario si ammo es igual a Bumeran en el numerador Ammo
        {
            GameObject bullet = Instantiate(bumeranPrefab, firePoint.position, firePoint.rotation);//el gameobject bullet se instancia en la posición firepoint y se mueve con la rotación de firepoint
            Controller_Bumeran bm = bullet.GetComponent<Controller_Bumeran>();//se llama al gameobject del script Controller_Bumeran
            bm.startPos = firePoint.position;//la posición de inicio del bumeran es igual a la posición del firepoint
            Rigidbody rb = bullet.GetComponent<Rigidbody>();//se llama al rigidbody de bullet
            rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);//bullet se mueve en hacia adelante del firepoint con la fuerza de bulletforce
            ammunition--;//munición disminuye en 1
        }
    }

    private void OnDisable()
    {
        Restart._Restart.OnRestart -= Reset;
    }
}

public enum Ammo //se crea el numerador
{
    Normal,
    Shotgun,
    Cannon,
    Bumeran
    //ZombieGun,
    //BulletHell
}

