using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int startingHealth = 3;
    [SerializeField] private GameObject deathVFXPrefab;
    [SerializeField] private float knockBackThrust = 15f;
//اضافی
    // public GameObject enemies;
    


    private int currentHealth;
    private Knockback knockback;
    private Flash flash;

    private void Awake() {
        flash = GetComponent<Flash>();
        knockback = GetComponent<Knockback>();
    }

    private void Start() {
        currentHealth = startingHealth;

    }

//اضافی
    // private void Update() {
    //      int subcategoryCount = CountSubcategories(enemies.transform);
    //     Debug.Log("Number of enemy subcategories: " + subcategoryCount);
    // }

    public void TakeDamage(int damage) {
        currentHealth -= damage;
        knockback.GetKnockedBack(PlayerController.Instance.transform, knockBackThrust);
        StartCoroutine(flash.FlashRoutine());
        StartCoroutine(CheckDetectDeathRoutine());
    }

    private IEnumerator CheckDetectDeathRoutine() {
        yield return new WaitForSeconds(flash.GetRestoreMatTime());
        DetectDeath();
    }

    public void DetectDeath() {
        if (currentHealth <= 0) {
            Instantiate(deathVFXPrefab, transform.position, Quaternion.identity);
            GetComponent<PickUpSpawner>().DropItems();
            Destroy(gameObject);
        }
    }


//اضافی
    // public int CountSubcategories(Transform parent)
    // {
    //     int count = 0;

    //     // Iterate through all child transforms
    //     foreach (Transform child in parent)
    //     {
    //         count++;
    //     }

    //     return count;
    // }

    
}
