using UnityEngine;

[CreateAssetMenu(fileName = "Weapon Scriptable Object", menuName = "Scriptable Objects/Weapon Scriptable Object")]
public class WeaponSO : ScriptableObject
{
    public int Damage = 1;
    public float FireRate = 0.5f;
}
