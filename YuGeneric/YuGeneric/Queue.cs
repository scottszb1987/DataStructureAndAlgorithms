﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuGeneric
{
    public class QueueNode<T>
    {
        private T _value;
        private QueueNode<T> _next;

        public QueueNode(){
        }

        public QueueNode(T value)
        {
            _value = value;
        }

        public T Value{
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        public QueueNode<T> Next
        {
            get
            {
                return _next;
            }
            set
            {
                _next = value;
            }
        }
    }

    public class Queue<T> 
    {
        private QueueNode<T> _front;
        private QueueNode<T> _rear;

        public QueueNode<T> Front
        {
            get
            {
                return _front;
            }
            set
            {
                _front = value;
            }
        }

        public bool IsEmpty()
        {
            if (_front == null && _rear == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int Count()
        {
            int count = 0;
            var current = _front;
            while (current != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }

        public void Join(QueueNode<T> node)
        {
            if (this.IsEmpty())
            {
                _front = node;
                _rear = node;
            }
            else
            {
                node.Next = _front;
                _front = node;
            }
        }

        public void Join(T value)
        {
            this.Join(new QueueNode<T>(value));
        }

        public bool Leave()
        {
            if (this.IsEmpty())
            {
                return false;
            }
            else if(this.Count() == 1)
            {
                _front = null;
                _rear = null;
                return true;
            }
            else
            {
                _front = _front.Next;
                return true;
            }
        }
    }
}