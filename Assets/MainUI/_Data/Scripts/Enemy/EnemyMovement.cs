using UnityEngine;
public class EnemyMovement : EnemyAbstract
{
    [Header("Enemy Movment")]
    [SerializeField] protected Transform homePoint;
    [SerializeField] protected float speed = 2f;
    [SerializeField] protected float distance;
    [SerializeField] protected int distanceMaxX = 4;
    [SerializeField] protected int distanceMinX = -4;
    [SerializeField] protected int distanceMaxY = 4;
    [SerializeField] protected int distanceMinY = -4;
    [SerializeField] protected float moveTime = 2f;
    [SerializeField] protected float moveTimeCounter = 0f;
    [SerializeField] protected bool isMoving;
    protected Vector2 wayPoint;
    public Vector2 WayPoint => wayPoint;
    public bool IsMoving => isMoving;
    public float Speed => speed;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadHomePoint();
    }
    protected void LoadHomePoint()
    {
        if (this.homePoint != null) return;
        this.homePoint = GameObject.Find("HomePoint").transform;
        Debug.Log(transform.name + ": LoadHomePoint", gameObject);
    }
    protected void FixedUpdate()
    {
        this.PlayMoving();
    }
    protected void PlayMoving()
    {
        if (this.enemyCtrl.EnemyDamReceive.IsDead) return;
        if (this.enemyCtrl.EnemyDamReceive.IsHurt) return;
        if (this.enemyCtrl.EnemyDetect.Detect)
        {
            this.isMoving = true;
            return;
        }
        this.Moving();
        this.StopMoving();
    }
    protected void Moving()
    {
        this.isMoving = true;
        this.enemyCtrl.Rigid.MovePosition(Vector2.MoveTowards
        (transform.parent.position, this.wayPoint, this.speed * Time.fixedDeltaTime));
    }
    protected void StopMoving()
    {
        this.distance = Vector2.Distance(transform.parent.position, this.wayPoint);
        if (this.distance < 0.5f)
        {
            this.isMoving = false;
            this.moveTimeCounter += Time.deltaTime;
            if (this.moveTimeCounter < this.moveTime) return;
            this.moveTimeCounter = 0;
            this.SetNewDestination();
        }
    }
    public void SetNewDestination()
    {
        Vector2 homePosition = (Vector2)homePoint.position;
        this.wayPoint = homePosition + new Vector2(
            Random.Range(this.distanceMinX, this.distanceMaxX),
            Random.Range(this.distanceMinY, this.distanceMaxY)
        );
    }
}
