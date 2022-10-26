using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    [SerializeField] private GameObject slicedWatermelonPrefab;
    [SerializeField] private GameObject scoreTextPrefab;
    [SerializeField] private int scoreValue;
    private GameObject slicedFruit;



    private void OnCollisionEnter(Collision collision)
    {
        SwordSwipeController sword = collision.gameObject.GetComponentInParent<SwordSwipeController>();
        if (sword != null)
        {
            if (sword.IsSwiping())
            {
                slicedFruit = Instantiate(slicedWatermelonPrefab, transform.position, Quaternion.identity);
                slicedFruit.transform.right = collision.GetContact(0).normal;
                GameManager.instance.IncreaseCombo();
                GameManager.instance.AddScore(scoreValue);
                GameObject scoreTextVisual = Instantiate(scoreTextPrefab, transform.position + new Vector3(0.5f, 0, 0.5f), Quaternion.identity);
                if (scoreTextVisual.TryGetComponent(out TextMeshPro tmp))
                {
                    tmp.text = "+" + scoreValue.ToString();
                }
                Destroy(gameObject);
            }
        }
    }

}
