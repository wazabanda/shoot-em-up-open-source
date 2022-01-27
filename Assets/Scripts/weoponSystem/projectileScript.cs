using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class projectileScript : MonoBehaviour//,Ihittable
{
    public string projectileID;
    public GameObject firedBy, parentFiredBy = null, particle;
    public weapon ability;
    
    public float damage,speed;
    public float targetCheckRadius,projectileHomeTime,projectileTimer,KnockBack;
    public bool allowDestroy = true, isDeflectable = false;
    public bool hasLockedOn;
    //public Color enemyColor, playerColor;
    public LayerMask attackLayer;
    [HideInInspector]
    public Transform lockedOnTarget;
    [HideInInspector]
    public List<Transform> PreviousLockOns;
    [HideInInspector] public Vector3 direction;
    [HideInInspector] public float maxBulletCollisions = 0;
    public Rigidbody rb;
    controlState controlState;
    SpriteRenderer sp;
    ParticleSystem ps;
    [HideInInspector]
    public Collider colliedrComp;
    public float currentprojectileTime;
    private void Start()
    {
        currentprojectileTime = 0;
        
        sp = GetComponent<SpriteRenderer>();
        if(sp == null)
        {
            ps = GetComponent<ParticleSystem>();
        }
        setParams();
    }
    private void Update()
    {

        timer();
        if (hasLockedOn)
                {
            transform.DOMove(lockedOnTarget.transform.position, projectileHomeTime);
                    transform.rotation = Quaternion.LookRotation(Vector3.forward, lockedOnTarget.transform.position - transform.position);
        }
        else
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, rb.velocity);
        }
  }
    public void setParams()
    {
        //PreviousLockOns = new List<Transform>();
        rb = GetComponent<Rigidbody>();
        colliedrComp = GetComponent<Collider>();

        hasLockedOn = false;
        if (firedBy != null)
        {
            if (firedBy.TryGetComponent(out StateManager sm))
            {
                controlState = sm.ControlState;
            }
            else if (firedBy.GetComponent<projectileScript>().firedBy.TryGetComponent(out StateManager smm))
            {
                controlState = smm.ControlState;

            }
        }
        rb.velocity = transform.forward * speed;

    }
    public void setDamage(float damage)
    {
        this.damage = damage;
    }
    private void OnTriggerEnter(Collider collision)
    {
        check(collision.gameObject);
    }
    private void OnParticleCollision(GameObject other)
    {
        check(other);
    }

    private void OnCollisionEnter(Collision collision)
    {
        check(collision.gameObject);
    }
    public void check(GameObject collision, bool ignoreWalls = false)
    {
        if(lockedOnTarget != null)
        {
            if(collision.transform == lockedOnTarget)
            {
                hasLockedOn = false;
            }
        }

        if (collision.TryGetComponent(out StateManager state))
        {
            if ( controlState == controlState.player && state.ControlState == controlState.enemy)
            {

                if (collision.TryGetComponent(out Ihittable hit))
                {
                    dealDamage(hit);
                    destroyBullet();
                }
            }
            else if (state.ControlState == controlState.player && controlState == controlState.enemy)
            {

                if (collision.TryGetComponent(out Ihittable hit))
                {
                    dealDamage(hit);
                    destroyBullet();
                }
            }else if(state.ControlState == controlState.neutral)
            {
                if (collision.TryGetComponent(out Ihittable hit))
                {
                    dealDamage(hit);
                    destroyBullet();
                }
            }

            if (firedBy == null)
            {
                if (collision.TryGetComponent(out Ihittable hit))
                {
                    dealDamage(hit);
                    destroyBullet();
                }
            }
        }

        else if (collision.TryGetComponent(out projectileScript ps))
        {
            if (ps.firedBy != firedBy) { 

                destroyBullet();
            }
        }
        else
        {
            destroyBullet();

        }
    }
    void dealDamage(Ihittable hit)
    {
            hit.OnHit(damage, ability, firedBy);

        /*        if (firedBy.TryGetComponent(out projectileScript ps))
                {
                    hit.OnHit(damage, ability, ps.firedBy);
                    ps.setParams();
                }
                else
                {

                    hit.OnHit(damage, ability, firedBy);
                }*/
    }
    public void destroyBullet()
    {
        if(particle != null)
        {
          GameObject obj = Instantiate(particle, transform.position, Quaternion.identity);
            if(obj.TryGetComponent(out projectileScript ps))
            {
                ps.firedBy = firedBy;
                ps.setParams();
            }
        }
        if (allowDestroy)
        {
            Destroy(gameObject);
            //gameObject.SetActive(false);
        }
        }
    public void timer()
    {
        if(currentprojectileTime <= projectileTimer)
        {
            currentprojectileTime += Time.deltaTime;
        }

    }
    public void resetTImer()
    {
        Debug.Log("fired");
        currentprojectileTime = 0;
    }
}
