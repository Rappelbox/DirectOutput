﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DirectOutput.Cab.Toys;

namespace DirectOutput.LedControl
{
    /// <summary>
    /// List of color configurations from a ledcontrol.ini file.
    /// </summary>
    public class ColorConfigList : List<ColorConfig>
    {

        public ColorConfig this[string Name]
        {
            get
            {
                foreach (ColorConfig  CC in this)
                {
                    if (CC.Name == Name)
                    {
                        return CC;
                    }

                }
                return null;
            }
        }

        /// <summary>
        /// Gets a cabinet color list for the config colors contained in this list.
        /// </summary>
        /// <returns>Cabinet ColorList.</returns>
        public ColorList GetCabinetColorList()
        {
            ColorList CL = new ColorList();
            foreach (ColorConfig CC in this)
            {
                CL.Add(CC.GetCabinetColor());
            }
            return CL;
        }

        /// <summary>
        /// Parses the led control data.
        /// </summary>
        /// <param name="LedControlData">The led control data.</param>
        /// <param name="ThrowExceptions">if set to <c>true</c> [throw exceptions].</param>
        public void ParseLedControlData(IEnumerable<string> LedControlData, bool ThrowExceptions = true)
        {
            foreach (string Data in LedControlData)
            {
                if (!Data.IsNullOrWhiteSpace())
                {
                    ParseLedControlData(Data, ThrowExceptions);
                }
            }
        }


        /// <summary>
        /// Parses the led control data.
        /// </summary>
        /// <param name="LedControlData">The led control data.</param>
        /// <param name="ThrowExceptions">if set to <c>true</c> [throw exceptions].</param>
        /// <exception cref="System.Exception">
        /// Could not parse color config data {0}.
        /// or
        /// Color {0} has already been defined.
        /// </exception>
        public void ParseLedControlData(string LedControlData, bool ThrowExceptions = true)
        {
            ColorConfig CC = null;

            try
            {
                CC = new ColorConfig(LedControlData, ThrowExceptions);

            }
            catch (Exception E)
            {

                if (ThrowExceptions)
                {
                    throw new Exception("Could not parse color config data {0}.".Build(LedControlData),E);
                }
            } 
            if (CC != null)
            {
                if (ThrowExceptions && Contains(CC.Name))
                {
                    throw new Exception("Color {0} has already been defined.".Build(CC.Name));
                }

                Add(CC);

            }
        }

        /// <summary>
        /// Determines whether the list contains the specified color name.
        /// </summary>
        /// <param name="ColorName">Name of the color.</param>
        /// <returns>
        ///   <c>true</c> if the list the specified color name; otherwise, <c>false</c>.
        /// </returns>
        public bool Contains(string ColorName)
        {
            foreach (ColorConfig CC in this)
            {
                if (CC.Name.Equals(ColorName, StringComparison.InvariantCultureIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }


        

    }
}
