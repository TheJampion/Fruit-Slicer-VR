using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnGroundCollision : MonoBehaviour
{
    [SerializeField] private float delay = 1.5f;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<Collider>().enabled = false;
            StartCoroutine(DestroyAfterDelay());
        }
    }

    private IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
