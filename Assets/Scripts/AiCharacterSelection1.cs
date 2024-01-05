using UnityEngine;
using UnityEngine.SceneManagement;

public class AiCharacterSelection1 : MonoBehaviour
{
	public GameObject[] Aicharacters;
	public int AiselectedCharacter = 0;

	public void NextCharacter()
	{
		Aicharacters[AiselectedCharacter].SetActive(false);
		AiselectedCharacter = (AiselectedCharacter + 1) % Aicharacters.Length;
		Aicharacters[AiselectedCharacter].SetActive(true);
	}

	public void PreviousCharacter()
	{
		Aicharacters[AiselectedCharacter].SetActive(false);
		AiselectedCharacter--;
		if (AiselectedCharacter < 0)
		{
			AiselectedCharacter += Aicharacters.Length;
		}
		Aicharacters[AiselectedCharacter].SetActive(true);
	}

	public void StartGame()
	{
		PlayerPrefs.SetInt("AiselectedCharacter", AiselectedCharacter);

		 SceneManager.LoadScene(2, LoadSceneMode.Single);
	}
}
