using EnvDTE;
using ReswPlus.Core.ResourceInfo;
using ReswPlus.Utils;
using System;

namespace ReswPlus.ResourceInfo
{
    public static class ResourceFileInfoBuilder
    {
        private static string GetProjectPriFileName(ProjectItem reswProjectItem)
        {
            // Try to find the ProjectPriFileName property
            try
            {
                var priFileNameProperty = reswProjectItem.ContainingProject.Properties.Item("ProjectPriFileName");

                // If the property is not set, default to ProjectName.pri
                if (priFileNameProperty == null || string.IsNullOrEmpty(priFileNameProperty.Value.ToString()))
                {
                    return $"{reswProjectItem.ContainingProject.Name}.pri";
                }

                return priFileNameProperty.Value.ToString();
            }
            catch (Exception)
            {
                // PriFileName property not found, return default name.
               return $"{reswProjectItem.ContainingProject.Name}.pri";
            }
        }

        public static ResourceFileInfo Create(ProjectItem reswProjectItem)
        {
            Microsoft.VisualStudio.Shell.ThreadHelper.ThrowIfNotOnUIThread();
            var project = reswProjectItem?.ContainingProject;
            if (project == null)
            {
                return null;
            }

            var priFileName = GetProjectPriFileName(reswProjectItem);
            var path = reswProjectItem.Properties.Item("FullPath").Value as string;
            var parentProject = new ProjectInfo(reswProjectItem);
            return new ResourceFileInfo(path, parentProject, priFileName);
        }
    }
}
