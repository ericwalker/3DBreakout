using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropScript : MonoBehaviour {


	[System.Serializable] // make the class being visible in the Inspector
	public class DropItem
	{
		public string name;
		public GameObject powerupItem;
		public int dropRarity;
	}

	public List<DropItem> PowerupItemTable = new List<DropItem> ();
	public int dropChance; // the drop probability of all of the items
	private Vector3 brickPos; // position to drop the powerUp and powerDown

	public void CalculateItem(Vector3 brickPos){
		int calc_dropChance = Random.Range (0, 101);
		if (calc_dropChance > dropChance) {
//			Debug.Log ("No item is dropping QQ");
			return;
		}

		if (calc_dropChance <= dropChance){
			int itemWeight = 0; // dropRarity

			for (int i = 0; i < PowerupItemTable.Count; i++) {
				itemWeight += PowerupItemTable [i].dropRarity; // sum of the itemWeight
			}
//			Debug.Log ("ItemWeight: " + itemWeight); // 48 = 8+10+30
			int randomValue = Random.Range (0, itemWeight); // 30

			// judge to instantiate which powerup item
			for (int j=0; j< itemWeight; j++){
				if(randomValue <= PowerupItemTable[j].dropRarity){
					Instantiate (PowerupItemTable[j].powerupItem,brickPos+PowerupItemTable[j].powerupItem.gameObject.transform.position,Quaternion.Euler(0, 0, 90));

					return;
				}

				randomValue -= PowerupItemTable [j].dropRarity;
//				Debug.Log ("randomValue decreased " + randomValue);
				
			}
		}
	}

}
