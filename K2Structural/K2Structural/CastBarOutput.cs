﻿using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace K2Structural
{
    public class CastBarOutput : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the CastBarOutput class.
        /// </summary>
        public CastBarOutput()
          : base("CastBarOutput", "BarOutput",
              "Cast the output of the bar goal",
              "K2Structural", "Utility")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("BarOutput", "O", "The output from the bar goal", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddIntegerParameter("PIndexStart", "PI0", "The start particle index of a bar element", GH_ParamAccess.item);
            pManager.AddIntegerParameter("PIndexEnd", "PI1", "The end particle index of a bar element", GH_ParamAccess.item);
            pManager.AddLineParameter("Line", "ln", "The updated line geometry", GH_ParamAccess.item);
            pManager.AddNumberParameter("AxialForce", "F", "The axial force [kN] in the bar (- is compression)", GH_ParamAccess.item);
            pManager.AddNumberParameter("AxialStress", "stressA", "The axial stress [MPa] in the bar (- is compression)", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            //Input
            Object[] output = new Object[4];
            DA.GetData(0, ref output);

            //Casting
            int pIndexStart = (int)output[0];
            int pIndexEnd = (int)output[1];

            Line ln = (Line)output[2];

            double force = (double)output[3];
            double stress = (double)output[4];

            //Output
            DA.SetData(0, pIndexStart);
            DA.SetData(1, pIndexEnd);
            DA.SetData(2, ln);
            DA.SetData(3, Math.Round(force, 2));
            DA.SetData(4, Math.Round(stress, 1));
        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;
                return null;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("{95d2e6d6-399c-4ec4-843f-fc6335ced616}"); }
        }
    }
}