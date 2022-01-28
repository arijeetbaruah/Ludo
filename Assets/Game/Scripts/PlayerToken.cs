using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class PlayerToken : MonoBehaviour
{
    public int position = -1;

    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public Sequence MoveToPosition(Vector3[] points)
    {
        var sequence = DOTween.Sequence();

        foreach (var pos in points)
        {
            sequence.Append(rectTransform.DOMove(pos, 1));
        }

        return sequence.Play();
    }
}
