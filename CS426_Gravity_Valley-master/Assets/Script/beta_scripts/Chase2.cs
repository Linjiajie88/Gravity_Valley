using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase2 : MonoBehaviour
{
    public Transform player;
    static Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.position, this.transform.position) < 50)
        {
            Vector3 direction = player.position - this.transform.position;
            direction.y = 0;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.05f);

            anim.SetBool("IsIdle2", false);
            if (direction.magnitude > 2.5)
            {
                this.transform.Translate(0, 0, 0.03f);
                anim.SetBool("IsRunning2", true);
                anim.SetBool("IsAttacking2", false);
            }
            else
            {
                anim.SetBool("IsAttacking2", true);
                anim.SetBool("IsRunning2", false);
            }
        }
        else
        {
            anim.SetBool("IsIdle2", true);
            anim.SetBool("IsAttacking2", false);
            anim.SetBool("IsRunning2", false);
        }

    }
}
