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
    public class MSE_DeleteShortestCurve : Rhino.Commands.Command
    {
        public override string EnglishName
        {
            get { return "MSE_DeleteShortestCurve"; }
        }

        protected override Result RunCommand(Rhino.RhinoDoc doc, RunMode mode)
        {
            Rhino.Input.Custom.GetObject getobjects = new Rhino.Input.Custom.GetObject();
            getobjects.GeometryFilter = Rhino.DocObjects.ObjectType.Curve;
            getobjects.AcceptNothing(false);

            switch(getobjects.GetMultiple(1,0))
            {
                case GetResult.ExitRhino:
                    return Result.ExitRhino;
                case GetResult.Cancel:
                    return Result.Cancel;
                case GetResult.Object:
                    if (getobjects.ObjectCount>1)
                    {
                        Rhino.DocObjects.ObjRef[] arrCurve = getobjects.Objects();
                        Array.Sort(arrCurve, (x, y) => x.Curve().GetLength().CompareTo(y.Curve().GetLength()));
                        doc.Objects.Delete(arrCurve[0], true);
                    }
                    return Result.Success;

                default:
                    return Result.Failure;

            }

        }
    }
}
