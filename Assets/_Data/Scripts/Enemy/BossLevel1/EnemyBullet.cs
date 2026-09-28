using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Vector3 movementDirection;

    [SerializeField] private float timeLife = 5f;

    [SerializeField] private int dmg = 2;
    void Start()
    {
        Destroy(gameObject, timeLife);
    }
    void Update()
    {
        if (movementDirection == Vector3.zero)
        {
            return;
        }
        transform.position += movementDirection * Time.deltaTime;
    }

    public void setMovementDirection(Vector3 direction)
    {
        movementDirection = direction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerDamReceive player = collision.GetComponentInParent<PlayerDamReceive>();

        if (player != null)
        {
            player.Deduct(dmg);
            Debug.Log("Trúng player rồi!");

            Destroy(gameObject);
        }
    }
}
