using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerType
{
    Attack,
    Defense,
    Unique,
}
public abstract class PowerObject : ScriptableObject
{
    public GameObject prefab;
    public PowerType type;
    public string name;
    [TextArea(15, 20)]
    public string description;
}