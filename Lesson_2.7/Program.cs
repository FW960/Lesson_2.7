using System;
using System.Text;

namespace Lesson_2._7
{

    interface ICoder
    {
        public string Encode(string message);

        public string Decode(string message);

    }

    public class ACoder : ICoder
    {
        private Encoding enc = Encoding.Unicode;
        public string Encode(string message)
        {
            byte[] bytesOfChars = enc.GetBytes(message);

            for (int i = 0; i < bytesOfChars.Length; i++)
            {
                if (bytesOfChars[i] == 4)
                {

                }
                else if (bytesOfChars[i] == 1)
                {
                    //Так как буквы ё и Ё по какой-то причине в байтовом представлении обладают числами 1 и 81 соответсвенно.
                    //Пришлось поменять логику перехода на следующую букву в байтовом представлении.

                    bytesOfChars[i] = 22;
                }
                else if (bytesOfChars[i] == 81)
                {
                    bytesOfChars[i] = 54;

                }
                else if (bytesOfChars[i] == 47)
                {
                    bytesOfChars[i] = 16;
                }
                else if (bytesOfChars[i] == 79)
                {
                    bytesOfChars[i] = 48;
                }
                else if (bytesOfChars[i] == 21)
                {
                    bytesOfChars[i] = 1;
                }
                else if (bytesOfChars[i] == 53)
                {
                    bytesOfChars[i] = 81;
                }
                else
                {
                    ++bytesOfChars[i];
                }
            }

            return message = enc.GetString(bytesOfChars);
        }

        public string Decode(string message)
        {
            byte[] bytesOfChars = enc.GetBytes(message);

            for (int i = 0; i < bytesOfChars.Length; i++)
            {
                if (bytesOfChars[i] == 4)
                {

                }
                else if (bytesOfChars[i] == 22)
                {
                    bytesOfChars[i] = 1;
                }
                else if (bytesOfChars[i] == 54)
                {
                    bytesOfChars[i] = 81;

                }
                else if (bytesOfChars[i] == 16)
                {
                    bytesOfChars[i] = 47;
                }
                else if (bytesOfChars[i] == 48)
                {
                    bytesOfChars[i] = 79;
                }
                else if (bytesOfChars[i] == 1)
                {
                    bytesOfChars[i] = 21;
                }
                else if (bytesOfChars[i] == 81)
                {
                    bytesOfChars[i] = 53;
                }
                else
                {
                    --bytesOfChars[i];
                }
            }
            return message = enc.GetString(bytesOfChars);
        }

    }
    public class BCoder : ICoder
    {
        private Encoding enc = Encoding.Unicode;
        public string Encode(string message)
        {
            byte[] bytesOfChars = enc.GetBytes(message);

            for (int i = 0; i < bytesOfChars.Length; i++)
            {
                if (bytesOfChars[i] == 4)
                {
                    continue;
                }
                else if (bytesOfChars[i] == 81)
                {
                    bytesOfChars[i] = 73;
                }
                else if (bytesOfChars[i] == 1)
                {
                    bytesOfChars[i] = 41;
                }
                else if (bytesOfChars[i] == 73)
                {
                    bytesOfChars[i] = 81;

                    continue;
                }
                else if (bytesOfChars[i] == 41)
                {
                    bytesOfChars[i] = 1;

                    continue;
                }
                else
                {
                    int oppositeNumOfChar;

                    if (bytesOfChars[i] >= 48 && bytesOfChars[i] <= 79)
                    {
                            oppositeNumOfChar = 79 - bytesOfChars[i];

                            if (bytesOfChars[i] >= 54 && bytesOfChars[i] < 74)
                            {
                                oppositeNumOfChar--;
                            }

                            bytesOfChars[i] = (byte)(48 + oppositeNumOfChar);

                            continue;
                    }
                    if (bytesOfChars[i] >= 16 && bytesOfChars[i] <= 47)
                    {
                            oppositeNumOfChar = 47 - bytesOfChars[i];

                            if (bytesOfChars[i] >= 22 && bytesOfChars[i] < 42)
                            {
                                oppositeNumOfChar--;
                            }

                            bytesOfChars[i] = (byte)(16 + oppositeNumOfChar);

                            continue;
                    }
                }

            }

            return message = enc.GetString(bytesOfChars);
        }
        public string Decode(string message)
        {
            return Encode(message);
        }
    }
    // 48 - а 79 - я 16 - А 47 - Я
    internal class Program
    {
        static void Main(string[] args)
        {
            ACoder aCoder = new ACoder();

            BCoder bCoder = new BCoder();

            string aCoded = aCoder.Encode("абвгдеёжзийклмнопрстуфхцчшщъыьэюя");

            Console.WriteLine(aCoded);

            string bEncoded = aCoder.Decode(aCoded);

            Console.WriteLine(bEncoded);

            string bCoded = bCoder.Encode("АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ");

            Console.WriteLine(bCoded);

            string bDecoded = bCoder.Decode(bCoded);

            Console.WriteLine(bDecoded);
        }


    }
}
