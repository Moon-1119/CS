using System;

namespace Report
{
    class Program
    {
        static void Main(string[] args)
        {
            string Name, Birth, Gender, ID, Passward1, Passward2, Nickname, Color, Brand, Style; // 정보를 저장할 변수

            int Max_input = 3;    // 프로그램을 종료하기 위해 조건식에 들어갈 변수의 값을 설정
            string Finish_answer; // 프로그램을 종료하기 위해 입력받는 변수

            for (int Gender_input = 0; Gender_input <= Max_input;) // 입력받는 성별과 종료하기위한 조건식
            {
                Console.WriteLine("안녕하세요. 고객맞춤 제품추천 의류쇼핑몰입니다.");
                Console.WriteLine("회원가입을 시작합니다.");
                Console.WriteLine("이름을 입력하세요.");
                Name = Console.ReadLine();

                Console.WriteLine("생년월일을 입력하세요. 매년 생일쿠폰을 발급해드립니다.");
                Birth = Console.ReadLine();

                Console.WriteLine("성별을 입력하세요.");
                Console.WriteLine("남자 / 여자");
                Gender = Console.ReadLine();
                if (Gender == "남자")
                {
                    Gender_input += 1; // 남자인 경우 1을 더함
                }
                else if (Gender == "여자")
                {
                    Gender_input += 2; // 여자인 경우 2를 더함
                }
                Console.WriteLine("사용하실 ID를 입력하세요.");
                ID = Console.ReadLine();

                Console.WriteLine("사용하실 비밀번호를 입력하세요.");
                Passward1 = Console.ReadLine();

                while (true)   // 비밀번호를 두 번 입력하고 틀렸을 경우 계속해서 반복
                {
                    Console.WriteLine("비밀번호를 한 번 더 입력하세요.");
                    Passward2 = Console.ReadLine();
                    if (Passward1 == Passward2)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("비밀번호가 다릅니다.");
                        continue;
                    }
                }
                Console.WriteLine("사용하실 닉네임을 입력하세요.");
                Nickname = Console.ReadLine();

                Console.WriteLine("선호하는 색상을 입력하세요.");
                Color = Console.ReadLine();

                Console.WriteLine("선호하는 브랜드를 입력하세요.");
                Brand = Console.ReadLine();

                Console.WriteLine("선호하는 패션 스타일을 입력하세요.");
                Style = Console.ReadLine();

                Console.WriteLine("회원가입이 완료되었습니다.");
                Console.WriteLine("반갑습니다. {0}님", Name);
                Console.WriteLine("사용하실 ID는 {0}입니다. 닉네임은 {1}입니다.", ID, Nickname);
                Console.WriteLine("입력하신 색상, 브랜드, 스타일을 바탕으로 제품을 추천해드립니다.");
                Console.WriteLine("입력을 계속하시겠습니까?  Y/N");
                Console.WriteLine("Gender_input:{0}, Max_input{1}", Gender_input, Max_input); // 프로그램이 제대로 실행되는지 확인
                Finish_answer = Console.ReadLine();
                if (Finish_answer == "N") // N을 입력받으면 반복문을 종료
                {
                    break;
                }
                else if (Finish_answer == "Y") // Y를 입력받으면 계속해서 반복문을 시행
                {
                    continue;
                }
            }
        }
    }
}
