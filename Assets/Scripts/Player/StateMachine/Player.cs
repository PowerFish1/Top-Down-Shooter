using UnityEngine;
using Powerfish.CoreSystem;
using Powerfish.WeaponSystem;

namespace Powerfish.Player
{

    public class Player : MonoBehaviour
    {
        public PlayerStateMachine stateMachine { get; private set; }
        public PlayerMoveState moveState { get; private set; }
        public PlayerIdleState idleState { get; private set; }
        [SerializeField] private PlayerData playerData;


        public Rigidbody2D rb { get; private set; }
        public Animator anim { get; private set; }

        public Core core { get; private set; }
        public PlayerInputHandler inputHandler { get; private set; }
        private Weapon weapon;

        private void Awake()
        {
            core = GetComponentInChildren<Core>();
            weapon = transform.Find("Weapon").GetComponent<Weapon>();
            
            weapon.SetCore(core);

            stateMachine = new PlayerStateMachine();

            idleState = new PlayerIdleState(this, stateMachine, playerData, "idle");
            moveState = new PlayerMoveState(this, stateMachine, playerData, "move");
        }
        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            inputHandler = GetComponent<PlayerInputHandler>();

            stateMachine.Initialize(idleState);
        }

        private void Update()
        {
            core.LogicUpdate();
            stateMachine.CurrentState.LogicUpdate();
        }

        private void FixedUpdate()
        {
            stateMachine.CurrentState.PyhsicsUpdate();
        }

        private void AnimationTrigger()
        {
            stateMachine.CurrentState.AnimationTrigger();
        }

        private void AnimationFinishTrigger()
        {
            stateMachine.CurrentState.AnimationFinishTrigger();
        }

    }
}