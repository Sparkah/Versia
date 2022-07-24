using UnityEngine;

namespace Veterok.Views
{
    public class PuddleView : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Packet"))
            {
                var packet = collision.gameObject.GetComponent<PacketView>();
                Interaction(packet);
            }
        }


        private void Interaction(PacketView packet)
        {
            if (packet.IsDead) return;
            packet.Die(transform.position);
        }
    }
}