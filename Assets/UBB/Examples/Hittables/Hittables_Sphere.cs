using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hittables_Sphere : MonoBehaviour
{
    public GameObject m_hitFX;
    public float m_timeToDestroy = 2f;

    public void SpawnParticle()
    {
        Destroy(Instantiate(m_hitFX, transform.position, Quaternion.identity), m_timeToDestroy);
    }
}
