using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SecretAgent
{
    class MyUniqueList
    {
        List<int> list = new List<int>();

        public MyUniqueList()
        {

        }

        public bool Add(int item)
        {
            if (!list.Contains(item))
            {
                list.Add(item);
                return true;
            } else
            {
                throw new ItemAlreadyExistException($"item: {item} already exist");
            }

            return false;
        }

        public bool Remove(int item)
        {
            if (list.Contains(item))
            {
                list.Remove(item);
                return true;
            } else
            {
                throw new ItemNotFoundException($"item: {item} not found");
            }

            return false;
        }

        public int Peek(int index)
        {
            if(index >= list.Count)
            {
                throw new IndexOutOfRangeException($"item in index: {index} not found");
            }
            return list[index];
        }

        public int this[int index]
        {
            get
            {
                if (index >= list.Count)
                {
                    throw new IndexOutOfRangeException($"item in index: {index} not found");
                }
                return this.list[index];
            }
            set
            {
                if (list[index] == value)
                    return;
                if (list.Contains(value))
                    return;
                if (!list.Contains(value))
                    throw new ItemNotFoundException($"item not found");

                list[index] = value;
            }
        }
    }

    [Serializable]
    internal class ItemNotFoundException : Exception
    {
        public ItemNotFoundException()
        {
        }

        public ItemNotFoundException(string message) : base(message)
        {
        }

        public ItemNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ItemNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    [Serializable]
    internal class ItemAlreadyExistException : Exception
    {
        public ItemAlreadyExistException()
        {
        }

        public ItemAlreadyExistException(string message) : base(message)
        {
        }

        public ItemAlreadyExistException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ItemAlreadyExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
