using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class BossLevel1 : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float damageInterval = 0.5f;

    [SerializeField] private GameObject bulletEnemy;

    [SerializeField] private Transform firePos;

    [SerializeField] private float timeRandomSkill = 2f;

    [SerializeField] private float bulletSpeedNormal = 20f;

    [SerializeField] private float bulletSpeedAround = 10f;

    [SerializeField] private GameObject miniEmeny;

    //[SerializeField] private GameObject usbPrefabs;

    private float damageTimer = 0f;

    [SerializeField] PlayerDamReceive player;

    [SerializeField] private Slider hPSlider;

    // private AudioEffect audioEffect;

    [SerializeField] private int maxHP;

    [SerializeField] private int dmgSender; 


    private void Start()
    {
        StartCoroutine(randomSkill());
     //   audioEffect = FindAnyObjectByType<AudioEffect>();
        hPSlider.maxValue = maxHP;
        hPSlider.value = maxHP;
    }

    private void Update()
    {
        MoveToWardsPlayer();
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        damageTimer -= Time.deltaTime;

        if (damageTimer <= 0)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if (player != null)
                {
                    player.Deduct(dmgSender);
                    damageTimer = damageInterval;
                }
            }
        }
    }

    //public override void Die()
    //{
    //    audioEffect.stopBossSound();
    //    Instantiate(usbPrefabs, transform.position, Quaternion.identity);
    //    base.Die();
    //}

    private void MoveToWardsPlayer()
    {

        if (player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, 
                player.transform.position, speed * Time.deltaTime);
            FlipEnemy();
        }
    }
    protected void FlipEnemy()
    {
        if (player != null)
        {
            if (transform.position.x < player.transform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (transform.position.x > player.transform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
    }

    private void shotNormal()
    {
        if (player != null)
        {
            Vector3 directionToPlayer = player.transform.position - firePos.position;
            directionToPlayer.Normalize();
            GameObject bullet = Instantiate(bulletEnemy, firePos.position, Quaternion.identity);
            EnemyBullet enemyBullet = bullet.AddComponent<EnemyBullet>();
            if (enemyBullet != null)
            {
                enemyBullet.setMovementDirection(directionToPlayer * bulletSpeedNormal);
            }
            else
            {
                Debug.LogError("Không tìm thấy EnemyBullet trong bullet prefab!");
            }
        }
    }

    private void shotAround()
    {
        const int countBuller = 12;
        float angleStep = 360f / countBuller;
        for (int i = 0; i < countBuller; i++)
        {
            float angle = i * angleStep;
            Vector3 direction = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0);
            GameObject bullet = Instantiate(bulletEnemy, firePos.position, Quaternion.identity);
            EnemyBullet enemyBullet = bullet.AddComponent<EnemyBullet>();
            enemyBullet.setMovementDirection(direction * bulletSpeedAround);

        }
    }

    private void createMiniEnemy()
    {
        Instantiate(miniEmeny, transform.position, Quaternion.identity);
    }

    private void heal()
    {
        if (hPSlider.value < maxHP)
        {
            hPSlider.value += 5f; // Heal the boss by 1 when this enemy dies
        }
    }

    private IEnumerator randomSkill()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeRandomSkill);
            if (player != null)
            {
                int randomSkill = Random.Range(0, 4);

                switch (randomSkill)
                {
                    case 0:
                        shotNormal();
                        break;
                    case 1:
                        shotAround();
                        break;
                    case 2:
                        createMiniEnemy();
                        break;
                    case 3:
                        heal();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
