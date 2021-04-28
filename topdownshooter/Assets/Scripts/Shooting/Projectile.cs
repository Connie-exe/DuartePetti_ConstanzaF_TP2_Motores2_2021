using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float xLimit = 30;//límite en x vale 30
    public float yLimit = 20;//límite en y vale 20

    private void Start()
    {
        Restart._Restart.OnRestart += Reset;
    }

    private void Reset()
    {
        Destroy(this.gameObject);//destruye este objeto
    }

    virtual public void Update()
    {
        CheckLimits();//llama a la clase CheckLimits
    }

    internal virtual void OnCollisionEnter(Collision collision)//si colisiona con...
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("PowerUp"))//con un objeto de etiqueta Wall o PowerUp
        {
            Destroy(this.gameObject);//destruye este objeto
        }
    }

    internal virtual void CheckLimits()
    {
        if (this.transform.position.x > xLimit)//si la posición en x de este objeto es mayor al límite en x
        {
            Destroy(this.gameObject);//destruye este objeto
        }
        if (this.transform.position.x < -xLimit)//si la posición en x de este objeto es menor a - límite en x
        {
            Destroy(this.gameObject);//destruye este objeto
        }
        if (this.transform.position.z > yLimit)//si la posición en y de este objeto es mayor al límite en y
        {
            Destroy(this.gameObject);//destruye este objeto
        }
        if (this.transform.position.z < -yLimit)//si la posición en y de este objeto es menor a - límite en y
        {
            Destroy(this.gameObject);//destruye este objeto
        }
    }

    private void OnDisable()
    {
        Restart._Restart.OnRestart -= Reset;
    }
}
