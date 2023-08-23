using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    public class TopDownCharacterController : MonoBehaviour
    {
        public float speed;

        private void Update()
        {
            
            Vector2 dir = new Vector2(Input.GetAxis("Horizontal"), 
                Input.GetAxis("Vertical"));

            GetComponent<Rigidbody2D>().velocity = speed * dir;
        }
    }
}
