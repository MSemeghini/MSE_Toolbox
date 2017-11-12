using System;
using Rhino;
using Rhino.Commands;
using Rhino.Geometry;
using Rhino.Input;
using Rhino.Input.Custom;
using Rhino.UI;
using Eto.Drawing;
using Eto.Forms;

namespace MSE_Toolbox
{
    public class MSE_TestCommand : Rhino.Commands.Command
    {
        
        public override string EnglishName
        {
            get { return "MSE_TestCommand"; }
        }

        protected override Result RunCommand(Rhino.RhinoDoc doc, RunMode mode)
        {
            // TODO: start here modifying the behaviour of your command.



            return Result.Success;
        }
    }
}
