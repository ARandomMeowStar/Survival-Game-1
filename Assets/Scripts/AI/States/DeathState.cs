using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeathState : BaseState
{
    private float deathTimeAnim=3.2f;
    private float timer;

    private Animator animator;
    private MobStatsSO stats;
    public DeathState(MobStateMachine states, MobStatsSO statsSO)
    {
        stateMachine = states;
        animator = stateMachine.GetComponent<Animator>();
        stats = statsSO;
    }
    public override void Enter()
    {
        animator.SetTrigger("Death");
    }

    public override void Exit()
    {
        throw new System.NotImplementedException();
    }

    public override void LogicUpdate()
    {
        timer += Time.deltaTime;
        {
            if (timer>= deathTimeAnim)
            {
                for (int i=0; i<stats.Drop.Length;i++)
                {
                    for(int j=0;j<stats.DropCount[i]; j++)
                    {
                        MonoBehaviour.Instantiate(stats.Drop[i].ItemObject,
                        stateMachine.transform.position+stateMachine.transform.up,
                        Quaternion.identity);
                    }
                }
                MonoBehaviour.Destroy(stateMachine.gameObject);
            }
        }
    }
}
