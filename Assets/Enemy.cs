using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(DeathTimer());
    }

    IEnumerator DeathTimer()
    {
        yield return new WaitForSeconds(5);

        EnemyPool.instance.Deactivate(this);
    }

    void Update()
    {
        transform.Translate(0,0, 1 * 3f *Time.deltaTime);
    }
}
