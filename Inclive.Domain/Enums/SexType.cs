using Inclive.Domain.Common;

namespace Inclive.Domain.Enums
{
    /*public class SexType : Enumeration
    {
        public SexType Male = new MaleSexType();
        public SexType Female = new FemaleSexType();

        protected SexType(int id, string name)
            : base(id, name)
        { }

        private class MaleSexType : SexType
        {
            public MaleSexType() : base(1, "Male")
            {
            }
        }

        private class FemaleSexType : SexType
        {
            public FemaleSexType() : base(2, "Female")
            {
                
            }
        }
    }*/
    public enum SexType
    {
        Male = 0,
        Female = 1
    }
}