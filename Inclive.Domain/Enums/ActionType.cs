using Inclive.Domain.Common;

namespace Inclive.Domain.Enums
{
    public class ActionType : Enumeration
    {
        public ActionType Walk = new WalkActionType();

        protected ActionType(int id, string name)
            : base(id, name)
        { }

        private class WalkActionType : ActionType
        {
            public WalkActionType() : base(1, "Walk")
            {

            }
        }
    }
}