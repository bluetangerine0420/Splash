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
        // ������Ʈ�� ��Ȱ��ȭ�Ͽ� ����
        gameObject.SetActive(false);
    }

    public void ChangeSpriteWithFade()
    {
        // ������Ʈ�� Ȱ��ȭ�Ͽ� �ڷ�ƾ ����
        gameObject.SetActive(true);
        // ������ ��������Ʈ ����
        int randomIndex = Random.Range(0, sprites.Length);
        StartCoroutine(ChangeSpriteCoroutine(sprites[randomIndex]));
    }

    IEnumerator ChangeSpriteCoroutine(Sprite sprite)
    {

        float timer = 0f;
       

        // ���õ� ��������Ʈ�� ����
        image.sprite = sprite;

        // ���̵� ��
        timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            // �̹����� ���� ���� �������� �ʰ� ����
            image.color = new Color(1f, 1f, 1f, timer / fadeDuration);
            yield return null;
        }
    }
}
