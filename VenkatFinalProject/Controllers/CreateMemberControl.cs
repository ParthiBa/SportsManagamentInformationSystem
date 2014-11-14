using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VenkatFinalProject.Controllers
{
    class CreateMemberControl : EDM.Command<bool>
    {

        public bool execute() 
        {

            MaintainMemberControl mmc = new MaintainMemberControl();
            mmc.createWindow(mmc);
            return true;

        }
    }
}
