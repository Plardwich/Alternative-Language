namespace Alternative_Language
{
    class CleanData
    {
        private string[] stringData;
        private float[] floatData;
        private int intData;
        public CleanData(String[] stringData, float[] floatData, int intData)
        {
            this.stringData = stringData;
            this.floatData = floatData;
            this.intData = intData;
        }

        public string[] getStringData() {
            return this.stringData;
        }

        public float[] getFloatData() {
            return this.floatData;
        }

        public int getIntData() {
            return this.intData;
        }
    }
}