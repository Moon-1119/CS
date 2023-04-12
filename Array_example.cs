using System;

namespace Array_example3
{
    class Program
    {
        static void Main(string[] args)
        {
            // 데이터
            // 정수 : 학생수
            // 배열 : String 학생이름. int 점수
            // 최고점 = String : 학생이름, int 최고점수
            // 최저점 = String : 학생이름, int 최저점수

            int num = 0;
            String[] std_names;  // 입력되는 학생들의 이름을 저장하는 변수(배열)                           // 스택영역에서 선언
            int[] std_score;     // 입력되는 학생들의 점수를 저장하는 변수(배열)

            String Max_std_name = "";  // 최고점수의 학생 이름을 저장하는 변수
            String Min_std_name = "";  // 최저점수의 학생 이름을 저장하는 변수
            int Max_std_score = Int32.MinValue;  // 입력되는 점수와 최고점을 비교하기 위한 변수
            int Min_std_score = Int32.MaxValue;  // 입력되는 점수와 최저점을 비교하기 위한 변수

            Console.Write("학생수: ");
            String input_num = Console.ReadLine();
            num = Int32.Parse(input_num);  // 입력받은 학생 수를 int자료로 형변환

            std_names = new string[num];  // num의 크기만큼 학생들의 이름을 저장하는 배열을 생성
            std_score = new int[num];     // num의 크기만큼 학생들의 점수를 저장하는 배열을 생성           // 힙영역에서 선언되고 불러옴

            for (int i = 0; i < num; i++)
            {
                Console.WriteLine("학생의 이름을 입력해주세요.");
                String name = Console.ReadLine();
                std_names[i] = name;    // 입력된 name이 std_names의 i번째 배열에 저장

                Console.WriteLine("학생의 점수를 입력해주세요.");
                String score = Console.ReadLine();
                std_score[i] = Int32.Parse(score);  // 입력된 score가 std_score의 i번째 배열이 int형자료로 score에 저장

                // 최고점
                if (std_score[i] > Max_std_score)   // i번째 score가 설정된 Max_std_score (처음에는 int자료형의 최소값)보다 크다면
                {
                    Max_std_name = std_names[i];    // i번째로 입력된 학생과 점수가 최고점이 됨
                    Max_std_score = std_score[i];
                }
                if (std_score[i] < Min_std_score)  // i번째 score가 설정된 Mins_std_score (처음에는 int자료형의 최대값)보다 작으면
                {
                    Min_std_name = std_names[i];   // i번째로 입력된 학생과 점수가 최저점이 됨
                    Min_std_score = std_score[i];
                }
                Console.WriteLine("------------------------------------------------------");   // 학생들의 점수와 이름을 입력할때마다 현재의 최고점 최저점을 출력
                Console.WriteLine("현재 최저점 : {0}, 이름:{1}", Min_std_score, Min_std_name);
                Console.WriteLine("현재 최고점 : {0}, 이름:{1}", Max_std_score, Max_std_name);
                Console.WriteLine("------------------------------------------------------");

            }
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("최저점 : {0}, 이름:{1}", Min_std_score, Min_std_name);
            Console.WriteLine("최고점 : {0}, 이름:{1}", Max_std_score, Max_std_name);
            Console.WriteLine("------------------------------------------------------");   // 모든 입력이 끝나고 최고점과 최저점의 학생과 점수를 출력


        }

    }
}
