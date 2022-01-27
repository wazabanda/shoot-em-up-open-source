using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum statType
{
    HP,AMMO
}
[System.Serializable]
public class statPickUpType
{
    public statType statType;
    public int minAmount, maxAmount;
    public Sprite image;
    public GameObject particle;
}
public class statPickUp : MonoBehaviour
{
    public List<statPickUpType> statPickUpTypes;
    public statPickUpType statPick;
    SpriteRenderer sp;
    private void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
        statPick = statPickUpTypes[Random.Range(0, statPickUpTypes.Count)];
        sp.sprite = statPick.image;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            int amount = Random.Range(statPick.minAmount, statPick.maxAmount);
            switch (statPick.statType)
            {
                case statType.HP:
                    player.instance.cs.heal(amount);
                    break;
                case statType.AMMO:
                    playerActions.instance.useAmmo(amount, false);
                    break;
                default:
                    break;
            }
            audioManager.instance.playSound("pick");
            Instantiate(statPick.particle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
