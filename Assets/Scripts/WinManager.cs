using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinManager : MonoBehaviour
{


    // //اضافی
    public GameObject enemies;

    //اضافی
    public void UpdateSubcategoryCount() {
         int subcategoryCount = CountSubcategories(enemies.transform);
        Debug.Log("Number of enemy subcategories: " + subcategoryCount);

        if (subcategoryCount == 1 ) {

            GameObject canvasObject = GameObject.Find("UICanvas");
            GameObject playerObject = GameObject.Find("Player");

            if (canvasObject != null )
                  {
                   Destroy(canvasObject);
                   Destroy(playerObject);
                  }
            SceneManager.LoadScene("final Scene");
        }
    }


public int CountSubcategories(Transform parent)
{
    int count = 0;

    // Find all GameObject child objects
    List<GameObject> childObjects = new List<GameObject>(GameObject.FindObjectsOfType<GameObject>(parent));

    // Check if there are any child objects
    if (childObjects.Count > 0)
    {
        foreach (GameObject child in childObjects)
        {
            if (child.transform.parent == parent)
            {
                count++;
            }
        }
    }

    return count;
}


}
