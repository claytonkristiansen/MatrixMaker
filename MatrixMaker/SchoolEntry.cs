using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixMaker
{
    class SchoolEntry
    {
        private String name;
        private String region;
        private float tuition;
        public SchoolEntry(String _name, String _region, float _tuition)
        {
            name = _name;
            region = _region;
            tuition = _tuition;
        }
        public String GetName()
        {
            return name;
        }
        public String GetRegion()
        {
            return region;
        }
        public float GetTuition()
        {
            return tuition;
        }
    }
}
