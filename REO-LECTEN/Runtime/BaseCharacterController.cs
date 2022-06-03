using UnityEngine;
using UnityEngine.AI;


namespace REO_Lecten_Package
{
    #region MonoBehaviour

    [RequireComponent(typeof(CharacterController))]
    public class BaseCharacterController : MonoBehaviour
    {

    }

    #endregion

    #region Controllers

    public class PlayerController : BaseCharacterController
    {
        #region Events

        public delegate void PlayerVoidEvents();

        public static event PlayerVoidEvents OnIsMoving;
        public static event PlayerVoidEvents OnPlayerDied;

        #endregion

        #region Vars
        protected CharacterController p_characterController;
        #endregion

        #region Built In
        protected virtual void Awake()
        {
            p_characterController = GetComponent<CharacterController>();
        }
        #endregion

        #region Functions
        /// <summary>
        /// Run repeatedly (in Update) to walk or run
        /// </summary>
        /// <param name="direction"> A vector of length 1</param>
        /// <param name="speed"> Movement speed</param>
        /// <param name="deadZone"> Input that will be ignored (Optional) </param>
        public virtual void p_moveCharacterController(Vector2 direction, float speed, float deadZone = 0.2f)
        {
            // Call in Update
            Vector3 movementDirection;
            if (direction.magnitude > deadZone)
            {
                movementDirection = new Vector3(direction.x, 0, direction.y);

                #region Event

                if (OnIsMoving != null) OnIsMoving();

                #endregion
            }
            else
            {
                movementDirection = Vector3.zero;
            }

            p_characterController.Move(movementDirection * speed * Time.deltaTime);
        }
        #endregion

    }

    public class EnemyController : BaseCharacterController
    {
        #region Vars
        protected NavMeshAgent p_NavMeshAgent;

        #endregion

        #region Built In

        protected virtual void Awake()
        {
            p_NavMeshAgent = GetComponent<NavMeshAgent>();
        }

        #endregion

        #region Navmesh Agent

        protected virtual void p_EnableNavMeshAgent()
        {
            if (p_NavMeshAgent) p_NavMeshAgent.enabled = true;
            p_NavMeshAgent.enabled = true;
        }
        protected virtual void p_DisableNavMeshAgent()
        {
            if (p_NavMeshAgent) p_NavMeshAgent.enabled = false;
        }
        protected virtual void p_StartNavMeshAgent(bool alsoEnableAgent = true)
        {
            if (alsoEnableAgent) p_EnableNavMeshAgent();
            if (p_NavMeshAgent) p_NavMeshAgent.isStopped = false;
        }
        protected virtual void p_StopNavMeshAgent(bool alsoDisableAgent = false)
        {
            if (p_NavMeshAgent) p_NavMeshAgent.isStopped = true;
            if (alsoDisableAgent) p_DisableNavMeshAgent();
        }
        protected virtual void p_SetNavMeshAgentSpeed(float speed)
        {
            if (p_NavMeshAgent) p_NavMeshAgent.speed = speed;
            p_NavMeshAgent?.Move(Vector3.zero);
        }
        protected virtual void p_SetNavMeshAgentDestination(Transform destination, bool alsoEnableNavMeshAgent = false)
        {
            if (alsoEnableNavMeshAgent) p_EnableNavMeshAgent();

            p_NavMeshAgent.destination = destination.position;
        }

        #endregion
    }

    #endregion

    #region Interfaces

    public interface IJoystickInputControllable
    {
        // todo: make use of this interface
    }
    public interface INavmeshControllable
    {
        // todo: make use of this interface
    }

    #endregion
}
