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
                // if there's something in the mainStack already
                if(mainStack.Count!=0)
                {
                    // push to the holdStack
                    holdStack.Push(query[1]);
                }
                // if there's nothing in mainStack
                else
                {   
                    // push to the mainStack since this is the first element
                    mainStack.Push(query[1]);
                }
                
            }
            else if(query[0] == 2)
            {
                // dequeue front element
                mainStack.Pop();
                
                // if mainStack is now empty
                if(mainStack.Count==0)
                {
                    // pop all values from holdStack and push them to mainStack
                    while(holdStack.Count>0)
                    {
                        mainStack.Push(holdStack.Peek());
                        holdStack.Pop();
                    }
                    //^since we were adding to the back of the queue
                    // if we enqueued 1 2 3 4
                    // mainStack = 1; holdStack = 4 3 2
                    // pop mainStack leaves mainStack empty so we push the values of holdStack
                    // mainStack = 2 3 4; holdStack = {}
                    // now we carry on and pop from main stack until it's empty
                }
                
            }
            else // query should be 3
            {
                // print front element
                Console.WriteLine(mainStack.Peek());
            }
            
            
        }
    }
}
