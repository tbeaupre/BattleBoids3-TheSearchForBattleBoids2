using System;
using System.Collections.Generic;
using Manager;
using UI.BoidList;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
	public class BreedScreen : MonoBehaviour
	{
		public Text topBarText;
		public Text forwardButtonText;
		private int currentStage = 0;

		private List<BoidListItem> full = new List<BoidListItem>();
		private List<BoidListItem> save;

		private void Start()
		{
			UpdateList();
		}

		private void UpdateList()
		{
			switch (currentStage)
			{
				case 0 : 
					// Stables
					topBarText.text = "Boid Stables";
					forwardButtonText.text = "Begin Breeding";
					if (full.Count == 0)
					{
						gameObject.GetComponentInChildren<BoidList.BoidList>().Init(BoidManager.GetCurrentBoids());
						full = new List<BoidListItem>(gameObject.GetComponentsInChildren<BoidListItem>());
					}
					foreach (BoidListItem item in full) {
						item.gameObject.SetActive(true);
						Toggle toggle = item.GetComponentInChildren<Toggle>();
						toggle.interactable = false;
						toggle.isOn = false;
					}
					Debug.Log(full.Count);
					Debug.Log(BoidManager.GetCurrentBoids().Count);
					break;
				case 1 : 
					// Select Boids to Save
					topBarText.text = "Select Boids to Save";
					forwardButtonText.text = "Next";
					foreach (BoidListItem item in full) {
						item.gameObject.SetActive(true);
						item.GetComponentInChildren<Toggle>().interactable = true;
					}
					save = null;
					break;
				case 2 : 
					// Select Boids to Breed
					topBarText.text = "Select Boids to Breed";
					forwardButtonText.text = "Breed";
					if (save == null)
					{
						save = new List<BoidListItem>();
						foreach (var item in full)
						{
							if (item.GetComponentInChildren<Toggle>().isOn)
							{
								save.Add(item);
								item.gameObject.SetActive(false);
							}
						}
					}
					else
					{
						foreach (BoidListItem item in full) {
							if (!save.Contains(item))
							item.gameObject.SetActive(false);
						}
					}
					break;
				case 3 :
					// Repopulate List
					List<BoidAttributes> breed = new List<BoidAttributes>();
					int toReplace = 0;
					
					foreach (BoidListItem item in full)
					{
						if (item.gameObject.activeSelf)
						{
							if (item.GetComponentInChildren<Toggle>().isOn)
							{
								breed.Add(item.attributes);
							}
							else
							{
								BoidManager.RemoveBoid(item.attributes);
								DestroyImmediate(item);
								toReplace++;
							}
						}
					}

					// Generate new boids and add them to flock.
					List<BoidAttributes> newBoids = Breeding.BreedPlayerBoids(breed, toReplace);
					BoidManager.AddBoids(newBoids);
					Debug.Log(full.Count);
					Debug.Log(newBoids.Count);
					
					// Reset the Breeding Screen at the Stables
					full.Clear();
					save = null;
					currentStage = 0;
					UpdateList();
					break;
			}
		}

		public void Forward()
		{
			currentStage++;
			UpdateList();
		}

		public void Back()
		{
			currentStage--;
			if (currentStage < 0)
			{
				SceneManager.LoadScene("main");
			}
			else
			{
				UpdateList();
			}
		}
	}
}
