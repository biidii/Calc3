using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCP
{
    public class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            bool noMultOrDiv = true;
            bool noParens = true;
            int parenStart = 0;
            int parenEnd = 0;
            while (true)
            {
                Console.WriteLine("Input the values and how you want them added?");
                var InputVar = Console.ReadLine();
                List<String> InputList = InputVar.Split(' ').ToList();
                while (InputList.Count != 1)
                {
                    startOfLoop:
                    noParens = true;
                    for (int parensCheck = 0; parensCheck < InputList.Count(); parensCheck++)
                    {
                        if (InputList[parensCheck] == "(")
                        {
                            noParens = false;
                            break;
                        }
                    }

                    if (noParens == false)
                    {
                        for (int z = 0; z < InputList.Count(); z++)
                        {
                            if (InputList[z] == ")")
                            {
                                parenEnd = z;
                                for (int y = z; y >= 0; y--)
                                {
                                    if (InputList[y] == "(")
                                    {
                                        if (z - y == 1)
                                        {
                                            InputList.Remove(InputList[y]);
                                            InputList.Remove(InputList[y]);
                                            goto startOfLoop;
                                        }
                                        if (z - y == 2)
                                        {
                                            InputList.Remove(InputList[y]);
                                            InputList.Remove(InputList[y + 1]);
                                            goto startOfLoop;
                                        }
                                        parenStart = y;
                                        noMultOrDiv = true;
                                        for (int n = parenStart; n < parenEnd; n++)
                                        {
                                            if (noMultOrDiv == false)
                                            {
                                                break;
                                            }
                                            else if (InputList[n] == "x")
                                            {
                                                noMultOrDiv = false;
                                            }
                                            else if (InputList[n] == "/")
                                            {
                                                noMultOrDiv = false;
                                            }
                                        }
                                    }
                                        for (int p = parenStart; p < parenEnd + 1; p++)
                                        {
                                            if (noMultOrDiv == false)
                                            {
                                                if (InputList[p] == "x")
                                                {
                                                InputList[p - 1] = int.Parse(InputList[p - 1]) * int.Parse(InputList[p + 1]) + "";
                                                deleteMath(p, InputList);
                                                goto startOfLoop;
                                            }
                                                if (InputList[p] == "/")
                                                {
                                                    InputList[p - 1] = int.Parse(InputList[p - 1]) / int.Parse(InputList[p + 1]) + "";
                                                deleteMath(p, InputList);
                                                goto startOfLoop;
                                            }
                                                                                              
                                            }

                                            else if (noMultOrDiv == true)
                                            {
                                                if (InputList[p] == "+")
                                                {
                                                InputList[p - 1] = int.Parse(InputList[p - 1]) + int.Parse(InputList[p + 1]) + "";
                                                deleteMath(p, InputList);
                                                goto startOfLoop;
                                            }
                                                if (InputList[p] == "-")
                                                {
                                                    InputList[p - 1] = int.Parse(InputList[p - 1]) - int.Parse(InputList[p + 1]) + "";
                                                deleteMath(p, InputList);
                                                goto startOfLoop;
                                            }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    

                    else
                    {
                        noMultOrDiv = true;
                        for (int a = 0; a < InputList.Count(); a++)
                        {
                            if (noMultOrDiv == false)
                            {
                                break;
                            }
                            else if (InputList[a] == "x")
                            {
                                noMultOrDiv = false;
                            }
                            else if (InputList[a] == "/")
                            {
                                noMultOrDiv = false;
                            }
                        }




                        for (int b = 0; b < InputList.Count(); b++)
                        {
                            if (noMultOrDiv == false)
                            {
                                if (InputList[b] == "x")
                                {
                                    InputList[b] = int.Parse(InputList[b - 1]) * int.Parse(InputList[b + 1]) + "";
                                    sum = int.Parse(InputList[b]);
                                    deleteDependingOnIndex(b, InputList);
                                    goto startOfLoop;
                                }
                                else if (InputList[b] == "/")
                                {
                                    InputList[b] = int.Parse(InputList[b - 1]) / int.Parse(InputList[b + 1]) + "";
                                    sum = int.Parse(InputList[b]);
                                    deleteDependingOnIndex(b, InputList);
                                    goto startOfLoop;
                                }
                            }

                            else if (noMultOrDiv == true)
                            {
                                if (InputList[b] == "+")
                                {
                                    InputList[b] = int.Parse(InputList[b - 1]) + int.Parse(InputList[b + 1]) + "";
                                    sum = int.Parse(InputList[b]);
                                    deleteDependingOnIndex(b, InputList);
                                    goto startOfLoop;
                                }
                                else if (InputList[b] == "-")
                                {
                                    InputList[b] = int.Parse(InputList[b - 1]) - int.Parse(InputList[b + 1]) + "";
                                    sum = int.Parse(InputList[b]);
                                    deleteDependingOnIndex(b, InputList);
                                    goto startOfLoop;
                                }

                            }

                        }

                    }

                    if (InputList.Count == 1)
                    {
                        Console.WriteLine(InputList[0]);
                        sum = 0;
                    }
                  }
                }
            }
        public static void deleteMath(int p, List<string> InputList)
        {
            InputList.Remove(InputList[p]);
            InputList.Remove(InputList[p]);

        }
        public static void deleteDependingOnIndex(int b, List<string> InputList)
        {
            if (b != 0)
            {
                InputList.Remove(InputList[b - 1]);
                InputList.Remove(InputList[b]);
            }
            else
            {
                InputList.Remove(InputList[b + 1]);
                InputList.Remove(InputList[b]);
            }
        }
        }
    } 

   


