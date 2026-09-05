using System;
using System.Collections.Generic;

namespace youusif_task_lec_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
     
            char choice = '&';
            List<int> list = new List<int>();

            bool stay = true;
            bool find(int n, ref int i)
            {
                bool isFound = false;
                for (i = 0; i < list.Count; i++)
                {
                    if (n == list[i])
                    {
                        isFound = true;
                        break;
                    }
                }
                if (!isFound) i = -1;
                return isFound;
            }

            do
            {
                Console.WriteLine(@"
   
    P - Print numbers  
    A - Add a not duplicate number 
    M - Display mean of the numbers
    S - Display the smallest number
    L - Display the largest number
    F - search for a number in the list 
    C - clearing out the list
    U - Update the number at index (new)
    D - Delete the number at index (new)
    W - Sort it ascending (new)
    E - Sort it descending (new)
    N - Count of Even (new)
    O - Count of Odd (new)
    G - Count of Negative (new)
    R - Reverse list (without function Reverse()) (new) 
    Q - Quit

    Enter your choice:
                    ");
                try
                {
                    choice = char.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    choice = '$';
                }
                switch (choice)
                {
                    case 'P':
                    case 'p':
                        {
                            if (list.Count < 1)
                            {
                                Console.WriteLine("[] - the list is empty");
                                continue;
                            }
                            else
                            {
                                Console.Write("[");
                                for (int i = 0; i < list.Count; i++)
                                    Console.Write($" {list[i]} ");
                                Console.Write("]");

                            }
                            continue;
                        }
                    case 'A':
                    case 'a':
                        {
                            Console.Write("Enter an integer to add : ");
                            int x = 0;
                            try
                            {
                                x = int.Parse(Console.ReadLine());
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("The entity must be integer _ cannot add");
                                break;
                            }
                            int i = -99;
                            if (!find(x, ref i))
                                list.Add(x);
                            else
                            { Console.WriteLine("Repeatead entity _ cannot add"); break; }
                            Console.Write($"{x} is added");
                            break;
                        }
                    case 'M':
                    case 'm':
                        {
                            double sum = 0;
                            if (list.Count >= 1)
                            {
                                for (int i = 0; i < list.Count; i++)
                                    sum = sum + list[i];
                                Console.WriteLine($"Mean: {sum / list.Count}");
                            }
                            else
                                Console.WriteLine("Unable to calculate the mean - no data");
                            break;
                        }
                    case 'S':
                    case 's':
                        {
                            if (list.Count >= 1)
                            {
                                int min = (int)list[0];
                                for (int i = 1; i < list.Count; i++)
                                {
                                    if (min > list[i])
                                        min = list[i];
                                }
                                Console.WriteLine($"The smallest number is {min}");
                            }
                            else
                            {
                                Console.WriteLine(" Unable to determine the smallest number -list is empty");
                            }

                            break;
                        }
                    case 'L':
                    case 'l':
                        {
                            if (list.Count >= 1)
                            {
                                int max = list[0];
                                for (int i = 1; i < list.Count; i++)
                                {
                                    if (max < list[i])
                                        max = list[i];
                                }
                                Console.WriteLine($"The largest number is {max}");
                            }
                            else
                            {
                                Console.WriteLine(" Unable to determine the largest number -list is empty");
                            }
                            break;
                        }
                    case 'F':
                    case 'f':
                        {
                            if (list.Count >= 1)
                            {
                                Console.Write("Enter number to seacrh: ");
                                int number = int.Parse(Console.ReadLine());
                                int i = -99;
                                bool isFound = find(number, ref i);
                                if (isFound)
                                    Console.WriteLine($"The index of that number in list is {i}");
                                else
                                    Console.WriteLine($"That number wasnot found in list !!");
                            }
                            else
                            {
                                Console.WriteLine(" Unable to find  -list is empty");
                            }
                            break;
                        }
                    case 'C':
                    case 'c':
                        {
                            if (list.Count >= 1)
                            {
                                list.Clear();
                                Console.WriteLine("The list is cleared successfully");
                            }
                            else
                                Console.WriteLine("The list is already empty !!");
                            break;
                        }
                    case 'U':
                    case 'u':
                        {
                            if (list.Count >= 1)
                            {
                                Console.Write("Enter index to Update: ");
                                int index = int.Parse(Console.ReadLine());

                                if (index > list.Count - 1 || index < 0)
                                {
                                    Console.WriteLine("there is no number at this index");
                                    break;
                                }
                                bool wait = false;
                                do
                                {
                                    Console.Write("Enter new number: ");
                                    int number = int.Parse(Console.ReadLine());
                                    int i = -99;
                                    if (!find(number, ref i) || index == i)
                                    {
                                        list[index] = number;
                                        Console.WriteLine("Updated Successfully !");
                                        wait = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"The Number was already exist at {i}");
                                        wait = true;
                                    }
                                } while (wait);
                            }
                            else
                            {
                                Console.WriteLine(" Unable to update  -list is empty");
                            }

                            break;
                        }
                    case 'D':
                    case 'd':
                        {
                            if (list.Count >= 1)
                            {
                                bool exist = false;
                                Console.WriteLine("Enter index to delete: ");
                                int index = int.Parse(Console.ReadLine());

                                if (index >= 0 && index < list.Count)
                                {
                                    list.RemoveAt(index);
                                    Console.WriteLine("Deleted Successfully");
                                    exist = true;
                                }
                                else
                                    Console.WriteLine("There is no number at that index !!");
                            }
                            else
                            {
                                Console.WriteLine(" Unable to delete -list is empty");
                            }

                            break;
                        }
                    case 'W':
                    case 'w':
                        {
                            if (list.Count >= 1)
                            {
                                int temp = 0;
                                bool exist = false;
                                for (int j = 0; j < list.Count - 1; j++)
                                {
                                    for (int i = 0; i < list.Count - 1; i++)
                                    {
                                        if (list[i] > list[i + 1])
                                        {
                                            temp = list[i];
                                            list[i] = list[i + 1];
                                            list[i + 1] = temp;
                                            exist = true;
                                        }
                                    }
                                }
                                if (!exist)
                                    Console.WriteLine("Already sorted !!");
                                else
                                    Console.WriteLine("Sorted Successfully !!");

                            }
                            else
                            {
                                Console.WriteLine(" Unable to sort -list is empty");
                            }
                            break;
                        }
                    case 'E':
                    case 'e':
                        {
                            if (list.Count >= 1)
                            {
                                int temp = 0;
                                bool exist = false;
                                for (int j = 0; j < list.Count - 1; j++)
                                {
                                    for (int i = 0; i < list.Count - 1; i++)
                                    {
                                        if (list[i] < list[i + 1])
                                        {
                                            temp = list[i];
                                            list[i] = list[i + 1];
                                            list[i + 1] = temp;
                                            exist = true;
                                        }
                                    }
                                }
                                if (!exist)
                                    Console.WriteLine("Already sorted !!");
                                else
                                    Console.WriteLine("Sorted Successfully !!");

                            }
                            else
                            {
                                Console.WriteLine(" Unable to sort -list is empty");
                            }
                            break;
                        }
                    case 'N':
                    case 'n':
                        {
                            if (list.Count >= 1)
                            {
                                int count = 0;
                                for (int i = 0; i < list.Count; i++)
                                {
                                    if (list[i] % 2 == 0)
                                    {
                                        count++;
                                    }
                                }
                                Console.WriteLine($"The count of even is {count}");
                            }
                            else
                            {
                                Console.WriteLine(" Unable to get count of even -list is empty");
                            }

                            break;
                        }
                    case 'O':
                    case 'o':
                        {
                            if (list.Count >= 1)
                            {
                                int count = 0;
                                for (int i = 0; i < list.Count; i++)
                                {
                                    if (list[i] % 2 != 0)
                                    {
                                        count++;
                                    }
                                }
                                Console.WriteLine($"The count of Odd is {count}");
                            }
                            else
                            {
                                Console.WriteLine(" Unable to get count of Odd -list is empty");
                            }

                            break;
                        }
                    case 'G':
                    case 'g':
                        {
                            if (list.Count >= 1)
                            {
                                int count = 0;
                                for (int i = 0; i < list.Count; i++)
                                {
                                    if (list[i] < 0)
                                    {
                                        count++;
                                    }
                                }
                                Console.WriteLine($"The count of negative numbers is {count}");
                            }
                            else
                            {
                                Console.WriteLine(" Unable to get count of negative -list is empty");
                            }

                            break;
                        }
                    case 'R':
                    case 'r':
                        {
                            if (list.Count >= 1)
                            {
                                int temp = 0;
                                for (int i = 0; i < list.Count / 2; i++)
                                {
                                    temp = list[i];
                                    list[i] = list[list.Count - 1 - i];
                                    list[list.Count - 1 - i] = temp;
                                }
                                Console.WriteLine($"The list is reversed successfully");
                            }
                            else
                            {
                                Console.WriteLine(" Unable to reverse -list is empty");
                            }

                            break;
                        }

                    case 'Q':
                    case 'q':
                        {
                            Console.WriteLine("Goodbye :)");
                            stay = false;
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Unknown selection, please try again");
                            break;
                        }
                }
            } while (stay);

        }
    }
}
