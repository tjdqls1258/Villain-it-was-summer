using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Cam_Shacking : MonoBehaviour
{
    public GameObject cam;
    public GameObject CamParent;
    public PostProcessVolume post;
    // Start is called before the first frame update
    void OnEnable()
    {
        post = CamParent.GetComponent<PostProcessVolume>();
        StartCoroutine(CameraShake(0.1f, 0.01f));
        StartCoroutine(ChagePost(0.1f));
    }

    public IEnumerator CameraShake(float durtion, float magnitude)
    {
        float timer = 0;
        Vector3 cam_originapos = cam.transform.position;
        while (timer<= durtion)
        {
            cam.transform.localPosition = Random.insideUnitCircle * magnitude * cam_originapos;
            cam.transform.localPosition = new Vector3(cam.transform.localPosition.x, cam.transform.localPosition.y, -10);
            timer += Time.deltaTime;
            yield return null;
        }
        cam.transform.localPosition = new Vector3(0, 0, -10);
    }
    public IEnumerator ChagePost(float durtion)
    {
        post.profile.GetSetting<Vignette>().color.value = Color.red;
        yield return new WaitForSeconds(durtion);
        post.profile.GetSetting<Vignette>().color.value = Color.white;
    }
}
