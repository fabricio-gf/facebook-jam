using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unidade : MonoBehaviour{

    public float MaxLife=10;
    public float Life = 10;

    public float Damage = 1;
    public float AtaqueDelay = 1;
    public float Range = 1.1f;

    public float MovementSpeed = 2;

    public Unidade Target;

    // Start is called before the first frame update
    void Start()
    {
        Life = MaxLife;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyDamage(float damage) {

        Life -= Mathf.Abs(damage);
        if (Life <= 0) {
            Destroy(gameObject);
        }
    }
}
