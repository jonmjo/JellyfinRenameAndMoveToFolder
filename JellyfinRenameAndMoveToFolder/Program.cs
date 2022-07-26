
using CommandLine;
using System.Text;

namespace Jon.Jellyfin.RenameAndMove
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Parser.Default.ParseArguments<ToolOption>(args)
                  .WithParsed<ToolOption>(options =>
                  {
                      Process(options);
                  });
        }

        private static void Process(ToolOption options)
        {
            if (string.IsNullOrEmpty(options.SourceFolder))
                options.SourceFolder = Environment.CurrentDirectory;

            if (string.IsNullOrEmpty(options.TargetFolder))
                options.TargetFolder = Environment.CurrentDirectory;

            var files = Directory.GetFiles(options.SourceFolder, options.FileNameFilter);

            foreach (var file in files)
            {
                var filename = Path.GetFileName(file);
                var extensionPosition = filename.LastIndexOf('.');
                var extension = filename.Substring(extensionPosition);
                var name = filename.Substring(0, extensionPosition);
                //name = "M.I.A";
                //name = "I.Robot";
                var newName = GetNewName(name);
                var newFolder = Path.Combine(options.TargetFolder, newName);

                var input = Input.ReadLine($"Rename and move file {filename} to: " + Environment.NewLine +
                    Path.Combine(newFolder, newName + extension) + ": ", false, "y", "n");
                if (input.Equals("y"))
                {
                    Directory.CreateDirectory(newFolder);
                    File.Move(file, Path.Combine(newFolder, newName + extension));
                }
            }

        }

        private static string GetNewName(string name)
        {
            var separators = new char[] { '.', ' ', '_' };
            var upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZÅÄÖ".ToCharArray();
            var alphabeth = "ABCDEFGHIJKLMNOPQRSTUVXYZÅÄÖabcdefghijklmnopqrstuvwxyzåäö".ToCharArray();

            StringBuilder sb = new StringBuilder();

            var nameArr = name.ToCharArray();
            for (int i = 0; i < nameArr.Length; i++)
            {
                if (separators.Contains(nameArr[i]))
                {
                    if (i == 0)
                        continue;
                    else if ( // Do right for names like I.Robot (replace dot) and M.I.A (keep dots).
                        alphabeth.Contains(nameArr[i - 1]) &&
                        (nameArr.Length > (i + 1) && alphabeth.Contains(nameArr[i + 1])) &&
                        ((i-2) >= 0 && alphabeth.Contains(nameArr[i - 2]) || i < 2) &&
                        (nameArr.Length >= (i + 2) && alphabeth.Contains(nameArr[i + 2]) || nameArr.Length < (i + 2))
                    )
                        sb.Append(" ");
                    else
                        sb.Append(nameArr[i]);
                }
                else if (upper.Contains(nameArr[i]))
                {
                    if (i > 0 && alphabeth.Contains(nameArr[i - 1]))
                        sb.Append(" " + nameArr[i]);
                    else
                        sb.Append(nameArr[i]);
                }
                else
                {
                    sb.Append(nameArr[i]);
                }
            }
            return sb.ToString();
        }
    }
}