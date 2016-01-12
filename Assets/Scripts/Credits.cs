using UnityEngine;
using System.Collections;

// This is the credits.  They stop moving once they are done.
// They take you back to the main menu.
public class Credits : MonoBehaviour
{
	public GameObject credits;

	public float speed;

	public string mainMenu;

	private bool crawling = true;

	
	// Update is called once per frame
	void Update()
	{
		if (!crawling)
		{
			return;
		}

		credits.transform.Translate (Vector3.up * speed);

		if (GameObject.Find("Middle").GetComponent<RectTransform>().localPosition.y > 6775)
		{
			crawling = false;
			StartCoroutine(LoadMenu());
		}
	}

	IEnumerator LoadMenu()
	{
		yield return new WaitForSeconds(2);
		Destroy(GameObject.FindGameObjectWithTag("Music"));
		Application.LoadLevel(mainMenu);
	}
}
