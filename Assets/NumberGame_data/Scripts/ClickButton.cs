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

        private DisplayNumber displayNumber;
        [SerializeField] private GameObject manager;

        private void Awake()
        {
            button = this.gameObject.GetComponent<Button>();
            button.onClick.AddListener(GetNum);
            displayNumber = manager.GetComponent<DisplayNumber>();
        }


        private void GetNum()
        {
            if (isClick)
            {
                isClick = false;

                StartCoroutine(IsPushTimer());
            }

            displayNumber.UpdateDictionary(buttonNum);            
        }

        private IEnumerator IsPushTimer()
        {
            yield return new WaitForSeconds(5f);
            isClick = true;
        }
    }

}
