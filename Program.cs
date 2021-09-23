using System;
using System.IO;
using static SolveEncoder.Encoder;

namespace EncoderProgram
{
    class Program
    {
        static void Main(string[] args)
        {
		    if (args.Length == 0)
            {
                Console.WriteLine("\n이것은 솔바브보 변환기입니다.\n=== 도움말 ===\n-solve : 문자열을 솔브어로 암호화합니다.\n(-text 와 같이 쓸수 없습니다.)\n\n-text : 솔브어를 문자열로 해독합니다.\n(-solve 와 같이 쓸수 없습니다.)\n\n-zero (값) : 0을 (값) 으로 대체합니다.\n\n-one (값) : 1을 (값) 으로 대체합니다.\n\n-string (값) : 파일이 아닌, -string 뒤에 적이는 문자열을 변환합니다.\n(이 뒤에는 다른 옵션 명령어를 붙힐수 없습니다, 같은 문자열로 인식합니다.)\n\n=== 예시 ===\n(이 프로그램명) -solve -zero 띠까 -one 바보 -string 솔브는 바보다! 반박하면 너 솔브\n\n(이 프로그램명) (파일 이름)\n\n=== 기타 ===\n-solve, -text 를 설정하지 않은경우 기본적으로 -solve로 작동합니다.\n\n-string을 쓰지 않는이상, 파일 주소를 올려서 사용합니다.\n\n=== 제작자 ===\n만든놈: 614\n\n깃허브 링크: https://github.com/614project/SolveEncoder \n\n이메일: 614project614@gmail.com\n\n(이 프로그램은 솔바브보 변환기의 공식(?) 빌드버전입니다.)\n(솔브 멍청이)");
            }
            else
            {
                string[] a = new string[0];
                bool solve = false;
                bool text = false;
                string code = null;
                string zero = null;
                string one = null;
                int type = 0;
                for (int num=0;num<args.Length;num++)
                {
                    switch(type)
                    {
                        case 0:
                            switch (args[num])
                            {
                                case "-solve":
                                    if (text)
                                    {
                                        Console.WriteLine("-solve : -text 명령어가 전자에 있습니다. 두 명령은 같이 쓸수 없습니다.");
                                        return;
                                    } else
                                    {
                                        if (solve)
                                        {
                                            Console.WriteLine("-solve : 이미 -solve가 쓰였습니다.");
                                            return;
                                        } else
                                        {
                                            solve = true;
                                        }
                                    }
                                    break;
                                case "-text":
                                    if (solve)
                                    {
                                        Console.WriteLine("-text : -solve 명령어가 전자에 있습니다. 두 명령은 같이 쓸수 없습니다.");
                                        return;
                                    } else
                                    {
                                        if (text)
                                        {
                                            Console.WriteLine("-text : 이미 -text가 쓰였습니다.");
                                        } else
                                        {
                                            text = true;
                                        }
                                    }
                                    break;
                                case "-zero":
                                    if (zero == null)
                                    {
                                        if (num + 1 < args.Length)
                                        {
                                            type = 1;
                                        } else
                                        {
                                            Console.WriteLine("-zero : -zero 뒤에 값이 없습니다.");
                                        }
                                    } else
                                    {
                                        Console.WriteLine("-zero : 이미 -zero 가 설정되있습니다.");
                                    }
                                    break;
                                case "-one":
                                    if (one == null)
                                    {
                                        if (num + 1 < args.Length)
                                        {
                                            type = 2;
                                        } else
                                        {
                                            Console.WriteLine("-one : -one 뒤에 값이 없습니다.");
                                        }
                                    } else
                                    {
                                        Console.WriteLine("-one : 이미 -one 가 설정되있습니다.");
                                    }
                                    break;
                                case "-string":
                                    if (num + 1 < args.Length)
                                    {
                                        type = 3;
                                    } else
                                    {
                                        Console.WriteLine("-string : -string 뒤에 값이 없습니다.");
                                    }
                                    break;
                                 default:
                                    a = new string[args.Length - num];
                                    Array.Copy(args,num,a,0,a.Length);
                                    code = string.Join(" ",a);
                                    type = 0;
                                    num = args.Length + 1;
                                    if (File.Exists(code))
                                    {
                                        code = File.ReadAllText(code);
                                    } else
                                    {
                                        Console.WriteLine("잘못된 파일 경로입니다.");
                                        return;
                                    }
                                    break;
                            }
                            break;
                        case 1:
                            zero = args[num];
                            type = 0;
                            break;
                        case 2:
                            one = args[num];
                            type = 0;
                            break;
                        case 3:
                            a = new string[args.Length - num];
                            Array.Copy(args,num,a,type = 0,a.Length);
                            code = string.Join(" ",a);
                            num = args.Length + 1;
                            break;
                    } 
                }
                if (zero == null) zero = "솔브";
                if (one == null) one = "바보";
                if (text)
                {
                    Console.WriteLine(SolveToText(code,zero,one));
                } else
                {
                    Console.WriteLine(TextToSolve(code,zero,one));
                }
            }
        }
	}
}
