using GateScripts;
using System.Collections.Generic;
using UnityEngine;

namespace TrackScripts
{
    public class LevelInfo : MonoBehaviour
    {
        public List<GateInfo> gates;
        public List<Vector3> targetsPositions;
        public readonly int finishScaleLeght;

        public LevelInfo(List<GateInfo> _gates, List<Vector3> _targetsPositions, int _finishScaleLeght)
        {
            gates = _gates;
            targetsPositions = _targetsPositions;
            finishScaleLeght = _finishScaleLeght;
        }
    }
}


