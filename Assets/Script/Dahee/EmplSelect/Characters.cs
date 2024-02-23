using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Characters : MonoBehaviour
{
    public Sprite[] sprites;
    public Image image;
    public float fadeDuration = 1.0f;

    void Start()
    {
        // 오브젝트를 비활성화하여 시작
        gameObject.SetActive(false);
    }

    public void ChangeSpriteWithFade()
    {
        // 오브젝트를 활성화하여 코루틴 실행
        gameObject.SetActive(true);
        // 랜덤한 스프라이트 선택
        int randomIndex = Random.Range(0, sprites.Length);
        StartCoroutine(ChangeSpriteCoroutine(sprites[randomIndex]));
    }

    IEnumerator ChangeSpriteCoroutine(Sprite sprite)
    {

        float timer = 0f;
       

        // 선택된 스프라이트로 변경
        image.sprite = sprite;

        // 페이드 인
        timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            // 이미지의 알파 값을 변경하지 않고 유지
            image.color = new Color(1f, 1f, 1f, timer / fadeDuration);
            yield return null;
        }
    }
}
