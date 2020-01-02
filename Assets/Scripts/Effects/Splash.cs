using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splash : MonoBehaviour
{
    SpriteRenderer spr;
    [SerializeField]
    float waitTime = 5;
    [SerializeField]
    float fadeTime = 3;


    private void Awake()
    {
        spr = gameObject.GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Fading());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Fading( )
    {
        
        yield return new WaitForSeconds(waitTime);

        float timeLeft = fadeTime;
        while(timeLeft >= 0)
        {
            timeLeft -= Time.deltaTime;
            Color cl = spr.color;
            spr.color = new Color(cl.r, cl.g, cl.b, timeLeft / fadeTime);
            yield return Time.deltaTime;
        }
        Destroy(gameObject);


    }

}
