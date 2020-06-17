using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject lazer;
    private Coroutine co;
    private Renderer renderer;

    private void Start()
    {
        renderer = lazer.GetComponent<Renderer>();
        renderer.sharedMaterial.color = Color.blue;
    }
    
    /**
     * 銃が向いている方向にレイを飛ばす
     */
    private void ShutGun()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit_info = new RaycastHit ();
        float max_distance = 100f;

        bool is_hit = Physics.Raycast (ray, out hit_info, max_distance);

        if (is_hit)
        {
            Debug.Log(hit_info.transform.name);
            Destroy(hit_info.transform.gameObject);
        }
    }

    private void changeLazerColor()
    {
        if (co != null)
            StopCoroutine(co); //色を戻す処理をキャンセル
        renderer.material.color = Color.red;
        co = StartCoroutine(ToBlueColor()); //撃った0.2秒後に色を戻す
    }

    public void OnShut()
    {
        changeLazerColor();
        ShutGun();
    }

    /**
     * 撃った0.2秒後に色を戻す
     */
    IEnumerator ToBlueColor()
    {
        yield return new WaitForSeconds(0.2f);
        renderer.material.color = Color.blue;
    }
}
