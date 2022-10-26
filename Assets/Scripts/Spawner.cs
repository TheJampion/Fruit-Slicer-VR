using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float speed = 5f;

    public void SpawnNewObject()
    {
        GameObject spawnedObject = Instantiate(objectToSpawn,spawnPoint.position, Quaternion.identity);
        float horizontalForce = Random.Range(-1f, 1f);
        if(spawnedObject.TryGetComponent(out Rigidbody rb))
        {
            rb.AddForce(Vector3.up * speed + Vector3.right * horizontalForce, ForceMode.Impulse);
        }
    }
}
