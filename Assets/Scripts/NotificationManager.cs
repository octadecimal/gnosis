using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public delegate void NotificationCallback(object data = null);

public class NotificationManager : MonoBehaviour
{
    /// <summary>
    /// Callback look up dictionary.
    /// </summary>
    static private Dictionary<string, List<Delegate>> listeners = new Dictionary<string, List<Delegate>>();

    /// <summary>
    /// Subscribes to a notification.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="callback"></param>
    public static void Subscribe(string id, NotificationCallback callback)
    {
        if (!listeners.ContainsKey(id))
        {
            listeners.Add(id, new List<Delegate>());
        }

        listeners[id].Add(callback);
    }

    /// <summary>
    /// Unsubscribes from a notification.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="callback"></param>
    public static void Unsubscribe(string id, NotificationCallback callback)
    {
        if (!listeners.ContainsKey(id))
        {
            listeners.Remove(id);
        }
    }

    /// <summary>
    /// Broadcasts a notification.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="arg"></param>
    public static void Broadcast(string id, object data = null)
    {
        //Debug.Log("Broadcasting: " + id + " arg=" + arg);

        if (listeners.ContainsKey(id))
        {
            foreach (Delegate d in listeners[id])
            {
                NotificationCallback callback = d as NotificationCallback;
                callback(data);
            }
        }
    }
}
