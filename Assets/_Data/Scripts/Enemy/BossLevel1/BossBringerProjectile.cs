using UnityEngine;

public class BossBringerProjectile : MonoBehaviour
{
    private Vector2 direction;
    private float speed;
    private int damage;
    private Transform target;
    private bool hasHit;

    private void Update()
    {
        transform.position += (Vector3)this.direction * this.speed * Time.deltaTime;
        if (this.target != null && Vector2.Distance(transform.position, this.target.position) <= 0.3f)
            this.HitPlayer(this.target.GetComponentInChildren<PlayerDamReceive>());
    }

    public void Launch(Vector2 targetDirection, float projectileSpeed, int projectileDamage)
    {
        this.direction = targetDirection.normalized;
        this.speed = projectileSpeed;
        this.damage = projectileDamage;
        GameObject player = GameObject.Find("Player");
        if (player != null) this.target = player.transform;
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerDamReceive player = other.GetComponentInParent<PlayerDamReceive>();
        this.HitPlayer(player);
    }

    private void HitPlayer(PlayerDamReceive player)
    {
        if (this.hasHit || player == null) return;
        this.hasHit = true;
        player.Deduct(this.damage);
        Destroy(gameObject);
    }
}
