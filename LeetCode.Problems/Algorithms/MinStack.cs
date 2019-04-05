using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.LeetCode.Algorithms
{
    public class MinStack
    {
        private readonly Stack<int> _stack = new Stack<int>();
        private int _min = int.MaxValue;

        public void Push(int x)
        {
            if (x < _min)
            {
                _stack.Push(_min);
                _min = x;
            }
            _stack.Push(x);
        }

        public void Pop()
        {
            if (_stack.Pop() == _min)
            {
                _min = _stack.Pop();
            }
        }

        public int Top()
        {
            return _stack.Peek();
        }

        public int GetMin()
        {
            return _min;
        }
    }
}
