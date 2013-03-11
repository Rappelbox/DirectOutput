﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.IO;

namespace DirectOutput.GlobalConfig
{
    public class FilePatternList : List<FilePattern>
    {
        /// <summary>
        /// Gets the files matching one of the entries in this list
        /// </summary>
        /// <param name="ReplaceValues">Dictionary containing key/value pairs used to replace placeholders in the form {PlaceHolder} in the patterns.</param>
        /// <returns>The list of files matching one of the entries in this list.</returns>
        public List<FileInfo> GetMatchingFiles(Dictionary<string, string> ReplaceValues=null)
        {
            List<FileInfo> L = new List<FileInfo>();
            foreach(FilePattern P in this) {
                List<FileInfo> PL = P.GetMatchingFiles(ReplaceValues);
                foreach (FileInfo FI in PL)
                {
                    if (!L.Any(x=>x.FullName==FI.FullName))
                    {
                        L.Add(FI);
                    }
                }
            }
            return L;
        }
    }
}
