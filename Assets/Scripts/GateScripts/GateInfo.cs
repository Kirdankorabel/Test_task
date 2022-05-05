namespace GateScripts
{
    [System.Serializable]
    public class GateInfo
    {
        public int firstPassValue;
        public int secondPassValue;
        public bool firstPassIsMultipler;
        public bool secondPassIsMultipler;
        public bool isMovebleGate;

        public GateInfo(int value1, int value2, bool firstPassIsMult, bool secondPassIsMult, bool isMoveble)
        {
            firstPassValue = value1;
            secondPassValue = value2;
            firstPassIsMultipler = firstPassIsMult;
            secondPassIsMultipler = secondPassIsMult;
            isMovebleGate = isMoveble;
        }
    }
}
