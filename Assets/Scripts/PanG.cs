using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanG : MonoBehaviour
{
    public RectTransform testePan ;
    public Button droite , gauche ;
    // Start is called before the first frame update
    [SerializeField]
    private float speed;

    public int[] index ;

    int i = 0 ;
    
    void Start()
    {
        droite.onClick.AddListener(DroiteClick);
        gauche.onClick.AddListener(GaucheClick);
    }

    // Update is called once per frame
    void Update()
    {
        if (i >= 0 && i < index.Length)
    {
        testePan.anchoredPosition = Vector2.MoveTowards(testePan.anchoredPosition, new Vector2(index[i], testePan.anchoredPosition.y),speed * Time.deltaTime);
    }
    }
    void DroiteClick()
    {
    i +=1;
    }
    void GaucheClick()
    {
      i -=1 ;
    }
}
