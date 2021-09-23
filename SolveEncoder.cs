using System;

//이것이 바로 핵심파일
namespace SolveEncoder
{
    public static class Encoder
    {
        public static string TextToSolve(string text, string zero, string one)
        {
            char[] a = text.ToCharArray();
            string b = "";
            for (int c = 0; c < a.Length; c++)
            {
                b += Convert.ToString(((int)a[c]), 2);
                while (b.Length < 16) b = "0" + b;
            }
            return b.Replace("0", zero).Replace("1", one);
        }
        public static string SolveToText(string solve, string zero, string one)
        {
            string b = solve.Replace(zero, "0").Replace(one, "1");
            char[] a = new char[b.Length];
            string d = "";
            int e = 0;
            for (int c = 0; b.Length >= 16; c++)
            {
                d = b.Substring(0, 16).Replace("0", " ").TrimStart().Replace(" ", "0");
                //Console.WriteLine(d); //2진 출력
                b = b.Length > 0 ? b.Substring(16) : null;
                //while(d.Substring(0,1) == "0" && d != "0") d = d.Substring(1,d.Length); //쓸모없음
                e = Convert.ToInt32(d, 2);
                a[c] = (char)e;
                //Console.WriteLine(a[c]); //한글자 출력
            }
            return new string(a);
        }
    }
    
}


     
