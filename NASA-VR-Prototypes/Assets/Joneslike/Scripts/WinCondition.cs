using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinCondition : MonoBehaviour
{
    public TextMeshProUGUI gameWinText;

    // Start is called before the first frame update
    void Start()
    {
        gameWinText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            gameWinText.enabled = true;
        }
    }
}
