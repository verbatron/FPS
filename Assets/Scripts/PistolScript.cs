using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolScript : MonoBehaviour
{
    public GameObject projectile; // pour stocker le prefab de la balle
    public Transform posTir; // Position d'instanciation de projectiles
    public float force; // Puissance de tir
    public AudioClip sonDeTir; // Son de tir

    void Update()
    {
        if(Input.GetMouseButtonDown(0)) // Si on clique
        {
            // On crée le projectile
            GameObject go = Instantiate(projectile, posTir.position, Quaternion.identity);
            // On lance le son de tir
            GetComponent<AudioSource>().PlayOneShot(sonDeTir);
            // On propulse le projectile
            go.GetComponent<Rigidbody>().AddForce(posTir.forward * force);
            Destroy(go, 10); // Détruire go après 10 secondes
        }
    }
}
