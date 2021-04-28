public class Following : Controller_Enemy
{
    private void FixedUpdate()
    {
        FollowingBehaviour();//se llama a la clase FollowingBehaviour
    }

    private void FollowingBehaviour()
    {
        if (player != null )//si player es distinto de null
        {
            agent.SetDestination(player.transform.position);//el enemigo utiliza el navmesh para seguir la posición en la que se encuentra el jugador
        }
    }
}
