using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnEnable()
    {
        print($"{name} Enemy enabled.");
        StartCoroutine(DeathTimer());
    }

    private void OnDisable()
    {
        print($"{name} Enemy disabled.");
    }

    IEnumerator DeathTimer()
    {
        yield return new WaitForSeconds(5);
        gameObject.SetActive(false);
    }

    void Update()
    {
        transform.Translate(0,0, 1 * 3f *Time.deltaTime);
    }
}
