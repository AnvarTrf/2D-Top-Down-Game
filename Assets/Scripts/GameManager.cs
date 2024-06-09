// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class GameManager : MonoBehaviour
// {
//    void Start()
//     {
//         // Ensure GameManager persists between scenes (optional)
//         DontDestroyOnLoad(gameObject);

//         // Add event listeners for scene loading and unloading (optional)
//         // SceneManager.sceneLoaded += OnSceneLoaded;
//         // SceneManager.sceneUnloaded += OnSceneUnloaded;
//     }

//     // Access the total enemy count if needed
//     public int GetTotalEnemyCount()
//     {
//         int totalEnemies = 0;

//         // Option 1: Using Enemy script (if attached to enemy prefabs)
//         if (EnemyHealth.CountSubcategories(EnemyHealth.enemies.transform) > 0)
//         {
//             totalEnemies = EnemyHealth.CountSubcategories();
//         }

//         return totalEnemies;
//     }

// }
