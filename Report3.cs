using System;

namespace Report3
{
    class Program
    {
        static void Main(string[] args)
        {
            // 배열과 int형 변수를 선언함
            int[] array = { 87, 32, 19, 18, 1, 46, 70, 75, 70, 93, 48, 1, 34, 48, 58, 47, 29, 96, 13, 77 };
            int num;  // 배열의 수와 비교할 변수
            int array_num = array.Length;  // 배열의 원소 개수를 저장

            for (int i = 0; i < array_num; i++)  // 바깥쪽 반복루프
            {
                for (int j = i+1; j < array_num; j++)  // 안쪽 반복루프
                {
                    if (array[i] > array[j])  // i번째 수가 j번째 수보다 클 경우 실행 
                    {
                        num = array[i];       // 비교할 변수에 배열의 i번째 수를 저장
                        array[i] = array[j];  // i번째 수는 j번째 수로 바뀜
                        array[j] = num;       // j번째 수는 i번째 수로 바뀜
                    }
                }
            }
            for (int i =0; i < array.Length; i++)
            {
                Console.Write(array[i] + ",");
            }
        }
    }
}
