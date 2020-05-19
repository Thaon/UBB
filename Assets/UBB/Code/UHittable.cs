using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class UHittable : MonoBehaviour
{
    #region member variables

    public int m_healthPoints;
    public UnityEvent m_onHit, m_onDeath;

    private Collider m_coll;
    private Rigidbody m_rb;

    #endregion

    void Start()
    {
        //cache and configure components
        m_coll = GetComponent<Collider>();
        m_coll.isTrigger = true;

        m_rb = GetComponent<Rigidbody>();
        m_rb.useGravity = false;
        m_rb.isKinematic = true;
    }

    /// <summary>
    /// Called externally from either Raycast or Volume Hitters
    /// </summary>
    /// <param name="dmg">The applied damage</param>
    public void Hit(int dmg)
    {
        if (m_healthPoints - dmg > 0)
        {
            //get damaged
            m_onHit.Invoke();
        }
        else
        {
            //we are dead
            m_onDeath.Invoke();
        }
        //apply actual damage
        m_healthPoints -= dmg;
    }
}
