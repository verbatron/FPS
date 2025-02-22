using UnityEngine;

public class TurretCollision : MonoBehaviour
{
    public int health; // Vie
    public GameObject explodeParticles; // Particules explosion
    public Transform healthBar; // Barre de vie
    float startHealth; // Vie max

    void Start()
    {
        startHealth = health;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Si la tourelle est touchée par une balle
        if (collision.gameObject.tag == "Balle")
        {
            health -= 1; // on perd 1 pts de vie
            if(healthBar != null) // Si on a une barre de vie
            {
                // On réduit la taille en x en fonction du nombre de points de vie
                healthBar.localScale = new Vector3(healthBar.localScale.x - (1f / startHealth), 0.2f, 1);
            }
            
            if (health <= 0) // Si vie <= 0
            {
                // Instanciation des particules sur la tourelle
                Instantiate(explodeParticles, transform.position, Quaternion.identity);
                Destroy(this.gameObject); // On détruit la tourelle
            }
        }
    }
}
