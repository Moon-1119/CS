using System;
using System.IO;

namespace Meannsquare
{
    class Program
    {
        enum data_value
        {
            X,
            Y,
            data_value_max
        }
        static void Main(string[] args)
        {
            // X의 합과 Y의 합은 크기가 같기 때문에 같은 for문

            // 기울기 구하기
            // X의 합, Y의 합 X의 평균, Y의 평균, (X- X평균) * (Y-Y평균)의 합
            // (X-X평균)^2의 합

            // y절편 구하기
            // Y평균 - 기울기 * X평균

            /* int[] value_X = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
             int[] value_Y = { 70, 75, 67, 58, 69, 80, 79, 76, 81, 85 };*/

            string data_test = (@"C:\Projects\Visual Studio\data_test.csv");

            string[] input_value = null; // 데이터 선언부와 데이터를 읽는 부분을 분리하기 위함
            char SEPERATOR = ',';


            input_value = File.ReadAllLines(data_test);  // 데이터 읽기

            int data_max = input_value.Length;       // 데이터 세팅
            int[] values_X = new int[data_max];     // 데이터의 크기만큼
            int[] values_Y = new int[data_max];

            // 문자형을 int형으로 초기화
            input_data_value(input_value, SEPERATOR, data_max, values_X, values_Y);

            int data_num = values_X.Length;
            int sum_X = 0;
            int sum_Y = 0;

            float avg_X = 0.0f;
            float avg_Y = 0.0f;

            float sumDif_XY = 0.0f;
            float sumDif_X2 = 0.0f;

            float a = 1.0f;  // 곱셈을 하는 것은 1 합을 하는 것은 0으로 초기화
            float b = 1.0f;

            float est = 0.0f;

            int target_Y = 11;


            Calculate(values_X, values_Y, data_num, ref sum_X, ref sum_Y, out avg_X, out avg_Y, ref sumDif_XY, ref sumDif_X2, out a, out b);

            est = get_est(a, b, target_Y);

            print_result(sum_X, sum_Y, avg_X, avg_Y, sumDif_X2, est);

            // sum의 값을 담기 위해 ref 사용, calculate함수 밖에서 선언된 변수의 값을 가져옴
            // out은 output만사용
        }

        private static void input_data_value(string[] input_value, char SEPERATOR, int data_max, int[] values_X, int[] values_Y)
        {
            for (int i = 0; i < data_max; i++) // 읽어 드린 데이터를 배열에 세팅
            {
                String[] val = input_value[i].Split(SEPERATOR); // 1, 70 을 seperator로 나눔
                String x = val[(int)data_value.X];
                String y = val[(int)data_value.Y];

                values_X[i] = Int16.Parse(x);
                values_Y[i] = Int16.Parse(y);
            }
        }
        private static void Calculate(int[] value_X, int[] value_Y, int data_num, ref int sum_X, ref int sum_Y, out float avg_X, out float avg_Y, ref float sumDif_XY, ref float sumDif_X2, out float a, out float b)
        {
            for (int i = 0; i < data_num; i++)
            {
                sum_X += value_X[i]; // 우변 좌변 모두 사용함, 원래 값 0을 가져와서 실행, input, output모두 사용
                sum_Y += value_Y[i];
            }

            avg_X = (float)sum_X / data_num; // 우변에는 없기 때문에 input으로 사용되지 않고 output으로만 사용되어서 out
            avg_Y = (float)sum_Y / data_num;

            for (int i = 0; i < data_num; i++)
            {
                ; sumDif_XY += ((float)(value_X[i] - avg_X)) * ((float)(value_Y[i] - avg_Y));
                ; sumDif_X2 += ((float)(value_X[i] - avg_X)) * ((float)(value_X[i] - avg_X));
            }

            a = sumDif_XY / sumDif_X2;
            b = avg_Y - a * avg_X;
        }
        // ref, out으로 다 반환하였음 (void 사용)
        // 반환이 있으면 ref, out이 필요없나?
        private static void print_result(int sum_X, int sum_Y, float avg_X, float avg_Y, float sumDif_X2, float est)
        {
            Console.WriteLine("X의 합: {0}", sum_X);
            Console.WriteLine("Y의 합: {0}", sum_Y);
            Console.WriteLine("X의 평균: {0}", avg_X);
            Console.WriteLine("Y의 평균: {0}", avg_Y);
            Console.WriteLine("X의 제곱의 합: {0}", sumDif_X2);
            Console.WriteLine("예측치 : {0}", est);
        }
        private static float get_est(float a, float b, int target_Y)
        {
            return a * target_Y + b;
        }
    }
}
