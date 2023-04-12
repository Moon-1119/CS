using System;

namespace def_example3
{
    class Program
    {
        static void Main(string[] args)
        {
            // 두 개의 문자열의 값을 교환하는 Swap_string

            String name = "종환";
            String title = "개미";

            //출력
            print_value(name, title); // 두 개를 입력받아 출력

            // swap
            do_swap(ref name, ref title);

            // 재출력
            print_value(name, title);

        }  // name과 title 은 main 스택에서 선언


        static void print_value(String s1, String s2)
        {
            Console.WriteLine("작가 : {0}, 제목 : {1}", s1, s2);

        }
        static void do_swap(ref String s1, ref String s2)
        {
            String temp; // 임시 저장
            temp = s1;
            s1 = s2;
            s2 = temp;
        }   // s1, s2는 swap함수 안에서 선언된 변수
            // 함수 밖에 변수를 변환시키려면 참조 ref 사용

    }
 
}
