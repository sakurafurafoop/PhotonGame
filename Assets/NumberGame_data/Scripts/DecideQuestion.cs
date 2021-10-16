using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NumberGame
{
    public class DecideQuestion : MonoBehaviour
    {
        int nowQuestionNum;

        int Decide()
        {
            nowQuestionNum = Random.Range(10, 16);
            return nowQuestionNum;
        }
    }
}

