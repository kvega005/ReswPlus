// Copyright (c) Rudy Huyn. All rights reserved.
// Licensed under the MIT License.
// Source: https://github.com/DotNetPlus/ReswPlus

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReswPlus.Core.ResourceInfo
{
    public class ResourceFileInfo
    {
        public string Path { get; }
        public IProject Project { get; }
        public string PriFile { get; }

        public ResourceFileInfo(string path, IProject parentProject, string priFile)
        {
            Path = path;
            Project = parentProject;
            PriFile = priFile;
        }
    }
}
