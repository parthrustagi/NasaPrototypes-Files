using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GM_SlidingPuzzle : MonoBehaviour
{
    public static GM_SlidingPuzzle GM_SlidingPuzzleInstance;
    public bool isPuzzleComplete = false;

    [SerializeField]
    TextMeshProUGUI InstructionsText;

    //public Event

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(startInstructions(10f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator startInstructions(float timeBwDialogues)
    {
        InstructionsText.text = "Use the Grip button on the controllers to point at one of the tiles with adjacent opening to move it";
        yield return new WaitForSeconds(timeBwDialogues);
        InstructionsText.text = "Solve the hieroglyphic puzzle";
        yield return new WaitForSeconds(timeBwDialogues);
        InstructionsText.gameObject.SetActive(false);
    }


    public void GameCompleteEvent()
    {
        InstructionsText.gameObject.SetActive(true);
        InstructionsText.text = "Well Done! You have solved the Hieroglyphic Puzzle";
    }
    
}
