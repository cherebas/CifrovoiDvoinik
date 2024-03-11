using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public float timeToSpeedUp = 10f;
    public float speedBonus = 5f;
    public float speed = 10f;

    public float instantiateCarTime = 5f;
    public float minimumInstantiateTime = 1.5f;
    public List<MovingObject> existingMovingObjects;
    public List<MovingObject> carsToInstantiate;

    public TextMeshProUGUI scoreText;
    
    private float timeElapsed = 0f;
    private float score = 0f;

    private void Start()
    {
        StartCoroutine(InstantiateCarOnTime());
    }

    private IEnumerator InstantiateCarOnTime()
    {
        List<float> positions = new List<float>(){-4f, 0f, 4f};
        int instAmount = Random.Range(1, 3);
        InstantiateCar(positions, instAmount);
        yield return new WaitForSeconds(instantiateCarTime);
        StartCoroutine(InstantiateCarOnTime());
    }

    private void InstantiateCar(List<float> positions, int amount)
    {
        while (true)
        {
            if (amount == 0) return;

            float xPos = positions[Random.Range(0, positions.Count)];
            positions.Remove(xPos);
            var car = Instantiate(carsToInstantiate[Random.Range(0, carsToInstantiate.Count)], new Vector3(xPos, -3.25f, 180f), Quaternion.identity);
            car.speed = speed;
            existingMovingObjects.Add(car);
            
            amount = amount - 1;
        }
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;
        score += Time.deltaTime;

        scoreText.text = $"Счёт: {(int)score}";

        if (!(timeElapsed > timeToSpeedUp)) return;
        
        SpeedUp();
        timeElapsed = 0f;
    }

    private void SpeedUp()
    {
        speed += speedBonus;
        
        foreach (var obj in existingMovingObjects)
        {
            obj.speed = speed;
        }
        
        if(instantiateCarTime-0.2f < minimumInstantiateTime) return;
        instantiateCarTime -= 0.2f;
    }
}
