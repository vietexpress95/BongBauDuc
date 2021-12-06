using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BongBauDuc_Fish : MonoBehaviour
{
    public Transform startPoint;
    public FishDirection direction;

    private void Start()
    {
        if(direction == FishDirection.up)
        {
            transform.position = startPoint.position + 3 * Vector3.forward;
            transform.eulerAngles = new Vector3(-90, 0, 0);
        }
        else if(direction == FishDirection.right)
        {
            transform.position = startPoint.position + 3 * Vector3.right;
            transform.eulerAngles = new Vector3(-90, 90, 0);
        }
        else
        {
            transform.position = startPoint.position + 3 * Vector3.left;
            transform.eulerAngles = new Vector3(-90, 90, 0);
        }

        StartCoroutine(Run());
    }

    private IEnumerator Run()
    {
        transform.DOMove(startPoint.position, 0.3f);
        yield return new WaitForSeconds(1);
        if(direction == FishDirection.up)
        {
            transform.DOMove(startPoint.position + 15 * Vector3.back , BongBauDuc_GameManager.ins.fishSpeed);
        }
        else if(direction == FishDirection.right)
        {
            transform.DOMove(startPoint.position + 15 * Vector3.left , BongBauDuc_GameManager.ins.fishSpeed);
        }
        else
        {
            transform.DOMove(startPoint.position + 15 * Vector3.right , BongBauDuc_GameManager.ins.fishSpeed);
        }
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}

public enum FishDirection{
    right, up, left
}
