using System;

namespace Report2
{
    class Program
    {
        static void Main(string[] args)
        {

            // 비교할 기준점이 되는 점수를 입력받음

            Console.WriteLine("비교할 기준 점수를 입력하세요.");
            String input_score = Console.ReadLine();
            int standard_score = Int32.Parse(input_score);

            // 점수들의 배열
            
            int[] array_score = { 51, 64, 72, 24, 21, 1, 4, 91, 15, 36, 83, 2, 41, 35, 11, 66, 19, 86, 9, 29 };
            int array_num = array_score.Length;  // 배열의 개수를 구함
            int std_num_more = 0;
            int std_num_less = 0;


            // 배열의 점수들과 입력된 기준 점수를 비교

            for (int i = 0; i < array_num; i++)
            {
                if (array_score[i] <= standard_score)  // 배열의 점수가 기준점수 이하
                {
                    std_num_less = std_num_less + 1;
                }

                if (array_score[i] > standard_score)  // 배열의 점수가 기준점수 초과 (겹치기 때문에 초과)
                {
                    std_num_more = std_num_more + 1;
                }
            }
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("기준점수 이하인 학생의 수 : {0}", std_num_less);
            Console.WriteLine("기준점수 초과인 학생의 수 : {0}", std_num_more);
            Console.WriteLine("-------------------------------------------");
        }
    }
}
