using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowFly : MonoBehaviour
{
    [Header("Arrow Fly")]
    [SerializeField] protected Vector2 direct = Vector2.right;
    [SerializeField] protected float speed = 20f;

    protected void FixedUpdate()
    {
        transform.position = new Vector3(transform.parent.position.x, transform.parent.position.y, -1f);
        transform.parent.Translate(this.direct * this.speed * Time.fixedDeltaTime);
    }
}
