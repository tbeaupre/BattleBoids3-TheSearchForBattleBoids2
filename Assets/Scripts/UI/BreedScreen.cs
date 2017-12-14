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

		private List<BoidListItem> full;
		private List<BoidListItem> save;
		private List<BoidAttributes> breed;

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
					if (full == null)
					{
						full = new List<BoidListItem>(gameObject.GetComponentsInChildren<BoidListItem>());
					}
					else
					{
						foreach (BoidListItem item in full) {
							item.GetComponentInChildren<Toggle>().interactable = false;
						}
					}
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
						save = new List<BoidListItem>(full);
						foreach (var item in full)
						{
							if (!item.GetComponentInChildren<Toggle>().isOn)
							{
								save.Remove(item);
							}
							else
							{
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
					breed = new List<BoidAttributes>();
					int toReplace = 0;
					
					foreach (BoidListItem item in full)
					{
						if (item.gameObject.activeSelf && !item.GetComponentInChildren<Toggle>())
						{
							BoidManager.RemoveBoid(item.attributes);
							toReplace++;
						}
						else
						{
							breed.Add(item.attributes);
						}
					}

					// Generate new boids and add them to flock.
					List<BoidAttributes> newBoids = Breeding.BreedPlayerBoids(breed, toReplace);
					BoidManager.AddBoids(newBoids);
					gameObject.GetComponentInChildren<BoidList.BoidList>().Init(newBoids);
					
					// Reset the Breeding Screen at the Stables
					full = null;
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
