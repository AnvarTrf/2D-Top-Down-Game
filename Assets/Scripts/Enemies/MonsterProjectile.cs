using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterProjectile : MonoBehaviour
{
    [SerializeField] private float duration = 1f;
    [SerializeField] private AnimationCurve animCurve;
    [SerializeField] private float heightY = 3f;
    [SerializeField] private GameObject monsterProjectileShadow;

    private void Start() {
        GameObject monsterShadow = 
        Instantiate(monsterProjectileShadow, transform.position + new Vector3(0, -0.3f, 0), Quaternion.identity);

        Vector3 playerPos = PlayerController.Instance.transform.position;
        Vector3 monsterShadowStartPosition = monsterShadow.transform.position;

        StartCoroutine(ProjectileCurveRoutine(transform.position, playerPos));
        StartCoroutine(MoveMonsterShadowRoutine(monsterShadow, monsterShadowStartPosition, playerPos));
    }

    private IEnumerator ProjectileCurveRoutine(Vector3 startPosition, Vector3 endPosition) {
        float timePassed = 0f;

        while (timePassed < duration)
        {
            timePassed += Time.deltaTime;
            float linearT = timePassed / duration;
            float heightT = animCurve.Evaluate(linearT);
            float height = Mathf.Lerp(0f, heightY, heightT);

            transform.position = Vector2.Lerp(startPosition, endPosition, linearT) + new Vector2(0f, height);

            yield return null;
        }

        Destroy(gameObject);
    }

    private IEnumerator MoveMonsterShadowRoutine(GameObject monsterShadow, Vector3 startPosition, Vector3 endPosition) {
        float timePassed = 0f;

        while (timePassed < duration) 
        {
            timePassed += Time.deltaTime;
            float linearT = timePassed / duration;
            monsterShadow.transform.position = Vector2.Lerp(startPosition, endPosition, linearT);
            yield return null;
        }

        Destroy(monsterShadow);
    }
}
