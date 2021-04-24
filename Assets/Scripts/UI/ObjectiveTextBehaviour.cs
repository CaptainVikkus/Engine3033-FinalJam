using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectiveTextBehaviour : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI objective;
    [SerializeField] float displaySeconds = 20f;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        objective.color = Color.Lerp(objective.color, Color.clear, timer / displaySeconds);

        if (timer >= displaySeconds)
            Destroy(gameObject);
    }
}
