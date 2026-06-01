using UnityEngine;

public class MonkController : MonoBehaviour
{
    Rigidbody2D Rigidbody2D;
    Animator animator;
    public float speed;
    public bool vertical;
    float timer;
    int direction = 1;
    public float changeTime = 3.0f;
    bool broken = true;
    private void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        timer = changeTime;
    }
    void Start()
    {
        
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }
    private void FixedUpdate()
    {
        if (!broken)
        {
            return;
        }
        Vector2 position = (Vector2)Rigidbody2D.position;
        if (vertical)
        {
            position.y = position.y + speed * direction * Time.deltaTime;
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);
        }
        else
        {
            position.x = position.x + speed * direction * Time.deltaTime;
            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0);
        }

        //position.x = position.x + speed*Time.deltaTime;
        Rigidbody2D.MovePosition(position);
    }
}
