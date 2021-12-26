using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreArea : MonoBehaviour
{
    public GameObject scoreEffect;

    void Start()
    {
        scoreEffect.SetActive(false);
    }

    void OnTriggerEnter (Collider otherCollider)
    {
        if(otherCollider.GetComponent<Ball>() != null)
        {
            scoreEffect.SetActive(true);
        }
    }
}
