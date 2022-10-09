using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution {
    static void Main(String[] args) 
    {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        int q = Convert.ToInt32(Console.ReadLine());
        Stack<int> mainStack = new Stack<int>();
        Stack<int> holdStack = new Stack<int>();

        // 1 enqueue, 2 dequeue, 3 print front element
        for(int i = 0; i < q; i++)
        {
            List<int> query = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(qTemp => Convert.ToInt32(qTemp)).ToList();
            
            if(query[0] == 1)
            {
                // enqueue query[1] AT THE END OF THE QUEUE
                
                // get everything in the mainStack and put in holdStack
                while(mainStack.Count>0)
                {
                    holdStack.Push(mainStack.Peek());
                    mainStack.Pop();
                }
                // push the thing we want to enqueue into the main stack
                mainStack.Push(query[1]);
                // push all stuff in holdStack back into mainStack
                while(holdStack.Count>0)
                {
                    mainStack.Push(holdStack.Peek());
                    holdStack.Pop();
                }
            }
            else if(query[0] == 2)
            {
                // dequeue front element
                mainStack.Pop();
            }
            else // query should be 3
            {
                // print front element
                Console.WriteLine(mainStack.Peek());
            }
        }
    }
}
