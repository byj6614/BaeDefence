using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "HomeData", menuName = "Data/HTower")]//Create�� �� �� ���ο� ����� �����.
public class HTowerData : ScriptableObject//ScriptableObject�� �־� �����͸� ���� ����
{
    [SerializeField] HTowerInfo[] towers;//�迭�� �������� ������ �޴´�.

    public HTowerInfo[] Towers { get { return towers; } }//private���̹Ƿ� �ۿ��� �ٲٴ� ��� get�� ����Ѵ�.

    [Serializable]
    public class HTowerInfo//������ �����Ѵ�.
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
