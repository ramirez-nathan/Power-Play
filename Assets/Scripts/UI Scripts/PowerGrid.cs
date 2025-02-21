using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerGrid 
{
    private int width;
    private int height;
    private int[,] gridArray;


    public PowerGrid(int width, int height)
    {
        this.width = width;
        this.height = height;

        gridArray = new int[width, height];

        Debug.Log(width + " " + height);
    }


}
