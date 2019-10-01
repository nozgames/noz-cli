using System;
using System.IO;
using System.IO.Compression;

using NoZ.Import;

namespace NoZ.CLI
{
    class Program
    {
        static void ReportError(string message)
        {
            Console.WriteLine($"NoZ.CLI: error: {message}");
        }

        static int Pack(string source, string output)
        {
#if false
            // Must have two argument 
            if (args.Length < 2)
            {
                ReportError("missing source directory");
                return 1;
            }

            // First argument is the source directory
            string source = args[1];
#endif
            if (!Directory.Exists(source))
            {
                ReportError($"invalid source diretory '{source}'");
                return 1;
            }

            // Parse options
#if false
            string output = "out.zip";
            for (int i = 2; i < args.Length - 1; i += 2)
            {
                // Output specified?
                if (string.Compare(args[i], "-o", true) == 0 ||
                    string.Compare(args[i], "-output", true) == 0)
                {
                    output = args[i + 1];
                }
                else
                {
                    ReportError($"unknown option {args[i]}");
                    return 1;
                }
            }
#endif

            // Delete old file if it is there.
            if (File.Exists(output))
                File.Delete(output);

            // Create diretory for new file
            Directory.CreateDirectory(Path.GetDirectoryName(output));

            // Create zip file.
            ZipFile.CreateFromDirectory(source, output);

            return 0;
        }

        static void Main(string[] args)
        {
            var importer = new Importer();
            importer.Import(args[0], args[1]);

            Pack(args[1], args[2]);
        }
    }
}

