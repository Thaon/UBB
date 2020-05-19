using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hittables_Mouse : MonoBehaviour
{
    #region member variables

    public GameObject m_projectilePrefab;

    private URaycastHitter m_hitter;

    #endregion

    void Start()
    {
        m_hitter = GetComponent<URaycastHitter>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            m_hitter.FireHitter();

        if (Input.GetButtonDown("Fire2"))
        {
            Rigidbody rb = Instantiate(m_projectilePrefab, transform.position, transform.rotation).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 10f, ForceMode.VelocityChange);
        }
    }
}
