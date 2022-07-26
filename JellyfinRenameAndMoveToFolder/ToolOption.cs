using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace Jon.Jellyfin.RenameAndMove
{
    internal class ToolOption
    {
        [Option('s', "source", Required = false, HelpText = "Folder to process. Default is current folder.")]
        public string SourceFolder { get; set; } = "";

        [Option('t', "target", Required = false, HelpText = "Folder to to create new folders in and move. Default is current folder.")]
        public string TargetFolder { get; set; } = "";

        [Option('f', "filter", Required = true, HelpText = "Files process.")]
        public string FileNameFilter { get; set; } = "";

        


    }
}
