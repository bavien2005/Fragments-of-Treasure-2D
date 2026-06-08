using UnityEngine;

public class EnemyLancer : MonoBehaviour
{
    Rigidbody2D Rigidbody2D;
    Animator animator;
    public Transform player;
    [SerializeField] float attackDistance;
    public Vector2 attackSize = new Vector2(1f, 0.5f);
    //[SerializeField] float attackCooldown = 1.5f;
    //float lastAttackTime;


    [Header("Attack Settings")]
    //public float attackRadius = 1.2f;          // bán kính đánh
    public int damage = 10;                    // damage
    public LayerMask playerLayer;              // layer của Player

    [Header("Attack Point")]
    public Transform attackPoint;              // vị trí check (đầu thuong, trước mặt)

    private void Awake()
    {
        animator = GetComponent<Animator>();
        Rigidbody2D = GetComponent<Rigidbody2D>();

    }
    private void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= attackDistance)
        {
            animator.SetTrigger("Attack");
            //lastAttackTime = Time.time;
        }
    }
    // 👉 HÀM NÀY GÁN VÀO ANIMATION EVENT
    //public void AttackPlayer()
    //{
    //    RaycastHit2D[] hits = Physics2D.BoxCastAll(
    //        attackPoint.position,
    //        attackSize,
    //        0f,
    //        transform.right, // hướng đâm
    //        attackDistance,
    //        playerLayer
    //    );

    //    foreach (RaycastHit2D hit in hits)
    //    {
    //        Debug.Log("Stab hit Player!");
    //    }
    //}

    // vẽ vùng attack trong Scene cho dễ nhìn
    //private void OnDrawGizmosSelected()
    //{
    //    if (attackPoint == null) return;

    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    //}
    public void AttackPlayer()
    {
        // hướng từ enemy → player
        Vector2 dir = (player.position - attackPoint.position).normalized;

        RaycastHit2D[] hits = Physics2D.RaycastAll(
        attackPoint.position,
        dir,
        attackDistance,
        playerLayer
);

        foreach (var hit in hits)
        {
            PlayerDamReceive player = hit.collider.GetComponentInParent<PlayerDamReceive>();

            if (player != null)
            {
                Debug.Log("Bố đâm chết cụ m h!");
                player.Deduct(1);
            }
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireCube(
            attackPoint.position + transform.right * attackDistance,
            attackSize
        );
    }
}
