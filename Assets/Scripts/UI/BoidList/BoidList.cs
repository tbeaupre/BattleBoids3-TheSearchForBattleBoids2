using System.Collections.Generic;
using Manager;
using UnityEngine;

namespace UI.BoidList
{
    public class BoidList : MonoBehaviour
    {
        public GameObject boidListItemPrefab;
        
        public void Init(List<BoidAttributes> boids)
        {
            foreach (BoidAttributes boid in boids)
            {
                GameObject boidListItem = Instantiate(boidListItemPrefab);
                boidListItem.transform.SetParent(transform);
                boidListItem.GetComponent<BoidListItem>().Init(boid, BoidManager.NUM_BOIDS);
            }
        }
        
        private void Start()
        {
        }
    }
}