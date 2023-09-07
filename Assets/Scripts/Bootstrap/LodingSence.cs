using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Scripts.Bootstrap 
{
    public class LodingSence : MonoBehaviour
    {
        [SerializeField] private Slider _sliderLodind;
        [SerializeField] private TMP_Text _textPrasent;
    
        private AsyncOperation asyncOperation;

        private int _IDSence = 1;

        private void Start()
        {
            if (_sliderLodind == null)
            {
                _sliderLodind.GetComponent<Slider>();
            }
            else if (_textPrasent == null)
            {
                _textPrasent = FindObjectOfType<TMP_Text>();
            }

            StartCoroutine("LodingSenceCorutin");
        }

        IEnumerator LodingSenceCorutin()
        {
            yield return new WaitForSeconds(1f);
            asyncOperation = SceneManager.LoadSceneAsync(_IDSence);

            while (!asyncOperation.isDone)
            {
                float prosent = asyncOperation.progress / 0.9f;
                _sliderLodind.value = prosent;
                _textPrasent.text = $"Загрузка {prosent * 100} %";
                yield return 0;

            }

        }
    }
}

