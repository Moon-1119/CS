using System;

namespace def_example2
{
    class Program
    {
        static void Main(string[] args)
        {
            // 두개의 숫자를 입력받아서 합을 구하는 함수

            int x1;
            int x2;
            int sum;

            // 첫번째 숫자 입력

            x1 = input_number();

            // 두번쨰 숫자 입력
            x2 = input_number();

            // 합

            sum = get_sum(x1, x2);

            // 출력
            print_sum(sum);

        }
       
        static int input_number()
        {

            Console.WriteLine("숫자를 입력하세요");
            String sx = Console.ReadLine();

            int nx = Int32.Parse(sx);

            return nx;
        }
        static int get_sum(int x, int y) // x1 = x   x2 = y  가 들어감
        {
            int z = x + y;

            return z;
        }
        static void print_sum(int sum)
        {
            Console.WriteLine("---------------------");
            Console.WriteLine("두 수의 합 : {0} ", sum);
            Console.WriteLine("---------------------");
        }
    }

}
