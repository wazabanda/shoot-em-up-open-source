using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using System;
public class CharacterStats : MonoBehaviour,Ihittable
{
    public class onCharacterDeathArgs : EventArgs
    {
        public GameObject sender;
    }
    public event EventHandler<onCharacterDeathArgs> onCharacterDeath;
    public event EventHandler onStaminaDrained;
    public statData statData;
    public List<GameObject> drops;
    [Header("UI ELEMENT")]
    public Slider HealthBar;
    public TextMeshProUGUI text;
    [SerializeField] private Vector3 popUpPos;

    [Header("Scripts for referenceing")]

    public float characterBaseRaycastDistance;
    [HideInInspector]public float baseGravityScale;

    public UnityEvent onDeafeatedEvent;
    public  StateManager sm;

    Material material;
    private void Awake()
    {
        sm = GetComponent<StateManager>();
        /*        baseGravityScale = movementScript.rb.gravityScale;*/

        statData.health = statData.Maxhealth;
        text?.SetText(statData.health.ToString("f1") + "/" + statData.Maxhealth.ToString("f1"));

        SetUI(statData);
        if (TryGetComponent(out SpriteRenderer sp))
        {
            material = sp.material;
        }
    }

    private void FixedUpdate()
    {
/*        if (statData.staminaRegainPerSecond > 0)
        {
            increaseStamina(statData.staminaRegainPerSecond * Time.deltaTime);
        }*/


    }
    public void SetUI(statData newStatData)
    {
        if (HealthBar != null)
        {
            HealthBar.maxValue = newStatData.Maxhealth;
            // staminaBar.maxValue = newStatData.Maxstamina;
            HealthBar.value = newStatData.health;
            //staminaBar.value = newStatData.stamina;
        }
    }
    public void OnHit(float damage, weapon hitBy,GameObject hitter = null)
    {

        StartCoroutine(hitEffect());
 
        

        DealDamage(damage,Color.red);

        if (sm.ControlState == controlState.enemy)
        {
            if (hitBy != null && statData.health <= 5)
            {
                if(Vector3.Distance(transform.position,hitter.transform.position) < 5)
                {
                    slowMotionEffect.instance.doslowmo();
                }

            }
        }
    }
    public IEnumerator hitEffect()
    {
        material?.EnableKeyword("HITEFFECT_ON");
        yield return new WaitForSeconds(0.1f);
        material?.DisableKeyword("HITEFFECT_ON");

    }
    public void DealDamage(float damage,Color color)
    {
/*        if(color == new Color())
        {
            color = Color.red;
        }*/
        if (statData.health > 0)
        {
            statData.health -= damage;
            if (HealthBar != null)
            {
                HealthBar.value = statData.health;
            }
            if(sm.ControlState == controlState.player) { audioManager.instance.playSound("HIT");}
        }
        text?.SetText(statData.health.ToString("f1") + "/" + statData.Maxhealth.ToString("f1"));
        if (statData.health <= 0)
        {
            material?.EnableKeyword("OUTBASE_ON");
            sm.actionState = ActionState.deafeted;
            onDeafeatedEvent?.Invoke();
            onCharacterDeath?.Invoke(this, new onCharacterDeathArgs { sender = gameObject});
            if(sm.ControlState == controlState.enemy ||sm.ControlState ==  controlState.neutral)
            {
                if (drops != null)
                {
                    foreach (var item in drops)
                    {

                        Instantiate(item, transform.position, Quaternion.identity);
                    }
                }
                Destroy(gameObject);
            }
        }


        //propSpawner.instance.spawnPopUpText(transform.position + popUpPos, damage.ToString() + " DMG", color, 0.3f);

    }
    public void heal(float healAmount)
    {
       
        material?.DisableKeyword("OUTBASE_ON");

        statData.health += healAmount;
        statData.health = Mathf.Clamp(statData.health, 0, statData.Maxhealth);
        text?.SetText(statData.health.ToString("f1") + "/" + statData.Maxhealth.ToString("f1"));
        HealthBar.value = statData.health;

        //propSpawner.instance.spawnPopUpText(transform.position + popUpPos, healAmount.ToString() + "HP", Color.green, 0.3f);

    }
    public statData getStats()
    {
        return statData;
    }
    public void setStats(statData newData)
    {
        statData = newData;
        statData.health = statData.Maxhealth;
        HealthBar.maxValue = statData.Maxhealth;
        //staminaBar.maxValue = statData.Maxstamina;
        HealthBar.value = statData.Maxhealth;
        //staminaBar.value = statData.Maxstamina;
    }
    public void increaseStamina(float increaseAmount = 1) {
        if(statData.stamina < statData.Maxstamina)
        {
            statData.stamina += increaseAmount;
            statData.stamina = Mathf.Clamp(statData.stamina, 0, statData.Maxstamina);
            //staminaBar.value = statData.stamina;
        }
    }
    public void DrainStamina(float drainAmount = 0)
    {
        statData.stamina -= drainAmount;
        statData.stamina = Mathf.Clamp(statData.stamina, 0, statData.Maxstamina);
        //staminaBar.value = statData.stamina;
        if(statData.stamina <= 0.5f)
        {
            onStaminaDrained?.Invoke(this, EventArgs.Empty);
        }

    }

    public void IncreaseSoul(float increaseAmount)
    {
            statData.special += increaseAmount;
            statData.special = Mathf.Clamp(statData.stamina, 0, statData.Maxspecial);
            //SpecialBar.value = statData.special;
    }
    public void DrainSoul(float drainAmount)
    {
        statData.special -= drainAmount;
        statData.special = Mathf.Clamp(statData.stamina, 0, statData.Maxspecial);
/*        if (SpecialBar != null)
        {
            SpecialBar.value = statData.special;
        }*/
    }
    #region for statusEffects
   

    #endregion

/*    public void fromUpgrades()
    {
        player_upgrade_manager upgradeManager = GlobalRefrences.instance.player.upgradeManager;
        statData.Maxhealth += upgradeManager.stateModifers.healthIncrease;
        statData.staminaRegainPerSecond += upgradeManager.stateModifers.staminaRegenBoost;
        statData.Maxspecial += upgradeManager.stateModifers.soulBoost;
        SetUI(statData);
    }*/

}
[System.Serializable]
public class statData
{
    public float Maxhealth, Maxstamina, Maxspecial;
    public float health, stamina, special;
    public float staminaRegainPerSecond;
}