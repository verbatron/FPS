using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    public Transform target; // cible
    public GameObject bullet; // prefab balle
    public float force; // puissance du tir
    public float reloadTime; // temps entre deux tirs
    public Transform posTir; // pour instancier la balle
    public GameObject canon; // Le canon de la tourelle
    bool canShot = true; // peut tirer ?

    void Update()
    {
        // On calcule la position de la cible (sauf axe Y qui reste fixe)
        Vector3 targetPostition = new Vector3(target.position.x, canon.transform.position.y, target.position.z);
        // On oriente la tourelle vers la cible (sauf l'axe y qui est fixe)
        canon.transform.LookAt(targetPostition);

        // Calcul de la distance entre joueur et tourelle
        float distance = Vector3.Distance(transform.position, target.position);

        // Si on peut tirer, on tire, sinon on attend
        if(canShot && distance < 15)
        {
            canShot = false;
            // On tire
            GameObject go = Instantiate(bullet, posTir.position, Quaternion.identity);
            go.GetComponent<Rigidbody>().AddForce(posTir.forward * force);
            Destroy(go, 5); // On détruit la balle après 5s
            // On recharge
            StartCoroutine("Reload");
        }
    }

    IEnumerator Reload()
    {
        // On attend un instant et on peut de nouveau tirer
        yield return new WaitForSeconds(reloadTime);
        canShot = true;
    }

}
