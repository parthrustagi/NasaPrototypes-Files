using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public Animator spikeAnimation;

    void Start()
    {
        spikeAnimation.enabled = false;   
    }

    //public void Shoot()
    //{
    //    if (this.transform.localPosition.y < -0.0335)
    //    {
    //        StartCoroutine(_Shoot());
    //    }
    //}

    //IEnumerator _Shoot()
    //{
    //    float delay = 2f;

    //    yield return new WaitForSeconds(delay);

    //    this.transform.localPosition += (Vector3.up * 0.0599f);
    //}

    //public void Retract()
    //{
    //    if (this.transform.localPosition.y > -0.0435)
    //    {
    //        StartCoroutine(_Retract());
    //    }
    //}

    //IEnumerator _Retract()
    //{

    //    float delay = 0.5f; ;

    //    yield return new WaitForSeconds(delay);

    //    this.transform.localPosition -= (Vector3.up * 0.0599f);
    //}

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            spikeAnimation.enabled = true;
            Invoke("StopAnimation", 2.5f);
        }
    }

    void StopAnimation()
    {
        spikeAnimation.enabled = false;
    }

    //public void OnTriggerStay(Collider other)
    //{
    //    this.transform.localPosition = transform.localPosition;
    //}

    //public void OnTriggerExit(Collider other)
    //{

    //}
}
