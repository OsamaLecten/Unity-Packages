using UnityEngine;

namespace REO_Lecten_Package
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
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
        protected virtual void p_moveCharacterController(Vector2 direction, float speed, float deadZone = 0.2f)
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
}
