using System;

namespace def_example
{
    class Program
    {
        static void Main(string[] args)
        {
            // 20개의 숫자를 읽어서 총합과 평균을 구하고자함

            int sum = 0;
            float result_avg = 0.0f;
            int max_input = 10;                    
            int[] numbers = new int[max_input];    
                                                   
            // 중요
            // int와 int[]는 서로 다름
            // int[] : 주소값을 선언하고 그 주소값이 int형임
            // 배열의 변수들은 주소를 가지고 움직이기 때문에 ref를 사용하지 않아도 됨
            // 스택을 이용해서 지역변수를 다룸 스택을 벗어나면 사라지기 때문에 ref사용
            // ref는 주소값을 사용하기 때문에 스택밖에서 사용해 매개변수형태로 전달 가능
            // new라고 선언하면 힙영역에 들어감


            input_values(numbers);     // 함수를 호출하면 그 함수로 점프함
            sum = get_sum(numbers);
            result_avg = get_avg(sum, max_input);
            print_result(numbers, sum, result_avg);  // 이 변수들은 코드 영역에 들어감

            // 20개의 값을 읽기
         static void input_values(int[] numbers) // 어떤 동작을 할지 모르기 때문에 void로 설정
            {
                Console.WriteLine("숫자를 입력하세요.");
                for (int i = 0; i < numbers.Length; i++)
                {
                    Console.Write("{0}번째 숫자 : ", i + 1);
                    String input = Console.ReadLine();
                    numbers[i] = Int32.Parse(input);
                }
            }
         static int get_sum(int[] numbers)
            {
                int sum = 0;
                for (int i = 0; i < numbers.Length; i++ )
                {
                    sum += numbers[i];
                }

                return sum;

            }
         static float get_avg(int sum, int max_input)
            {
                int avg = 0;

                avg = sum / max_input;

                return avg; // 함수 안에서 구해진 변수를 함수 밖 변수에 저장
            }
         static void print_result(int[] numbers, int sum, float avg)
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    if ( i != 0)
                    {
                        Console.Write(", ");
                    }
                    Console.Write("{0} ", numbers[i]);

                }
            }

        }
    }
}
