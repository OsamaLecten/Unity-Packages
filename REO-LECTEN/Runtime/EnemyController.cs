using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

namespace REO_Lecten_Package
{
    /// <summary>
    ///     REO: You should probably inherit from this class to use it
    /// </summary>
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyController : MonoBehaviour
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

}
