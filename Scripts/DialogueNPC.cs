using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueNPC
{
    //defines specifications of TextArea
    [TextAreaAttribute(3, 10)]
    public string[] sentences;
}
