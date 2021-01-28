using System.Collections.Generic;

namespace MarsRover.Extensions
{
    public static class LinkedList
    {
        public static LinkedListNode<T> NextOrFirst<T>(this LinkedListNode<T> listNode)
        {
            return listNode.Next ?? listNode.List.First;
        }

        public static LinkedListNode<T> PreviousOrLast<T>(this LinkedListNode<T> listNode)
        {
            return listNode.Previous ?? listNode.List.Last;
        }
    }
}
