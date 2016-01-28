using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MenuLauncher
{
    public class Parameters
    {
        public string DirectoryPath { get; private set; }
        public List<string> InfoPartsBelow { get; private set; } = new List<string>();
        public List<string> InfoPartsBefore { get; private set; } = new List<string>();
        public bool ShowIcons { get; private set; } = true;
        public int HideLeft { get; private set; } = 0;

        public static Parameters Parse(string[] args)
        {
            Parameters parsedParams = new Parameters();

            foreach (string item in args)
            {
                if (!item.StartsWith("-"))
                {
                    if (Directory.Exists(item))
                        parsedParams.DirectoryPath = item;
                }
                else
                {
                    if (item.StartsWith("--add-info-below=", StringComparison.CurrentCultureIgnoreCase))
                        parsedParams.InfoPartsBelow.Add(Environment.ExpandEnvironmentVariables(String.Join("", item.Split('=').Skip(1).ToArray())));

                    if (item.StartsWith("--add-info-before=", StringComparison.CurrentCultureIgnoreCase))
                        parsedParams.InfoPartsBefore.Add(Environment.ExpandEnvironmentVariables(String.Join("", item.Split('=').Skip(1).ToArray())));

                    if (item.Equals("--no-icons", StringComparison.CurrentCultureIgnoreCase))
                        parsedParams.ShowIcons = false;

                    if (item.StartsWith("--hide-left=", StringComparison.CurrentCultureIgnoreCase))
                    {
                        try
                        {
                            parsedParams.HideLeft = int.Parse(item.Split('=')[1]);
                        }
                        catch (Exception)
                        { }
                    }
                }
            }

            return parsedParams;
        }
    }
}
