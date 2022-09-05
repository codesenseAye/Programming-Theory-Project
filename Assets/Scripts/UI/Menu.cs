using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Menu : MonoBehaviour
{
    public GameObject[] planes;
    public static GameObject playB;

    public static void Restart()
    {
        GameObject menu = GameObject.Find("Menu");
        GameObject title = menu.transform.Find("Title").gameObject;
        title.GetComponent<Animator>().SetBool("MenuState", true);

        title.GetComponent<TMP_Text>().text = "PLANE GAME";
        playB.SetActive(true);
    }

    public void DoStart()
    {
        GameObject plane = DoPickPlane();
        GameObject title = transform.Find("Title").gameObject;

        TMP_Text c_text = title.GetComponent<TMP_Text>();
        c_text.text = plane.name.Substring(0, plane.name.Length - 7);

        title.GetComponent<Animator>().SetBool("MenuState", false);

        if (playB == null)
        {
            playB = transform.Find("Play").gameObject;
        }

        playB.SetActive(false);

        CameraController cam = GameObject.Find("Main Camera").GetComponent<CameraController>();

        cam.plane = plane;
    }

    private GameObject DoPickPlane()
    {
        int planeNum = Random.Range(0, planes.Length);
        GameObject plane = Instantiate(planes[planeNum]);

        plane.transform.SetParent(null);
        return plane;
    }
}
