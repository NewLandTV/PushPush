using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PopManager : MonoBehaviour
{
    [SerializeField]
    private GameObject cubePopButton;
    [SerializeField]
    private GameObject spherePopButton;

    [SerializeField]
    private Text cubePopCountText;
    [SerializeField]
    private Text spherePopCountText;

    [SerializeField]
    private PopSpawner popSpawner;

    private IEnumerator Start()
    {
        while (true)
        {
            cubePopCountText.text = string.Format("큐브 팝 개수 : {0:n0}", popSpawner.GetCubePopCount());
            spherePopCountText.text = string.Format("스피어 팝 개수 : {0:n0}", popSpawner.GetSpherePopCount());

            yield return null;
        }
    }

    public void OnCubePopButtonClick()
    {
        StartCoroutine(Pop(PopType.Cube));
    }

    public void OnSpherePopButtonClick()
    {
        StartCoroutine(Pop(PopType.Sphere));
    }

    private IEnumerator Pop(PopType popType)
    {
        int index = Random.Range(0, popSpawner.PopPooling.Count);

        switch (popType)
        {
            case PopType.Cube:
                if (popSpawner.PopPooling[index].PopType == popType && popSpawner.PopPooling[index].gameObject.activeSelf)
                {
                    popSpawner.PopPooling[index].FreePop();

                    cubePopButton.SetActive(false);
                }

                break;
            case PopType.Sphere:
                if (popSpawner.PopPooling[index].PopType == popType && popSpawner.PopPooling[index].gameObject.activeSelf)
                {
                    popSpawner.PopPooling[index].FreePop();

                    spherePopButton.SetActive(false);
                }

                break;
        }

        yield return new WaitForSeconds(5f);

        switch (popType)
        {
            case PopType.Cube:
                cubePopButton.SetActive(true);

                break;
            case PopType.Sphere:
                spherePopButton.SetActive(true);

                break;
        }
    }
}
