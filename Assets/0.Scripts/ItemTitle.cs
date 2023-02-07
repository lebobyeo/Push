using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemTitle : MonoBehaviour
{
    [SerializeReference] private TMP_Text titleText;
    
    public void SetText(string str)
    {
        titleText.text = str;
    }
}
