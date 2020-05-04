using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : Trans
{
    public Image fill;
    Slider sld;
    public float adder1;
    public float adder2;
    public float adder3;
    public float adder4;
    public GameObject ChooseMenu;
    public GameObject ChooseMap;
    void Start()
    {
        sld = GetComponent<Slider>();
    }

    void Update()
    {
        sld.value = Mathf.Lerp(sld.value, adder1 + adder2 + adder3 + adder4, 3 * Time.deltaTime);
        if (sld.value >= 0.95f) 
        {
            ChooseMenu.SetActive(false);
            ChooseMap.SetActive(true);
            //todo:增加转场动画
        }
    }
    private void LateUpdate()
    {
        fill.SetNativeSize();
    }
}
