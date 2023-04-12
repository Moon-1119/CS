using System;

namespace Report4_4._6_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // 입력할 숫자의 수를 입력받음
            int max_number;
            Console.WriteLine("입력하실 숫자의 갯수를 입력하세요.");
            max_number = Int32.Parse(Console.ReadLine());
            Console.WriteLine("{0}개의 숫자를 입력받습니다.", max_number);
            Console.WriteLine("--------------------------------------");

            // 프로그램에 필요한 배열 2개 선언
            int[] array_1 = new int[max_number];
            int[] array_2 = new int[max_number];

            input_array(ref max_number, array_1,array_2);       // 입력받는 숫자를 배열로 전환하는 함수

            bouble_array(ref max_number, array_1, array_2);     // 입력받은 숫자를 오름차순으로 전환하는 함수

            print_result(array_1, array_2);                     // 결과를 출력하는 함수

        }
        static void input_array(ref int max_number, int[] array_1, int[] array_2)
        {
            for (int i = 0; i < array_1.Length; i++)                    // 배열의 크기만큼 반복하여 숫자를 입력받음
            {
                Console.WriteLine("{0}번째 숫자를 입력해주세요", i + 1);
                String input = Console.ReadLine();
                array_1[i] = Int32.Parse(input);
                swap_array(ref max_number, array_1, array_2);           // swap함수를 넣어 똑같은 배열 array_2를 생성
            }

        }
        static void bouble_array(ref int max_number, int[] array_1, int[] array_2)
        {
            for (int i = 0; i < max_number; i++)                        // 중첩반복문을 이용하여 배열의 값을 오름차순으로 정렬
            {
                for (int j = i+1; j < max_number; j++)
                {
                    if (array_1[i] > array_1[j])
                    {
                        int temp = array_1[i];
                        array_1[i] = array_1[j];
                        array_1[j] = temp;
                    }
                }
            }
        }
        static void swap_array(ref int max_number, int[] array_1, int[] array_2)
        {
            for (int i=0; i < max_number; i++)                          // array_1과 같은 array_2를 생성
            {
                array_2[i] = array_1[i];
            }
        }
        static void print_result(int[] array_1, int[] array_2)          // 함수를 거친 값들을 출력하는 함수
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("정렬 전 숫자를 나열합니다.");
            for (int i = 0; i < array_2.Length; i++)
            {
                Console.Write(array_2[i] + ",");
            }

            Console.WriteLine();
            Console.WriteLine("-------------------------------");
            Console.WriteLine("정렬후 숫자를 나열합니다.");

            for (int i = 0; i < array_1.Length; i++)
            {
                Console.Write(array_1[i] + ",");
            }
            Console.WriteLine();
            Console.WriteLine("-------------------------------");

        }
    }
}
