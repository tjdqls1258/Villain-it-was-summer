using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Cam_Shacking : MonoBehaviour
{
    public GameObject cam;
    public GameObject CamParent;
    public PostProcessVolume post;
    public bool IsRun, IsRed;

// Start is called before the first frame update
    private void Awake()
    {
        post = CamParent.GetComponent<PostProcessVolume>();
        IsRun = false;
        IsRed = false;
    }
    void OnEnable()
    {
        cam.transform.localPosition = new Vector3(0, 0, -10);
        post.profile.GetSetting<Vignette>().color.value = Color.white;
    }

    public IEnumerator CameraShake(float durtion, float magnitude , float Delay)
    {
        if (!IsRun)
        {
            IsRun = true;
            float timer = 0;
            Vector3 cam_originapos = cam.transform.position;
            while (timer <= durtion)
            {
                cam.transform.localPosition = Random.insideUnitCircle * magnitude * cam_originapos;
                cam.transform.localPosition = new Vector3(cam.transform.localPosition.x, cam.transform.localPosition.y, -10);
                timer += Time.deltaTime;
                yield return null;
            }
            cam.transform.localPosition = new Vector3(0, 0, -10);
            yield return new WaitForSeconds(Delay - durtion);
            IsRun = false;
        }
    }
    public IEnumerator ChagePost(float durtion, float Delay)
    {
        if (!IsRed)
        {
            IsRun = true;
            post.profile.GetSetting<Vignette>().color.value = Color.red;
            yield return new WaitForSeconds(durtion);
            post.profile.GetSetting<Vignette>().color.value = Color.white;
            yield return new WaitForSeconds(Delay- durtion);
            IsRed = false;
        }
    }
}
