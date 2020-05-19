using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class UVolumeHitter : MonoBehaviour
{
    #region member variables

    public int m_damage;
    public bool m_isContinous = false;
    public bool m_destroyOnImpact = true;

    #endregion

    private void Start()
    {
        GetComponent<Collider>().isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        var hittable = other.GetComponent<UHittable>();

        if (hittable)
        {
            hittable.Hit(m_damage);
        }

        if (m_destroyOnImpact)
            Destroy(this.gameObject);
    }

    private void OnTriggerStay(Collider other)
    {
        if (m_isContinous)
        {
            var hittable = other.GetComponent<UHittable>();

            if (hittable)
            {
                hittable.Hit(m_damage);
            }
        }
    }
}
