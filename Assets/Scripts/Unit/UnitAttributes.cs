using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewUnit", menuName = "UnitAttributes")]
public class UnitAttributes : ScriptableObject
{
    public string unitName;
    public int level; 
    public int cost;
    public int hp;
    public int attackSpeed;
}
