using UnityEngine;
using UnityEngine.UI;//para poder usar los objetos de la ui

public class Controller_Hud : MonoBehaviour
{
    public static bool gameOver; //declara un bool para indicar si el juego terminó, static para que se pueda llamar desde otros scripts
    public static int points; //declara un int para contar los puntos de forma exacta, static para que se pueda llamar desde otros scripts
    public static Ammo ammo; //declara un enumerador de munición
    public Text gameOverText;//declara el text para acceder al objeto de la ui, public para poder cambiarlo desde unity
    public Text pointsText;//idem
    public Text powerUpText;//idem

    void Start()
    {
        Restart._Restart.OnRestart += Reset;
        gameOver = false;//empieza el juego por lo que el juego aún no termina
        gameOverText.gameObject.SetActive(false); //el texto de gameover se desactiva por lo que no es visible en pantalla
        points = 0;//el contador de puntos vale 0 al inicio del juego
    }

    private void Reset()
    {
        gameOver = false;//si el juego se resetea el bool gameover sigue siendo falso
        gameOverText.gameObject.SetActive(false);// y el texto de gameover no es visible en pantalla aún
        points = 0;//los puntos vuelven a valer 0
    }

    void Update()
    {
        if (gameOver)//si el bool gameover es true
        {
            Time.timeScale = 0;
            gameOverText.text = "Game Over";//el texto de gameover escribirá lo que está puesto entre comillas
            gameOverText.gameObject.SetActive(true);//el objeto texto se hace visible en pantalla
        }

        switch (Controller_Shooting.ammo)//llama al enum ammo del script Controller_Shooting
        {
            case Ammo.Normal: //si es el primer caso es Normal
                powerUpText.text = "Gun: Normal - Ammo:∞"; //el texto de powerup dirá lo que está entre comillas
                break;//sale del switch
            case Ammo.Shotgun://si es el segundo caso es Shotgun
                powerUpText.text = "Gun: Shotgun - Ammo:" + Controller_Shooting.ammunition.ToString();//el texto de powerup dirá lo que está entre comillas y llamará convertirá el valor de ammunition del script Controller_Shooting a string
                break;//sale del switch
            case Ammo.Cannon://si es el tercer caso es Cannon
                powerUpText.text = "Gun: Cannon - Ammo:" + Controller_Shooting.ammunition.ToString();//idem
                break;//sale del switch
            case Ammo.Bumeran://si es el segundo caso es Bumeran
                powerUpText.text = "Gun: Bumeran - Ammo:" + Controller_Shooting.ammunition.ToString();//idem
                break;//sale del switch

        }

        pointsText.text = "Score: " + points.ToString();//se actualizará en todo momento los puntos, pasando el valor de points a string
    }

    private void OnDisable()//si el objeto es destruido
    {
        Restart._Restart.OnRestart -= Reset;
    }
}
