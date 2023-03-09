using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Bubbles
{
    public class LevelTest : MonoBehaviour
    {
        public int level = 2;

        private int moi()
        {
            level = 1;
            return level;
        }
    }
}
