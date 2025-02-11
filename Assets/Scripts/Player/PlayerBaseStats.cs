using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseStats : MonoBehaviour
{
    public static PlayerBaseStats Instance;

    public float health = 100f;
    public float dmg = 5f;
    public float defense = 1f;
    public float moveSpeed = 9f;
    public float knockBack = 1f;
    public int stocks = 3;

}