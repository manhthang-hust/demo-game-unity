using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterStatHealthModifierSO : CharacterStatModifierSO
{
    public override void AffectCharacter(GameObject player, float val)
    {
        GameManager.instance.player.HP += 5;
        if (GameManager.instance.player.HP > 60) GameManager.instance.player.HP = 60;
    }
}