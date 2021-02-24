using System;
using System.Collections;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(DeathTimer());
    }

    IEnumerator DeathTimer()
    {
        yield return new WaitForSeconds(5);

        EnemyPool2.instance.ReturnToPool(this);
    }

    void Update()
    {
        transform.Translate(0,0, 1 * 3f *Time.deltaTime);
    }
}
