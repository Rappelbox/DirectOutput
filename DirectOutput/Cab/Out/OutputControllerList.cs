﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Xml.Serialization;
using System.Xml;
using DirectOutput.General.Generic;

namespace DirectOutput.Cab.Out
{

    /// <summary>
    /// List of IOutputController objects 
    /// </summary>
    public class OutputControllerList : NamedItemList<IOutputController>, IXmlSerializable
    {

        #region IXmlSerializable implementation
        /// <summary>
        /// Serializes the IOutputController objects in this list to Xml.
        /// IOutputController objects are serialized as the contained objects. The enclosing tags represent the object type
        /// WriteXml is part if the IXmlSerializable interface.
        /// </summary>
        public void WriteXml(XmlWriter writer)
        {

            XmlSerializerNamespaces Namespaces = new XmlSerializerNamespaces();
            Namespaces.Add(string.Empty, string.Empty);
            foreach (IOutputController OC in this)
            {
                XmlSerializer serializer = new XmlSerializer(OC.GetType());
                serializer.Serialize(writer, OC, Namespaces);
            }
        }


        /// <summary>
        /// Deserializes the IOutputController objects in the XmlReader
        /// The IOutputController objects are deserialized using the object name in the enclosing tags.
        /// ReadXml is part if the IXmlSerializable interface.
        /// </summary>
        public void ReadXml(XmlReader reader)
        {
            if (reader.IsEmptyElement)
            {
                reader.ReadStartElement();
                return;
            }

            General.TypeList Types = new General.TypeList(AppDomain.CurrentDomain.GetAssemblies().ToList().SelectMany(s => s.GetTypes()).Where(p => typeof(IOutputController).IsAssignableFrom(p) && !p.IsAbstract));

            reader.Read();

            while (Types.Contains(reader.LocalName))
            {
                Type T = Types[reader.LocalName];
                if (T != null)
                {
                    XmlSerializer serializer = new XmlSerializer(T);
                    Add((IOutputController)serializer.Deserialize(reader));
                }
            }

            reader.ReadEndElement();
        }


        /// <summary>
        /// Method is required by the IXmlSerializable interface
        /// </summary>
        /// <returns>Returns always null</returns>
        public System.Xml.Schema.XmlSchema GetSchema() { return (null); }
        #endregion



        /// <summary>
        /// Initializes all IOutputController objects in the list
        /// </summary>
        public void Init()
        {
            foreach (IOutputController OC in this)
            {
                OC.Init();
            }
        }

        /// <summary>
        /// Finishes all IOutputController objects in the list
        /// </summary>
        public void Finish()
        {
            foreach (IOutputController OC in this)
            {
                OC.Finish();
            }
        }

        /// <summary>
        /// Updates all IOutputController objects in the list
        /// </summary>
        public void Update()
        {
            foreach (IOutputController OC in this)
            {
                OC.Update();
            }
        }



    }
}
