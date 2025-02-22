using UnityEngine;

public class RotateScript : MonoBehaviour
{
    public Vector3 rotation;

    void Update()
    {
        transform.Rotate(rotation * Time.deltaTime);    
    }
}
