using System;

namespace SolveEncoder
{
    class Program
    {
        static void Main(string[] args)
        {
		    if (args.Length == 0)
            {
			    Console.WriteLine("솔바브보 변환기입니다.\n=== 도움말 ===\n-solve : 문자열을 솔브어로 암호화합니다.\n(-text 와 같이 쓸수 없습니다.)\n-text : 솔브어를 문자열로 해독합니다.(-solve 와 같이 쓸수 없습니다.)\n-zero (값) : 0을 (값) 으로 대체합니다.\n-one (값) : 1을 (값) 으로 대체합니다.\n-string (값) : 파일이 아닌, -string 뒤에 적이는 문자열을 변환합니다. (이 뒤에는 다른 옵션 명령어를 붙힐수 없습니다, 같은 문자열로 인식합니다.)\n=== 예시 ===\n(이 프로그램명) -solve -zero 띠까 -one 바보 -string 솔브는 바보다! 반박하면 너 솔브\n(이 프로그램명) (파일 이름)");
            }
        }
	}
}
