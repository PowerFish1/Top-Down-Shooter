using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Powerfish.Enemy
{
    public class EnemyPatrolState : EnemyState
    {
        public EnemyPatrolState(Enemy enemy, EnemyStateMachine stateMachine, EnemyData enemyData, string animBoolName) : base(enemy, stateMachine, enemyData, animBoolName)
        {
        }
    }
}
