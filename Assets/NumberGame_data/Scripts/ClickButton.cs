using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace NumberGame
{
    public class ClickButton : MonoBehaviour
    {
        [SerializeField] int buttonNum;
        private Button button;

        private bool isClick;

        private void Awake()
        {
            button.onClick.AddListener(GetNum);
        }


        void GetNum()
        {
            if (isClick)
            {
                isClick = false;

                StartCoroutine(IsPushTimer());
            }
            
        }

        private IEnumerator IsPushTimer()
        {
            yield return new WaitForSeconds(5f);
            isClick = true;
        }
    }

}
