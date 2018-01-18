﻿using System;

public class BinaryTree<T>
{
    public T Value { get; }
    public BinaryTree<T> LeftChild { get; }
    public BinaryTree<T> RightChild { get; }

    public BinaryTree(T value, BinaryTree<T> leftChild = null, BinaryTree<T> rightChild = null)
    {
        this.Value = value;
        this.LeftChild = leftChild;
        this.RightChild = rightChild;
    }

    public void PrintIndentedPreOrder(int indent = 0)
    {
        Console.WriteLine(new string(' ', indent) + this.Value);

        if (this.LeftChild != null)
        {
            this.LeftChild.PrintIndentedPreOrder(indent + 2);
        }

        if (this.RightChild != null)
        {
            this.RightChild.PrintIndentedPreOrder(indent + 2);
        }
    }

    public void EachInOrder(Action<T> action)
    {
        if (this.LeftChild != null)
        {
            this.LeftChild.EachInOrder(action);
        }

        action(this.Value);

        if (this.RightChild != null)
        {
            this.RightChild.EachInOrder(action);
        }
    }

    public void EachPostOrder(Action<T> action)
    {
        if (this.LeftChild != null)
        {
            this.LeftChild.EachPostOrder(action);
        }

        if (this.RightChild != null)
        {
            this.RightChild.EachPostOrder(action);
        }

        action(this.Value);
    }
}
