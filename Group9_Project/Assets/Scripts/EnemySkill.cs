using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySkill : MonoBehaviour
{
    NavMeshAgent nav;
    Rigidbody rigid;
    public Transform player;
    public Animator anim;
    public float attackRange;
    int cool;
    Quaternion rot;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cool > 0)
        {
            cool--;
        }
        if ((player.position - transform.position).magnitude > attackRange)
        {
            anim.SetInteger("Move", 1);
            if(!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack1") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Attack2") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Attack3") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Attack4"))
                nav.SetDestination(player.position);
        }
        else
        {
            anim.SetInteger("Move", 0);
            if(cool>0)
                transform.rotation = Quaternion.Euler(new Vector3(0, Quaternion.LookRotation(player.position - transform.position).eulerAngles.y, 0));
            if (cool == 0)
            {
                cool = 500;
                int r = Random.Range(0, 4);
                if (r == 0)
                    anim.SetTrigger("Attack1");
                else if (r == 1)
                    anim.SetTrigger("Attack2");
                else if (r == 2)
                    anim.SetTrigger("Attack3");
                else if (r == 3)
                    anim.SetTrigger("Attack4");
                rot = transform.rotation;
            }
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack1") || anim.GetCurrentAnimatorStateInfo(0).IsName("Attack2") || anim.GetCurrentAnimatorStateInfo(0).IsName("Attack3") || anim.GetCurrentAnimatorStateInfo(0).IsName("Attack4"))
        {
            transform.rotation = rot;
        }
    }
}
