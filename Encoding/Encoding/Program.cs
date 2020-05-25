using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Text;

namespace Encoding1
{
    class Program
    {
        static string user;
        static byte[] asciiByte;
        static byte[] utf8Byte;

        static void Main(string[] args)
        {
            while (Choice()){}
        }

        static bool Choice()
        {
            Console.Clear();
            int choice = Convert.ToInt32(Console.ReadLine());
                        
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Sætning/Ord");
                    string userInput = Console.ReadLine();
                    user = userInput;
                    utf8Byte = Encoding.UTF8.GetBytes(user);
                    asciiByte = Encoding.ASCII.GetBytes(user);
                    break;
                case 2:
                    Console.WriteLine("Sætning/Ord som ASCII");
                    asciiMes();
                    break;
                case 3:
                    Console.WriteLine("Sætning/Ord som UTF-8");
                    utf8Mes();
                    break;
                case 4:
                    Console.WriteLine("UTF-8 som ASCII");
                    utf8ascii();
                    break;
                case 5:
                    Console.WriteLine("ASCII som UTF-8");
                    asciiutf8();
                    break;
                case 6:
                    Console.WriteLine("ASCII og UTF-8 udskrevet");
                    print();
                    break;
                case 7:
                    Console.WriteLine("Bonus lavede");
                    bonus();
                    break;
                case 8:
                    return false;
                    break;
            }
            return true;
        }

        static void asciiMes()
        {
            foreach(byte b in asciiByte)
            {
                Console.WriteLine(b);
            }
        }

        static void utf8Mes()
        {
            foreach(byte b in utf8Byte)
            {
                Console.WriteLine(b);
            }
        }

        static void utf8ascii()
        {
            Console.WriteLine(Encoding.ASCII.GetString(utf8Byte));
        }

        static void asciiutf8()
        {
            Console.WriteLine(Encoding.UTF8.GetString(asciiByte));
        }

        static void print()
        {
            Console.WriteLine("UTF-8" + Encoding.UTF8.GetString(utf8Byte));
            Console.WriteLine("ASCII" + Encoding.ASCII.GetString(asciiByte));
        }

        static void bonus()
        {
            foreach (char c in user)
            {
                switch (c)
                {
                    case 'A':
                        Console.WriteLine(65);
                        break;
                    case 'B':
                        Console.WriteLine(66);
                        break;
                    case 'C':
                        Console.WriteLine(67);
                        break;
                    case 'D':
                        Console.WriteLine(68);
                        break;
                    case 'E':
                        Console.WriteLine(69);
                        break;
                    case 'F':
                        Console.WriteLine(70);
                        break;
                    case 'G':
                        Console.WriteLine(71);
                        break;
                    case 'H':
                        Console.WriteLine(72);
                        break;
                    case 'I':
                        Console.WriteLine(73);
                        break;
                    case 'J':
                        Console.WriteLine(74);
                        break;
                    case 'K':
                        Console.WriteLine(75);
                        break;
                    case 'L':
                        Console.WriteLine(76);
                        break;
                    case 'M':
                        Console.WriteLine(77);
                        break;
                    case 'N':
                        Console.WriteLine(78);
                        break;
                    case 'O':
                        Console.WriteLine(79);
                        break;
                    case 'P':
                        Console.WriteLine(80);
                        break;
                    case 'Q':
                        Console.WriteLine(81);
                        break;
                    case 'R':
                        Console.WriteLine(82);
                        break;
                    case 'S':
                        Console.WriteLine(83);
                        break;
                    case 'T':
                        Console.WriteLine(84);
                        break;
                    case 'U':
                        Console.WriteLine(85);
                        break;
                    case 'V':
                        Console.WriteLine(86);
                        break;
                    case 'W':
                        Console.WriteLine(87);
                        break;
                    case 'X':
                        Console.WriteLine(88);
                        break;
                    case 'Y':
                        Console.WriteLine(89);
                        break;
                    case 'Z':
                        Console.WriteLine(90);
                        break;
                    case 'Æ':
                        Console.WriteLine(63);
                        break;
                    case 'Ø':
                        Console.WriteLine(63);
                        break;
                    case 'Å':
                        Console.WriteLine(63);
                        break;
                    case 'a':
                        Console.WriteLine(97);
                        break;
                    case 'b':
                        Console.WriteLine(98);
                        break;
                    case 'c':
                        Console.WriteLine(99);
                        break;
                    case 'd':
                        Console.WriteLine(100);
                        break;
                    case 'e':
                        Console.WriteLine(101);
                        break;
                    case 'f':
                        Console.WriteLine(102);
                        break;
                    case 'g':
                        Console.WriteLine(103);
                        break;
                    case 'h':
                        Console.WriteLine(104);
                        break;
                    case 'i':
                        Console.WriteLine(105);
                        break;
                    case 'j':
                        Console.WriteLine(106);
                        break;
                    case 'k':
                        Console.WriteLine(107);
                        break;
                    case 'l':
                        Console.WriteLine(108);
                        break;
                    case 'm':
                        Console.WriteLine(109);
                        break;
                    case 'n':
                        Console.WriteLine(110);
                        break;
                    case 'o':
                        Console.WriteLine(111);
                        break;
                    case 'p':
                        Console.WriteLine(112);
                        break;
                    case 'q':
                        Console.WriteLine(113);
                        break;
                    case 'r':
                        Console.WriteLine(114);
                        break;
                    case 's':
                        Console.WriteLine(115);
                        break;
                    case 't':
                        Console.WriteLine(116);
                        break;
                    case 'u':
                        Console.WriteLine(117);
                        break;
                    case 'v':
                        Console.WriteLine(118);
                        break;
                    case 'w':
                        Console.WriteLine(119);
                        break;
                    case 'x':
                        Console.WriteLine(120);
                        break;
                    case 'y':
                        Console.WriteLine(121);
                        break;
                    case 'z':
                        Console.WriteLine(122);
                        break;
                    case 'æ':
                        Console.WriteLine(63);
                        break;
                    case 'ø':
                        Console.WriteLine(63);
                        break;
                    case 'å':
                        Console.WriteLine(63);
                        break;
                    case ' ':
                        Console.WriteLine(32);
                        break;
                }
            }
            
        }
    }
}
