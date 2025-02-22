using UnityEngine;
using UnityEngine.UI;

public class SwitchWeapon : MonoBehaviour
{
    int activeWeapon = 0; // arme active (0=pistolet, 1=fusil)
    public GameObject[] weapons; // armes
    public Image[] weaponIcons; // images des armes
    public Color activeColor; // couleur blanc alpha 200
    public Color inactiveColor; // couleur blanc alpha 100

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1)) // SI on appuie sur 1
        {
            DesactivateWeapons(); // On désactive tout
            ActivateWeaponById(0); // On active l'arme 0
        }

        if (Input.GetKeyUp(KeyCode.Alpha2)) // SI on appuie sur 2
        {
            DesactivateWeapons();
            ActivateWeaponById(1); // On active l'arme 1
        }

        if (Input.GetAxis("Mouse ScrollWheel") != 0f) // Si on utilise la molette
        {
            DesactivateWeapons();
            if(activeWeapon == 1) // Si l'arme active est 1
            {
                ActivateWeaponById(0); // on active 0
            }
            else
            {
                ActivateWeaponById(1); // Sinon on active 1
            }
        }
    }

    public void DesactivateWeapons() // Tout désactiver
    {
        foreach(GameObject go in weapons) // Pour chaque arme
        {
            go.SetActive(false); // On désactive
        }
        foreach(Image img in weaponIcons) // pour chaque icone d'arme
        {
            img.color = inactiveColor; // On met la couleur inactive
        }
    }

    public void ActivateWeaponById(int id) // Activer l'arme spécifiée
    {
        activeWeapon = id; // on active l'arme 
        weapons[id].SetActive(true); // on montre le modèle de l'arme
        weaponIcons[id].color = activeColor; // on active l'icone de l'arme
    }
}
