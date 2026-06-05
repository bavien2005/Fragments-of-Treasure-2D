using UnityEngine;


enum EnemyState
{
    Patrol,
    Chase
}

public class Enemy : MonoBehaviour
{
    EnemyState state;
    Rigidbody2D rb;
    Animator animator;
    public Transform player;
    int direction = 1;
    float timer;
    public float changeTime = 3.0f;

    [SerializeField] float attackDistance;
    [SerializeField] float attackNonDistance;
    [Header("Attack Settings")]
    public float attackRadius = 1.2f;          // bán kính đánh
    public int damage = 10;                    // damage
    public LayerMask playerLayer;
    // layer của Player

    [Header("Movement")]
    [SerializeField]  private float speed;
    [SerializeField] private Transform posA;
    [SerializeField] private Transform posB;

    [SerializeField] private Vector2 firtPosA;
    [SerializeField] private Vector2 firtPosB;
    [SerializeField] private Vector2 posTarget;
    [SerializeField] private Vector2 moveVelocity;
    private DamageReceiver damageReceiver;

    [Header("Attack Point")]
    public Transform attackPoint;              // vị trí check (đầu kiếm, trước mặt)

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //timer = changeTime;
    }
    private void Start()
    {
        firtPosA = posA.position;
        firtPosB = posB.position;
        posTarget = firtPosA;
    }

    private void Update()
    {
        Vector2 current = rb.position;
        float dist = Vector2.Distance(transform.position, player.position);

        // ===== STATE SWITCH =====
        if (dist < attackDistance)
        {
            state = EnemyState.Chase;
            animator.SetTrigger("Attack");
        }
        else if (dist > attackNonDistance)
        {
            state = EnemyState.Patrol;
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
                posTarget = (posTarget == (Vector2)firtPosA) ? firtPosB : firtPosA;
            }
        }

        // ===== MOVE =====
        Vector2 dir = Vector2.zero;

        if (Vector2.Distance(transform.position, posTarget) < 0.05f)
        {
            
            //if(state == EnemyState.Chase)
            //{
            //    animator.SetTrigger("Attack");
            //}
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
    public void AttackPlayer()
    {
        // check player trong vùng tròn
        Collider2D[] hits = Physics2D.OverlapCircleAll(
            attackPoint.position,
            attackRadius,
            playerLayer
        );

        foreach (Collider2D hit in hits)
        {
            // thử lấy script Player
            PlayerCtrl player = hit.GetComponentInParent<PlayerCtrl>();

            if (player != null)
            {
                player.Anim.SetBool("Hurt", true);
            }
        }
    }

    // vẽ vùng attack trong Scene cho dễ nhìn
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }

    private void FixedUpdate()
    {
       
    }
}
