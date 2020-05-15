using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonSkill : MonoBehaviour
{
    public GameObject efx;
    public int Camp;
    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - 0.23f);
    }
    public void EFX()
    {
        var efx1 = Instantiate(efx, transform.position, Quaternion.identity);
        efx1.GetComponent<CannonSkillEFX>().Camp = Camp;
        efx1.transform.parent = null;
        Destroy(gameObject);
    }
}
