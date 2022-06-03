
namespace REO_Lecten_Package
{
    public abstract class State
    {
        public StateManager StateManager;
        protected State(StateManager stateManager)
        {
            this.StateManager = stateManager;
        }
        public abstract void EnterState();
        public abstract void UpdateState();
        public abstract void ExitState();
    }

    public class StateManager
    {
        public State CurrentState;
        public BaseCharacterController Controller;

        public StateManager(BaseCharacterController controller)
        {
            Controller = controller;
        }

        public virtual void SwitchState(State state)
        {
            CurrentState?.ExitState();
            CurrentState = state;
            state.EnterState();
        }
    }
    public interface IStateMachine
    {
        /// <summary>
        /// Declare an object for each state outside then initialize each inside the function, then call the function inside Awake()
        /// <code>
        /// private Idle_State idleState;
        /// private Running_State running_State;
        /// private Capturing_State capturing_State;
        /// public void InstantiateStateObjects()
        /// {
        ///     idleState = new Idle_State(StateManager);
        ///     running_State = new Running_State(StateManager);
        ///     capturing_State = new Capturing_State(StateManager);
        /// }
        /// </code>
        /// </summary>
        void InstantiateStateObjects();
        /// <summary>
        /// Declare outside then initialize inside the function, then call this function in the Awake()
        /// <code>
        /// private PloicemanStateManager StateManager;
        /// public void InstantiateSingleStateManagerObject()
        /// {
        ///     StateManager = new PloicemanStateManager();
        /// }
        /// </code>
        /// </summary>
        void InstantiateSingleStateManagerObject();
        /// <summary>
        /// Call this function in the start function of the MonoBehaviour
        /// Here you should probably add something like
        /// <code> StateManager.SwitchState(idleState); </code>
        /// </summary>
        void RunInitialStateOnStart();
        /// <summary>
        /// Run this function in the update function of the MonoBehaviour
        /// Here you should probably add something like
        /// <code> StateManager.CurrentState.UpdateState(); </code>
        /// </summary>
        void UpdateCurrentStateOnUpdate();
    }
}
