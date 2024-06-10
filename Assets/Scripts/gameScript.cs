using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameScript : MonoBehaviour
{
    int spriteIndex = -1;

    public int PlayerTurn()
    {
        spriteIndex++;
        return spriteIndex % 2;
    }
}
