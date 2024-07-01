using System.Collections;
using TMPro;
using UnityEngine;

public class WheelOfFortune : MonoBehaviour
{
    [SerializeField] float spinDuration = 4f; // Длительность вращения
    [SerializeField] GameObject buttonSpin;
    [SerializeField] GameObject winImagee;
    [SerializeField] TextMeshProUGUI textWin;

    private float[] angles = { 40f, 80f, 120f, 160f, 200f, 240f, 280f, 320f, 360f };
    private bool isSpinning = false;
    private float targetAngle;


    public void Spin()
    {
        if (!isSpinning)
        {
            buttonSpin.gameObject.SetActive(false);
            StartCoroutine(SpinWheel());
        }
    }

    private IEnumerator SpinWheel()
    {
        isSpinning = true;

        // Случайный выбор угла
        int chosenIndex = Random.Range(0, angles.Length);
        targetAngle = angles[chosenIndex];

        float startAngle = transform.eulerAngles.z;
        float endAngle = startAngle + 360 * 3 + targetAngle; // Вращение на 3 оборота + целевой угол

        float elapsed = 0f;

        while (elapsed < spinDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / spinDuration;
            float currentAngle = Mathf.Lerp(startAngle, endAngle, EaseOutCubic(t));
            transform.eulerAngles = new Vector3(0, 0, currentAngle);
            yield return null;
        }

        transform.eulerAngles = new Vector3(0, 0, endAngle);

        Debug.Log($"Sector: {angles[chosenIndex]}");

        isSpinning = false;

        yield return new WaitForSeconds(0.5f);

        int coefficient = 0;
        if (angles[chosenIndex] == 40)
            coefficient = 1;
        else if (angles[chosenIndex] == 80)
            coefficient = 5;
        else if (angles[chosenIndex] == 120)
            coefficient = 3;
        else if (angles[chosenIndex] == 160)
            coefficient = 1;
        else if (angles[chosenIndex] == 200)
            coefficient = 4;
        else if (angles[chosenIndex] == 240)
            coefficient = 1;
        else if (angles[chosenIndex] == 280)
            coefficient = 2;
        else if (angles[chosenIndex] == 320)
            coefficient = 1;
        else if (angles[chosenIndex] == 360)
            coefficient = 2;

        int crystalsAtFinish = FindObjectOfType<Crystals>().crystals * coefficient;
        Data.SetCrystals(crystalsAtFinish);

        winImagee.gameObject.SetActive(true);
        textWin.text = $"X{coefficient} YOUR DIAMONDS";
    }

    private float EaseOutCubic(float t)
    {
        t--;
        return t * t * t + 1;
    }
}
