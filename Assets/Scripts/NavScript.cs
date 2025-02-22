using UnityEngine;
using UnityEngine.AI;

public class NavScript : MonoBehaviour
{
    public GameObject[] points; // points de patrouille
    public Transform player; // joueur à attaquer

    NavMeshAgent agent; // Nav Mesh Agent du robot

    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // On récupère le composant agent
        GotoNextPoint(); // On va au point aléatoire suivant
    }

    void GotoNextPoint()
    {
        // On donne une destination à l'agent
        // On tire un nombre aléatoire entre 0 et nombre de points - 1
        agent.destination = points[Random.Range(0, points.Length-1)].transform.position;
    }

    void Update()
    {
        if(Vector3.Distance(transform.position, player.position) > 12) // Si on est loin du joueur
        {
            agent.isStopped = false;
            // On patrouille
            // Si on a pas de chemin en attente et si on a atteint le point
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                GotoNextPoint(); // On va au point suivant
            }
        }
        else
        {
            agent.isStopped = true;
        }
    }
}
