using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class AiLoadCharacter : MonoBehaviour
{
	public GameObject[] characterPrefabs;
	public Transform spawnPoint;
	 

	void Start()
	{
		int AiselectedCharacter = PlayerPrefs.GetInt("AiselectedCharacter");
		GameObject prefab = characterPrefabs[AiselectedCharacter];
		GameObject clone = Instantiate(prefab, spawnPoint.position, Quaternion.AngleAxis(180, transform.up));
		 
	}
}
