using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class URaycastHitter : MonoBehaviour
{
    #region member variables

    [Header("Base settings")]
    public Transform m_firingTransform;
    public float m_range;
    public int m_damage;
    [Header("Automatic settings")]
    public bool m_isAutomatic;
    public float m_rechargeTime;

    private bool m_canFire = true;

    #endregion

    private void Start()
    {
        if (m_isAutomatic) FireHitter();
    }

    public void FireHitter()
    {
        if (!m_canFire)
            return;

        Ray ray = new Ray(m_firingTransform.position, m_firingTransform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, m_range))
        {
            var hittable = hit.collider.GetComponent<UHittable>();
            if (hittable != null)
            {
                hittable.Hit(m_damage);
                m_canFire = false;
                StartCoroutine(ResetFireCO());
            }
        }
    }

    private IEnumerator ResetFireCO()
    {
        yield return new WaitForSeconds(m_rechargeTime);
        m_canFire = true;
        if (m_isAutomatic) FireHitter();
    }
}
