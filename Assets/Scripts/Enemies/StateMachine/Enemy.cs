using UnityEngine;
using Powerfish.CoreSystem;

namespace Powerfish.Enemy
{
    public class Enemy : MonoBehaviour
    {
        public Core core { get; private set; }
        public Animator anim { get; private set; }
        public Rigidbody2D rb { get; private set; }


        public EnemyIdleState idleState { get; private set; }
        public EnemyChaseState chaseState { get; private set; }

        public EnemyStateMachine stateMachine { get; private set; }
        [SerializeField] private EnemyData enemyData;

        public Transform playerTransform { get; private set; }

        private void Awake()
        {
            core = GetComponentInChildren<Core>();

            stateMachine = new EnemyStateMachine();

            idleState = new EnemyIdleState(this, stateMachine, enemyData, "idle");
            chaseState = new EnemyChaseState(this, stateMachine, enemyData, "chase");

            playerTransform = GameObject.FindWithTag("Player").transform;
        }

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();

            stateMachine.Initialize(idleState);
        }

        private void Update()
        {
            core.LogicUpdate();
            stateMachine.CurrentState.LogicUpdate();
        }

        private void FixedUpdate()
        {
            stateMachine.CurrentState.PhysicsUpdate();
        }

        public virtual bool CheckIsPlayerNearby()
        {
            return Physics2D.OverlapCircle(transform.position, enemyData.playerDetectDistance, enemyData.whatIsPlayer);
        }

        public virtual Vector2 CheckWhichDirectionIsPlayer() 
        {
            return (playerTransform.position - transform.position).normalized;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, enemyData.playerDetectDistance);
        }

    }
}
