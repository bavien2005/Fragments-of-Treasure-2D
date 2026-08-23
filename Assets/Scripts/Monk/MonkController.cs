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

    public DialogueController dialogue;

    public Transform player;
    public float talkDistance = 2f;

    bool hasTalked = false; // để tránh lặp
    private void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        timer = changeTime;
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        // Lại gần → nói
        if (distance < talkDistance && !hasTalked)
        {
            Debug.Log("Trigger hội thoại");

            broken = false;
            hasTalked = true;

            dialogue.StartDialogue();
        }

        // Đi xa → tắt hội thoại
        if (distance > talkDistance)
        {
            if (hasTalked)
            {
                dialogue.EndDialogue(); // 🔥 TẮT
                broken = true;          // NPC đi lại tiếp
            }

            hasTalked = false;
        }

        if (!broken) return;

        timer -= Time.deltaTime;
        if (timer < 0)
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
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player vào vùng NPC");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player rời NPC");
        }
    }
}
