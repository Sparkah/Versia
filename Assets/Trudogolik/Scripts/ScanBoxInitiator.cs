using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Trudogolik
{
    public class ScanBoxInitiator : MonoBehaviour
    {
        [SerializeField] private GameObject scanBox;
        void Start()
        {
            StartCoroutine(ScanBoxInitiatorCoroutine());
        }

        IEnumerator ScanBoxInitiatorCoroutine()
        {
            yield return new WaitForSeconds(Random.Range(1, 6));
            Instantiate(scanBox, transform.position, Quaternion.identity);
            StartCoroutine(ScanBoxInitiatorCoroutine());
        }
    }
}