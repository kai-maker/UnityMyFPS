using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Gun gun;
    GameObject hit_target;
    private Coroutine co;

    void Start()
    {
        co = StartCoroutine(EnemyShutCoroutine());
    }

    /**
     * 一秒ごとに撃つ
     */
    IEnumerator EnemyShutCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            gun.OnShut();
        }
    }

    private void OnDestroy()
    {
        StopCoroutine(co);
    }
}
