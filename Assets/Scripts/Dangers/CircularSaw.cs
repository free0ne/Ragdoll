using UnityEngine;

public class CircularSaw : MonoBehaviour
{
    [SerializeField] private float speed;
    
    private void Update()
    {
        transform.Rotate(0f, 0f, speed * Time.deltaTime); // вращение по оси Z
    }
}
