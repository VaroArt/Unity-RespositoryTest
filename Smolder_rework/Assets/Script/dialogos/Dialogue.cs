using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name;
    [TextArea(10,10)]
    public string[] sentences;
    [TextArea(10, 10)]
    public string[] sentences2;
    [TextArea(10, 20)]
    public string[] sentences3;



}
