using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon Scriptable Object", menuName = "Scriptable Objects/Weapon Scriptable Object")]
public class WeaponSO : ScriptableObject
{
    public GameObject WeaponPrefab; // Reference to the weapon prefab
    public int Damage = 1;
    public float FireRate = 0.5f;
    public GameObject HitVFXPrefab;
    public bool IsAutomatic = false; // Added property to check if the weapon is automatic ex. machine guns
    public AnimatorController animatorController;

    public string SHOOT_STRING = "Shoot";
}
