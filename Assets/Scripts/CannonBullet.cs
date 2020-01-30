using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBullet : MonoBehaviour
{
    public Vector3 targetPos;
    public float xOffSet;
    public float yOffSet;
    public float velocity = 20;//炮弹速度    
    public float velocityX;
    public float velocityY;
    public float velocityZ0;
    private float time = 1;
    private float screenY;
    private float screenZ;
    private float screenX;
    private bool start = false;
    private float timer = 0;
    private int ColorType;
    public GameObject efx;
    public GameObject shadow;
    public Collider2D explosion;
    public GameObject ColorPool1;
    public GameObject ColorPool2;
    public GameObject ColorPool3;
    #region same height
    public float height = 1;
    public float TotalTime = 1.2f;

    public void StartShoot(Vector3 target)
    {
        start = true;
        targetPos = target;
        velocityX = (target.x - transform.position.x) / TotalTime;
        velocityY = (target.y - transform.position.y) / TotalTime;
        velocityZ0 = height / TotalTime + 10 * TotalTime;
    }
    void Start()
    {
        ColorType = Mathf.FloorToInt(Random.Range(0, 2.9f));
        screenX = transform.position.x;
        screenY = transform.position.y;
        screenZ = 0;
    }
    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if (timer > TotalTime)
        {
            Destroy(gameObject);
            explosion.enabled = true;
        }
        if (start)
        {
            screenX += velocityX * Time.fixedDeltaTime;
            screenY += velocityY * Time.fixedDeltaTime;
            velocityZ0 -= 20 * Time.fixedDeltaTime;
            screenZ -= velocityZ0 * Time.fixedDeltaTime;
            //transform.position = new Vector3(screenX, screenY, screenZ);
            transform.position = new Vector3((screenX - xOffSet), (screenY - screenZ - yOffSet),0);
        }
    }
    private void Update()
    {
        shadow.transform.localPosition += new Vector3(0, 0.6f / 1.2f * Time.deltaTime, 0);
    }
    #endregion
    //#region same velocity
    //public void StartShoot(Vector3 target)
    //{
    //    start = true;
    //    targetPos = target;
    //    time = Mathf.Sqrt(Mathf.Pow(Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x, 2) + Mathf.Pow(Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y, 2)) / velocity;
    //    velocityX = (Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x) / time;
    //    velocityY = (Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y) / time;
    //    velocityZ0 = -20 / 2 * time;
    //}
    //void Start()
    //{
    //    screenX = transform.position.x;
    //    screenY = transform.position.y;
    //    screenZ = 0;
    //}
    //private void FixedUpdate()
    //{
    //    timer += Time.fixedDeltaTime;
    //    if (timer > time)
    //    {
    //        Destroy(gameObject);
    //        explosion.SetActive(true);
    //    }
    //    if (start)
    //    {
    //        screenX += velocityX * Time.fixedDeltaTime;
    //        screenY += velocityY * Time.fixedDeltaTime;
    //        velocityZ0 += 20 * Time.fixedDeltaTime;
    //        screenZ += velocityZ0 * Time.fixedDeltaTime;
    //        //transform.position = new Vector3(screenX, screenY, screenZ);
    //        transform.position = new Vector3((screenX - xOffSet), (screenY - screenZ - yOffSet), 0);
    //    }
    //}
    //private void Update()
    //{
    //    shadow.transform.localPosition += new Vector3(0, 0.6f / time * Time.deltaTime, 0);
    //}
    //#endregion
    private void OnDestroy()
    {
        switch (ColorType)
        {
            case 0:
                Instantiate(ColorPool1, gameObject.transform.position, Quaternion.identity);
                break;
            case 1:
                Instantiate(ColorPool2, gameObject.transform.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(ColorPool3, gameObject.transform.position, Quaternion.identity);
                break;
            default:
                Instantiate(ColorPool1, gameObject.transform.position, Quaternion.identity);
                break;
        }
        if (efx)
        {
            Instantiate(efx, gameObject.transform.position, Quaternion.identity);
        }

    }

}
