using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObserver
{
    public void OnNotify(NotifyActions action);

}