using System;
using System.Collections.Generic;

namespace StackExercise
{
    public class Stack
    {
        private List<object> _stackList;
        public object topObj { get; private set; }
        
        public Stack()
        {
            _stackList = new List<object>();
        }

        public void Push(object obj)
        {
            if (obj == null)
                throw new InvalidOperationException();
            else
            {
                _stackList.Add(obj);
            }
        }

        public object Pop()
        {
            if (_stackList.Count > 0)
            {
                topObj = _stackList[_stackList.Count - 1];
                _stackList.RemoveAt(_stackList.Count - 1);
                return topObj;
            }
            // In case the stack is empty we cannot call the .Pop() method
            else
                throw new InvalidOperationException();
            
        }

        public void Clear()
        {
            _stackList.Clear();
        }
    }
}