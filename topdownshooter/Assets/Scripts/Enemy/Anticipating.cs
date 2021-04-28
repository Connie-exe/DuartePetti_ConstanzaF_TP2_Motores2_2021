public class Anticipating : Controller_Enemy
{
    private void FixedUpdate()
    {
        AnticipatingBehaviour();//llama a la clase AnticipatingBehaviour
    }

    private void AnticipatingBehaviour()
    {
        if (player != null)//si el player es distinto de null
        {
            Controller_Player p = player.GetComponent<Controller_Player>();//se llama al player del script Controller_Player
            agent.SetDestination(player.transform.position + p.GetLastAngle() * 2);//se llama al navmesh para que el enemigo se mueva en el último ángulo en el que el jugador se movió y vaya con ese ángulo en dirección al jugador
        }
    }
}
