using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ill : MonoBehaviour
{
    CanvasRenderer ren;

    [SerializeField]
    int _hp = 100;
    [SerializeField]
    float maxhp = 100;

    float maxhphalf;

    Vector3 pos1,pos2,pos;

    Color col = Color.white;

    RectTransform rectt;

    void CalculateColor(ref Color color, int hp)
    {
        if (hp >= maxhphalf)
        {
            color.r = Mathf.Lerp(1, 0, (hp - maxhphalf) / maxhphalf);
        }

        if (hp <= maxhphalf)
        {
            color.g = Mathf.Lerp(0, 1, hp / maxhphalf);
        }
    }

    void CalculatePos(int hp)
    {
        pos.y = Mathf.Lerp(pos2.y, pos1.y, hp / maxhp);
        rectt.position = pos;
    }

    void Awake()
    {
        rectt = GetComponent<RectTransform>();
        ren = GetComponent<CanvasRenderer>();
        maxhphalf = maxhp / 2;
        col.a = 1;
        col.r = Mathf.Lerp(1, 0, (_hp - maxhphalf) / maxhphalf);
        col.g = Mathf.Lerp(0, 1, _hp / maxhphalf);
        col.b = 0;
        pos1 = rectt.position;
        pos2 = rectt.position;
        pos2.y -= rectt.rect.height;
        pos = pos1;
    }

    void Update()
    {
        CalculatePos(_hp);
        CalculateColor(ref col, _hp);
        ren.SetColor(col);
    }


}
/*

체력 변화에 따라 체워지는건 z-depth이용하면 되나

*/

/*
Lerp가 시작상태와 끝 상태가 있을때, 시작상태로부터 어느정도 떨어졌는지를 주면, 그 지점의 값을 주는거니까
일일히 지정해주기 어려운 이런곳에서 잘 쓰일거같은데

        //col = Color.Lerp(Color.green, Color.red, hp / maxhp); // 두 값이 동시에 움직여서, 중간에 체도가 낮아지는 문제 있음

//Lerp쓰면 깔끔하게 처리 가능할거같은데





--------------

100~50까지는 r이
50~0까지는 g가 움직여야 한다


t의 범위는 0~1이다
이때, 저 t는 최대 체력의 절반으로 나눠야 한다
왜냐하면, t=1 또는 0일때는 양 끝값이 있는거고, 우측 끝값으로 나눈다면, 우측 끝값과 같을떄 1이 나오고, 그보다 낮을떄는 1보다 낮게 나오기 때문(n~우측끝값 사이의 값중 하나가 되기 때문)
그리고, 최대 범위는 최대 체력의 절반이기 때문에, /2를 해준 값으로 나누는거다




*/