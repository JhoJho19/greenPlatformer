using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WheelOfFortune : MonoBehaviour
{
    public Transform wheel; // Ссылка на колесо (Transform)
    public float spinDuration = 4.0f; // Длительность вращения
    public float slowDownDuration = 2.0f; // Длительность замедления
    [SerializeField] private Button button;
    private float[] sectorAngles; // Углы для каждого сектора
    private bool isSpinning = false;

    private void Start()
    {
        // Инициализация углов для каждого сектора (360 / 9 = 40 градусов на сектор)
        sectorAngles = new float[9];
        for (int i = 0; i < 9; i++)
        {
            sectorAngles[i] = i * (360 / 9);
        }
    }

    public void StartSpin()
    {
        button.gameObject.SetActive(false);
        if (!isSpinning)
        {
            StartCoroutine(SpinWheel());
        }
    }

    private IEnumerator SpinWheel()
    {
        isSpinning = true;

        float elapsedTime = 0f;
        float currentAngle = wheel.eulerAngles.z;
        float targetAngle = currentAngle + 360 * 5 + Random.Range(0, 360); // 5 полных оборотов плюс случайный угол

        // Вращение колеса
        while (elapsedTime < spinDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / spinDuration;
            float angle = Mathf.Lerp(currentAngle, targetAngle, t);
            wheel.eulerAngles = new Vector3(0, 0, angle);
            yield return null;
        }

        // Замедление вращения
        elapsedTime = 0f;
        currentAngle = wheel.eulerAngles.z;
        targetAngle = currentAngle + Random.Range(0, 360); // Дополнительный случайный угол для замедления

        while (elapsedTime < slowDownDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / slowDownDuration;
            float angle = Mathf.Lerp(currentAngle, targetAngle, t);
            wheel.eulerAngles = new Vector3(0, 0, angle);
            yield return null;
        }

        // Остановка на случайном секторе
        float finalAngle = wheel.eulerAngles.z;
        int sector = GetSector(finalAngle);
        Debug.Log("Landed on sector: " + sector);

        isSpinning = false;
    }

    private int GetSector(float angle)
    {
        angle = Mathf.Repeat(angle, 360); // Приведение угла к диапазону [0, 360)
        float sectorSize = 360 / 9;

        for (int i = 0; i < sectorAngles.Length; i++)
        {
            if (angle >= sectorAngles[i] && angle < sectorAngles[i] + sectorSize)
            {
                return i + 1; // Возвращает номер сектора (1-9)
            }
        }

        return 1; // На случай ошибки возвращаем сектор 1
    }
}
