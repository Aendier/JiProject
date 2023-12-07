using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UndoRedoPanelController<T> : MonoBehaviour
{
    private Stack<T> operationStack;
    private Stack<T> undoStack;

    public UndoRedoPanelController()
    {
        operationStack = new Stack<T>();
        undoStack = new Stack<T>();
    }

    public void Do(T action)
    {
        operationStack.Push(action);
        undoStack.Clear(); // Clear undo stack when a new action is performed
    }

    public T Undo()
    {
        if (operationStack.Count > 0)
        {
            T undoneAction = operationStack.Pop();
            undoStack.Push(undoneAction);
            return undoneAction;
        }
        else
        {
            return default(T);
        }
    }

    public T Redo()
    {
        if (undoStack.Count > 0)
        {
            T redoneAction = undoStack.Pop();
            operationStack.Push(redoneAction);
            return redoneAction;
        }
        else
        {
            return default(T);
        }
    }

}
