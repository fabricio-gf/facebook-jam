using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Unidade : MonoBehaviour{

    public float MaxLife=10;
    public float Life = 10;

    public float Damage = 1;
    public float AtaqueDelay = 1;
    public int Range = 1;

    public float MovementSpeed = 2;

    public Unidade Target;
    public GridManager grid;

    Animator _Animator;

    // Start is called before the first frame update
    void Start()
    {
        _Animator = GetComponent<Animator>();
        Life = MaxLife;
        grid = FindObjectOfType<GridManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int DistanceToTarget() {
        if (Target != null) {
            Debug.Log(name + " distancia:" + grid.ManhattanDistance(transform, Target.transform) + " de " + Target.name);
            return grid.ManhattanDistance(transform.parent, Target.transform.parent);
        } else {
            return int.MaxValue;
        }
    }

    public bool TargetInRange() {
        return (DistanceToTarget() <= Range);
    }

    public void ApplyDamage(float damage) {

        Life -= Mathf.Abs(damage);
        if (Life <= 0) {
            if(tag == "Player") UnitLimitManager.instance.PlayerUnitDeath();
            if(tag == "Enemy") UnitLimitManager.instance.EnemyUnitDeath();

            Destroy(gameObject);
        }
    }

    public void ApplyHeal(float amount) {
        Life += Mathf.Abs(amount);
    }

    public void StartFight() {
        _Animator.enabled = true;
    }

    public void StopFight() {
        _Animator.enabled = false;
    }
}
