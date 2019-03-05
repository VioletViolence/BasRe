using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Characters/CommonCharacter")]
public class ScriptableCharacter : ScriptableObject
{
    //Generics
    public GameObject CharacterModel;
    public string Name;
    public string Race;
    public string Class;
    //Prefabs
    public GameObject Bullet;
    public GameObject MeleeAttackEffect;
    //Stats
    public bool IsMelee;
    public int Health;
    public int MovementSpeed;
    public float AttackSpeed;
    public int AttackDamage;
    public int AbilityDamage;
    public int Armor;
    public int MagicResistance;
    //Effects&Abilities
    public GameObject OnPlaceEffectPrefab;
    public GameObject OnRoundStartEffectPrefab;
    public GameObject AuraEffectPrefab;
    public GameObject OnAttackEffectPrefab;
    public GameObject OnBeingHitEffectPrefab;
    public GameObject OnDeathEffectPrefab;
    public GameObject ActiveSpellPrefab;
    public GameObject PassiveSpellPrefab;
        
}
