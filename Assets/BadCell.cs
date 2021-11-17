using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadCell : MonoBehaviour
{

    [SerializeField] float health;
    [SerializeField] float dmg;
    [SerializeField] float time;

    // Start is called before the first frame update
    void Start()
    {
        health = 10f;
        dmg = health/3.0f;
        time = 0f;
    }

    public void fight(float dmg)
    {
        health -= dmg;
    }

    public float getHealth()
    {
        return health;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject o = collision.gameObject;
        if(o.tag == "GoodCell")
        {
            StartCoroutine(Engaged(o));
        }
    }

    private IEnumerator Engaged(GameObject o)
    {
        GoodCell c = o.GetComponent<GoodCell>();
        while (o != null)
        {
            if(time > 2)
            {
                c.fight(dmg);
                time = 0;
            }
            if(health<= 0)
            {
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (health<=0)
        {
            Destroy(this.gameObject);
        }

        if(time > 5)
        {
            health += 3.0f;
            time = 0;
        }
        dmg = health / 3.0f;
    }
}
