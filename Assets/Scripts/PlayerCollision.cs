using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour 
{
    public Text healthTxt;
    public int health = 100;
    bool hasKey = false;
    public GameObject porte;
    public GameObject texteVictoire;
    public GameObject cameraAnimation;
    public GameObject texteObjectif;

    // Détecter les collisions
    void OnCollisionEnter(Collision collision)
    {
        // Si l'objet qui nous touche a le Tag Tourelle
        if(collision.gameObject.tag == "Tourelle")
        {
            LooseHealth(20); // On demande à perdre 20 points de vie
            Destroy(collision.gameObject); // Détruire le projectile
        }
    }

    // Si on touche un trigger
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pic") // Si on touche un piège
        {
            LooseHealth(100); // On perd 100 points de vie
        }

        if (other.gameObject.tag == "Vie") // Si on touche la vie
        {
            Destroy(other.gameObject); // On détruit l'objet ramassé
            LooseHealth(-50); // On gagne 50 points de vie
        }

        if (other.gameObject.tag == "Key") // Si on touche la clé
        {
            Destroy(other.gameObject); // On détruit la clé
            hasKey = true; // Ajout à l'inventaire
        }

        if (other.gameObject.tag == "Porte" && hasKey) // Si on touche la porte
        { // Si on a la clé
            porte.GetComponent<Animator>().enabled = true;
        }

        if (other.gameObject.tag == "Portal")
        {
            // Déclencher ici la fin du jeu
            StartCoroutine("FinDuJeu");
        }

        if (other.gameObject.tag == "Robot") // SI on parle au robot
        {
            // Déclencher le dialogue / cinématique
            cameraAnimation.SetActive(true);
            texteObjectif.SetActive(true);
            // Bonus : Désactiver le dialogue après celui-ci
            Destroy(other.GetComponent<Collider>()); // Pour pas relancer la cinématique après
            // L'icone doit avoir le nom "dialog" et être enfant du robot
            Destroy(other.transform.Find("dialog").gameObject); // Détruire l'icône dialogue
            StartCoroutine("FinCinematique");
        }
    }

    // Perdre de la vie
    void LooseHealth(int val) // val = valeur à déduire
    {
        health = health - val; // On perd 20% de notre vie
        healthTxt.text = health + "%"; // Mise à jour du texte
        if(health < 0)
        {
            health = 0; // On bloque la vie à 0
            // Le personnage n'a plus de vie, il faut lancer le GameOver ici
            SceneManager.LoadScene(0); // On charge la scène 0
        }
    }

    IEnumerator FinDuJeu()
    {
        texteVictoire.SetActive(true);
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(0);
    }

    IEnumerator FinCinematique()
    {
        yield return new WaitForSeconds(14f);
        cameraAnimation.SetActive(false);
        texteObjectif.SetActive(false);
    }
}
