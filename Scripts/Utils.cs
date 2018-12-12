using UnityEditor;
using System.Reflection;
using System;
using System.Collections;
using UnityEngine;

namespace CoverShooter.Tools
{
    public static class Utils
    {
        static MethodInfo _clearConsoleMethod;
        static MethodInfo clearConsoleMethod
        {
            get
            {
                if (_clearConsoleMethod == null)
                {
                    Assembly assembly = Assembly.GetAssembly(typeof(SceneView));
                    Type logEntries = assembly.GetType("UnityEditor.LogEntries");
                    _clearConsoleMethod = logEntries.GetMethod("Clear");
                }
                return _clearConsoleMethod;
            }
        }

        public static void ClearLogConsole()
        {
            clearConsoleMethod.Invoke(new object(), null);
        }

        public static int GetIndexFromString(String index_name)
        {
            int return_value = -1;
            ArrayList layerNames = new ArrayList();
            for (int i = 8; i <= 31; i++) //user defined layers start with layer 8 and unity supports 31 layers
            {
                if(index_name == LayerMask.LayerToName(i))
                {
                    return i;
                }
            }

            return return_value;
        }

        public static String[] GetLayers()
        {
            // https://answers.unity.com/questions/558158/how-to-get-a-list-from-user-layers.html
            ArrayList layerNames = new ArrayList();
            for (int i = 8; i <= 31; i++) //user defined layers start with layer 8 and unity supports 31 layers
            {
                var layerN = LayerMask.LayerToName(i); //get the name of the layer
                if (layerN.Length > 0) //only add the layer if it has been named (comment this line out if you want every layer)
                    layerNames.Add(layerN);
            }

            // Add stuff to the ArrayList.
            String[] layers = (String[])layerNames.ToArray(typeof(string));
            return layers;
        }
    }

}   