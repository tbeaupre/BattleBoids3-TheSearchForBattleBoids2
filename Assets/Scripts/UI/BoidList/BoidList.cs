using System.Collections.Generic;
using UnityEngine;

namespace UI.BoidList
{
    public class BoidList : MonoBehaviour
    {
        public GameObject boidListItemPrefab;
        
        public void Init(List<BoidAttributes> boids, float maxValue)
        {
            foreach (BoidAttributes boid in boids)
            {
                GameObject boidListItem = Instantiate(boidListItemPrefab);
                boidListItem.transform.SetParent(transform);
                boidListItem.GetComponent<BoidListItem>().Init(boid, maxValue);
            }
        }
        
        private void Start()
        {
            List<BoidAttributes> boids = new List<BoidAttributes>()
            {
                new BoidAttributes(1, 3, 5, 7, 9, 11, 13, 15, 17),
            };
            
            Init(boids, 20);
        }
    }
}