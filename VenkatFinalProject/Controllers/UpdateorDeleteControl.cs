using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VenkatFinalProject.Controllers
{
    class UpdateorDeleteControl :EDM.Command<bool>
    {
        private bool update;
        public UpdateorDeleteControl(bool isupdate)
        {
            update = isupdate;
        }

        public bool execute()
        {

            MaintainMemberControl mmc = new MaintainMemberControl();
            mmc.updateorDeleteWindow(mmc,update);
            return true;

        }
    }
}
