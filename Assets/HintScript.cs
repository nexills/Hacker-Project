using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintScript : MonoBehaviour
{
    public Text displayText;

    public void setText(string newText)
    {
        displayText.text = newText;
    }
}
