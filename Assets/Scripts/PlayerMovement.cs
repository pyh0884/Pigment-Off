using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed = 5f;
    private Rigidbody2D rb;
    Vector2 movement;
    public float HitBackForce = 5;
    public float HitBackTime = 0.2f;
    private float hitBackTime = 0;
    public bool controllable = true;
    void HitBack()
    {
        hitBackTime = 0;
        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        rb.velocity = new Vector2(dir.x, dir.y).normalized * HitBackForce * -1;

    }
    public void Paoxie()
    {
        StartCoroutine("PaoXie");
    }
    IEnumerator PaoXie()
    {
        MoveSpeed *= 1.4f;
        yield return new WaitForSeconds(5);
        MoveSpeed /= 1.4f;
    }
    //Top-down Shooting Movement
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    { hitBackTime += Time.deltaTime;
        if (hitBackTime > HitBackTime)
        {
            rb.velocity = Vector2.zero;
        }
        //
        if (Input.GetKeyDown(KeyCode.Space)) { HitBack(); }
        //
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }
    void FixedUpdate()
    {
        rb.position = (rb.position + movement * MoveSpeed * Time.fixedDeltaTime);
    }

}
