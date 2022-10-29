using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/EnemyData")]
public class EnemyData : ScriptableObject
{
    public int Health;
    public int Score;
    public bool AutoLock;
    public float RotateSpeed;
}
