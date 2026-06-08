using UnityEngine;

public class EnemyLancerBlue : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;

    public Transform player;

    public enum EnemyState { Patrol, Chase }
    EnemyState state;

    [Header("Distance")]
    public float attackDistance = 1.5f;
    public float attackNonDistance = 3f;

    [Header("Movement")]
    public float speed = 2f;
    public Transform posA;
    public Transform posB;

    Vector2 firtPosA;
    Vector2 firtPosB;
    Vector2 posTarget;
    Vector2 moveVelocity;

    [Header("Attack")]
    public int damage = 10;
    public LayerMask playerLayer;

    //float attackCooldown = 1.2f;
    //float lastAttackTime;
    bool isAttacking;

    Vector2 attackDir;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        firtPosA = posA.position;
        firtPosB = posB.position;
        posTarget = firtPosA;
    }

    private void Update()
    {
        float dist = Vector2.Distance(transform.position, player.position);

        // ===== STATE =====
        if (dist < attackDistance)
        {
            state = EnemyState.Chase;
            TryAttack();
        }
        else if (dist > attackNonDistance)
        {
            state = EnemyState.Patrol;
            animator.SetBool("Attack", false);
        }

        // ===== TARGET =====
        if (state == EnemyState.Chase)
        {
            posTarget = player.position;
        }
        else if (state == EnemyState.Patrol)
        {
            if (Vector2.Distance(transform.position, posTarget) < 0.05f)
            {
                posTarget = (posTarget == firtPosA) ? firtPosB : firtPosA;
            }
        }

        // ===== MOVE =====
        Vector2 current = rb.position;
        Vector2 dir = Vector2.zero;

        if (isAttacking)
        {
            moveVelocity = Vector2.zero;
        }
        else if (Vector2.Distance(transform.position, posTarget) < 0.05f)
        {
            moveVelocity = Vector2.zero;
        }
        else
        {
            dir = (posTarget - current).normalized;
            moveVelocity = dir * speed;
        }

        rb.linearVelocity = moveVelocity;

        // ===== ANIMATION =====
        animator.SetFloat("Speed", moveVelocity.magnitude);

        // ===== FLIP =====
        if (moveVelocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveVelocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    // ================= ATTACK =================

    void TryAttack()
    {
        //if (Time.time < lastAttackTime + attackCooldown) return;
        if (isAttacking) return;

        attackDir = GetAttackDirection(transform.position, player.position);

        animator.SetFloat("Look X", attackDir.x);
        animator.SetFloat("Look Y", attackDir.y);

        animator.SetBool("Attack", true);

        isAttacking = true;
        //lastAttackTime = Time.time;
    }

    //public void AttackPlayer() // gọi bằng Animation Event
    //{
    //    Vector2 attackPos = (Vector2)transform.position + attackDir * attackDistance;

    //    Vector2 boxSize = (attackDir == Vector2.up || attackDir == Vector2.down)
    //        ? new Vector2(0.5f, 1.5f)
    //        : new Vector2(1.5f, 0.5f);

    //    Collider2D hit = Physics2D.OverlapBox(attackPos, boxSize, 0f, playerLayer);

    //    if (hit != null)
    //    {
    //        Debug.Log("Đâm trúng player!");

    //        PlayerDamReceive player = hit.GetComponentInParent<PlayerDamReceive>();

    //        if (player != null)
    //        {
    //            player.Deduct(100);

    //        }
    //    }
    //}
    public void AttackPlayer()
    {
        Vector2 attackPos = (Vector2)transform.position + attackDir * attackDistance;

        Vector2 boxSize = (attackDir == Vector2.up || attackDir == Vector2.down)
            ? new Vector2(0.5f, 1.5f)
            : new Vector2(1.5f, 0.5f);

        Collider2D[] hits = Physics2D.OverlapBoxAll(attackPos, boxSize, 0f, playerLayer);

        foreach (var hit in hits)
        {
            PlayerDamReceive player = hit.GetComponentInParent<PlayerDamReceive>();

            if (player != null)
            {
                Debug.Log("Đâm trúng player!");
                player.Deduct(1);
            }
        }
    }

    public void EndAttack() // gọi ở cuối animation
    {
        isAttacking = false;
    }

    // ================= DIRECTION =================

    Vector2 GetAttackDirection(Vector2 enemyPos, Vector2 playerPos)
    {
        Vector2 dir = (playerPos - enemyPos).normalized;

        if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
        {
            return dir.x > 0 ? Vector2.right : Vector2.left;
        }
        else
        {
            return dir.y > 0 ? Vector2.up : Vector2.down;
        }
    }

    // ================= DEBUG =================
    [SerializeField] private Vector2 boxSize;
    private void OnDrawGizmos()
    {
        if (player == null) return;

        Vector2 dir = GetAttackDirection(transform.position, player.position);
        Vector2 attackPos = (Vector2)transform.position + dir * attackDistance;

        boxSize = (dir == Vector2.up || dir == Vector2.down)
            ? new Vector2(0.5f, 1.5f)
            : new Vector2(1.5f, 0.5f);

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPos, boxSize);
    }
}