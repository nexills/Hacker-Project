using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintScript : MonoBehaviour
{
    public Text displayText;

    void Start()
    {
        displayText.text = "Hint:";
    }

    public void setText(string newText)
    {
        displayText.text = "Hint:\n" + newText;
    }
}
