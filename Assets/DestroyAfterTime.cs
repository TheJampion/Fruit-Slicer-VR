using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [SerializeField] private float time = 1f;
    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer > time)
        {
            Destroy(gameObject);
        }
    }
}
