using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class Board : MonoBehaviour
{
    [System.Serializable]
    public class SpawnPoints
    {
        public RectTransform spawn1;
        public RectTransform spawn2;
        public RectTransform spawn3;
        public RectTransform spawn4;
    }

    [SerializeField] private RectTransform[] redPath;
    [SerializeField] private PlayerToken redTokenPrefab;

    [SerializeField] private SpawnPoints redSpawnPoint;

    private PlayerToken[] redTokens;
    public int tokenPos = -1;

    private void Start()
    {
        redTokens = new PlayerToken[4];

        for(int i = 0; i < 4; i++)
        {
            redTokens[i] = Instantiate(redTokenPrefab, transform);
            redTokens[i].GetComponent<RectTransform>().position = redSpawnPoint.spawn1.position;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int die = Random.Range(1, 6);

            List<Vector3> points = new List<Vector3>();
            for (int i = redTokens[0].position == -1 ? 0 : redTokens[0].position; i < redTokens[0].position + die; i++)
            {
                points.Add(redPath[i].position);
            }
            redTokens[0].position += die;
            redTokens[0].MoveToPosition(points.ToArray());
            //redTokens[0].MoveToPosition = redPath[redTokens[0].position].position;
        }
    }
}
