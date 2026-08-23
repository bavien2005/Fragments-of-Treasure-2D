using UnityEngine;

public class BirdController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    [SerializeField] private float timeLife;
    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        Destroy(gameObject, timeLife);
    }
}
