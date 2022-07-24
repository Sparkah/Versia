using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pigeon
{
    public class SphereCaster
    {
        private const int k_countToFind = 10;

        public void CastSphere(Vector3 pos, float radius, LayerMask layer)
        {
            Ray ray = new Ray(pos, pos);
            RaycastHit[] hits = new RaycastHit[k_countToFind];
            if (Physics.SphereCastNonAlloc(ray, radius, hits, radius, layer) > 0)
            {
                foreach (RaycastHit hit in hits)
                {
                    if (hit.transform != null && hit.transform.TryGetComponent(out PigeonController controller))
                    {
                        try
                        {
                            controller.ScarePigeon();
                        }
                        catch
                        {
#if (UNITY_EDITOR)
                        Debug.Log("SphereCast script cs 21");
#endif
                        }
                    }
                }
            }
        }
    }
}