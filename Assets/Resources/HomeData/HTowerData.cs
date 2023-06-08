using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "HomeData", menuName = "Data/HTower")]//Create를 할 시 새로운 목록이 생긴다.
public class HTowerData : ScriptableObject//ScriptableObject를 주어 데이터를 생성 가능
{
    [SerializeField] HTowerInfo[] towers;//배열로 여러개의 정보를 받는다.

    public HTowerInfo[] Towers { get { return towers; } }//private형이므로 밖에서 바꾸는 방법 get을 사용한다.

    [Serializable]
    public class HTowerInfo//정보를 저장한다.
    {
        public HTowerData Tower;

        public int damage;
        public float range;
        public int delay;
        public float buildTime;
        public int buildCost;
        public int sellCost;
    }
}
