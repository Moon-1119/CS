using System;

namespace if_test
{
    class Program
    {
        static void Main(string[] args)
        {
            string Number, name, Finish_answer;
            String classno = "", major = "";            // 빈 String 변수 생성 (문자열에 값을 대입할 때 ""필요)
            int idx_classNo = 4;                        // SubString 메소드에서 사용할 수 (4번째 수 부터 +3번째 수를 읽음)
            int len_classNo = 3;
            int Max_input;                              // 입력받을 최대 학생수
            int Finish_num = 0;                         // 종료 시 까지 입력받은 학생 수를 저장받는 변수
            
            String classNO_IE = "001";                  // 학번의 학과 식별번호가 001이면 산공, 002면 기계, 003이면 컴공
            String classNo_MA = "002";
            String classNo_CC = "003";

            Console.WriteLine("입력하실 학생 수를 입력하세요.");       // Max_input을 입력받음
            Max_input = Int32.Parse(Console.ReadLine());

            String[] std_major = new String[Max_input];             // Max_input과 같은 크기의 학과, 학번, 이름을 저장하는 배열을 생성
            String[] std_name = new String[Max_input];
            int[] std_no = new int[Max_input];


            for (int i = 0; i < Max_input; i++)                     // 학생 수 보다 작을 때 까지 반복
            {
                Console.WriteLine("학번을 입력하세요.");                
                Number = Console.ReadLine();
                classno = Number.Substring(idx_classNo, len_classNo);
                std_no[i] = Int32.Parse(classno);                   // 입력받은 학번을 배열에 저장

                Console.WriteLine("이름을 입력하세요.");
                name = Console.ReadLine();
                std_name[i] = name;                                 // 입력받은 이름을 배열에 저장

                if (classno == classNO_IE)                          // 학번의 학과 식별번호에 따라 식별
                {
                    major = "산공과";
                }
                else if (classno == classNo_MA)
                {
                    major = "수학과";
                }
                else if (classno == classNo_CC)
                {
                    major = "컴공과";
                }

                std_major[i] = major;                   // 식별한 학과를 배열에 저장

                Finish_num += 1;                        // 종료할 때 까지 입력되는 학생 수를 저장

                Console.WriteLine("학과:{0}, 학번:{1}, 이름:{2}", major, Number, name);   // 입력받은 정보를 출력
                Console.WriteLine("------------------------------------------------");
               
                if (i < Max_input)                      // Max_input보다 입력받은 수가 적지만 종료 할 수 있는 조건문
                {
                    Console.WriteLine("계속하시겠습니까? Y/N");
                    Finish_answer = Console.ReadLine();
                    if (Finish_answer == "N")           // N을 입력받으면 반복문을 종료
                    {
                        Console.WriteLine("--------------------------------------------");
                        Console.WriteLine("프로그램을 종료합니다. 감사합니다.");
                        Console.WriteLine("--------------------------------------------");

                        for (int j = 0; j < Finish_num; j++)    // 직전까지 입력받은 정보를 반복하여 출력
                        {
                            Console.WriteLine("학과:{0}, 학번: {1}, 이름: {2}", std_major[j], std_no[j], std_name[j]);
                        }
                        break;
                    }
                    if (Finish_answer == "Y")      // Y를 입력받으면 계속해서 반복문을 시행
                    {
                        continue;

                    }
                }

                if (i >= Max_input)                // Max_input과 입력받은 학생 수가 같아지면 종료
            {
                    Console.WriteLine("--------------------------------------------");
                    Console.WriteLine("프로그램을 종료합니다. 감사합니다.");
                    Console.WriteLine("--------------------------------------------");

                    for (int j = 0; j < std_no.Length; j++)           // 입력받은 모든 정보를 반복하여 출력
                    {
                        Console.WriteLine("학과:{0}, 학번: {1}, 이름: {2}", std_major[j], std_no[j], std_name[j]);
                    }

            }
                
            }
        }
    }
}

//       012345678
// 학번: 201702963
// classno = number.Substring(4, 3);
