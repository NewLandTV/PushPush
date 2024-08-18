using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] pops;
    [SerializeField]
    private Transform popParent;
    private List<Pop> popPooling = new List<Pop>();

    public List<Pop> PopPooling => popPooling;

    private void Awake()
    {
        for (int i = 0; i < 100; i++)
        {
            CreatePop((PopType)Random.Range(0, pops.Length));
        }

        StartCoroutine(SetActiveToAllWaitTime(0.1f));
    }

    public Pop CreatePop(PopType popType)
    {
        GameObject instance = Instantiate(pops[(int)popType], new Vector3(Random.Range(-11f, 11f), 0f, Random.Range(-11f, 11f)), Quaternion.identity, popParent);

        Pop instancePopComponent = instance.GetComponent<Pop>();

        popPooling.Add(instancePopComponent);

        return instancePopComponent;
    }

    public IEnumerator SetActiveToAllWaitTime(float waitTime)
    {
        for (int i = popPooling.Count - 1; i >= 0; i--)
        {
            popPooling[i].gameObject.SetActive(true);

            yield return new WaitForSeconds(waitTime);
        }
    }

    public int GetCubePopCount()
    {
        int count = 0;

        for (int i = popPooling.Count - 1; i >= 0; i--)
        {
            if (popPooling[i].gameObject.activeSelf && popPooling[i].PopType == PopType.Cube)
            {
                count++;
            }
        }

        return count;
    }

    public int GetSpherePopCount()
    {
        int count = 0;

        for (int i = popPooling.Count - 1; i >= 0; i--)
        {
            if (popPooling[i].gameObject.activeSelf && popPooling[i].PopType == PopType.Sphere)
            {
                count++;
            }
        }

        return count;
    }
}
